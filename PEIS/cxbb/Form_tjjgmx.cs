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
using PEIS.ywsz;

namespace PEIS.cxbb
{
    public partial class Form_tjjgmx : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        cxbbBiz cxbbbiz = new cxbbBiz();
        ywszBiz ywszbiz = new ywszBiz();

        DataTable dt_tjxm = null;
        string str_dwbh = "";
        string str_bmbh = "";
        string str_xmbm = "";

        public Form_tjjgmx()
        {
            InitializeComponent();
        }

        private void Form_yxjghz_Load(object sender, EventArgs e)
        {
            dtp_begin.Value = xtbiz.GetServerDate();
            dtp_end.Value = dtp_begin.Value;

            cmb_xmmb.SelectedIndexChanged -= new EventHandler(cmb_xmmb_SelectedIndexChanged);
            cmb_xmmb.DataSource = ywszbiz.Get_tj_xmmb_hd();
            cmb_xmmb.ValueMember = "bh";
            cmb_xmmb.DisplayMember = "mbmc";
            cmb_xmmb.SelectedIndex = -1;
            cmb_xmmb.SelectedIndexChanged += new EventHandler(cmb_xmmb_SelectedIndexChanged);
        }

        void cmb_xmmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            str_xmbm = cmb_xmmb.SelectedValue.ToString();
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
            if (object.Equals(null,cmb_xmmb.SelectedValue))
            {
                MessageBox.Show("请选择统计项目模板！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_xmmb;
                return;
            }
            if (txt_tjdw.Text == "") txt_tjdw.Tag = "";
            str_dwbh = txt_tjdw.Tag.ToString().Trim();
            if (str_dwbh.Length > 4)
            {
                str_bmbh = str_dwbh;
                str_dwbh = str_dwbh.Substring(0, 4);
            }

            pictureBox.Visible = true;
            pictureBox.BringToFront();
            worker.RunWorkerAsync();
            
            //reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjmxjg.rdlc";
            //reportView.LocalReport.EnableExternalImages = true;
            //ReportParameter rp1 = new ReportParameter("tjdw", txt_tjdw.Text.Trim());
            //ReportParameter rp2 = new ReportParameter("begin", dtp_begin.Value.ToString("yyyy-MM-dd"));
            //ReportParameter rp3 = new ReportParameter("end", dtp_end.Value.ToString("yyyy-MM-dd"));
            //ReportParameter rp4 = new ReportParameter("czy", Program.username);
            //ReportParameter rp5 = new ReportParameter("bbmc", Program.reg_dwmc);
            //reportView.LocalReport.DataSources.Clear();
            //reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 ,rp4 ,rp5});
            //reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_pro_tj_tjxmjg", dt1));
            ////reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            //reportView.RefreshReport();

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
            //RdlcPrintNew rdlcprint = new RdlcPrintNew();
            //rdlcprint.Run(reportView.LocalReport, "单据打印", false, "A4");

            //DataGridViewExport.DataGridviewShowToExcel(dgv_tjxm,false);

            string path = "";
            bool overWrite = true;

            if (dgv_tjxm.Rows.Count == 0)
            {
                return;
            }

            Common.Common comn = new Common.Common();

            saveFileDialog1.Filter = "Excel File|*.xls";
            saveFileDialog1.Title = "数据导出";

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                path = saveFileDialog1.FileName;
                DataGridViewExport.ExportToExcel(dgv_tjxm, path, "s", overWrite);
            }

            DialogResult result = MessageBox.Show("是否打开Excel文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (DataGridViewExport.IsExistsExcel())
            {
                DataGridViewExport.OpenExcel(path);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            dt_tjxm = cxbbbiz.Get_pro_tj_tjxmjg(str_dwbh, str_bmbh, dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"), str_xmbm);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgv_tjxm.DataSource = dt_tjxm;
            pictureBox.Visible = false;
        }
    }
}

