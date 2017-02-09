using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PEIS.cxbb;

namespace PEIS.tjjg
{
    public partial class Form_tzs_ly : MdiChildrenForm
    {
        private DataTable dt;
        private tjjgBiz tjjgBiz = new tjjgBiz();
        private Zyjk_tzs tzs = new Zyjk_tzs();
        private string str_dwbh;
        private string from;
        private string to;
        private xtBiz xtbiz = new xtBiz();
        private string dw;

        public Form_tzs_ly(DataTable dt, string str_dwbh, string from, string to, string dw)
        {
            InitializeComponent();
            this.dt = dt;
            this.str_dwbh = str_dwbh;
            this.from = from;
            this.to = to;
            this.dw = dw;
        }

        private void Form_tzs_ly_Load(object sender, EventArgs e)
        {
            string tjrq = DateTime.Now.ToString("yyyy年MM月dd日");
            DataTable dtTjrq = tzs.GetTjrq(str_dwbh, from, to,"");
            if (dtTjrq.Rows.Count > 0)
            {
                DateTime mindate = Convert.ToDateTime(dtTjrq.Rows[0]["mindate"].ToString().Trim());
                DateTime maxdate = Convert.ToDateTime(dtTjrq.Rows[0]["maxdate"].ToString().Trim());
                string date1 = mindate.ToString("yyyy年MM月dd日");
                string date2 = maxdate.ToString("yyyy年MM月dd日");
                if (date1 == date2)
                {
                    tjrq = date1;
                }
                else
                {
                    tjrq = date1 + "—" + date2;
                }
            }
            StringBuilder gzjwhys = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //bgid,maxdate,mindate,sjdw,tjrs,tjxm,tjjl,gz,zrs,jkycrs,zyycrs,dwmc,rylb,whys
                gzjwhys.Append(dt.Rows[i]["gz"].ToString().Trim() + "共" + dt.Rows[i]["zrs"]
                    + "人,接触的主要职业病危害因素是" + dt.Rows[i]["whys"].ToString().Trim() + "；");
            }

            LocalReport report = reportViewer1.LocalReport;
            report.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing);
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_zyjc_main.rdlc";
            report.EnableExternalImages = true;
            DateTime dqrq = xtbiz.GetDataNow();



            ReportParameter rp1 = new ReportParameter("dwmc", dw);
            ReportParameter rp2 = new ReportParameter("tjrq", tjrq);
            ReportParameter rp3 = new ReportParameter("bgrqdx", tzs.ChangeTime(dqrq));
            ReportParameter rp4 = new ReportParameter("gzjwhys", gzjwhys.ToString());
            ReportParameter rp5 = new ReportParameter("ys", "1");
            //ReportParameter rp4 = new ReportParameter("bblx", str_bblx);
            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5 });
            //report.DataSources.Add(new ReportDataSource("PEISDataSet_v_sz_tjbg", dt));
            this.reportViewer1.RefreshReport();
        }

        void report_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            //DataTable dt = tjjgBiz.GetSzTjbg(from,
            //   to, str_dwbh);

            DataTable dt2 = tjjgBiz.GetSzTjbgMx(from,
               to, str_dwbh);

            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_sz_tjbg", dt));
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_sz_tjbg_mxfz", dt2));
        }


        /// <summary>
        /// EXCEL导出方法
        /// </summary>
        /// <param name="control">控件名称</param>
        /// <param name="filename">文件名称</param>
        public void ToExcel(System.Windows.Forms.Control control, string filename)
        {
            ////定义文档类型、字符编码
            //System.Web.HttpContext.Current.Response.Charset = "GB2312";
            ////下面这行很重要， attachment 参数表示作为附件下载，您可以改成 online在线打开
            ////filename=FileFlow.xls 指定输出文件的名称，注意其扩展名和指定文件类型相符，可以为：.doc 　　 .xls 　　 .txt 　　.htm
            //System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename + ".doc");
            //System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            ////Response.ContentType指定文件类型 可以为application/ms-excel、application/ms-word、application/ms-txt、application/ms-html 或其他浏览器可直接支持文档
            //System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";

            //System.IO.StringWriter tw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            //control.Page.EnableViewState = false;
            //control.RenderControl(hw);

            //System.Web.HttpContext.Current.Response.Write(tw);
            //System.Web.HttpContext.Current.Response.End();
        }

       
    }
}