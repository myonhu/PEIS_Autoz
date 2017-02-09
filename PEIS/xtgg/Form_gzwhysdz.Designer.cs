namespace PEIS.xtgg
{
    partial class Form_gzwhysdz
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvGz = new System.Windows.Forms.DataGridView();
            this.gz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gzid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGb = new System.Windows.Forms.Button();
            this.btnQxdz = new System.Windows.Forms.Button();
            this.btnDz = new System.Windows.Forms.Button();
            this.dgvWhys = new System.Windows.Forms.DataGridView();
            this.whys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whysid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGz)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhys)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGz
            // 
            this.dgvGz.AllowUserToAddRows = false;
            this.dgvGz.AllowUserToDeleteRows = false;
            this.dgvGz.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvGz.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGz.BackgroundColor = System.Drawing.Color.White;
            this.dgvGz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGz.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gz,
            this.gzid});
            this.dgvGz.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvGz.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvGz.Location = new System.Drawing.Point(0, 0);
            this.dgvGz.Name = "dgvGz";
            this.dgvGz.ReadOnly = true;
            this.dgvGz.RowHeadersVisible = false;
            this.dgvGz.RowTemplate.Height = 23;
            this.dgvGz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGz.Size = new System.Drawing.Size(205, 524);
            this.dgvGz.TabIndex = 10;
            this.dgvGz.SelectionChanged += new System.EventHandler(this.dgvGz_SelectionChanged);
            // 
            // gz
            // 
            this.gz.DataPropertyName = "xmmc";
            this.gz.HeaderText = "工种";
            this.gz.Name = "gz";
            this.gz.ReadOnly = true;
            this.gz.Width = 200;
            // 
            // gzid
            // 
            this.gzid.DataPropertyName = "bzdm";
            this.gzid.HeaderText = "bzdm";
            this.gzid.Name = "gzid";
            this.gzid.ReadOnly = true;
            this.gzid.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGb);
            this.panel1.Controls.Add(this.btnQxdz);
            this.panel1.Controls.Add(this.btnDz);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(205, 477);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 47);
            this.panel1.TabIndex = 11;
            // 
            // btnGb
            // 
            this.btnGb.Location = new System.Drawing.Point(233, 12);
            this.btnGb.Name = "btnGb";
            this.btnGb.Size = new System.Drawing.Size(75, 23);
            this.btnGb.TabIndex = 1;
            this.btnGb.Text = "关闭(&C)";
            this.btnGb.UseVisualStyleBackColor = true;
            this.btnGb.Click += new System.EventHandler(this.btnGb_Click);
            // 
            // btnQxdz
            // 
            this.btnQxdz.Location = new System.Drawing.Point(138, 12);
            this.btnQxdz.Name = "btnQxdz";
            this.btnQxdz.Size = new System.Drawing.Size(75, 23);
            this.btnQxdz.TabIndex = 1;
            this.btnQxdz.Text = "取消(&Q)";
            this.btnQxdz.UseVisualStyleBackColor = true;
            this.btnQxdz.Click += new System.EventHandler(this.btnQxdz_Click);
            // 
            // btnDz
            // 
            this.btnDz.Location = new System.Drawing.Point(43, 12);
            this.btnDz.Name = "btnDz";
            this.btnDz.Size = new System.Drawing.Size(75, 23);
            this.btnDz.TabIndex = 0;
            this.btnDz.Text = "对照(&D)";
            this.btnDz.UseVisualStyleBackColor = true;
            this.btnDz.Click += new System.EventHandler(this.btnDz_Click);
            // 
            // dgvWhys
            // 
            this.dgvWhys.AllowUserToAddRows = false;
            this.dgvWhys.AllowUserToDeleteRows = false;
            this.dgvWhys.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvWhys.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvWhys.BackgroundColor = System.Drawing.Color.White;
            this.dgvWhys.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWhys.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvWhys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWhys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.whys,
            this.whysid});
            this.dgvWhys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWhys.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvWhys.Location = new System.Drawing.Point(205, 0);
            this.dgvWhys.Name = "dgvWhys";
            this.dgvWhys.ReadOnly = true;
            this.dgvWhys.RowHeadersVisible = false;
            this.dgvWhys.RowTemplate.Height = 23;
            this.dgvWhys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWhys.Size = new System.Drawing.Size(364, 477);
            this.dgvWhys.TabIndex = 12;
            this.dgvWhys.DoubleClick += new System.EventHandler(this.dgvWhys_DoubleClick);
            // 
            // whys
            // 
            this.whys.DataPropertyName = "xmmc";
            this.whys.FillWeight = 300F;
            this.whys.HeaderText = "危害因素";
            this.whys.Name = "whys";
            this.whys.ReadOnly = true;
            this.whys.Width = 300;
            // 
            // whysid
            // 
            this.whysid.DataPropertyName = "bzdm";
            this.whysid.HeaderText = "bzdm";
            this.whysid.Name = "whysid";
            this.whysid.ReadOnly = true;
            this.whysid.Visible = false;
            // 
            // Form_gzwhysdz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 524);
            this.Controls.Add(this.dgvWhys);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvGz);
            this.Name = "Form_gzwhysdz";
            this.Text = "工种、危害因素对照";
            this.Load += new System.EventHandler(this.Form_gzwhysdz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGz)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGz;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvWhys;
        private System.Windows.Forms.Button btnGb;
        private System.Windows.Forms.Button btnQxdz;
        private System.Windows.Forms.Button btnDz;
        private System.Windows.Forms.DataGridViewTextBoxColumn whys;
        private System.Windows.Forms.DataGridViewTextBoxColumn whysid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gz;
        private System.Windows.Forms.DataGridViewTextBoxColumn gzid;
    }
}