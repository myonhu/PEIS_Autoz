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
using PEIS.xtgg;


namespace PEIS.cxbb
{
    public partial class Form_zybhztj_yx : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        cxbbBiz cxbbbiz = new cxbbBiz();
        private PEIS.tjjg.tjjgBiz tjjgBiz = new PEIS.tjjg.tjjgBiz();

        public Form_zybhztj_yx()
        {
            InitializeComponent();
        }

        private void Form_zybhztj_yx_Load(object sender, EventArgs e)
        {
            dtp_begin.Value = xtbiz.GetServerDate();
            dtp_end.Value = dtp_begin.Value;
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

            if (txt_tjdw.Text == "") txt_tjdw.Tag = "";
            string str_dwbh = txt_tjdw.Tag.ToString().Trim();
            string str_bmbh = "";
            if (str_dwbh.Length > 4)
            {
                str_bmbh = str_dwbh;
                str_dwbh = str_dwbh.Substring(0, 4);
            }

            string str_bblx = "";
            if (rbt_1.Checked)
            {
                str_bblx = "1"; //阳性报表
            }
            if (rbt_2.Checked)
            {
                str_bblx = "0"; //正常报表
            }

            reportView.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(report_SubreportProcessing);
            
            DataTable dt1 = cxbbbiz.Get_pro_tj_zybhzbb(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"), str_dwbh, str_bblx);

            reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlc/Report_zybhzbb.rdlc";
            reportView.LocalReport.EnableExternalImages = true;

            ReportParameter rp1 = new ReportParameter("ksrq", dtp_begin.Value.ToString("yyyy-MM-dd"));
            ReportParameter rp2 = new ReportParameter("jsrq", dtp_end.Value.ToString("yyyy-MM-dd"));
            ReportParameter rp3 = new ReportParameter("dwmc", txt_tjdw.Text.Trim());
            ReportParameter rp4 = new ReportParameter("bblx", str_bblx);
            reportView.LocalReport.DataSources.Clear();
            reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
            reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet1_pro_bb_zybhz", dt1));
            //reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            reportView.RefreshReport();

        }
            
        void report_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            string str_tjbh = e.Parameters["pTjbh"].Values[0];
            DataTable dt1 = tjjgBiz.Get_TJ_TJJLB_XJ(str_tjbh);
            e.DataSources.Add(new ReportDataSource("PEISDataSet_v_tjjlmx", dt1));
        }

        private void bt_tjdw_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_tjdw.Text = frm.str_tjdwmc;
                txt_tjdw.Tag = frm.str_tjdwid;
            }
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            rdlcprint.Run(reportView.LocalReport, "单据打印", false, "A4");
        }



    }
}

