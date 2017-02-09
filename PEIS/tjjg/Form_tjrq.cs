using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjjg
{
    public partial class Form_tjrq : PEIS.MdiChildrenForm
    {
        public string str_tjrq;
        xtBiz xtbiz = new xtBiz();
        public Form_tjrq()
        {
            InitializeComponent();
        }

        private void Form_tjrq_Load(object sender, EventArgs e)
        {
            dtp_tjdjrq.Value = xtbiz.GetServerDate();
        }

        private void bt_qx_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            str_tjrq = dtp_tjdjrq.Value.ToString("yyyy-MM-dd");
            this.DialogResult = DialogResult.OK;
        }
    }
}

