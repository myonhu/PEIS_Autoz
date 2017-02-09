using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.tjjg;
using PEIS.main;
using Encrypt;

namespace PEIS
{
    public partial class Form_login_zypc : Form
    {
        xtBiz xtbiz = new xtBiz();
        xtggBiz xtggbiz = new xtggBiz();
        loginBiz loginbiz = new loginBiz();
        Jiami jm = new Jiami();
        Rijndael_ rijndael_ = new Rijndael_();
        public Form_login_zypc()
        {
            InitializeComponent();
        }

        private void Form_login_zypc_Load(object sender, EventArgs e)
        {
            string str_tjdw = xtbiz.GetXtCsz("TjDwMc");//单位名称
            Program.reg_dwmc = str_tjdw;
            Program.sfzc = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PEIS.tjjg.Form_zywj frm = new PEIS.tjjg.Form_zywj();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PEIS.tjjg.Form_tjbg frm = new PEIS.tjjg.Form_tjbg();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();
        }
    }
}
