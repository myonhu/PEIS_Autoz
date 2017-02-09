using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Cobainsoft.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using PEIS.tjdj;
using PEIS.tjjg;
using PEIS.xtgg;
using PEIS.main;
using Encrypt;
using PEIS.zybtj;
using PEIS.Rdlc;


namespace PEIS.Rdlc
{
    public partial class Form_reportZYJKTJBG : Form
    {

        string strTjbh = "";
        string strTjcs = "";
        string str_djlsh = "";
        rdlcBiz rdlcbiz = new rdlcBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        tjjgBiz tjjgbiz = new tjjgBiz();
        xtBiz xtBiz = new xtBiz();
        xtggBiz xtggbiz = new xtggBiz();
        Rijndael_ rijndael_ = new Rijndael_();

        private TjZybZysBiz zysBiz = new TjZybZysBiz();
        private TjZybZzBiz zzBiz = new TjZybZzBiz();

        public Form_reportZYJKTJBG()
        {
            InitializeComponent();
        }
        public Form_reportZYJKTJBG(string tjbh, string tjcs, string djlsh)
        {
            InitializeComponent();
            strTjbh = tjbh;
            strTjcs = tjcs;
            str_djlsh = djlsh;

        }
        private void Form_report_Load(object sender, EventArgs e)
        {
            BarcodeControl barcode = new BarcodeControl();
            barcode.BarcodeType = BarcodeType.CODE128C;
            barcode.Data = str_djlsh;
            barcode.CopyRight = "";
            MemoryStream stream = new MemoryStream();
            barcode.MakeImage(ImageFormat.Png, 1, 50, true, false, null, stream);
            Bitmap myimge = new Bitmap(stream);

            string str_path = Application.StartupPath + @"/barcode.png";
            myimge.Save(str_path, ImageFormat.Png);
            str_path = "file:///" + str_path;
            myimge.Dispose();              //201203

            string str_dwlxr = xtBiz.GetXtCsz("dwlxr").Trim();//单位联系人
            string str_dwdz = xtBiz.GetXtCsz("dwdz").Trim();//单位地址
            string str_dwdh = xtBiz.GetXtCsz("tjdwdh").Trim();//体检单位电话
            string str_tjzgzbh = xtBiz.GetXtCsz("zytjzgbh").Trim();//职业健康体检资格编号

            //string str_dwlxr ="hh";//单位联系人
            //string str_dwdz = "hh";//单位地址
            //string str_dwdh = "hh";//体检单位电话
            //string str_tjzgzbh = "hh";//职业健康体检资格编号


            //LocalReport report = new LocalReport();
            reportView.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing);
            string title = "职业健康检查表";

            DataTable dt2 = GetZybRyxx(strTjbh, strTjcs);

            reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_zyb_jkda_new.rdlc";
            reportView.LocalReport.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("dqrq", xtBiz.GetDataNow().ToString("yyyy-MM-dd"));
            ReportParameter rp2 = new ReportParameter("title", title);
            ReportParameter rp3 = new ReportParameter("bbmc", Program.reg_dwmc);
            ReportParameter rp4 = new ReportParameter("barcode", str_path);
            ReportParameter rp5 = new ReportParameter("dz", str_dwdz);
            ReportParameter rp6 = new ReportParameter("dh", str_dwdh);
            ReportParameter rp7 = new ReportParameter("lxr", str_dwlxr);
            ReportParameter rp8 = new ReportParameter("zgbh", str_tjzgzbh);

