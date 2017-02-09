using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.main;

namespace PEIS.cxgl
{
    public partial class Form_Tjz : PEIS.MdiChildrenForm
    {
        private DataTable dt = null;

        public Form_Tjz(DataTable table)
        {
            InitializeComponent();
            this.dt = table;            
        }

        private void Form_Tjz_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.listBox1.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            TongJiEntity.Tj = listBox1.Text.Trim();
            this.Close();
        }

       
    }
}