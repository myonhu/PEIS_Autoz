using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjdj
{
    public partial class Form_tjdw1 : PEIS.MdiChildrenForm
    {
        public string str_tjdwid="";//ID
        public string str_tjdwmc="";//Ãû³Æ
        private DataTable dt_tjdw = null;

        public Form_tjdw1(DataTable dt)
        {
            InitializeComponent();
            dt_tjdw = dt;
        }

        private void Form_tmqr_Load(object sender, EventArgs e)
        {
            dgv_tjdw.DataSource = dt_tjdw;
        }

        private void dgv_tjdw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            str_tjdwid = dgv_tjdw.CurrentRow.Cells["bh"].Value.ToString();
            str_tjdwmc = dgv_tjdw.CurrentRow.Cells["mc"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}

