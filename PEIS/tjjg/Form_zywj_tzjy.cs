using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjjg
{
    public partial class Form_zywj_tzjy
    {
        string str_tjbh = "";
        string str_tjcs = "";
        string str_tzjl = "";
        tjjgBiz tjjgbiz = new tjjgBiz();
        public Form_zywj_tzjy(string tjbh, string tjcs, string tzjl)
        {
            InitializeComponent();
            str_tjbh = tjbh;
            str_tjcs = tjcs;
            str_tzjl = tzjl;
            this.Text = "【" + str_tzjl + "】的体质建议为：";
        }

        private void Form_zywj_tzjy_Load(object sender, EventArgs e)
        {
            richTextBox.AppendText(tjjgbiz.Get_v_tj_zyjgb(str_tjbh, str_tjcs).Rows[0]["体质建议"].ToString());
            richTextBox.SelectionStart = 0;
        }
    }
}

