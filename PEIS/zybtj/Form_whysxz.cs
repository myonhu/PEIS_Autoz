using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.zybtj
{
    public partial class Form_whysxz : PEIS.MdiChildrenForm
    {
        public Form_whysxz()
        {
            InitializeComponent();
        }
        public string str_zdxmmc = "";
        public string str_bh = "";
        xtBiz biz = new xtBiz();
        private void Form_zjjl_zdjy_Load(object sender, EventArgs e)
        {
            DataTable dt = biz.GetXtZd(20);
            dataGridView1.DataSource = dt;
            this.ActiveControl = txt_mc;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            str_zdxmmc = dataGridView1.CurrentRow.Cells["xmmc"].Value.ToString();
            str_bh = dataGridView1.CurrentRow.Cells["bzdm"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cx_Click(object sender, EventArgs e)
        {
            DataTable dt = biz.GetXtZd(20);
            dataGridView1.DataSource = dt;
        }
    }
}

