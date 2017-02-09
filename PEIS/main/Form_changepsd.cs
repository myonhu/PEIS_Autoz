using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.main
{
    public partial class Form_changepsd : PEIS.MdiChildrenForm
    {
        public Form_changepsd()
        {
            InitializeComponent();
        }
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Ok_Click(object sender, EventArgs e)
        {
            if (txt_ymm.Text == "" || object.Equals(txt_ymm.Text, null))
            {
                MessageBox.Show("原密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_xmm.Text == "" || object.Equals(txt_xmm.Text, null))
            {
                MessageBox.Show("现密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_qrmm.Text.Trim()!=txt_xmm.Text.Trim())
            {
                MessageBox.Show("确认密码和新密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_ymm.Text.Trim() != Program.password)
            {
                MessageBox.Show("原密码输入错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #region 日志记录
                loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上尝试修改密码失败!IP：" + Program.hostip, Program.username);
                #endregion
                return;
            }
            loginbiz.UpdatePsd(Program.userid, txt_xmm.Text.Trim());
            Program.password = txt_xmm.Text.Trim();
            MessageBox.Show("密码修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" +Program.username + "】" + "在电脑【" + ma.HostName() + "】上修改密码成功!IP：" + Program.hostip, Program.username);
            #endregion

        }
    }
}

