using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Encrypt;

namespace PEIS.main
{
    public partial class Form_reg : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        MachineCode machine = new MachineCode();
        xtggBiz xtggbiz = new xtggBiz();
        Jiami jm = new Jiami();
        Rijndael_ rijndael_ = new Rijndael_();
        loginBiz loginbiz = new loginBiz();
        public Form_reg()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            if (Program.sfzc)
            {
                this.Close();
            }
            else
            {
                Application.Exit();
            }
            //this.Close();
        }

        private void bt_reg_Click(object sender, EventArgs e)
        {
            if (txt_yhmc.Text.Trim() == "")
            {
                MessageBox.Show("请填写用户名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_yhmc;
                return;
            }
            if (txt_zcm.Text.Trim() == "")
            {
                MessageBox.Show("请填写注册码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_zcm;
                return;
            }

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + machine.HostName() + "】上尝试了系统注册!IP：" + Program.hostip, Program.username);
            #endregion

            string str_code = "";
            try
            {
                //str_code = rijndael_.Decrypt(txt_zcm.Text);
                str_code = jm.DecryptDES(txt_zcm.Text, "@xxsoft@");
            }
            catch
            {
 
            }
            if (str_code.Split('|')[0] != txt_jqm.Text.Trim())//机器码
            {
                MessageBox.Show("注册码错误，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_zcm;
                return;
            }
            if (str_code.Split('|')[1] != txt_yhmc.Text.Trim())//医院名称
            {
                MessageBox.Show("注册码错误，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_zcm;
                return;
            }
            xtggbiz.Insert_Reg(txt_zcm.Text.Trim(), txt_jqm.Text.Trim(), txt_yhmc.Text.Trim());

            MessageBox.Show("注册成功，请重新启动系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #region 日志记录
            loginbiz.WriteLog(this.Name.Trim(), "【" + Program.username + "】" + "在电脑【" + machine.HostName() + "】上成功进行了系统注册!IP：" + Program.hostip, Program.username);
            #endregion
        }

        private void Form_reg_Load(object sender, EventArgs e)
        {
            txt_jqm.Text = machine.GetCpuInfo();
            DataTable dt_xt_reg = xtggbiz.Get_xt_reg();
            if (dt_xt_reg.Rows.Count < 1) return;
            string str_code = dt_xt_reg.Rows[0]["reg"].ToString().Trim();
            try
            {
                //str_code = rijndael_.Decrypt(str_code);
                str_code = jm.DecryptDES(str_code, "@xxsoft@");
                txt_yhmc1.Text = str_code.Split('|')[1];
                txt_jzrq.Text = str_code.Split('|')[3];
                txt_yhsl.Text = str_code.Split('|')[2];
            }
            catch
            {
                //MessageBox.Show("系统注册码异常，请联系供应商：！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.sfzc = false;
                txt_yhmc1.Text = xtbiz.GetXtCsz("TjDwMc");//单位名称
                //Application.Exit();
            }
        }

        private void Form_reg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.sfzc)
            {
                this.Dispose();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}

