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
    public partial class Form_zyb_plbgdy : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        rdlcBiz rdlcbiz = new rdlcBiz();
        string str_tjdw = "";
        string str_dwdh = "";
        
        public Form_zyb_plbgdy()
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

            string str_xb = "%";
            if (!object.Equals(null, cmb_xb.SelectedValue)) str_xb = cmb_xb.SelectedValue.ToString().Trim();

            string str_zjzt = "0";
            if(cmb_zjzt.Text=="已总检")
            {
                str_zjzt = "2";
            }
            else if(cmb_zjzt.Text=="未总检")
            {
                str_zjzt = "1";
            }
            else//全部
            {
                str_zjzt = "0";
            }
            dgv_tjdjb.DataSource = tjdjbiz.Get_TJ_TJDJB(dtp_begin.Value.ToString("yyyy-MM-dd"), dtp_end.Value.ToString("yyyy-MM-dd"), txt_tjbh1.Text.Trim(), txt_tjbh2.Text.Trim(), txt_xm.Text.Trim(),str_xb, str_dwbh, str_bmbh, str_zjzt);
            ChargeColor();
        }
        void ChargeColor()
        {
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                string str_sumover = dgr.Cells["sumover"].Value.ToString().Trim();
                if (str_sumover == "0") dgr.DefaultCellStyle.BackColor = Color.White;//未检
                if (str_sumover == "1") dgr.DefaultCellStyle.BackColor = Color.Green;//已检
                if (str_sumover == "2") dgr.DefaultCellStyle.BackColor = Color.Red;//总检
            }
        }

        private void Form_tjbg_Load(object sender, EventArgs e)
        {
            txt_tjdw.Tag = "";

            str_tjdw = xtbiz.GetXtCsz("TjDwMc");
            str_dwdh = xtbiz.GetXtCsz("TjDwDh");

            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
            cmb_xb.SelectedValue = "%";

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

            DataGridViewRow dgr = dgv_tjdjb.CurrentRow;
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            string str_djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();
             

            RdlcPrint print = new RdlcPrint();
            print.PrintJkda(str_tjbh, str_tjcs, str_djlsh,txt_zxym.Text.Trim());
            

        }

        private void bt_allprint_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_tjdjb.CurrentRow)) return;
            if (dgv_tjdjb.Rows.Count < 1) return;
            foreach (DataGridViewRow  dgr in dgv_tjdjb.Rows)
            {
                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")
                {
                    string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    string str_djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();

                    RdlcPrint print = new RdlcPrint();
                    print.PrintJkda(str_tjbh, str_tjcs, str_djlsh,txt_zxym.Text.Trim());
                }
            }
        }

        private void dgv_tjdjb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv_tjdjb.Rows.Count < 1) return;

            DataGridViewRow dgr = dgv_tjdjb.CurrentRow;
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
            string str_djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();

            Form_reportZYJKTJBG frm = new Form_reportZYJKTJBG(str_tjbh, str_tjcs, str_djlsh);
            frm.ShowDialog();
        }
    }
}

