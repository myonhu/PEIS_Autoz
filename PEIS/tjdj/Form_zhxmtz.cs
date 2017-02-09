using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PEIS.xtgg;
using PEIS.ywsz;

namespace PEIS.tjdj
{
    public partial class Form_zhxmtz : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();

        public Form_zhxmtz()
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
            if (!object.Equals(null, dgv_tjdjb.CurrentRow))
            {
                BindYxzhxm(dgv_tjdjb.CurrentRow);
            }
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

        private void dgv_tjdjb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dgr = dgv_tjdjb.CurrentRow;
            BindYxzhxm(dgr);
        }
        private void BindYxzhxm(DataGridViewRow dgr)//已选组合项目
        {
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();

            lv_yxxm.Items.Clear();
            new Common.Common().AddImages(imageList1);
            lv_yxxm.SmallImageList = imageList1;
            lv_yxxm.StateImageList = imageList1;
            lv_yxxm.LargeImageList = imageList1;

            DataTable dt_tj_tjjlb = tjdjbiz.Get_dt_tj_tjjlb(str_tjbh, str_tjcs);
            foreach (DataRow dr in dt_tj_tjjlb.Rows)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = dr["zhxm"].ToString().Trim();
                item.Text = dr["mc"].ToString().Trim();
                item.ImageIndex = 4;
                lv_yxxm.Items.Add(item);
            }
        }

        private void bt_zhxm_Click(object sender, EventArgs e)
        {
            Form_zhxmxz frm = new Form_zhxmxz();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_zhxm.Tag = frm.str_bh;
                txt_zhxm.Text = frm.str_mc;
            }
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            if (dgv_tjdjb.Rows.Count < 1) return;

            if (txt_zhxm.Text.Trim() == "")
            {
                MessageBox.Show("请选择组合项目名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_zhxm;
                return;
            }
            bool exists = false;//是否选择了人员
            tjdjBiz tjdjbiz1 = new tjdjBiz();
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")
                {
                    exists = true;
                    string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    string str_tjrq = dgr.Cells["tjrq"].Value.ToString().Trim();
                    string str_sumover = dgr.Cells["sumover"].Value.ToString().Trim();
                    if (str_sumover == "2")//总检
                    {
                        MessageBox.Show("体检编号为：【" + str_tjbh + "】的人员已经总检，不允许调整项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    if (tjdjbiz1.Existes_tj_tjjlb(str_tjbh, str_tjcs, txt_zhxm.Tag.ToString().Trim())) //是否存在该组合项目ID
                    {
                        MessageBox.Show("体检编号为：【" + str_tjbh + "】的人员已存在该体检项目，不允许重复添加该项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    DataTable dt_tj_zhxm_hd = tjdjbiz.Get_tj_zhxm_hd(txt_zhxm.Tag.ToString().Trim());
                    string str_xh = xtbiz.GetHmz("tjjlbxh", 1);//体检记录本序号
                    string str_lxbh = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_tjxmbh = dt_tj_zhxm_hd.Rows[0]["bh"].ToString().Trim();
                    string str_xmdj = dt_tj_zhxm_hd.Rows[0]["dj"].ToString().Trim();
                    string str_zxks = dt_tj_zhxm_hd.Rows[0]["tjlx"].ToString().Trim();
                    string str_xmlx = dt_tj_zhxm_hd.Rows[0]["jcjylx"].ToString().Trim();
                    string str_sflb = dt_tj_zhxm_hd.Rows[0]["sflb"].ToString().Trim();
                    tjdjbiz1.str_Insert_tj_tjjlb(str_xh, str_tjbh, str_tjcs, str_lxbh, str_tjrq, str_tjxmbh, str_xmdj, "0", "1", str_sflb, str_zxks, str_xmlx);
                }
            }
            if (!exists)//没有选择人员
                return;
            tjdjbiz1.Exec_ArryList();
            MessageBox.Show("批量调整成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!object.Equals(null, dgv_tjdjb.CurrentRow))
            {
                BindYxzhxm(dgv_tjdjb.CurrentRow);
            }
            txt_zhxm.Text = "";
            txt_zhxm.Tag = "";
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (dgv_tjdjb.Rows.Count < 1) return;

            if (txt_zhxm.Text.Trim() == "")
            {
                MessageBox.Show("请选择组合项目名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_zhxm;
                return;
            }
            bool exists = false;//是否选择了人员
            tjdjBiz tjdjbiz1 = new tjdjBiz();
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")
                {
                    exists = true;
                    string str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    string str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    //string str_djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();
                    string str_sumover = dgr.Cells["sumover"].Value.ToString().Trim();
                    if (str_sumover == "2")//总检
                    {
                        MessageBox.Show("体检编号为：【" + str_tjbh + "】的人员已经总检，不允许调整项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    tjdjbiz1.str_Delete_tj_tjjlb(str_tjbh, str_tjcs, txt_zhxm.Tag.ToString().Trim());
                }
            }
            if (!exists)//没有选择人员
                return;
            tjdjbiz1.Exec_ArryList();
            MessageBox.Show("批量调整成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!object.Equals(null, dgv_tjdjb.CurrentRow))
            {
                BindYxzhxm(dgv_tjdjb.CurrentRow);
            }
            txt_zhxm.Text = "";
            txt_zhxm.Tag = "";
        }
    }
}

