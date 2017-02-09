using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Reporting.WinForms;
using Cobainsoft.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using PEIS.xtgg;
using PEIS.Rdlc;
using PEIS.tjdj;
using System.Data;
using System.Windows.Forms;
using PEIS.zybtj;
using PEIS.main;
using System.Drawing;
namespace PEIS
{
    class RdlcPrint:Base
    {

        private StringBuilder sql;
        private string strTitle="********";
        private xtBiz xtBiz = new xtBiz();
        private TjZybZysBiz zysBiz = new TjZybZysBiz();
        private string strTjbh = "";
        private string strTjcs = "";
        private TjZybZzBiz zzBiz = new TjZybZzBiz();
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();
        rdlcBiz rdlcbiz = new rdlcBiz();
        private string str_dwlxr;
        private string str_dwdz;
        private string str_dwdh;
        private string str_tjzgzbh;

        public RdlcPrint()
        {
            if (Program.sfzc)
            {
                strTitle = xtBiz.GetXtCsz("TjDwMc");
            }
        }

        /// <summary>
        /// 获取检验结果
        /// </summary>
        /// <param name="djlsh"></param>
        /// <param name="jyjx"></param>
        /// <returns></returns>
        public DataTable GetJyjg(string djlsh, string jyjx)
        {
            sql = new StringBuilder("select tjbh,djlsh,djrq,brlx,ksmc,xm,xb,nl,dwmc,jcys,jcysmc,fbys,shrq,yblx,xmbh,xmsx,xmmc,jg,bz,ckz,dw,jyjx from v_jy_jybg");
            sql.Append(" where djlsh='"+djlsh+"' and jyjx='"+jyjx+"'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取职业病人员信息
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetZybRyxx(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select gz,hyzk,tjbh,tjcs,xm,sfzh,csnyr,dw,dwdh,gh,bh,convert(varchar(10),tbrq,120) tbrq,lx,jws,bm,zdrq,zddw,sfqy,ccnl,jq,zq,tjnl,xyzn,lccs,zccs,sccs,yctc,sfxy,xyns,sfyj,yjsl,yjsj,qt,jtbs,dwdz,gz,ygzdwjgz,zybwhjcs,mingcheng,mzmc,hy,zyjcs,lcbx,xysjcjg,zdbz,zdjl,clyj,wjh,zgl,jsgl,xysl,dhqk,picture,zgqj,sgq,lgs,whcd,xb from v_tj_zyb_ryxx ");
            sql.Append(" where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 打印检验报告
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <param name="jyjx">检验机器</param>
        public void PrintJyjg(string djlsh, string jyjx)
        {
          
            LocalReport report = new LocalReport();

            DataTable dt2 = GetJyjg(djlsh, jyjx);
            if (dt2.Rows.Count<=0)
            {
                MessageBox.Show("请先保存检验结果，再打印检验报告！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jybg_dy.rdlc";
            //report.EnableExternalImages = true;
            string yb = "";
            if (jyjx=="0001")
            {
                yb = "(小便)";
            }
            else if (jyjx=="0002")
            {
                yb = "(血液)";
            }
            else if (jyjx=="0003")
            {
                yb = "(血清)";
            }
            string title = strTitle + yb;

            ReportParameter rp1 = new ReportParameter("title", Program.reg_dwmc);
            ReportParameter rp2 = new ReportParameter("dysj", xtBiz.GetDataNow().ToString());
            
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_jy_jybg", dt2));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "检验报告打印", false, "A4");
        }


        /// <summary>
        /// 按体检中的组合项目打印检验报告
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <param name="jyjx">检验机器</param>
        public void PrintJyjg_zhxm(string djlsh, string zhxm)
        {

            LocalReport report = new LocalReport();
            PEIS.jkgl.LisBiz lisBiz = new PEIS.jkgl.LisBiz();

            DataTable dt2 = lisBiz.GetJyjg(djlsh, zhxm);
            if (dt2.Rows.Count == 0)
            {
                //MessageBox.Show("请先保存检验结果，再打印检验报告！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jybg_dy.rdlc";
            //report.EnableExternalImages = true;

            string jyjx = dt2.Rows[0]["jyjx"].ToString().Trim();
            string title="";
            if (jyjx == "0001")
            {
                //yb = "(小便)";
                title = "尿液常规";
            }
            else if (jyjx == "0002"||jyjx=="0004")
            {
                //yb = "(血液)";
                title = "血液细胞分析";
            }
            else if (jyjx == "0003")
            {
                //yb = "(血清)";
                title = "血液生化";
            }
            title = strTitle + title;
            XtNumber.Name = jyjx;
            ReportParameter rp1 = new ReportParameter("title", Program.reg_dwmc);
            ReportParameter rp2 = new ReportParameter("dysj", xtBiz.GetDataNow().ToString());

            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_jy_jybg", dt2));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "检验报告打印"+jyjx, false, "A4");
        }

        /// <summary>
        /// 打印健康档案——高原
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        public void PrintJkda_gy(string tjbh, string tjcs)
        {
            this.strTjbh = tjbh;
            this.strTjcs = tjcs;
            LocalReport report = new LocalReport();
            report.SubreportProcessing+=new SubreportProcessingEventHandler(report_SubreportProcessing2);
            string title = "高原机车、乘务人员职业健康检查表";
            DataTable dt2 = GetZybRyxx(tjbh, tjcs);
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_zyb_gy_jkda.rdlc";
            report.EnableExternalImages = true;
            //ReportParameter rp1 = new ReportParameter("dqrq", xtBiz.GetDataNow().ToString("yyyy-MM-dd"));
            ReportParameter rp2 = new ReportParameter("title", title);
            ReportParameter rp3 = new ReportParameter("bbmc", Program.reg_dwmc);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] {  rp2,rp3 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "高原机车、乘务人员职业健康检查表打印", false, "A4");
        }

        void report_SubreportProcessing2(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dt1 = new TjGyzzBiz().GetGyzz(strTjbh, strTjcs);
            DataTable dt2 = GetZybRyxx(strTjbh, strTjcs);
            DataTable dt3 = zzBiz.GetZybZz(strTjbh, strTjcs);
            DataTable dtTz = zzBiz.GetTz_gy(strTjbh, strTjcs);
            if (dtTz.Rows.Count == 0)
            {
                DataRow row = dtTz.NewRow();
                row["tjbh"] = strTjbh;
                row["tjcs"] = strTjcs;
                row["一般状况"] = DBNull.Value;
            }

            e.DataSources.Add(new ReportDataSource("PEISDataSet_tj_zyb_gyzz", dt1));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_TJ_ZYB_ZZ", dt3));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_zyb_zz", dt3));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_Pro_zybtj_bg_gycw", dtTz));

        }

        /// <summary>
        /// 打印健康档案——高原
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        public void PrintJkda_cwjc(string tjbh, string tjcs)
        {
            this.strTjbh = tjbh;
            this.strTjcs = tjcs;
            LocalReport report = new LocalReport();
            report.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing3);
            string title = "铁路机车乘务员职业健康检查表";
            DataTable dt2 = GetZybRyxx(tjbh, tjcs);
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_zyb_cwjc_jkda.rdlc";
            report.EnableExternalImages = true;
            //ReportParameter rp1 = new ReportParameter("dqrq", xtBiz.GetDataNow().ToString("yyyy-MM-dd"));
            ReportParameter rp2 = new ReportParameter("title", title);
            ReportParameter rp3 = new ReportParameter("bbmc", Program.reg_dwmc);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp2 ,rp3});
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "铁路机车乘务员职业健康检查表打印", false, "A4");
        }

