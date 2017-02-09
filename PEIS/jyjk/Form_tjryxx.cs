using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PEIS.xtgg;
using PEIS.main;
using PEIS.Rdlc;
using System.IO;
namespace PEIS.jyjk
{
    public partial class Form_tjryxx : MdiChildrenForm
    {
        public Form_tjryxx()
        {
            InitializeComponent();
        }
        JyjkBiz y = new JyjkBiz();
        xtBiz xtbiz = new xtBiz();
        private void Form_tjryxx_Load(object sender, EventArgs e)
        {
            dtp_begin.Value = xtbiz.GetServerDate();
            dtp_end.Value = dtp_begin.Value;
        }

        private void btn_cx_Click(object sender, EventArgs e)
        {
            if (dtp_begin.Value > dtp_end.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtp_begin;
                return;
            }

            DataTable dt=new DataTable();

            dt = y.Get_tjryxx(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.AddDays(1).ToString("yyyy-MM-dd"), txt_xm.Text.Trim(), txt_djlsh.Text.Trim());
            dataGridView1.DataSource = dt;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dataGridView1.CurrentRow)) return;
            if (dataGridView1.Rows.Count < 1) return;
            rdlcBiz rdlcbiz = new rdlcBiz();
            foreach (DataGridViewRow dgr in dataGridView1.Rows)
            {
                if (dgr.Cells["xz"].Value.ToString().Trim() == "1")
                {
                    string str_tjbh = dgr.Cells["djlsh"].Value.ToString().Trim();


                    DataTable dt2 = rdlcbiz.Get_v_jy_jybgdy(str_tjbh);
                    LocalReport report = new LocalReport();
                    report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jybgdy.rdlc";
                    report.EnableExternalImages = true;

                    ReportParameter rp1 = new ReportParameter("djlsh", str_tjbh);
                    ReportParameter rp2 = new ReportParameter("zcdw", Program.reg_dwmc);
                    

                    report.DataSources.Clear();
                    report.SetParameters(new ReportParameter[] { rp1, rp2});
                    report.DataSources.Add(new ReportDataSource("PEISDataSet_v_jy_jybgdy", dt2));

                    RdlcPrintNew rdlcprint = new RdlcPrintNew();
                    try
                    {
                        rdlcprint.Run(report, "检验报告", false, "A4");
                    }
                    catch (Exception ex3)
                    {
                        MessageBox.Show(ex3.ToString());
                        return;
                    }
 
                }
            }
 

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckb_all_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckb_xz.Checked == true)
            {

                foreach (DataGridViewRow dgr in dataGridView1.Rows)
                {
                    dgr.Cells["xz"].Value = "1";
                }
            }
            else
            {
                foreach (DataGridViewRow dgr in dataGridView1.Rows)
                {
                    dgr.Cells["xz"].Value = "0";
                }
            }
        }
    }
}