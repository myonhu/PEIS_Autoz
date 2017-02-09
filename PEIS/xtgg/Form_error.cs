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
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϲ���ʱ����ϵͳ���������ǣ�" + txt_error.Text.Trim() + "!IP��" + Program.hostip, Program.username);
            #endregion
            //MessageBox.Show("ϵͳ�Ѿ���¼�ô�����رճ������ԣ�\n����������⣬�뼰ʱ֪ͨ����Ա���������˾��ϵ!", "��ʾ");
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