        void report_SubreportProcessing3(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dt1 = zysBiz.GetZys(strTjbh);
            DataTable dt2 = GetZybRyxx(strTjbh, strTjcs);
            DataTable dt3 = zzBiz.GetTljc(strTjbh, strTjcs);
           

            //e.DataSources.Add(new ReportDataSource("PEISDataSet_tj_zyb_gyzz", dt1));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));
            //e.DataSources.Add(new ReportDataSource("PEISDataSet_TJ_ZYB_ZZ", dt3));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_Pro_zybtj_bg_cwjc", dt3));
            //e.DataSources.Add(new ReportDataSource("PEISDataSet_Pro_zybtj_bg_gycw", dtTz));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_zyb_zys", dt1));  
        }

        /// <summary>
        /// 打印健康档案
        /// </summary>
        /// <param name="tjbh">体检编号</param>
        /// <param name="tjcs">体检次数</param>
        /// <param name="djlsh">登记流水号</param>
        /// <param name="pagefw">打印页码范围,""表示所有</param>
        public void PrintJkda(string tjbh, string tjcs,string djlsh,string pagefw)
        {
            BarcodeControl barcode = new BarcodeControl();
            barcode.BarcodeType = BarcodeType.CODE128C;
            barcode.Data = djlsh;
            barcode.CopyRight = "";
            MemoryStream stream = new MemoryStream();
            barcode.MakeImage(ImageFormat.Png, 1, 50, true, false, null, stream);
            Bitmap myimge = new Bitmap(stream);

            string str_path = Application.StartupPath + @"/barcode.png";
            myimge.Save(str_path, ImageFormat.Png);
            str_path = "file:///" + str_path;
            myimge.Dispose();              //201203

            str_dwlxr = xtBiz.GetXtCsz("dwlxr").Trim();
            str_dwdz = xtBiz.GetXtCsz("dwdz").Trim();
            str_dwdh = xtBiz.GetXtCsz("TjDwDh").Trim();
            str_tjzgzbh = xtBiz.GetXtCsz("zytjzgbh").Trim();//职业健康体检资格编号

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            //this.strTjbh = tjbh;
            //this.strTjcs = tjcs;
            //LocalReport report = new LocalReport();
            //report.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing);
            //string title = "职业健康检查表";

            //DataTable dt2 = GetZybRyxx(tjbh, tjcs);

            //report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_zyb_jkda_new.rdlc";
            //report.EnableExternalImages = true;
            //ReportParameter rp1 = new ReportParameter("dqrq", xtBiz.GetDataNow().ToString("yyyy-MM-dd"));
            //ReportParameter rp2 = new ReportParameter("title", title);
            //ReportParameter rp3 = new ReportParameter("bbmc", Program.reg_dwmc);
            //ReportParameter rp4 = new ReportParameter("barcode", str_path);
            //ReportParameter rp5 = new ReportParameter("dz", str_dwdz);
            //ReportParameter rp6 = new ReportParameter("dh", str_dwdh);
            //ReportParameter rp7 = new ReportParameter("lxr", str_dwlxr);
            //ReportParameter rp8 = new ReportParameter("zgbh", str_tjzgzbh);


            //report.DataSources.Clear();
            //report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });
            ////report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4,rp8 });
            //report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));

            //RdlcPrintNew rdlcprint = new RdlcPrintNew();
            //rdlcprint.Run(report, "职业健康检查表打印", false, "A4", pagefw);
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            this.strTjbh = tjbh;
            this.strTjcs = tjcs;
            LocalReport report = new LocalReport();
            report.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing);
            string title = xtBiz.GetXtCsz("TjDwMc");

