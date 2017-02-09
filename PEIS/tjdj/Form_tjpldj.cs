using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjdj
{
    public partial class Form_tjpldj : PEIS.MdiChildrenForm
    {
        tjdjBiz tjdjbiz = new tjdjBiz();
        public Form_tjpldj()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_next_Click(object sender, EventArgs e)
        {
            if (rb_excel.Checked)
            {
                Form_excel frm = new Form_excel();
                frm.ShowDialog();
                this.Close();
            }
            if (rb_lsjl.Checked)
            {
                Form_lsjl frm = new Form_lsjl();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void Form_tjpldj_Load(object sender, EventArgs e)
        {
            if (!Program.sfzc)//没有注册
            {
                if (tjdjbiz.GetTjCounts() > 300)
                {
                    MessageBox.Show("软件试用期已到，请联系供应商：！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
        }
    }
}

