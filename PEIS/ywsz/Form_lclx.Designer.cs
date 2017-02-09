namespace PEIS.ywsz
{
    partial class Form_lclx
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
            this.txt_mc = new System.Windows.Forms.TextBox();
            this.bt_delete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_disp_order = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_lclx = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_bz = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_add = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_lclxb = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2.SuspendLayout();
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
            // txt_mc
            // 
            this.txt_mc.Location = new System.Drawing.Point(93, 95);
            this.txt_mc.Name = "txt_mc";
            this.txt_mc.Size = new System.Drawing.Size(304, 24);
            this.txt_mc.TabIndex = 5;
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
            this.label3.Location = new System.Drawing.Point(20, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "类型名称：";
            // 
            // txt_disp_order
            // 
            this.txt_disp_order.Location = new System.Drawing.Point(297, 39);
            this.txt_disp_order.Name = "txt_disp_order";
            this.txt_disp_order.Size = new System.Drawing.Size(100, 24);
            this.txt_disp_order.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "显示顺序：";
            // 
            // txt_lclx
            // 
            this.txt_lclx.Location = new System.Drawing.Point(93, 39);
            this.txt_lclx.Name = "txt_lclx";
            this.txt_lclx.ReadOnly = true;
            this.txt_lclx.Size = new System.Drawing.Size(100, 24);
            this.txt_lclx.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_bz);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_mc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_disp_order);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_lclx);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(265, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 294);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "临床类型信息";
            // 
            // txt_bz
            // 
            this.txt_bz.Location = new System.Drawing.Point(93, 142);
            this.txt_bz.Name = "txt_bz";
            this.txt_bz.Size = new System.Drawing.Size(304, 24);
            this.txt_bz.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "备    注：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型编号：";
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
            this.groupBox3.Location = new System.Drawing.Point(265, 297);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 66);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_lclxb);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 369);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "临床类型";
            // 
            // tv_lclxb
            // 
            this.tv_lclxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_lclxb.Location = new System.Drawing.Point(3, 20);
            this.tv_lclxb.Name = "tv_lclxb";
            this.tv_lclxb.Size = new System.Drawing.Size(244, 346);
            this.tv_lclxb.TabIndex = 0;
            this.tv_lclxb.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_lclxb_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form_lclx
            // 
            this.ClientSize = new System.Drawing.Size(711, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_lclx";
            this.Text = "临床类型设置";
            this.Load += new System.EventHandler(this.Form_lclx_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TextBox txt_mc;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_disp_order;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_lclx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_bz;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_lclxb;
        private System.Windows.Forms.ImageList imageList1;
    }
}
