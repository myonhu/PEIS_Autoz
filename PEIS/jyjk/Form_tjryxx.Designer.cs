namespace PEIS.jyjk
{
    partial class Form_tjryxx
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.xz = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tjbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.djlsh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.djrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dwmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_cx = new System.Windows.Forms.Button();
            this.txt_xm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_djlsh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckb_xz = new System.Windows.Forms.CheckBox();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_begin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xz,
            this.tjbh,
            this.djlsh,
            this.djrq,
            this.xm,
            this.xb,
            this.nl,
            this.dwmc});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 75);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(774, 498);
            this.dataGridView1.TabIndex = 3;
            // 
            // xz
            // 
            this.xz.DataPropertyName = "xz";
            this.xz.FalseValue = "0";
            this.xz.HeaderText = "选";
            this.xz.IndeterminateValue = "0";
            this.xz.Name = "xz";
            this.xz.ReadOnly = true;
            this.xz.TrueValue = "1";
            this.xz.Width = 28;
            // 
            // tjbh
            // 
            this.tjbh.DataPropertyName = "tjbh";
            this.tjbh.HeaderText = "体检编号";
            this.tjbh.Name = "tjbh";
            this.tjbh.ReadOnly = true;
            this.tjbh.Width = 92;
            // 
            // djlsh
            // 
            this.djlsh.DataPropertyName = "djlsh";
            this.djlsh.HeaderText = "流水号";
            this.djlsh.Name = "djlsh";
            this.djlsh.ReadOnly = true;
            this.djlsh.Width = 77;
            // 
            // djrq
            // 
            this.djrq.DataPropertyName = "djrq";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.djrq.DefaultCellStyle = dataGridViewCellStyle1;
            this.djrq.HeaderText = "登记日期";
            this.djrq.Name = "djrq";
            this.djrq.ReadOnly = true;
            this.djrq.Width = 92;
            // 
            // xm
            // 
            this.xm.DataPropertyName = "xm";
            this.xm.HeaderText = "姓名";
            this.xm.Name = "xm";
            this.xm.ReadOnly = true;
            this.xm.Width = 62;
            // 
            // xb
            // 
            this.xb.DataPropertyName = "xb";
            this.xb.HeaderText = "性别";
            this.xb.Name = "xb";
            this.xb.ReadOnly = true;
            this.xb.Width = 62;
            // 
            // nl
            // 
            this.nl.DataPropertyName = "nl";
            this.nl.HeaderText = "年龄";
            this.nl.Name = "nl";
            this.nl.ReadOnly = true;
            this.nl.Width = 62;
            // 
            // dwmc
            // 
            this.dwmc.DataPropertyName = "dwmc";
            this.dwmc.HeaderText = "单位";
            this.dwmc.Name = "dwmc";
            this.dwmc.ReadOnly = true;
            this.dwmc.Width = 62;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(606, 43);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(74, 24);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "打印(&E)";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(686, 43);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(74, 24);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "关闭(&C)";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_cx
            // 
            this.btn_cx.Location = new System.Drawing.Point(527, 43);
            this.btn_cx.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cx.Name = "btn_cx";
            this.btn_cx.Size = new System.Drawing.Size(74, 24);
            this.btn_cx.TabIndex = 6;
            this.btn_cx.Text = "查询(&Q)";
            this.btn_cx.UseVisualStyleBackColor = true;
            this.btn_cx.Click += new System.EventHandler(this.btn_cx_Click);
            // 
            // txt_xm
            // 
            this.txt_xm.Location = new System.Drawing.Point(363, 11);
            this.txt_xm.Margin = new System.Windows.Forms.Padding(4);
            this.txt_xm.Name = "txt_xm";
            this.txt_xm.Size = new System.Drawing.Size(123, 24);
            this.txt_xm.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "姓名：";
            // 
            // txt_djlsh
            // 
            this.txt_djlsh.Location = new System.Drawing.Point(575, 11);
            this.txt_djlsh.Margin = new System.Windows.Forms.Padding(4);
            this.txt_djlsh.Name = "txt_djlsh";
            this.txt_djlsh.Size = new System.Drawing.Size(132, 24);
            this.txt_djlsh.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "登记流水号：";
            // 
            // ckb_xz
            // 
            this.ckb_xz.AutoSize = true;
            this.ckb_xz.Location = new System.Drawing.Point(8, 48);
            this.ckb_xz.Margin = new System.Windows.Forms.Padding(4);
            this.ckb_xz.Name = "ckb_xz";
            this.ckb_xz.Size = new System.Drawing.Size(56, 19);
            this.ckb_xz.TabIndex = 11;
            this.ckb_xz.Text = "全选";
            this.ckb_xz.UseVisualStyleBackColor = true;
            this.ckb_xz.CheckedChanged += new System.EventHandler(this.ckb_all_CheckedChanged);
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd";
            this.dtp_end.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(200, 13);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(117, 23);
            this.dtp_end.TabIndex = 39;
            // 
            // dtp_begin
            // 
            this.dtp_begin.CustomFormat = "yyyy-MM-dd";
            this.dtp_begin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_begin.Location = new System.Drawing.Point(81, 13);
            this.dtp_begin.Name = "dtp_begin";
            this.dtp_begin.Size = new System.Drawing.Size(106, 23);
            this.dtp_begin.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = "登记日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "至";
            // 
            // Form_tjryxx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 573);
            this.Controls.Add(this.dtp_end);
            this.Controls.Add(this.dtp_begin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ckb_xz);
            this.Controls.Add(this.txt_djlsh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_xm);
            this.Controls.Add(this.btn_cx);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_tjryxx";
            this.Text = "检验报告合并打印";
            this.Load += new System.EventHandler(this.Form_tjryxx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_cx;
        private System.Windows.Forms.TextBox txt_xm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_djlsh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckb_xz;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_begin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn xz;
        private System.Windows.Forms.DataGridViewTextBoxColumn tjbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn djlsh;
        private System.Windows.Forms.DataGridViewTextBoxColumn djrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn nl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dwmc;
    }
}