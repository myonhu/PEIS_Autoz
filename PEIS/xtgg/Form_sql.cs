using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.main;
namespace PEIS.xtgg
{
    public partial class Form_sql : PEIS.MdiChildrenForm
    {
        public Form_sql()
        {
            InitializeComponent();
        }
        string strConn = "";
        loginBiz loginbiz = new loginBiz();
        MachineCode ma = new MachineCode();
        xtBiz biz = new xtBiz();
        private void btn_read_Click(object sender, EventArgs e)
        {
            try
            {
                //strConn = "server=192.168.167.222;database=PEIS;uid=sa;pwd=123";
            strConn = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            txt_ip.Text = strConn.Split(';')[0].ToString().Substring(7, strConn.Split(';')[0].ToString().Length-7);
            txt_db.Text = strConn.Split(';')[1].ToString().Substring(9,strConn.Split(';')[1].ToString().Length-9);
            txt_user.Text = strConn.Split(';')[2].ToString().Substring(4,strConn.Split(';')[2].ToString().Length-4);
            txt_pwd.Text = strConn.Split(';')[3].ToString().Substring(4,strConn.Split(';')[3].ToString().Length-4);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"��ʾ");
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void btn_exec_Click(object sender, EventArgs e)
        {
            #region �����ж�
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("������sql�ű�!", "��ʾ");
                return;
            }
            if (txt_user.Text == "")
            {
                MessageBox.Show("���ȶ�ȡ����!", "��ʾ");
                return;
            }
            //if (txt_pwd.Text == "")
            //{
            //    MessageBox.Show("����������!", "��ʾ");
            //    return;
            //}
            if (txt_ip.Text == "")
            {
                MessageBox.Show("���ȶ�ȡ����!", "��ʾ");
                return;
            }
            if (txt_db.Text == "")
            {
                MessageBox.Show("���ȶ�ȡ����!", "��ʾ");
                return;
            }
            #endregion

            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "����ִ����sql�ű�!IP��" + Program.hostip, Program.username);
            #endregion

            string str_sql = richTextBox1.Text.Trim();
            try
            {
                biz.ExecSql(str_sql);
                richTextBox2.Text = "ִ�нű��ɹ�!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"�쳣��ʾ");
                richTextBox2.Text = ex.ToString();
            }
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                MessageBox.Show("���ؽ��Ϊ�գ�����Ҫ����!", "��ʾ");
                return;
            }


            #region ��־��¼
            loginbiz.WriteLog(this.Name.Trim(), "��" + Program.username + "��" + "�ڵ��ԡ�" + ma.HostName() + "���ϵ�����ִ�нű����ؽ��!IP��" + Program.hostip, Program.username);
            #endregion

            saveFileDialog1.Filter = "Word�ĵ�|*.doc|RTF�ĵ�|*.rtf";
            saveFileDialog1.Title = "ִ�нű����ؽ������";
            this.saveFileDialog1.FileName = "ִ�нű����ؽ��" + biz.GetServerDate().ToString("yyyy-MM-dd");
            string path = string.Empty;
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                path = saveFileDialog1.FileName;
                try
                {
                    richTextBox2.SaveFile(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                MessageBox.Show("�������ؽ���ɹ�!·��:" + path, "��ʾ");
            }
        }

        private void Form_sql_Load(object sender, EventArgs e)
        {
            btn_read_Click(null, null);
        }

        private void btn_open_Click(object sender, EventArgs e)
        {

        }
    }
}
 