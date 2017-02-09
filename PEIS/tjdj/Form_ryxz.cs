using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjdj
{
    public partial class Form_ryxz : PEIS.MdiChildrenForm
    {

        public string str_tjbh = "";
        public string str_tjcs = "";
        public string str_sumover = "";
        private DataTable dt_tjdjb = null;
        public Form_ryxz(DataTable dt)
        {
            InitializeComponent();
            dt_tjdjb = dt;
        }

        private void Form_tmqr_Load(object sender, EventArgs e)
        {
            dgv_tjdjb.DataSource = dt_tjdjb;
        }

        private void dgv_tjdjb_DoubleClick(object sender, EventArgs e)
        {
            if (object.Equals(dgv_tjdjb.CurrentRow, null)) return;

            str_tjbh = dgv_tjdjb.CurrentRow.Cells["tjbh"].Value.ToString().Trim();
            str_tjcs = dgv_tjdjb.CurrentRow.Cells["tjcs"].Value.ToString().Trim();
            str_sumover = dgv_tjdjb.CurrentRow.Cells["tjcs"].Value.ToString().Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}

