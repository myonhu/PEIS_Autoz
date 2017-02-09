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
    public partial class Form_jbrstj : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        cxbbBiz cxbbbiz = new cxbbBiz();
        public Form_jbrstj()
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
            if (lv_yxjb.Items.Count < 1)
            {
                MessageBox.Show("请选择需要统计的疾病项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = lv_wxjb;
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
            string str_jbbh = "";
            foreach (ListViewItem item in lv_yxjb.Items)
            {
                str_jbbh = str_jbbh + "," + item.Tag.ToString().Trim() + "";
            }
            str_jbbh = str_jbbh.Substring(1, str_jbbh.Length - 1);
            
            DataTable dt1 = cxbbbiz.Get_pro_tj_jbrstj(str_dwbh, str_bmbh, dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"),
                str_rylb, str_xb, str_jbbh);

            reportView.LocalReport.ReportPath = Application.StartupPath + @"/rdlc/Report_jbrstj.rdlc";
            reportView.LocalReport.EnableExternalImages = true;
            ReportParameter rp1 = new ReportParameter("tjdw", txt_tjdw.Text.Trim());
            ReportParameter rp2 = new ReportParameter("begin", dtp_begin.Value.ToString("yyyy-MM-dd"));
            ReportParameter rp3 = new ReportParameter("end", dtp_end.Value.ToString("yyyy-MM-dd"));
            ReportParameter rp4 = new ReportParameter("czy", Program.username);
            ReportParameter rp5 = new ReportParameter("bbmc", Program.reg_dwmc);
            reportView.LocalReport.DataSources.Clear();
            reportView.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3 ,rp4 ,rp5});
            reportView.LocalReport.DataSources.Add(new ReportDataSource("PEISDataSet_tj_jbrstj", dt1));
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

        private void rb_mb_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_mb.Checked)
            {
                lv_wxjb.Items.Clear();
                lv_yxjb.Items.Clear();

                DataTable dt_TJ_JBMB_HD = cxbbbiz.Get_TJ_JBMB_HD();
                foreach (DataRow dr in dt_TJ_JBMB_HD.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = dr["bh"].ToString().Trim();
                    item.Text = dr["mbmc"].ToString().Trim();
                    lv_wxjb.Items.Add(item);
                }
            }
        }

        private void rb_dx_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_dx.Checked)
            {
                lv_wxjb.Items.Clear();
                lv_yxjb.Items.Clear();

                DataTable dt_TJ_SUGGESTION = cxbbbiz.Get_TJ_SUGGESTION();
                foreach (DataRow dr in dt_TJ_SUGGESTION.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = dr["bh"].ToString().Trim();
                    item.Text = dr["keyword"].ToString().Trim();
                    lv_wxjb.Items.Add(item);
                }
            }
        }

        private void lv_wxjb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lv_wxjb.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;
            if (rb_mb.Checked)
            {
                lv_yxjb.Items.Clear();//换模板时情况数据
                DataTable dt_TJ_JBMB_DT = cxbbbiz.Get_TJ_JBMB_DT(item.Tag.ToString().Trim());
                foreach (DataRow dr in dt_TJ_JBMB_DT.Rows)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.Tag = dr["jbbh"].ToString().Trim();
                    item1.Text = dr["keyword"].ToString().Trim();
                    lv_yxjb.Items.Add(item1);
                }
            }
            else
            {
                ListViewItem item1 = new ListViewItem();
                item1.Tag = item.Tag;
                item1.Text = item.Text;
                lv_yxjb.Items.Add(item1);
                lv_wxjb.Items.Remove(item);
            }
        }

        private void lv_yxjb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = lv_yxjb.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;
            lv_yxjb.Items.Remove(item);
        }
    }
}

