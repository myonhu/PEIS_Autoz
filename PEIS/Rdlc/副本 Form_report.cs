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

namespace PEIS.Rdlc
{
    public partial class Form_report : PEIS.MdiChildrenForm
    {
        string str_tjbh = "";
        string str_tjcs = "";
        string str_djlsh = "";
        string str_type = "";
        string str_tjdw = "";
        string str_dwdh = "";
        string sqd_ts = "";
        string str_bggs = "";
        rdlcBiz rdlcbiz = new rdlcBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        tjjgBiz tjjgbiz = new tjjgBiz();
        xtBiz xtbiz = new xtBiz();
        xtggBiz xtggbiz = new xtggBiz();
        Rijndael_ rijndael_ = new Rijndael_();

        public Form_report()
        {
            InitializeComponent();
        }
        public Form_report(string tjbh,string tjcs,string djlsh,string type)
        {
            InitializeComponent();
            str_tjbh = tjbh;
            str_tjcs = tjcs;
            str_djlsh = djlsh;
            str_type = type;
        }

        public Form_report(string tjbh, string tjcs, string djlsh, string type,string bggs)
        {
            InitializeComponent();
            str_tjbh = tjbh;
            str_tjcs = tjcs;
            str_djlsh = djlsh;
            str_type = type;
            str_bggs = bggs;
        }