            reportView.LocalReport.DataSources.Clear();
            reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });
            reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));
            this.reportView.RefreshReport();

        }
        void report_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            DataTable dt1 = zysBiz.GetZys(strTjbh);
            DataTable dt2 = GetZybRyxx(strTjbh, strTjcs);
            DataTable dt3 = zzBiz.GetZybZz(strTjbh, strTjcs);
            DataTable dtTz = zzBiz.GetTz(strTjbh, strTjcs);
            DataTable dt4 = rdlcbiz.Get_v_tj_tjdjb(strTjbh, strTjcs);
            DataTable dt5 = GetMobliePh(strTjbh);


            DataTable dtZhxmmx = new DataTable();
            dtZhxmmx = rdlcbiz.GetTjjlmx(strTjbh, strTjcs);


            if (dtTz.Rows.Count <= 0)
            {
                DataRow row = dtTz.NewRow();
                row["tjbh"] = strTjbh;
                row["tjcs"] = strTjcs;
                row["一般状况"] = DBNull.Value;
            }

            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_zyb_zys", dt1));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_TJ_ZYB_ZZ", dt3));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_zyb_zz", dt3));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_Pro_zybtj_bg", dtTz));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt4));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tjjlmx", dtZhxmmx));
            e.DataSources.Add(new ReportDataSource("DataSet1", dt5));
            //e.DataSources.Add(new ReportDataSource("PEISDataSet_Pro_zybtj_bg", dt6));


        }
        public DataTable GetZybRyxx(string tjbh, string tjcs)
        {
            StringBuilder sql = new StringBuilder("select gz,hyzk,tjbh,tjcs,xm,sfzh,csnyr,dw,dwdh,gh,bh,convert(varchar(10),tbrq,120) tbrq,lx,jws,bm,zdrq,zddw,sfqy,ccnl,jq,zq,tjnl,xyzn,lccs,zccs,sccs,yctc,sfxy,xyns,sfyj,yjsl,yjsj,qt,jtbs,dwdz,gz,ygzdwjgz,zybwhjcs,mingcheng,mzmc,hy,zyjcs,lcbx,xysjcjg,zdbz,zdjl,clyj,wjh,zgl,jsgl,xysl,dhqk,picture,zgqj,sgq,lgs,whcd,xb from v_tj_zyb_ryxx ");
            sql.Append(" where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'");

            string strConn = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            strConn = strConn + ";App=XXTJXT";
            DataAgent da = new DataAgent(strConn);
            return da.GetDataTable(sql.ToString());
        }
        public DataTable GetMobliePh(string tjbh)
        {
            string sql = "SELECT tjbh,ph,MOBILE FROM v_tj_dh_ph where  tjbh='" + tjbh + "'";
            string strConn = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            strConn = strConn + ";App=XXTJXT";
            DataAgent da1 = new DataAgent(strConn);
            return da1.GetDataTable(sql);
        }

        private void reportView_Load(object sender, EventArgs e)
        {
            BarcodeControl barcode = new BarcodeControl();
            barcode.BarcodeType = BarcodeType.CODE128C;
            barcode.Data = str_djlsh;
            barcode.CopyRight = "";
            MemoryStream stream = new MemoryStream();
            barcode.MakeImage(ImageFormat.Png, 1, 50, true, false, null, stream);
            Bitmap myimge = new Bitmap(stream);

            string str_path = Application.StartupPath + @"/barcode.png";
            myimge.Save(str_path, ImageFormat.Png);
            str_path = "file:///" + str_path;
            myimge.Dispose();              //201203

            string str_dwlxr = xtBiz.GetXtCsz("dwlxr").Trim();//单位联系人
            string str_dwdz = xtBiz.GetXtCsz("dwdz").Trim();//单位地址
            string str_dwdh = xtBiz.GetXtCsz("TjDwDh").Trim();//体检单位电话
            string str_tjzgzbh = xtBiz.GetXtCsz("zytjzgbh").Trim();//职业健康体检资格编号



            //string str_dwlxr = "hh";//单位联系人
            //string str_dwdz = "hh";//单位地址
            //string str_dwdh = "hh";//体检单位电话
            //string str_tjzgzbh = "hh";//职业健康体检资格编号

            //LocalReport report = new LocalReport();
            reportView.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing);
            string title = "职业健康检查表";

            DataTable dt2 = GetZybRyxx(strTjbh, strTjcs);

            reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_zyb_jkda_new.rdlc";
            reportView.LocalReport.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("dqrq", xtBiz.GetDataNow().ToString("yyyy-MM-dd"));
            ReportParameter rp2 = new ReportParameter("title", title);
            ReportParameter rp3 = new ReportParameter("bbmc", Program.reg_dwmc);
            ReportParameter rp4 = new ReportParameter("barcode", str_path);
            ReportParameter rp5 = new ReportParameter("dz", str_dwdz);
            ReportParameter rp6 = new ReportParameter("dh", str_dwdh);
            ReportParameter rp7 = new ReportParameter("lxr", str_dwlxr);
            ReportParameter rp8 = new ReportParameter("zgbh", str_tjzgzbh);

            reportView.LocalReport.DataSources.Clear();
            reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });

            //reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
            reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));
            this.reportView.RefreshReport();
        }

    }
}
