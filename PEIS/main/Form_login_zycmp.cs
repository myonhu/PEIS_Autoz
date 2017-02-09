using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.tjjg;
using PEIS.tjdj;
using PEIS.main;
using Encrypt;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PEIS
{
    public partial class Form_login_zycmp : Form
    {
        xtBiz xtbiz = new xtBiz();
        xtggBiz xtggbiz = new xtggBiz();
        loginBiz loginbiz = new loginBiz();
        Jiami jm = new Jiami();
        Rijndael_ rijndael_ = new Rijndael_();
        tjjgBiz tjjgbiz = new tjjgBiz();

        public Form_login_zycmp()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach (Control control in textNumberControl.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    txt_kl.Text = control.Text;
                }
            }
            //Form_zywj_out frm = new Form_zywj_out();
            if (txt_kl.Text.Trim() == "")
            {
                MessageBox.Show("请输入口令！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_kl;
                return;
            }

            DataTable dt_TJ_TJDJB = tjjgbiz.Get_TJ_TJDJB(txt_kl.Text.Trim());
            if (dt_TJ_TJDJB.Rows.Count != 1)
            {
                MessageBox.Show("口令输入有误，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_kl;
                txt_kl.SelectAll();
                return;
            }

            string tjbh = dt_TJ_TJDJB.Rows[0]["tjbh"].ToString();
            string tjcs = dt_TJ_TJDJB.Rows[0]["tjcs"].ToString();
            string sumover = dt_TJ_TJDJB.Rows[0]["sumover"].ToString();
            string dycs = dt_TJ_TJDJB.Rows[0]["dycs"].ToString();
            PEIS.tjjg.Form_zywj_out frm = new PEIS.tjjg.Form_zywj_out("CMP", tjbh, tjcs, sumover, dycs);
            frm.ShowDialog();
            //this.Hide();
            txt_kl.Text = "";
            foreach (Control control in textNumberControl.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    control.Text = "";
                }
            }
        }

        private void Form_login_zycmp_Load(object sender, EventArgs e)
        {
            string str_tjdw = xtbiz.GetXtCsz("TjDwMc");//单位名称
            Program.reg_dwmc = str_tjdw;
            Program.sfzc = true;

        }

        private void txt_kl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox2_Click(null, null);
            }
        }
    }
}
