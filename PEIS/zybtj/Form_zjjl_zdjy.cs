using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.zybtj
{
    public partial class Form_zjjl_zdjy : PEIS.MdiChildrenForm
    {
        public Form_zjjl_zdjy(string str_xmmc)
        {
            InitializeComponent();
            zdxmmc = str_xmmc;
        }
        ZyjkdaBiz zyjk = new ZyjkdaBiz();
        string zdxmmc="";
        public string str_zdxmmc = "";
        private void Form_zjjl_zdjy_Load(object sender, EventArgs e)
        {
            DataTable dt = zyjk.GetZybZdyj();
            dataGridView1.DataSource = dt;
            this.ActiveControl = txt_mc;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            str_zdxmmc = dataGridView1.CurrentRow.Cells["xmmc"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cx_Click(object sender, EventArgs e)
        {
            DataTable dt = zyjk.GetZybZdyj(txt_mc.Text.Trim());
            dataGridView1.DataSource = dt;
        }
    }
}

