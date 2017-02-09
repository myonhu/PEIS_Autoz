using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.xtgg;

namespace PEIS.main
{
    public partial class ZY_MainForm : Form
    {
        public ZY_MainForm()
        {
            InitializeComponent();
        }

        private void ZY_MainForm_Load(object sender, EventArgs e)
        {
            addMenu();
            if (!Program.sfzc)
            {
                Form_reg frm = new Form_reg();
                frm.ShowDialog();
            }
        }

        private void ZY_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addMenu()
        {
            //在最后添加退出按钮和退出事件
            ToolStripMenuItem menuitem = new ToolStripMenuItem("系统(&W)");
            ToolStripMenuItem item0 = new ToolStripMenuItem("重新登陆");
            ToolStripMenuItem item2 = new ToolStripMenuItem("系统注册");
            ToolStripMenuItem item3 = new ToolStripMenuItem("关于");
            ToolStripMenuItem item4 = new ToolStripMenuItem("帮助");
            ToolStripMenuItem item5 = new ToolStripMenuItem("打印机");
            ToolStripMenuItem item6 = new ToolStripMenuItem("退出");
            item0.Click += new EventHandler(item0_Click);
            item2.Click += new EventHandler(item2_Click);
            item3.Click += new EventHandler(item3_Click);
            item4.Click += new EventHandler(item4_Click);
            item5.Click += new EventHandler(item5_Click);
            item6.Click += new EventHandler(item6_Click);
            menuitem.DropDownItems.Add(item0);
            menuitem.DropDownItems.Add(item2);
            menuitem.DropDownItems.Add(item3);
            menuitem.DropDownItems.Add(item4);
            menuitem.DropDownItems.Add(item5);
            menuitem.DropDownItems.Add(item6);
            menuStrip.Items.Add(menuitem);
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

        void item0_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Form_login_zy();
            frm.Show();
        }

        private void 体检登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PEIS.tjjg.Form_zywj_insert frm = new PEIS.tjjg.Form_zywj_insert();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 问卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PEIS.tjjg.Form_zywj frm = new PEIS.tjjg.Form_zywj();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();
        }

        private void 触摸屏问卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PEIS.tjjg.Form_zywj_out frm = new PEIS.tjjg.Form_zywj_out();
            frm.ShowDialog();
        }

        private void 体检报告查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PEIS.tjjg.Form_tjbg frm = new PEIS.tjjg.Form_tjbg();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();
        }

        private void 体检结果查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PEIS.cxgl.Form_ggcx frm = new PEIS.cxgl.Form_ggcx();
            PEIS.cxgl.FormArg.Arg = "v_tj_zyjgb1";
            PEIS.cxgl.FormArg.Name = "体检结果查询";
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            问卷ToolStripMenuItem_Click(null, null);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            触摸屏问卷ToolStripMenuItem_Click(null, null);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            体检报告查询ToolStripMenuItem_Click(null, null);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            体检结果查询ToolStripMenuItem_Click(null, null);
        }

    }
}
