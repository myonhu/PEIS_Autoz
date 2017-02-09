namespace PEIS.ywsz
{
    partial class Form_tjks
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
            this.tv_tjlxb = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_bz = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ksxx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ksxj = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rb_jcjylx3 = new System.Windows.Forms.RadioButton();
            this.rb_jcjylx2 = new System.Windows.Forms.RadioButton();
            this.rb_jcjylx1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_mc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_disp_order = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_lxbh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_tjlxb);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "体检科室";
            // 
            // tv_tjlxb
            // 
            this.tv_tjlxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_tjlxb.Location = new System.Drawing.Point(3, 20);
            this.tv_tjlxb.Name = "tv_tjlxb";
            this.tv_tjlxb.Size = new System.Drawing.Size(244, 346);
            this.tv_tjlxb.TabIndex = 0;
            this.tv_tjlxb.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_tjlxb_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_bz);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_ksxx);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_ksxj);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rb_jcjylx3);
            this.groupBox2.Controls.Add(this.rb_jcjylx2);
            this.groupBox2.Controls.Add(this.rb_jcjylx1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_mc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_disp_order);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_lxbh);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(271, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 294);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "体检科室信息";
            // 
            // txt_bz
            // 
            this.txt_bz.Location = new System.Drawing.Point(93, 242);
            this.txt_bz.Name = "txt_bz";
            this.txt_bz.Size = new System.Drawing.Size(304, 24);
            this.txt_bz.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "备    注：";
            // 
            // txt_ksxx
            // 
            this.txt_ksxx.Location = new System.Drawing.Point(93, 201);
            this.txt_ksxx.Name = "txt_ksxx";
            this.txt_ksxx.Size = new System.Drawing.Size(304, 24);
            this.txt_ksxx.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "科室信息：";
            // 
            // txt_ksxj
            // 
            this.txt_ksxj.Location = new System.Drawing.Point(93, 159);
            this.txt_ksxj.Name = "txt_ksxj";
            this.txt_ksxj.Size = new System.Drawing.Size(304, 24);
            this.txt_ksxj.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "正常小结：";
            // 
            // rb_jcjylx3
            // 
            this.rb_jcjylx3.AutoSize = true;
            this.rb_jcjylx3.Location = new System.Drawing.Point(275, 118);
            this.rb_jcjylx3.Name = "rb_jcjylx3";
            this.rb_jcjylx3.Size = new System.Drawing.Size(85, 19);
            this.rb_jcjylx3.TabIndex = 9;
            this.rb_jcjylx3.TabStop = true;
            this.rb_jcjylx3.Text = "功能科室";
            this.rb_jcjylx3.UseVisualStyleBackColor = true;
            // 
            // rb_jcjylx2
            // 
            this.rb_jcjylx2.AutoSize = true;
            this.rb_jcjylx2.Location = new System.Drawing.Point(184, 118);
            this.rb_jcjylx2.Name = "rb_jcjylx2";
            this.rb_jcjylx2.Size = new System.Drawing.Size(85, 19);
            this.rb_jcjylx2.TabIndex = 8;
            this.rb_jcjylx2.TabStop = true;
            this.rb_jcjylx2.Text = "物理科室";
            this.rb_jcjylx2.UseVisualStyleBackColor = true;
            // 
            // rb_jcjylx1
            // 
            this.rb_jcjylx1.AutoSize = true;
            this.rb_jcjylx1.Location = new System.Drawing.Point(93, 118);
            this.rb_jcjylx1.Name = "rb_jcjylx1";
            this.rb_jcjylx1.Size = new System.Drawing.Size(85, 19);
            this.rb_jcjylx1.TabIndex = 7;
            this.rb_jcjylx1.TabStop = true;
            this.rb_jcjylx1.Text = "实验科室";
            this.rb_jcjylx1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "科室类型：";
            // 
            // txt_mc
            // 
            this.txt_mc.Location = new System.Drawing.Point(93, 70);
            this.txt_mc.Name = "txt_mc";
            this.txt_mc.Size = new System.Drawing.Size(304, 24);
            this.txt_mc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "科室名称：";
            // 
            // txt_disp_order
            // 
            this.txt_disp_order.Location = new System.Drawing.Point(297, 28);
            this.txt_disp_order.Name = "txt_disp_order";
            this.txt_disp_order.Size = new System.Drawing.Size(100, 24);
            this.txt_disp_order.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "显示顺序：";
            // 
            // txt_lxbh
            // 
            this.txt_lxbh.Location = new System.Drawing.Point(93, 28);
            this.txt_lxbh.Name = "txt_lxbh";
            this.txt_lxbh.ReadOnly = true;
            this.txt_lxbh.Size = new System.Drawing.Size(100, 24);
            this.txt_lxbh.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室编号：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_exit);
            this.groupBox3.Controls.Add(this.bt_save);
            this.groupBox3.Controls.Add(this.bt_delete);
            this.groupBox3.Controls.Add(this.bt_add);
            this.groupBox3.Location = new System.Drawing.Point(271, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(321, 23);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 9;
            this.bt_exit.Text = "退出(X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(221, 23);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 8;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(118, 23);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 7;
            this.bt_delete.Text = "删除(&D)";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(19, 23);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 6;
            this.bt_add.Text = "增加(&A)";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form_tjks
            // 
            this.ClientSize = new System.Drawing.Size(711, 377);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_tjks";
            this.Text = "体检科室设置";
            this.Load += new System.EventHandler(this.Form_tjks_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.TreeView tv_tjlxb;
        private System.Windows.Forms.TextBox txt_ksxj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rb_jcjylx3;
        private System.Windows.Forms.RadioButton rb_jcjylx2;
        private System.Windows.Forms.RadioButton rb_jcjylx1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_mc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_disp_order;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_lxbh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bz;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ksxx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList1;
    }
}
