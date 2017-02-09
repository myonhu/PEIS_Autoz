using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PEIS.xtgg;
using PEIS.Rdlc;
using Cobainsoft.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using PEIS.tjdj;
namespace PEIS.zybtj
{
    public partial class Form_jkzpldy : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        rdlcBiz rdlcbiz = new rdlcBiz();
        string str_tjdw = "";
        string str_dwdh = "";

        private Common.Common comn = new Common.Common();

        public Form_jkzpldy()
        {
            InitializeComponent();
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

        private void bt_select_Click(object sender, EventArgs e)
        {
            if (dtp_begin.Value > dtp_end.Value)
            {
                MessageBox.Show("开始日期不能大于结束日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = dtp_begin;
                return;
            }

            if (txt_tjdw.Text == "") txt_tjdw.Tag = "";
            string str_dwbh = "";
            if (txt_tjdw.Tag.ToString().Trim() != "")
            {
                str_dwbh = txt_tjdw.Tag.ToString().Trim().Substring(0, 4);
            }
            string str_bmbh = txt_tjdw.Tag.ToString().Trim();
            if (str_bmbh.Length == 4) str_bmbh = "";


            DataTable dtJbxx = new DataTable();
            dtJbxx = tjdjbiz.GetTjdjxx_jkzpldy(str_dwbh, comn.DateTimeChange(dtp_begin.Value.AddDays(-1)) + " 23:59:59", comn.DateTimeChange(dtp_end.Value)
                + " 23:59:59", txt_xm.Text.Trim());
            dgv_tjdjb.DataSource = dtJbxx;
            ChargeColor();

            groupBox2.Text = "体检记录----办证人数合计：" + dtJbxx.Rows.Count.ToString() + "人";
        }

        void ChargeColor()
        {
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                string str_dycs = dgr.Cells["dycs"].Value.ToString().Trim();
                if (str_dycs == "0")
                {
                    dgr.DefaultCellStyle.BackColor = Color.White;//未打印
                }
                else
                {
                    dgr.DefaultCellStyle.BackColor = Color.Red;//已打印
                }
                
            }
        }


        private void Form_tjbg_Load(object sender, EventArgs e)
        {
            txt_tjdw.Tag = "";

            str_tjdw = xtbiz.GetXtCsz("TjDwMc");
            str_dwdh = xtbiz.GetXtCsz("TjDwDh");

            dtp_begin.Value = xtbiz.GetServerDate();
            dtp_end.Value = dtp_begin.Value;
        }

        private void bt_allcheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow  dgr in dgv_tjdjb.Rows)
            {
                dgr.Cells["selected"].Value = "1";
            }
        }

        private void bt_alluncheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                dgr.Cells["selected"].Value = "0";
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private PrintWaiting pw = new PrintWaiting();
        private void bt_singeprint_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;
            pw.StartThread();
            DataGridViewRow dgr = dgv_tjdjb.CurrentRow;

            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            string str_jkzbh = dgr.Cells["jkzbh"].Value.ToString().Trim();

            PrintRdlc(str_tjbh, str_tjcs, str_jkzbh);

            //add
            try
            {
                tjdjbiz.TjJkzDycsSave(str_jkzbh, str_tjbh, str_tjcs, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            pw.StopThread();
        }

        private void bt_allprint_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;
            pw.StartThread();
            foreach (DataGridViewRow  dgr in dgv_tjdjb.Rows)
            {
                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")
                {
                    string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    string str_jkzbh = dgr.Cells["jkzbh"].Value.ToString().Trim();

                    PrintRdlc(str_tjbh, str_tjcs, str_jkzbh);

                    //add
                    try
                    {
                        tjdjbiz.TjJkzDycsSave(str_jkzbh, str_tjbh, str_tjcs, 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
            pw.StopThread();

        }
        void PrintRdlc(string tjbh, string tjcs, string str_jkzbh)
        {
            DataTable dt1 = tjdjbiz.TjJkzbb(str_jkzbh, tjbh, tjcs);
            if (dt1.Rows.Count <= 0)
            {
                MessageBox.Show("请确认已经保存办证信息！", "提示");
                return;
            }
            LocalReport report = new LocalReport();
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jkz_head.rdlc";
            report.EnableExternalImages = true;

            LocalReport report2 = new LocalReport();
            report2.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jkz_foot.rdlc";
            report2.EnableExternalImages = true;

            ReportParameter rp1 = new ReportParameter("jkzbh", str_jkzbh);
            ReportParameter rp2 = new ReportParameter("tjbh", tjbh);
            ReportParameter rp3 = new ReportParameter("tjcs", tjcs);
            ReportParameter rp4 = new ReportParameter("bbmc", Program.sys_reportname);

            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_jkzxx", dt1));

            report2.DataSources.Clear();
            report2.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
            report2.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_jkzxx", dt1));

            //reportViewer1.RefreshReport();

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            //rdlcprint.Hxdy = true;
            rdlcprint.Run(report, "健康证", false, "jkzhead");

            rdlcprint.Run(report2, "健康证", false, "jkzfoot");
        }

        private void dgv_tjdjb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //DataGridViewRow dgr = dgv_tjdjb.CurrentRow;
            //string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            //string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            //string str_djlsh = dgr.Cells["jkzbh"].Value.ToString().Trim();
            //Form_report frm = new Form_report(str_tjbh, str_tjcs, str_djlsh, "tjzyd");
            //frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;
            pw.StartThread();
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")
                {
                    string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    string str_jkzbh = dgr.Cells["jkzbh"].Value.ToString().Trim();

                    PrintRdlc_zmdy(str_tjbh, str_tjcs, str_jkzbh);

 

                }
            }
            pw.StopThread();
        }


        void PrintRdlc_zmdy(string tjbh, string tjcs, string str_jkzbh)
        {
            DataTable dt1 = tjdjbiz.TjJkzbb(str_jkzbh, tjbh, tjcs);
            if (dt1.Rows.Count <= 0)
            {
                MessageBox.Show("请确认已经保存办证信息！", "提示");
                return;
            }
            LocalReport report = new LocalReport();
            report.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jkz_head.rdlc";
            report.EnableExternalImages = true;


            ReportParameter rp1 = new ReportParameter("jkzbh", str_jkzbh);
            ReportParameter rp2 = new ReportParameter("tjbh", tjbh);
            ReportParameter rp3 = new ReportParameter("tjcs", tjcs);
            ReportParameter rp4 = new ReportParameter("bbmc", Program.sys_reportname);

            report.DataSources.Clear();
            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
            report.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_jkzxx", dt1));


            //reportViewer1.RefreshReport();

            RdlcPrintNew rdlcprint = new RdlcPrintNew();
            //rdlcprint.Hxdy = true;
            rdlcprint.Run(report, "健康证", false, "jkzhead");
        }

        void PrintRdlc_bmdy(string tjbh, string tjcs, string str_jkzbh)
        {
            DataTable dt1 = tjdjbiz.TjJkzbb(str_jkzbh, tjbh, tjcs);
            if (dt1.Rows.Count <= 0)
            {
                MessageBox.Show("请确认已经保存办证信息！", "提示");
                return;
            }
         

            LocalReport report2 = new LocalReport();
            report2.ReportPath = Application.StartupPath + @"/rdlcreport/Report_jkz_foot.rdlc";
            report2.EnableExternalImages = true;

            ReportParameter rp1 = new ReportParameter("jkzbh", str_jkzbh);
            ReportParameter rp2 = new ReportParameter("tjbh", tjbh);
            ReportParameter rp3 = new ReportParameter("tjcs", tjcs);
            ReportParameter rp4 = new ReportParameter("bbmc", Program.sys_reportname);

 

            report2.DataSources.Clear();
            report2.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
            report2.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_jkzxx", dt1));

            //reportViewer1.RefreshReport();

            RdlcPrintNew rdlcprint = new RdlcPrintNew();

            rdlcprint.Run(report2, "健康证", false, "jkzfoot");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;
            pw.StartThread();
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")
                {
                    string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    string str_jkzbh = dgr.Cells["jkzbh"].Value.ToString().Trim();

                    PrintRdlc_bmdy(str_tjbh, str_tjcs, str_jkzbh);

                  

                }
            }
            pw.StopThread();
        }
    }
}

