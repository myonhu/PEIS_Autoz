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
                MessageBox.Show(ex.ToString(),"提示");
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void btn_exec_Click(object sender, EventArgs e)
        {
            #region 输入判断
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("请输入sql脚本!", "提示");
                return;
            }
            if (txt_user.Text == "")
            {
                MessageBox.Show("请先读取配置!", "提示");
                return;
            }
            //if (txt_pwd.Text == "")
            //{
            //    MessageBox.Show("请输入密码!", "提示");
            //    return;
            //}
            if (txt_ip.Text == "")
            {
                MessageBox.Show("请先读取配置!", "提示");
                return;
            }
            if (txt_db.Text == "")
            {
                MessageBox.Show("请先读取配置!", "提示");
                return;
            }
            #endregion

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上执行了sql脚本!IP：" + Program.hostip, Program.username);
            #endregion

            string str_sql = richTextBox1.Text.Trim();
            try
            {
                biz.ExecSql(str_sql);
                richTextBox2.Text = "执行脚本成功!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"异常提示");
                richTextBox2.Text = ex.ToString();
            }
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                MessageBox.Show("返回结果为空，不需要导出!", "提示");
                return;
            }


            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + ma.HostName() + "】上导出了执行脚本返回结果!IP：" + Program.hostip, Program.username);
            #endregion

            saveFileDialog1.Filter = "Word文档|*.doc|RTF文档|*.rtf";
            saveFileDialog1.Title = "执行脚本返回结果导出";
            this.saveFileDialog1.FileName = "执行脚本返回结果" + biz.GetServerDate().ToString("yyyy-MM-dd");
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
                MessageBox.Show("导出返回结果成功!路径:" + path, "提示");
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
 