namespace PEIS.ywsz
{
    partial class Form_tjtc
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_tc = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmb_xb = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.lv_tjtcxm = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.增加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_bz = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_tjywlx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_jg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_dz = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_bzjg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_jc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_mc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_disp_order = new System.Windows.Forms.TextBox();
            this.txt_bh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_tc);
            this.groupBox1.Location = new System.Drawing.Point(2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 479);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "体检套餐";
            // 
            // tv_tc
            // 
            this.tv_tc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_tc.Location = new System.Drawing.Point(3, 20);
            this.tv_tc.Name = "tv_tc";
            this.tv_tc.Size = new System.Drawing.Size(228, 456);
            this.tv_tc.TabIndex = 0;
            this.tv_tc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_tc_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(240, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(498, 483);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmb_xb);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.bt_exit);
            this.tabPage1.Controls.Add(this.bt_save);
            this.tabPage1.Controls.Add(this.bt_delete);
            this.tabPage1.Controls.Add(this.bt_add);
            this.tabPage1.Controls.Add(this.lv_tjtcxm);
            this.tabPage1.Controls.Add(this.txt_bz);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmb_tjywlx);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txt_jg);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txt_dz);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txt_bzjg);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_jc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_mc);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_disp_order);
            this.tabPage1.Controls.Add(this.txt_bh);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(490, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "套餐详细信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmb_xb
            // 
            this.cmb_xb.FormattingEnabled = true;
            this.cmb_xb.Location = new System.Drawing.Point(354, 7);
            this.cmb_xb.Name = "cmb_xb";
            this.cmb_xb.Size = new System.Drawing.Size(100, 23);
            this.cmb_xb.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "性别：";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(353, 430);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 28;
            this.bt_exit.Text = "退出(X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(253, 430);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 27;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(150, 430);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 26;
            this.bt_delete.Text = "删除(&D)";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(51, 430);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 25;
            this.bt_add.Text = "增加(&A)";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // lv_tjtcxm
            // 
            this.lv_tjtcxm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_tjtcxm.ContextMenuStrip = this.contextMenuStrip1;
            this.lv_tjtcxm.Location = new System.Drawing.Point(5, 131);
            this.lv_tjtcxm.Name = "lv_tjtcxm";
            this.lv_tjtcxm.Size = new System.Drawing.Size(480, 293);
            this.lv_tjtcxm.TabIndex = 24;
            this.lv_tjtcxm.UseCompatibleStateImageBehavior = false;
            this.lv_tjtcxm.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.清除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 70);
            // 
            // 增加ToolStripMenuItem
            // 
            this.增加ToolStripMenuItem.Name = "增加ToolStripMenuItem";
            this.增加ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.增加ToolStripMenuItem.Text = "增加";
            this.增加ToolStripMenuItem.Click += new System.EventHandler(this.增加ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.清除ToolStripMenuItem.Text = "清除";
            this.清除ToolStripMenuItem.Click += new System.EventHandler(this.清除ToolStripMenuItem_Click);
            // 
            // txt_bz
            // 
            this.txt_bz.Location = new System.Drawing.Point(228, 100);
            this.txt_bz.Name = "txt_bz";
            this.txt_bz.Size = new System.Drawing.Size(226, 24);
            this.txt_bz.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "备注：";
            // 
            // cmb_tjywlx
            // 
            this.cmb_tjywlx.FormattingEnabled = true;
            this.cmb_tjywlx.Location = new System.Drawing.Point(81, 99);
            this.cmb_tjywlx.Name = "cmb_tjywlx";
            this.cmb_tjywlx.Size = new System.Drawing.Size(100, 23);
            this.cmb_tjywlx.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "业务类型：";
            // 
            // txt_jg
            // 
            this.txt_jg.Location = new System.Drawing.Point(354, 68);
            this.txt_jg.Name = "txt_jg";
            this.txt_jg.ReadOnly = true;
            this.txt_jg.Size = new System.Drawing.Size(100, 24);
            this.txt_jg.TabIndex = 19;
            this.txt_jg.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "实际价格：";
            // 
            // txt_dz
            // 
            this.txt_dz.Location = new System.Drawing.Point(227, 68);
            this.txt_dz.MaxLength = 3;
            this.txt_dz.Name = "txt_dz";
            this.txt_dz.ReadOnly = true;
            this.txt_dz.Size = new System.Drawing.Size(41, 24);
            this.txt_dz.TabIndex = 17;
            this.txt_dz.Text = "100";
            this.txt_dz.TextChanged += new System.EventHandler(this.txt_dz_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "打折：";
            // 
            // txt_bzjg
            // 
            this.txt_bzjg.Location = new System.Drawing.Point(81, 68);
            this.txt_bzjg.Name = "txt_bzjg";
            this.txt_bzjg.ReadOnly = true;
            this.txt_bzjg.Size = new System.Drawing.Size(100, 24);
            this.txt_bzjg.TabIndex = 15;
            this.txt_bzjg.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "标准价格：";
            // 
            // txt_jc
            // 
            this.txt_jc.Location = new System.Drawing.Point(354, 37);
            this.txt_jc.Name = "txt_jc";
            this.txt_jc.Size = new System.Drawing.Size(100, 24);
            this.txt_jc.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "简称：";
            // 
            // txt_mc
            // 
            this.txt_mc.Location = new System.Drawing.Point(81, 37);
            this.txt_mc.Name = "txt_mc";
            this.txt_mc.Size = new System.Drawing.Size(224, 24);
            this.txt_mc.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "套餐名称：";
            // 
            // txt_disp_order
            // 
            this.txt_disp_order.Location = new System.Drawing.Point(257, 7);
            this.txt_disp_order.Name = "txt_disp_order";
            this.txt_disp_order.Size = new System.Drawing.Size(47, 24);
            this.txt_disp_order.TabIndex = 9;
            this.txt_disp_order.Leave += new System.EventHandler(this.txt_disp_order_Leave);
            // 
            // txt_bh
            // 
            this.txt_bh.Location = new System.Drawing.Point(81, 7);
            this.txt_bh.Name = "txt_bh";
            this.txt_bh.ReadOnly = true;
            this.txt_bh.Size = new System.Drawing.Size(100, 24);
            this.txt_bh.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "编    号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "显示顺序：";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form_tjtc
            // 
            this.ClientSize = new System.Drawing.Size(740, 487);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_tjtc";
            this.Text = "体检套餐设置";
            this.Load += new System.EventHandler(this.Form_tjtc_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_tc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.ListView lv_tjtcxm;
        private System.Windows.Forms.TextBox txt_bz;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_tjywlx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_jg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_dz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_bzjg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_jc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_mc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_disp_order;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_xb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 增加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}
