using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.main;
namespace PEIS
{
    public partial class Form_error : PEIS.MdiChildrenForm
    {
        private string str_text;
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();
        public Form_error()
        {
            InitializeComponent();
        }
        public Form_error(string text)
        {
            InitializeComponent();
            str_text = text;
        }
        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_jx_Click(object sender, EventArgs e)
        {
            //bt_fs_Click(null, null);
            this.Close();
        }

        private void bt_fs_Click(object sender, EventArgs e)
        {
            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上操作时出现系统错误，内容是：" + txt_error.Text.Trim() + "!IP：" + Program.hostip, Program.username);
            #endregion
            //MessageBox.Show("系统已经记录该错误，请关闭程序重试！\n如果仍有问题，请及时通知管理员，与软件公司联系!", "提示");
            this.Close();
        }

        private void Form_error_Load(object sender, EventArgs e)
        {
            if (str_text.Trim().Length > 0)
            {
                txt_error.Text = str_text;
            }
        }
    }
}

