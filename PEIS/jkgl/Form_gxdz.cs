using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    public partial class Form_gxdz : PEIS.MdiChildrenForm
    {
        public Form_gxdz()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_gx_Click(object sender, EventArgs e)
        {
            LisBiz lisbiz = new LisBiz();
            lisbiz.Exec_Gxdzm();
            MessageBox.Show("更新成功！");
        }
    }
}

