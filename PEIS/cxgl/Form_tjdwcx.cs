using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PEIS.cxgl
{
    public partial class Form_tjdwcx : MdiChildrenForm
    {
        private PEIS.tjjg.tjjgBiz tjjgBiz = new PEIS.tjjg.tjjgBiz();
        private DataTable dtTjdw;

        public Form_tjdwcx()
        {
            InitializeComponent();
        }

        void LoadDgvTjdw()
        {
            dtTjdw = new DataTable();
            dtTjdw = tjjgBiz.GetDwxxByCondition(cbxQy.Checked, txtZjm.Text.Trim());
            dgvTjdw.DataSource = dtTjdw;

        }

        private void Form_tjdwcx_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDgvTjdw();
        }

        private void txtZjm_TextChanged(object sender, EventArgs e)
        {
            LoadDgvTjdw();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}