namespace PEIS.main
{
    partial class Form_xtczy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_czy = new System.Windows.Forms.DataGridView();
            this.czyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czymc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_bz = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_ks = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_delete = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.ckb_sfty = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_mm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_rysx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_yhz = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_czybm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_czymc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_czyid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_czy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_czy);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作人员列表";
            // 
            // dgv_czy
            // 
            this.dgv_czy.AllowUserToAddRows = false;
            this.dgv_czy.AllowUserToDeleteRows = false;
            this.dgv_czy.AllowUserToResizeRows = false;
            this.dgv_czy.BackgroundColor = System.Drawing.Color.White;
            this.dgv_czy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_czy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_czy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_czy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.czyid,
            this.czymc});
            this.dgv_czy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_czy.Location = new System.Drawing.Point(3, 20);
            this.dgv_czy.Name = "dgv_czy";
            this.dgv_czy.ReadOnly = true;
            this.dgv_czy.RowHeadersVisible = false;
            this.dgv_czy.RowTemplate.Height = 23;
            this.dgv_czy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_czy.Size = new System.Drawing.Size(223, 346);
            this.dgv_czy.TabIndex = 6;
            this.dgv_czy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_czy_CellClick);
            // 
            // czyid
            // 
            this.czyid.DataPropertyName = "czyid";
            this.czyid.HeaderText = "操作员ID";
            this.czyid.Name = "czyid";
            this.czyid.ReadOnly = true;
            // 
            // czymc
            // 
            this.czymc.DataPropertyName = "czymc";
            this.czymc.HeaderText = "操作员名称";
            this.czymc.Name = "czymc";
            this.czymc.ReadOnly = true;
            this.czymc.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_bz);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmb_ks);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.bt_exit);
            this.groupBox2.Controls.Add(this.bt_delete);
            this.groupBox2.Controls.Add(this.bt_save);
            this.groupBox2.Controls.Add(this.bt_add);
            this.groupBox2.Controls.Add(this.ckb_sfty);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_mm);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmb_rysx);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmb_yhz);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_czybm);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_czymc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_czyid);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(242, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 366);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "人员详细信息";
            // 
            // txt_bz
            // 
            this.txt_bz.Location = new System.Drawing.Point(79, 230);
            this.txt_bz.Name = "txt_bz";
            this.txt_bz.Size = new System.Drawing.Size(136, 24);
            this.txt_bz.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "备    注：";
            // 
            // cmb_ks
            // 
            this.cmb_ks.FormattingEnabled = true;
            this.cmb_ks.Location = new System.Drawing.Point(79, 139);
            this.cmb_ks.Name = "cmb_ks";
            this.cmb_ks.Size = new System.Drawing.Size(136, 23);
            this.cmb_ks.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "所属科室：";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(131, 330);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 17;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_delete
            // 
            this.bt_delete.Location = new System.Drawing.Point(23, 330);
            this.bt_delete.Name = "bt_delete";
            this.bt_delete.Size = new System.Drawing.Size(75, 23);
            this.bt_delete.TabIndex = 16;
            this.bt_delete.Text = "删除(&D)";
            this.bt_delete.UseVisualStyleBackColor = true;
            this.bt_delete.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(131, 301);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 15;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(23, 301);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 14;
            this.bt_add.Text = "增加(&A)";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // ckb_sfty
            // 
            this.ckb_sfty.AutoSize = true;
            this.ckb_sfty.Location = new System.Drawing.Point(79, 271);
            this.ckb_sfty.Name = "ckb_sfty";
            this.ckb_sfty.Size = new System.Drawing.Size(86, 19);
            this.ckb_sfty.TabIndex = 12;
            this.ckb_sfty.Text = "是否停用";
            this.ckb_sfty.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "停用标志：";
            // 
            // txt_mm
            // 
            this.txt_mm.Location = new System.Drawing.Point(79, 109);
            this.txt_mm.Name = "txt_mm";
            this.txt_mm.Size = new System.Drawing.Size(136, 24);
            this.txt_mm.TabIndex = 11;
            this.txt_mm.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "登陆密码：";
            // 
            // cmb_rysx
            // 
            this.cmb_rysx.FormattingEnabled = true;
            this.cmb_rysx.Location = new System.Drawing.Point(79, 197);
            this.cmb_rysx.Name = "cmb_rysx";
            this.cmb_rysx.Size = new System.Drawing.Size(136, 23);
            this.cmb_rysx.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "人员属性：";
            // 
            // cmb_yhz
            // 
            this.cmb_yhz.FormattingEnabled = true;
            this.cmb_yhz.Location = new System.Drawing.Point(79, 167);
            this.cmb_yhz.Name = "cmb_yhz";
            this.cmb_yhz.Size = new System.Drawing.Size(136, 23);
            this.cmb_yhz.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "用 户 组：";
            // 
            // txt_czybm
            // 
            this.txt_czybm.Location = new System.Drawing.Point(79, 53);
            this.txt_czybm.MaxLength = 10;
            this.txt_czybm.Name = "txt_czybm";
            this.txt_czybm.Size = new System.Drawing.Size(136, 24);
            this.txt_czybm.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户编码：";
            // 
            // txt_czymc
            // 
            this.txt_czymc.Location = new System.Drawing.Point(79, 81);
            this.txt_czymc.MaxLength = 5;
            this.txt_czymc.Name = "txt_czymc";
            this.txt_czymc.Size = new System.Drawing.Size(136, 24);
            this.txt_czymc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名称：";
            // 
            // txt_czyid
            // 
            this.txt_czyid.Location = new System.Drawing.Point(79, 23);
            this.txt_czyid.Name = "txt_czyid";
            this.txt_czyid.ReadOnly = true;
            this.txt_czyid.Size = new System.Drawing.Size(136, 24);
            this.txt_czyid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用　户ID：";
            // 
            // Form_xtczy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 372);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_xtczy";
            this.Text = "操作人员管理";
            this.Load += new System.EventHandler(this.Form_xtczy_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_czy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_czy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_czymc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_czyid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_czybm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_yhz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckb_sfty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_mm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_rysx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_delete;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn czyid;
        private System.Windows.Forms.DataGridViewTextBoxColumn czymc;
        private System.Windows.Forms.ComboBox cmb_ks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_bz;
        private System.Windows.Forms.Label label9;
    }
}