            DataTable dt2 = GetZybRyxx(tjbh, tjcs);

            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_zyb_jkda_new.rdlc";
            report.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("dqrq", xtBiz.GetDataNow().ToString("yyyy-MM-dd"));
            ReportParameter rp2 = new ReportParameter("title", title);
            ReportParameter rp3 = new ReportParameter("bbmc", Program.reg_dwmc);
            ReportParameter rp4 = new ReportParameter("barcode", str_path);
            ReportParameter rp5 = new ReportParameter("dz", str_dwdz);
            ReportParameter rp6 = new ReportParameter("dh", str_dwdh);
            ReportParameter rp7 = new ReportParameter("lxr", str_dwlxr);
            ReportParameter rp8 = new ReportParameter("zgbh", str_tjzgzbh);


            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });
            //report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4,rp8 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_zyb_ryxx", dt2));

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "职业健康检查表打印", false, "A4", pagefw);
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


            if (dtTz.Rows.Count<=0)
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

        public DataTable GetMobliePh(string tjbh)
        {
            string sql = "SELECT tjbh,ph,MOBILE FROM v_tj_dh_ph where  tjbh='"+tjbh+"'";
            return base.SqlDBAgent.GetDataTable(sql);
        }


        PrintWaiting pw = new PrintWaiting();

        /// <summary>
        /// 打印检查表
        /// </summary>
        public void PrintJcb(string str_tjbh, string str_tjcs,string xm,string dwmc)
        {
            pw.StartThread();
            string number = xtBiz.GetHmz("tgjcb_bh", 1);
            int len = number.Length;
            for (int i = 0; i < 4 - len; i++)
            {
                number = "0" + number;
            }

            string str_fph = xtBiz.GetHmz("tjbfph", 1);
            int len2 = str_fph.Length;
            for (int j = 0; j < 7 - len; j++)
            {
                str_fph = "0" + str_fph;
            }



            this.strTjbh = str_tjbh;
            this.strTjcs = str_tjcs;
           

            LocalReport report = new LocalReport();
            report.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing_Jcb);
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jcb_main.rdlc";
            report.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("bgrq", xtBiz.GetDataNow().ToString("yyyy年MM月dd日"));
            ReportParameter rp2 = new ReportParameter("title", Program.reg_dwmc);
            ReportParameter rp3 = new ReportParameter("number", number);
            ReportParameter rp4 = new ReportParameter("fph", str_fph);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3 ,rp4});
 
            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(report, "体格检查表", false, "A4");
            loginbiz.Insert_fplog(str_fph,xm,dwmc,Program.username);
            pw.StopThread();
        }

        void report_SubreportProcessing_Jcb(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dt1 = rdlcbiz.Get_v_tj_tjdjb(strTjbh, strTjcs);
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt1));
        }
    }
}
