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
                MessageBox.Show("ԭ���벻��Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_xmm.Text == "" || object.Equals(txt_xmm.Text, null))
            {
                MessageBox.Show("�����벻��Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_qrmm.Text.Trim()!=txt_xmm.Text.Trim())
            {
                MessageBox.Show("ȷ������������벻һ�£�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_ymm.Text.Trim() != Program.password)
            {
                MessageBox.Show("ԭ�����������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #region ��־��¼
                loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϳ����޸�����ʧ��!IP��" + Program.hostip, Program.username);
                #endregion
                return;
            }
            loginbiz.UpdatePsd(Program.userid, txt_xmm.Text.Trim());
            Program.password = txt_xmm.Text.Trim();
            MessageBox.Show("�����޸ĳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" +Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "�����޸�����ɹ�!IP��" + Program.hostip, Program.username);
            #endregion

        }
    }
}

