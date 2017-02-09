using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PEIS.xtgg;

namespace PEIS.cxbb
{
    public partial class Form_gztjb : MdiChildrenForm
    {
        private Gztjb tjb = new Gztjb();

        public Form_gztjb()
        {
            InitializeComponent();
        }

        private void Form_gztjb_Load(object sender, EventArgs e)
        {

            this.reportView.RefreshReport();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_select_Click(object sender, EventArgs e)
        {
            if (dtp_begin.Value > dtp_end.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtp_begin;
                return;
            }

          

            DataTable dt = tjb.GetGztjb(dtp_begin.Value.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59",
                dtp_end.Value.ToString("yyyy-MM-dd") + " 23:59:59");

            string year = dtp_begin.Value.Year.ToString();
            int month = dtp_begin.Value.Month;
            int jd = (month-1) / 3 + 1;

            string sj = year + "年  " + jd.ToString() + "  季度";

            string path = @"/rdlcreport/Report_tj_gztjb.rdlc";
            reportView.LocalReport.ReportPath = Application.StartupPath + path;
            reportView.LocalReport.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("sj",sj);
            ReportParameter rp2 = new ReportParameter("bbmc", Program.reg_dwmc);
            reportView.LocalReport.DataSources.Clear();
            reportView.LocalReport.SetParameters(new ReportParameter[] { rp1,rp2 });
            reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_gztjb", dt));
          
            reportView.RefreshReport();
        }

        PrintWaiting pw = new PrintWaiting();

        private void bt_print_Click(object sender, EventArgs e)
        {
            pw.StartThread();
            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Hxdy = true;
            rdlcprint.Run(reportView.LocalReport, "工作统计表", false, "tjjgdy");
            pw.StopThread();
        }
    }
}