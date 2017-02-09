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
    public partial class Form_tjzcqd : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        cxbbBiz cxbbbiz = new cxbbBiz();
        public Form_tjzcqd()
        {
            InitializeComponent();
        }

        private void Form_yxjghz_Load(object sender, EventArgs e)
        {
            dtp_begin.Value = xtbiz.GetServerDate();
            dtp_end.Value = dtp_begin.Value;

            cmb_rylx.DataSource = xtbiz.GetXtZd(8);//人员类别
            cmb_rylx.DisplayMember = "xmmc";
            cmb_rylx.ValueMember = "bzdm";
            cmb_rylx.SelectedIndex = -1;

            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
            cmb_xb.SelectedIndex = -1;

            cmb_gz.DataSource = xtbiz.GetXtZd(19);//工种
            cmb_gz.DisplayMember = "xmmc";
            cmb_gz.ValueMember = "bzdm";
            cmb_gz.SelectedIndex = -1;

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
            string str_xb = "%";
            if (!object.Equals(null, cmb_xb.SelectedValue)) str_xb = cmb_xb.SelectedValue.ToString().Trim();
            string str_rylb = "";
            if (!object.Equals(null, cmb_rylx.SelectedValue)) str_rylb = cmb_rylx.SelectedValue.ToString().Trim();
            string str_gz = "";
            if (!object.Equals(null, cmb_gz.Text.Trim())) str_gz = cmb_gz.Text.Trim();


            DataTable dt1 = cxbbbiz.Get_pro_tj_tjzcqd(str_dwbh, str_bmbh, dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"),
                str_rylb, str_xb,str_gz);

            reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlcreport/Report_tjzcqd.rdlc";
            reportView.LocalReport.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("tjdw", txt_tjdw.Text.Trim());
            ReportParameter rp2 = new ReportParameter("begin", dtp_begin.Value.ToString("yyyy-MM-dd"));
            ReportParameter rp3 = new ReportParameter("end", dtp_end.Value.ToString("yyyy-MM-dd"));
            ReportParameter rp4 = new ReportParameter("czy", Program.username);
            ReportParameter rp5 = new ReportParameter("bbmc", Program.reg_dwmc);
            ReportParameter rp6 = new ReportParameter("gz", str_gz);
            reportView.LocalReport.DataSources.Clear();
            reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 ,rp4 ,rp5,rp6});
            reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_tj_tjzcqd", dt1));
            //reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_v_tj_tjdjb", dt2));
            reportView.RefreshReport();

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

