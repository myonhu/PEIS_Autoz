using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Configuration;

namespace PEIS.xtgg
{
    public partial class Form_dbc : PEIS.MdiChildrenForm
    {
        public Form_dbc()
        {
            InitializeComponent();
        }
        loginBiz log = new loginBiz();
        ConnectionTestInfo test = new ConnectionTestInfo();
        string constr = "";
        string strConn = "";
        bool result = false;
        xtBiz biz = new xtBiz();
        private void Form_dbc_Load(object sender, EventArgs e)
        {
            try
            {
                strConn = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
                txt_server.Text = strConn.Split(';')[0].ToString().Substring(7, strConn.Split(';')[0].ToString().Length - 7);
                txt_dbname.Text = strConn.Split(';')[1].ToString().Substring(9, strConn.Split(';')[1].ToString().Length - 9);
                txt_user.Text = strConn.Split(';')[2].ToString().Substring(4, strConn.Split(';')[2].ToString().Length - 4);
                txt_pwd.Text = strConn.Split(';')[3].ToString().Substring(4, strConn.Split(';')[3].ToString().Length - 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            constr = "server=" + txt_server.Text.Trim() + ";database=" + txt_dbname.Text.Trim() + ";uid=" + txt_user.Text.Trim() + ";pwd=" + txt_pwd.Text.Trim();
            //MessageBox.Show(constr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                result = test.ConnectionTest(constr);
                if (result)
                {
                    MessageBox.Show("测试连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("测试连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (result)
            {
                SaveConfig("Constr", constr);
            }
            else
            {
                MessageBox.Show("请测试连接成功后再确定！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("程序需要重新启动才能生效，请点击确定重新启动程序。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);    
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void SaveConfig(string keyName, string value)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == keyName)
                {
                    isModified = true;
                    break;
                }
            }
            if (!isModified)
            {
                MessageBox.Show("保存失败：找不到保存节点。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExeConfigurationFileMap filemap = new ExeConfigurationFileMap();
            filemap.ExeConfigFilename = Application.StartupPath + @"\PEIS.exe.config";//配置文件路径   
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(filemap, ConfigurationUserLevel.None);
            if (isModified)
            {
                config.AppSettings.Settings.Remove(keyName);
            }
            config.AppSettings.Settings.Add(keyName, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