        private void Form_report_Load(object sender, EventArgs e)
        {
            str_tjdw = xtbiz.GetXtCsz("TjDwMc");
            str_dwdh = xtbiz.GetXtCsz("TjDwDh");
            sqd_ts = xtbiz.GetXtCsz("sqd_ts");

            BarcodeControl barcode = new BarcodeControl();
            barcode.BarcodeType = BarcodeType.CODE128C;
            barcode.Data = str_djlsh;
            barcode.CopyRight = "";
            MemoryStream stream = new MemoryStream();
            barcode.MakeImage(ImageFormat.Png, 1, 50, true, false, null, stream);
            Bitmap myimge = new Bitmap(stream);

            string str_picpath = Application.StartupPath + @"/Img/医院徽标.bmp";
            string str_barpath = Application.StartupPath + @"/barcode.png";
            string str_ZYBG_Top = Application.StartupPath + @"/Img/ZYBG_Top.png";
            string str_yyewm = Application.StartupPath + @"/Img/微信.png";
            myimge.Save(str_barpath, ImageFormat.Png);
            str_picpath = "file:///" + str_picpath;
            str_barpath = "file:///" + str_barpath;
            str_ZYBG_Top = "file:///" + str_ZYBG_Top;
            string strLog = "file:///" + Application.StartupPath + @"/Img/log.jpg";
            str_yyewm = "file:///" + str_yyewm;//微信二维码

            if (str_type == "tjzyd")
            {
                string str_dwlxr = ""; //联系人
                string str_dwczhm = "";//传真
                string str_version = "";//版本
                string str_dwdz = "";//地址
                str_dwczhm = xtbiz.GetXtCsz("dwczdh").Trim();
                str_dwlxr = xtbiz.GetXtCsz("dwlxr").Trim();
                str_dwdz = xtbiz.GetXtCsz("dwdz").Trim();
                str_version = xtbiz.GetXtCsz("version").Trim();

                DataTable dt1 = rdlcbiz.Get_tj_tjjlb(str_tjbh, str_tjcs);
                DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(str_tjbh,str_tjcs);
                DataTable dt3 = rdlcbiz.Get_v_tj_fyxx(str_tjbh, str_tjcs);

                if (xtbiz.GetXtCsz("version").Trim() == "1") //职业体检
                {
                     reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjzyd_zyb.rdlc";
                }
                else
                {
                     reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjzyd.rdlc";
                }
                reportView.LocalReport.EnableExternalImages = true;
                ReportParameter rp1 = new ReportParameter("tjdw", str_tjdw);
                ReportParameter rp2 = new ReportParameter("barcode", str_barpath);
                ReportParameter rp3 = new ReportParameter("tjdh", str_dwdh);
                ReportParameter rp4 = new ReportParameter("log", strLog);
                ReportParameter rp5 = new ReportParameter("dwcz", str_dwczhm);
                ReportParameter rp6 = new ReportParameter("dwlxr", str_dwlxr);
                ReportParameter rp7 = new ReportParameter("version", str_version);
                ReportParameter rp8 = new ReportParameter("dwdz", str_dwdz);
                reportView.LocalReport.DataSources.Clear();
                reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });
                reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_tj_tjjlb", dt1));
                reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
                reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_fyxx", dt3));
            }
            if (str_type == "tjsqd")
            {
                DataTable dt1 = rdlcbiz.Get_tj_sqdlx_hd(str_tjbh, str_tjcs);
                DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(str_tjbh, str_tjcs);
                reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjsqd.rdlc";
                reportView.LocalReport.EnableExternalImages = true;
                ReportParameter rp1 = new ReportParameter("tjdw", str_tjdw);
                ReportParameter rp2 = new ReportParameter("barcode", str_barpath);
                ReportParameter rp3 = new ReportParameter("sqd_ts", sqd_ts);
                reportView.LocalReport.DataSources.Clear();
                reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 });
                reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_tj_sqdlx_hd", dt1));
                reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            }
            if (str_type == "tjtxm")
            {
                DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(str_tjbh, str_tjcs);
                reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjtxm.rdlc";
                reportView.LocalReport.EnableExternalImages = true;
                ReportParameter rp1 = new ReportParameter("barcode", str_barpath);
                reportView.LocalReport.DataSources.Clear();
                reportView.LocalReport.SetParameters(new ReportParameter[] { rp1 });
                reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            }
            if (str_type == "tjbg")
            {
                DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(str_tjbh, str_tjcs);

                string str_tjlb = dt2.Rows[0]["lbbh"].ToString();
                if (str_tjlb == "05")//中医体检 2014-06-26
                {
                    DataTable dt = tjjgbiz.Get_v_tj_zyjgb(str_tjbh, str_tjcs);
                    byte[] bytes = PEIS.Properties.Resources.Report_tjbg_zytj;
                    FileStream fstream = File.Create(@"C:\WINDOWS\Temp\Report_tjbg_temp", bytes.Length);
                    try
                    {
                        fstream.Write(bytes, 0, bytes.Length);   //二进制转换成文件
                    }
                    catch (Exception ex)
                    {
                        //抛出异常信息
                        MessageBox.Show("报表文件处理异常，请联系技术支持人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    finally
                    {
                        fstream.Close();
                    }
                    File.Copy(@"C:\WINDOWS\Temp\Report_tjbg_temp", @"C:\WINDOWS\Temp\Report_tjbg_zytj", true);
                    reportView.LocalReport.ReportPath = @"C:\WINDOWS\Temp\Report_tjbg_zytj";
                    //reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg_zytj.rdlc";
                    reportView.LocalReport.EnableExternalImages = true;
                    reportView.LocalReport.DataSources.Clear();
                    ReportParameter rp = new ReportParameter("dwmc", Program.reg_dwmc);
                    ReportParameter rp_top = new ReportParameter("ZYBG_Top", str_ZYBG_Top);
                    reportView.LocalReport.SetParameters(new ReportParameter[] { rp,rp_top });
                    reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyjgb", dt));
                    this.reportView.RefreshReport();
                    return;
                }

                reportView.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

                if (str_bggs == "明细结果格式")
                    reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg_jgjcb.rdlc";
                else if (str_bggs == "结论格式")
                    reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg_zsbg.rdlc";
                else//标准格式
                    reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg.rdlc";

                //reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjbg.rdlc";

                reportView.LocalReport.EnableExternalImages = true;
                ReportParameter rp1 = new ReportParameter("tjdw", str_tjdw);
                ReportParameter rp2 = new ReportParameter("barcode", str_barpath);
                ReportParameter rp3 = new ReportParameter("tjdh", str_dwdh);
                ReportParameter rp4 = new ReportParameter("yypic", str_picpath);
                ReportParameter rp5 = new ReportParameter("yyewm", str_yyewm);
                reportView.LocalReport.DataSources.Clear();
                reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3,rp4,rp5 });
                //reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_tj_tjjlb", dt1));
                reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            }
            this.reportView.RefreshReport();
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dt1 = rdlcbiz.Get_TJ_TJBG_BZB(str_tjbh, str_tjcs);
            DataTable dt2 = rdlcbiz.Get_v_tj_tjdjb(str_tjbh, str_tjcs);
            DataTable dtZhxmmx = new DataTable();
            dtZhxmmx = rdlcbiz.GetTjjlmx(str_tjbh, str_tjcs);

            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tjjlmx", dtZhxmmx));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_tj_tjjlmxb", dt1));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            //RdlcPrintNew rdlcprint = new RdlcPrintNew();

            //rdlcprint.Run(reportView.LocalReport, "单据打印", false,"A4");
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

    }
}

