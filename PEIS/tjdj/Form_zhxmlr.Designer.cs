namespace PEIS.tjdj
{
    partial class Form_zhxmlr
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
            this.lv_checkxm = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lv_fz = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lv_uncheckxm = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.txt_jsm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tv_tjlxb = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lv_tc = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lv_checkxm);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 510);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已选项目";
            // 
            // lv_checkxm
            // 
            this.lv_checkxm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.lv_checkxm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_checkxm.Location = new System.Drawing.Point(3, 20);
            this.lv_checkxm.Name = "lv_checkxm";
            this.lv_checkxm.Size = new System.Drawing.Size(185, 487);
            this.lv_checkxm.TabIndex = 0;
            this.lv_checkxm.UseCompatibleStateImageBehavior = false;
            this.lv_checkxm.View = System.Windows.Forms.View.SmallIcon;
            this.lv_checkxm.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_checkxm_MouseDoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 180;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.bt_exit);
            this.groupBox2.Controls.Add(this.bt_ok);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(199, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 510);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "未选项目";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lv_fz);
            this.groupBox5.Location = new System.Drawing.Point(6, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(523, 65);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "按分组选择";
            // 
            // lv_fz
            // 
            this.lv_fz.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lv_fz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_fz.Location = new System.Drawing.Point(3, 20);
            this.lv_fz.Name = "lv_fz";
            this.lv_fz.Size = new System.Drawing.Size(517, 42);
            this.lv_fz.TabIndex = 0;
            this.lv_fz.UseCompatibleStateImageBehavior = false;
            this.lv_fz.View = System.Windows.Forms.View.SmallIcon;
            this.lv_fz.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_fz_MouseDoubleClick);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Width = 150;
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(266, 487);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 3;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(168, 487);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 2;
            this.bt_ok.Text = "确定(&O)";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lv_uncheckxm);
            this.groupBox4.Controls.Add(this.txt_jsm);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tv_tjlxb);
            this.groupBox4.Location = new System.Drawing.Point(6, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(523, 307);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "按组合项目选择";
            // 
            // lv_uncheckxm
            // 
            this.lv_uncheckxm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lv_uncheckxm.Location = new System.Drawing.Point(150, 39);
            this.lv_uncheckxm.Name = "lv_uncheckxm";
            this.lv_uncheckxm.Size = new System.Drawing.Size(370, 265);
            this.lv_uncheckxm.TabIndex = 4;
            this.lv_uncheckxm.UseCompatibleStateImageBehavior = false;
            this.lv_uncheckxm.View = System.Windows.Forms.View.SmallIcon;
            this.lv_uncheckxm.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_uncheckxm_MouseDoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 180;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 180;
            // 
            // txt_jsm
            // 
            this.txt_jsm.Location = new System.Drawing.Point(276, 9);
            this.txt_jsm.Name = "txt_jsm";
            this.txt_jsm.Size = new System.Drawing.Size(100, 24);
            this.txt_jsm.TabIndex = 3;
            this.txt_jsm.TextChanged += new System.EventHandler(this.txt_jsm_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "检索码：";
            // 
            // tv_tjlxb
            // 
            this.tv_tjlxb.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_tjlxb.Location = new System.Drawing.Point(3, 20);
            this.tv_tjlxb.Name = "tv_tjlxb";
            this.tv_tjlxb.Size = new System.Drawing.Size(147, 284);
            this.tv_tjlxb.TabIndex = 1;
            this.tv_tjlxb.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_tjlxb_AfterSelect);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lv_tc);
            this.groupBox3.Location = new System.Drawing.Point(6, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 102);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "按套餐选择";
            // 
            // lv_tc
            // 
            this.lv_tc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_tc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_tc.Location = new System.Drawing.Point(3, 20);
            this.lv_tc.Name = "lv_tc";
            this.lv_tc.Size = new System.Drawing.Size(517, 79);
            this.lv_tc.TabIndex = 0;
            this.lv_tc.UseCompatibleStateImageBehavior = false;
            this.lv_tc.View = System.Windows.Forms.View.SmallIcon;
            this.lv_tc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_tc_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form_zhxmlr
            // 
            this.ClientSize = new System.Drawing.Size(735, 513);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_zhxmlr";
            this.Text = "体检项目录入";
            this.Load += new System.EventHandler(this.Form_zhxmlr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView tv_tjlxb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_jsm;
        private System.Windows.Forms.ListView lv_checkxm;
        private System.Windows.Forms.ListView lv_uncheckxm;
        private System.Windows.Forms.ListView lv_tc;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView lv_fz;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ImageList imageList1;
    }
}
