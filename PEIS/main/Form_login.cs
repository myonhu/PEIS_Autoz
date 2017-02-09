using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Encrypt;
using PEIS.main;

namespace PEIS
{
    public partial class Form_login : MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        xtggBiz xtggbiz = new xtggBiz();
        Rijndael_ rijndael_ = new Rijndael_();
        Jiami jm = new Jiami();
        MachineCode ma = new MachineCode();
        loginBiz loginbiz = new loginBiz();
        string str_tjdw = "";//单位名称
        public Form_login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 赋值系统共用参数
        /// </summary>
        private void BindData()
        {
            DataTable dt = new DataTable();
            dt = loginbiz.GetCzyInfo(txt_username.Text.Trim());

            //ksid
            Program.czybm = dt.Rows[0]["czybm"].ToString();
            Program.czylx = dt.Rows[0]["rysx"].ToString().Trim();
            Program.username = dt.Rows[0]["czymc"].ToString().Trim();
            Program.userid = dt.Rows[0]["czyid"].ToString().Trim();
            Program.password = dt.Rows[0]["mm"].ToString();
            Program.yhzid = Convert.ToInt32(dt.Rows[0]["yhzid"]);
            Program.ksid = dt.Rows[0]["ksid"].ToString();
            //Program.ksmc = dt.Rows[0]["ksmc"].ToString().Trim();
            //Program.kssx = dt.Rows[0]["kssx"].ToString().Trim();
            Program.yljgmc = xtbiz.GetXtCsz("TjDwMc");
            Program.hostname = ma.HostName();                         //主机名
            Program.hostip = GetIP();                                 //IP
        }

        //获取IP:多IP处理
        private string GetIP()
        {
            string strIP = "";
            List<string> sql = new List<string>();
            sql = ma.GetIPList();
            if (sql.Count > 0)
            {
                for (int i = 0; i < sql.Count; i++)
                {
                    strIP = strIP + sql[i].ToString() + " ";
                }
            }
            return strIP;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" || object.Equals(txt_username.Text, null))
            {
                MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dt = new DataTable();
            dt = loginbiz.GetNewsList(txt_username.Text.Trim());
            if (object.Equals(dt, null)) return;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("该用户不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            str_tjdw = xtbiz.GetXtCsz("TjDwMc");//单位名称
            if (txt_password.Text == dt.Rows[0][2].ToString().Trim())
            {
                #region 注册判断
                Program.sys_jzzcrq = "2099-12-30";
                Program.sfzc = true;
                #endregion

                #region 全局单位名称赋值
                if (Program.sfzc)
                {
                    Program.reg_dwmc = str_tjdw;
                    Program.sys_reportname = Program.reg_dwmc;
                }
                else
                {
                    Program.reg_dwmc = "未注册单位";
                }
                #endregion

                MainForm frmmain = new MainForm();
                BindData();

                #region 日志记录
                loginbiz.WriteLog(this.Name.Trim(), "【" + txt_username.Text.Trim() + "】" + "在电脑【" + ma.HostName() + "】上登录成功!IP：" + Program.hostip, Program.username);
                #endregion

                //加载主窗体
                frmmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region 日志记录
                loginbiz.WriteLog(this.Name.Trim(), "【" + txt_username.Text.Trim() + "】" + "在电脑【" + ma.HostName() + "】上输入密码错误，登录失败!IP：" + Program.hostip, Program.username);
                #endregion

                txt_password.Text = "";
                txt_password.Focus();
            }
        }

        private void Form_login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txt_username.Text.Trim() == "")
            {
                loginbiz.WriteLog(this.Name.Trim(), "未知用户在电脑【" + ma.HostName() + "】" + "上打开登录窗口，什么没有做，退出了系统!该电脑IP:" + Program.hostip + ",物理地址是：" + ma.GetMoAddress(), Program.username);
            }
            Application.Exit();
        }
        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                bt_ok_Click(sender, e);
            }
        }

        private void Form_login_Load(object sender, EventArgs e)
        {
            string xtxsmc = xtbiz.GetXtCsz("Xtdlxsmc");
            if (xtxsmc.Trim() == "" || xtxsmc == null)
            {
                xtxsmc = "体检管理信息平台";
            }

            try
            {
                string path = Application.StartupPath + @"\" + System.Configuration.ConfigurationManager.AppSettings["skinpath"].ToString();
                skinEngine1.SkinFile = path;
            }
            catch
            {
                skinEngine1.Active = false;
            }
        }

    }
}