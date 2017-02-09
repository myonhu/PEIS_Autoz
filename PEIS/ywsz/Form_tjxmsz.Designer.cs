namespace PEIS.ywsz
{
    partial class Form_tjxmsz
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
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.txt_tjxm = new System.Windows.Forms.TextBox();
            this.bt_delete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_dj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_ksmc = new System.Windows.Forms.ComboBox();
            this.txt_maxvalue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_minvalue = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_dw = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_lclx = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_xb = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_xmmc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_disp_order = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_zcjg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rb_jglx2 = new System.Windows.Forms.RadioButton();
            this.rb_jglx1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rb_qybz2 = new System.Windows.Forms.RadioButton();
            this.rb_qybz1 = new System.Windows.Forms.RadioButton();
            this.bt_add = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_tjlxb = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // txt_tjxm
            // 
            this.txt_tjxm.Location = new System.Drawing.Point(93, 70);
            this.txt_tjxm.Name = "txt_tjxm";
            this.txt_tjxm.ReadOnly = true;
            this.txt_tjxm.Size = new System.Drawing.Size(100, 24);
            this.txt_tjxm.TabIndex = 5;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "项目编号：";
            // 
            // txt_dj
            // 
            this.txt_dj.Location = new System.Drawing.Point(297, 28);
            this.txt_dj.Name = "txt_dj";
            this.txt_dj.Size = new System.Drawing.Size(100, 24);
            this.txt_dj.TabIndex = 3;
            this.txt_dj.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "单    价：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_ksmc);
            this.groupBox2.Controls.Add(this.txt_maxvalue);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txt_minvalue);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txt_dw);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmb_lclx);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cmb_xb);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_xmmc);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_disp_order);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_zcjg);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_tjxm);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_dj);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(267, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 333);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "体检项目信息";
            // 
            // cmb_ksmc
            // 
            this.cmb_ksmc.Enabled = false;
            this.cmb_ksmc.FormattingEnabled = true;
            this.cmb_ksmc.Location = new System.Drawing.Point(93, 28);
            this.cmb_ksmc.Name = "cmb_ksmc";
            this.cmb_ksmc.Size = new System.Drawing.Size(100, 23);
            this.cmb_ksmc.TabIndex = 35;
            // 
            // txt_maxvalue
            // 
            this.txt_maxvalue.Location = new System.Drawing.Point(311, 290);
            this.txt_maxvalue.Name = "txt_maxvalue";
            this.txt_maxvalue.ReadOnly = true;
            this.txt_maxvalue.Size = new System.Drawing.Size(86, 24);
            this.txt_maxvalue.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(226, 293);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 31;
            this.label13.Text = "最大极限值：";
            // 
            // txt_minvalue
            // 
            this.txt_minvalue.Location = new System.Drawing.Point(113, 290);
            this.txt_minvalue.Name = "txt_minvalue";
            this.txt_minvalue.ReadOnly = true;
            this.txt_minvalue.Size = new System.Drawing.Size(80, 24);
            this.txt_minvalue.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 293);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 15);
            this.label14.TabIndex = 29;
            this.label14.Text = "最小极限值：";
            // 
            // txt_dw
            // 
            this.txt_dw.Location = new System.Drawing.Point(297, 153);
            this.txt_dw.Name = "txt_dw";
            this.txt_dw.ReadOnly = true;
            this.txt_dw.Size = new System.Drawing.Size(100, 24);
            this.txt_dw.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(224, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "单    位：";
            // 
            // cmb_lclx
            // 
            this.cmb_lclx.Enabled = false;
            this.cmb_lclx.FormattingEnabled = true;
            this.cmb_lclx.Location = new System.Drawing.Point(93, 153);
            this.cmb_lclx.Name = "cmb_lclx";
            this.cmb_lclx.Size = new System.Drawing.Size(100, 23);
            this.cmb_lclx.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "临床类型：";
            // 
            // cmb_xb
            // 
            this.cmb_xb.FormattingEnabled = true;
            this.cmb_xb.Location = new System.Drawing.Point(311, 111);
            this.cmb_xb.Name = "cmb_xb";
            this.cmb_xb.Size = new System.Drawing.Size(85, 23);
            this.cmb_xb.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "性别：";
            // 
            // txt_xmmc
            // 
            this.txt_xmmc.Location = new System.Drawing.Point(93, 110);
            this.txt_xmmc.Name = "txt_xmmc";
            this.txt_xmmc.Size = new System.Drawing.Size(176, 24);
            this.txt_xmmc.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "项目名称：";
            // 
            // txt_disp_order
            // 
            this.txt_disp_order.Location = new System.Drawing.Point(297, 70);
            this.txt_disp_order.Name = "txt_disp_order";
            this.txt_disp_order.Size = new System.Drawing.Size(100, 24);
            this.txt_disp_order.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "显示顺序：";
            // 
            // txt_zcjg
            // 
            this.txt_zcjg.Location = new System.Drawing.Point(93, 201);
            this.txt_zcjg.Name = "txt_zcjg";
            this.txt_zcjg.Size = new System.Drawing.Size(304, 24);
            this.txt_zcjg.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "正常结果：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "科室名称：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rb_jglx2);
            this.groupBox4.Controls.Add(this.rb_jglx1);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(19, 233);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(182, 51);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            // 
            // rb_jglx2
            // 
            this.rb_jglx2.AutoSize = true;
            this.rb_jglx2.Location = new System.Drawing.Point(125, 19);
            this.rb_jglx2.Name = "rb_jglx2";
            this.rb_jglx2.Size = new System.Drawing.Size(55, 19);
            this.rb_jglx2.TabIndex = 36;
            this.rb_jglx2.Text = "数字";
            this.rb_jglx2.UseVisualStyleBackColor = true;
            this.rb_jglx2.CheckedChanged += new System.EventHandler(this.rb_jglx2_CheckedChanged);
            // 
            // rb_jglx1
            // 
            this.rb_jglx1.AutoSize = true;
            this.rb_jglx1.Checked = true;
            this.rb_jglx1.Location = new System.Drawing.Point(74, 19);
            this.rb_jglx1.Name = "rb_jglx1";
            this.rb_jglx1.Size = new System.Drawing.Size(55, 19);
            this.rb_jglx1.TabIndex = 35;
            this.rb_jglx1.TabStop = true;
            this.rb_jglx1.Text = "字符";
            this.rb_jglx1.UseVisualStyleBackColor = true;
            this.rb_jglx1.CheckedChanged += new System.EventHandler(this.rb_jglx1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "结果类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "启用标志：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rb_qybz2);
            this.groupBox5.Controls.Add(this.rb_qybz1);
            this.groupBox5.Location = new System.Drawing.Point(214, 233);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(182, 51);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            // 
            // rb_qybz2
            // 
            this.rb_qybz2.AutoSize = true;
            this.rb_qybz2.Location = new System.Drawing.Point(131, 19);
            this.rb_qybz2.Name = "rb_qybz2";
            this.rb_qybz2.Size = new System.Drawing.Size(40, 19);
            this.rb_qybz2.TabIndex = 36;
            this.rb_qybz2.Text = "否";
            this.rb_qybz2.UseVisualStyleBackColor = true;
            // 
            // rb_qybz1
            // 
            this.rb_qybz1.AutoSize = true;
            this.rb_qybz1.Checked = true;
            this.rb_qybz1.Location = new System.Drawing.Point(92, 19);
            this.rb_qybz1.Name = "rb_qybz1";
            this.rb_qybz1.Size = new System.Drawing.Size(40, 19);
            this.rb_qybz1.TabIndex = 35;
            this.rb_qybz1.TabStop = true;
            this.rb_qybz1.Text = "是";
            this.rb_qybz1.UseVisualStyleBackColor = true;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_exit);
            this.groupBox3.Controls.Add(this.bt_save);
            this.groupBox3.Controls.Add(this.bt_delete);
            this.groupBox3.Controls.Add(this.bt_add);
            this.groupBox3.Location = new System.Drawing.Point(267, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 66);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_tjlxb);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 404);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "体检科室";
            // 
            // tv_tjlxb
            // 
            this.tv_tjlxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_tjlxb.Location = new System.Drawing.Point(3, 20);
            this.tv_tjlxb.Name = "tv_tjlxb";
            this.tv_tjlxb.Size = new System.Drawing.Size(244, 381);
            this.tv_tjlxb.TabIndex = 0;
            this.tv_tjlxb.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_tjlxb_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form_tjxmsz
            // 
            this.ClientSize = new System.Drawing.Size(707, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_tjxmsz";
            this.Text = "体检项目设置";
            this.Load += new System.EventHandler(this.Form_tjxmsz_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TextBox txt_tjxm;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_dj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_zcjg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_tjlxb;
        private System.Windows.Forms.ComboBox cmb_lclx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_xb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_xmmc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_disp_order;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_dw;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_maxvalue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_minvalue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rb_jglx2;
        private System.Windows.Forms.RadioButton rb_jglx1;
        private System.Windows.Forms.RadioButton rb_qybz2;
        private System.Windows.Forms.RadioButton rb_qybz1;
        private System.Windows.Forms.ComboBox cmb_ksmc;
        private System.Windows.Forms.ImageList imageList1;
    }
}
