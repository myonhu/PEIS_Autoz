namespace PEIS.cxgl
{
    partial class Form_tjdwcx
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtZjm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxQy = new System.Windows.Forms.CheckBox();
            this.dgvTjdw = new System.Windows.Forms.DataGridView();
            this.bh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dwfzr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxdh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxdz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yzbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ywyy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yhzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jjlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qygm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jzrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scgrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yhzyrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTjdw)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtZjm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxQy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 62);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(710, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(589, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(101, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印监护卡";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(486, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询(&S)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtZjm
            // 
            this.txtZjm.Location = new System.Drawing.Point(203, 18);
            this.txtZjm.Name = "txtZjm";
            this.txtZjm.Size = new System.Drawing.Size(223, 24);
            this.txtZjm.TabIndex = 1;
            this.txtZjm.TextChanged += new System.EventHandler(this.txtZjm_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "助记码";
            // 
            // cbxQy
            // 
            this.cbxQy.AutoSize = true;
            this.cbxQy.Checked = true;
            this.cbxQy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxQy.Location = new System.Drawing.Point(48, 21);
            this.cbxQy.Name = "cbxQy";
            this.cbxQy.Size = new System.Drawing.Size(56, 19);
            this.cbxQy.TabIndex = 0;
            this.cbxQy.Text = "启用";
            this.cbxQy.UseVisualStyleBackColor = true;
            // 
            // dgvTjdw
            // 
            this.dgvTjdw.AllowUserToAddRows = false;
            this.dgvTjdw.AllowUserToDeleteRows = false;
            this.dgvTjdw.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvTjdw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTjdw.BackgroundColor = System.Drawing.Color.White;
            this.dgvTjdw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTjdw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTjdw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTjdw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bh,
            this.mc,
            this.dwfzr,
            this.lxdh,
            this.lxdz,
            this.yzbm,
            this.ywyy,
            this.yhzh,
            this.jjlx,
            this.hy,
            this.qygm,
            this.jzrs,
            this.scgrs,
            this.yhzyrs,
            this.bz});
            this.dgvTjdw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTjdw.Location = new System.Drawing.Point(0, 62);
            this.dgvTjdw.Name = "dgvTjdw";
            this.dgvTjdw.ReadOnly = true;
            this.dgvTjdw.RowHeadersVisible = false;
            this.dgvTjdw.RowTemplate.Height = 23;
            this.dgvTjdw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTjdw.Size = new System.Drawing.Size(923, 471);
            this.dgvTjdw.TabIndex = 30;
            // 
            // bh
            // 
            this.bh.DataPropertyName = "bh";
            this.bh.HeaderText = "单位编号";
            this.bh.Name = "bh";
            this.bh.ReadOnly = true;
            this.bh.Visible = false;
            this.bh.Width = 61;
            // 
            // mc
            // 
            this.mc.DataPropertyName = "mc";
            this.mc.HeaderText = "单位名称";
            this.mc.Name = "mc";
            this.mc.ReadOnly = true;
            // 
            // dwfzr
            // 
            this.dwfzr.DataPropertyName = "dwfzr";
            this.dwfzr.HeaderText = "负责人";
            this.dwfzr.Name = "dwfzr";
            this.dwfzr.ReadOnly = true;
            // 
            // lxdh
            // 
            this.lxdh.DataPropertyName = "lxdh";
            this.lxdh.HeaderText = "联系电话";
            this.lxdh.Name = "lxdh";
            this.lxdh.ReadOnly = true;
            // 
            // lxdz
            // 
            this.lxdz.DataPropertyName = "lxdz";
            this.lxdz.HeaderText = "联系地址";
            this.lxdz.Name = "lxdz";
            this.lxdz.ReadOnly = true;
            // 
            // yzbm
            // 
            this.yzbm.DataPropertyName = "yzbm";
            this.yzbm.HeaderText = "邮政编码";
            this.yzbm.Name = "yzbm";
            this.yzbm.ReadOnly = true;
            // 
            // ywyy
            // 
            this.ywyy.DataPropertyName = "ywyy";
            this.ywyy.HeaderText = "业务银行";
            this.ywyy.Name = "ywyy";
            this.ywyy.ReadOnly = true;
            // 
            // yhzh
            // 
            this.yhzh.DataPropertyName = "yhzh";
            this.yhzh.HeaderText = "银行账号";
            this.yhzh.Name = "yhzh";
            this.yhzh.ReadOnly = true;
            // 
            // jjlx
            // 
            this.jjlx.DataPropertyName = "jjlx";
            this.jjlx.HeaderText = "经济类型";
            this.jjlx.Name = "jjlx";
            this.jjlx.ReadOnly = true;
            // 
            // hy
            // 
            this.hy.DataPropertyName = "hy";
            this.hy.HeaderText = "行业";
            this.hy.Name = "hy";
            this.hy.ReadOnly = true;
            // 
            // qygm
            // 
            this.qygm.DataPropertyName = "qygm";
            this.qygm.HeaderText = "企业规模";
            this.qygm.Name = "qygm";
            this.qygm.ReadOnly = true;
            // 
            // jzrs
            // 
            this.jzrs.DataPropertyName = "jzrs";
            this.jzrs.HeaderText = "职工人数";
            this.jzrs.Name = "jzrs";
            this.jzrs.ReadOnly = true;
            // 
            // scgrs
            // 
            this.scgrs.DataPropertyName = "scgrs";
            this.scgrs.HeaderText = "生产人数";
            this.scgrs.Name = "scgrs";
            this.scgrs.ReadOnly = true;
            // 
            // yhzyrs
            // 
            this.yhzyrs.DataPropertyName = "yhzyrs";
            this.yhzyrs.HeaderText = "有害作业人数";
            this.yhzyrs.Name = "yhzyrs";
            this.yhzyrs.ReadOnly = true;
            this.yhzyrs.Width = 150;
            // 
            // bz
            // 
            this.bz.DataPropertyName = "bz";
            this.bz.HeaderText = "备注";
            this.bz.Name = "bz";
            this.bz.ReadOnly = true;
            // 
            // Form_tjdwcx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 533);
            this.Controls.Add(this.dgvTjdw);
            this.Controls.Add(this.panel1);
            this.Name = "Form_tjdwcx";
            this.Text = "体检单位查询";
            this.Load += new System.EventHandler(this.Form_tjdwcx_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTjdw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxQy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtZjm;
        private System.Windows.Forms.DataGridView dgvTjdw;
        private System.Windows.Forms.DataGridViewTextBoxColumn bh;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dwfzr;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxdh;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxdz;
        private System.Windows.Forms.DataGridViewTextBoxColumn yzbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ywyy;
        private System.Windows.Forms.DataGridViewTextBoxColumn yhzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn jjlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn hy;
        private System.Windows.Forms.DataGridViewTextBoxColumn qygm;
        private System.Windows.Forms.DataGridViewTextBoxColumn jzrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn scgrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn yhzyrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
    }
}