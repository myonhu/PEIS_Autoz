using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjdj
{
    public partial class Form_tmqr : PEIS.MdiChildrenForm
    {

        public string str_return = "0";
        public string str_tjbh = "";
        public string str_tjcs = "";
        public string str_djlsh = "";
        private DataTable dt_tjdjb = null;
        public Form_tmqr(DataTable dt)
        {
            InitializeComponent();
            dt_tjdjb = dt;
        }

        private void bt_cancle_Click(object sender, EventArgs e)
        {
            str_return = "0";//取消
            this.DialogResult = DialogResult.OK;
        }

        private void bt_no_Click(object sender, EventArgs e)
        {
            str_return = "1";//不为同一人
            this.DialogResult = DialogResult.OK;
        }

        private void bt_yes_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in dgv_tjdjb.Rows)
            {
                if (dgr.Cells["selected"].Value.ToString().Trim() == "1")//同一人
                {
                    str_tjbh = dgr.Cells["tjbh"].Value.ToString().Trim();
                    str_tjcs = dgr.Cells["tjcs"].Value.ToString().Trim();
                    str_return = "2";
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }
            MessageBox.Show("请选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form_tmqr_Load(object sender, EventArgs e)
        {
            dgv_tjdjb.DataSource = dt_tjdjb;
        }
    }
}

