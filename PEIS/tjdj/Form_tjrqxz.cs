using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjdj
{
    public partial class Form_tjrqxz : PEIS.MdiChildrenForm
    {
        public Form_tjrqxz()
        {
            InitializeComponent();
        }
        public string str_tjrq;

        xtBiz xtbiz = new xtBiz();
        private void bt_ok_Click(object sender, EventArgs e)
        {
            str_tjrq = dtp_tjdjrq.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(str_tjrq) > Convert.ToDateTime(Program.sys_jzzcrq))
            {
                MessageBox.Show("系统使用非法，程序将自动关闭，请联系销售人员：！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.sfzc = false;
                main.Form_reg frm_reg = new PEIS.main.Form_reg();
                frm_reg.ShowDialog();
            }
            Form_tjdj frm = new Form_tjdj(str_tjrq);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
            //this.DialogResult = DialogResult.OK;
        }

        private void Form_tjrqxz_Load(object sender, EventArgs e)
        {
            dtp_tjdjrq.Value = xtbiz.GetServerDate();
        }

        private void bt_qx_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

