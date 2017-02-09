using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using PEIS.main;
using PEIS.xtgg;

namespace PEIS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\main.jpg");
            //pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\img\main.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //获取系统标题栏名称
            xtBiz xtbiz = new xtBiz();
            string xtxsmc = xtbiz.GetXtCsz("Xtdlxsmc");
            if (xtxsmc.Trim() == "" || xtxsmc == null)
            {
                xtxsmc = "体检管理信息平台";
            }

            if (!Program.sfzc)
            {
                Form frm = new Form_reg();
                frm.ShowDialog();
            }
            else
            {
                this.Text = "【" + Program.yljgmc + "】" + xtxsmc;
            }
            //toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + Program.ksmc;
            toolStripStatusLabel2.Text = toolStripStatusLabel2.Text + Program.username;
            toolStripStatusLabel3.Text = toolStripStatusLabel3.Text + DateTime.Now;
            addMenu(this);
        }

        private void addMenu(MainForm mainForm )
        {
            mainBiz objMain = new mainBiz();
            MainMenuStrip.Items.Clear();

            MainMenuStrip = objMain.GetMenuList(MainMenuStrip,Program.yhzid,mainForm);
            //在最后添加退出按钮和退出事件
            ToolStripMenuItem menuitem = new ToolStripMenuItem("系统(&W)");
            ToolStripMenuItem item0 = new ToolStripMenuItem("重新登陆");
            ToolStripMenuItem item1 = new ToolStripMenuItem("修改密码");
            ToolStripMenuItem item2 = new ToolStripMenuItem("系统注册");
            ToolStripMenuItem item3 = new ToolStripMenuItem("关于");
            ToolStripMenuItem item4 = new ToolStripMenuItem("帮助");
            ToolStripMenuItem item5 = new ToolStripMenuItem("打印机");
            ToolStripMenuItem item6 = new ToolStripMenuItem("退出");
            item0.Click += new EventHandler(item0_Click);
            item1.Click += new EventHandler(item1_Click);
            item2.Click += new EventHandler(item2_Click);
            item3.Click += new EventHandler(item3_Click);
            item4.Click += new EventHandler(item4_Click);
            item5.Click += new EventHandler(item5_Click);
            item6.Click += new EventHandler(item6_Click);
            menuitem.DropDownItems.Add(item0);
            menuitem.DropDownItems.Add(item1);
            menuitem.DropDownItems.Add(item2);
            menuitem.DropDownItems.Add(item3);
            menuitem.DropDownItems.Add(item4);
            menuitem.DropDownItems.Add(item5);
            menuitem.DropDownItems.Add(item6);
            MainMenuStrip.Items.Add(menuitem);
        }

        void item6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void item5_Click(object sender, EventArgs e)
        {
            Form_dysz frm = new Form_dysz();
            frm.ShowDialog();
        }

        void item4_Click(object sender, EventArgs e)
        {
            //帮助
            MessageBox.Show("请直接联系技术支持人员：！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void item3_Click(object sender, EventArgs e)
        {
            Form frm = new About();
            frm.ShowDialog();
        }

        void item2_Click(object sender, EventArgs e)
        {
            Form frm = new Form_reg();
            frm.ShowDialog();
        }

        void item1_Click(object sender, EventArgs e)
        {
            Form frm = new Form_changepsd();
            frm.Show();
        }

        void item0_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Form_login();
            frm.Show();
        }
 
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        //缩放
        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_RESTORE)
                {
                    if (this.WindowState != FormWindowState.Minimized)
                        return;
                }
            }

            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                return;
            }
            base.WndProc(ref m);
        }

        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_RESTORE = 0xF120;

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "当前时间：" + DateTime.Now;
        }

       
        
    }
}