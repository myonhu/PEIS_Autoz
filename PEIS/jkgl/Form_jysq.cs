using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PEIS.jkgl
{
    public partial class Form_jysq : PEIS.MdiChildrenForm
    {
        LisBiz lisbiz = new LisBiz();
        DataTable dt = null;
        public Form_jysq()
        {
            InitializeComponent();
        }

        private void Form_jysq_Load(object sender, EventArgs e)
        {
            dtp_rq1.Value = Convert.ToDateTime(lisbiz.Get_ServerDate());
            dtp_rq2.Value = Convert.ToDateTime(lisbiz.Get_ServerDate());
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            int zt=0;
            if (cmb_zt.Text == "全部") zt = 0;
            if (cmb_zt.Text == "未登记") zt = 1;
            if (cmb_zt.Text == "已登记") zt = 2;
            string rq1 = dtp_rq1.Value.ToString("yyyyMMdd");
            string rq2 = dtp_rq2.Value.ToString("yyyyMMdd");
            dg_djry.DataSource = lisbiz.Get_TJ_TJDJB(zt, txt_djh.Text.Trim(), txt_xm.Text.Trim(), rq1, rq2);

            foreach (DataGridViewRow dgrow in dg_djry.Rows)
            {
                string sjcxxh = dgrow.Cells["sjcxxh"].Value.ToString();
                if (sjcxxh != "")
                {
                    dgrow.DefaultCellStyle.BackColor = Color.Violet;
                }
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_djry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //DataGridViewRow dgr = dg_djry.SelectedRows[0];
            ////string str_djlsh = dgr.Cells["djlsh"].Value.ToString();
            //string str_tjbh = dgr.Cells["tjbh"].Value.ToString();
            //string str_tjcs = dgr.Cells["tjcs"].Value.ToString();
            //dt = lisbiz.Get_TJ_BBDJB(str_tjbh, str_tjcs);
            //dg_djrymx.DataSource = dt;

            //foreach (DataGridViewRow dgrow in dg_djrymx.Rows)
            //{
            //    string djrq1 = dgrow.Cells["djrq1"].Value.ToString();
            //    if (djrq1 != "")
            //    {
            //        dgrow.DefaultCellStyle.BackColor = Color.Violet;
            //    }
            //}
        }

        private void bt_dj_Click(object sender, EventArgs e)
        {
            if (dg_djrymx.RowCount < 1 || dg_djry.RowCount < 1)
            {
                MessageBox.Show("请选择你要申请的人员信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dgr = dg_djry.CurrentRow;
            string djlsh = dgr.Cells["djlsh"].Value.ToString();
            string tjbh = dgr.Cells["tjbh"].Value.ToString();
            string tjcs = dgr.Cells["tjcs"].Value.ToString();

            string result = lisbiz.Exec_Proc_LisApply(djlsh, tjbh, Program.username, tjcs);
            if (result == "1")
            {
                MessageBox.Show("申请成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dg_djry.Rows.Remove(dgr);
                if (dg_djry.Rows.Count>0)
                {
                    dg_djry.CurrentCell=dg_djry.Rows[0].Cells[0];
                }
                //dt.Rows.Clear();
            }
            else if (result=="2")
            {
                MessageBox.Show("该人员已经申请登记了！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("申请失败，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_alldj_Click(object sender, EventArgs e)
        {
            if (dg_djry.Rows.Count < 1)
            {
                MessageBox.Show("没有需要申请LIS的人员信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pgb1.Maximum = dg_djry.Rows.Count;
            pgb1.Value = 0;
            foreach (DataGridViewRow dgr in dg_djry.Rows)
            {
                string djlsh = dgr.Cells["djlsh"].Value.ToString();
                string tjbh = dgr.Cells["tjbh"].Value.ToString();
                string tjcs = dgr.Cells["tjcs"].Value.ToString();

                string result = lisbiz.Exec_Proc_LisApply(djlsh, tjbh, Program.username, tjcs);
                if (result == "2")
                {
                    MessageBox.Show("登记流水号：【" + djlsh + "】已经申请登记了！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (result == "0")
                {
                    MessageBox.Show("登记流水号：【"+djlsh+"】申请失败，请重新申请！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                pgb1.Value = pgb1.Value + 1;
            }
            bt_search_Click(null, null);
            pgb1.Value = 0;
            if (!object.Equals(dt, null))
            {
                dt.Rows.Clear();
            }
            MessageBox.Show("批量申请处理完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dg_djry_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_djry.SelectedRows.Count<=0) return;
            DataGridViewRow dgr = dg_djry.SelectedRows[0];
            //string str_djlsh = dgr.Cells["djlsh"].Value.ToString();
            string str_tjbh = dgr.Cells["tjbh"].Value.ToString();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString();
            dt = lisbiz.Get_TJ_BBDJB(str_tjbh, str_tjcs);
            dg_djrymx.DataSource = dt;

            foreach (DataGridViewRow dgrow in dg_djrymx.Rows)
            {
                string djrq1 = dgrow.Cells["djrq1"].Value.ToString();
                if (djrq1 != "")
                {
                    dgrow.DefaultCellStyle.BackColor = Color.Violet;
                }
            }
        }

        private void dg_djrymx_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_djrymx.SelectedRows.Count<=0)
            {
                return;
            }

            DataGridViewRow dgr = dg_djrymx.SelectedRows[0];
            string zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();
            DataTable dt = new DataTable();
            dt = lisbiz.GetXmmx(zhxm);
            dgvXmmx.DataSource = dt;
        }

        private void dg_djry_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dg_djry_SelectionChanged(null, null);
        }

        private void txt_djh_Leave(object sender, EventArgs e)
        {
            txt_djh.Text = new Common.Common().CharConverter(txt_djh.Text.Trim());
        }
    }
}

