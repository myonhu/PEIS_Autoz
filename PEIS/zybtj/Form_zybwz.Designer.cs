namespace PEIS.zybtj
{
    partial class Form_zybwz
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
            this.dgvZz = new System.Windows.Forms.DataGridView();
            this.xm1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jg1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jg2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jg3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbYs = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.dtpJcrq = new System.Windows.Forms.DateTimePicker();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZz)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvZz
            // 
            this.dgvZz.AllowUserToAddRows = false;
            this.dgvZz.AllowUserToDeleteRows = false;
            this.dgvZz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvZz.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvZz.BackgroundColor = System.Drawing.Color.White;
            this.dgvZz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xm1,
            this.jg1,
            this.xm2,
            this.jg2,
            this.xm3,
            this.jg3});
            this.dgvZz.Location = new System.Drawing.Point(3, 35);
            this.dgvZz.Name = "dgvZz";
            this.dgvZz.ReadOnly = true;
            this.dgvZz.RowHeadersVisible = false;
            this.dgvZz.RowTemplate.Height = 23;
            this.dgvZz.Size = new System.Drawing.Size(557, 471);
            this.dgvZz.TabIndex = 10;
            this.dgvZz.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZz_CellClick);
            // 
            // xm1
            // 
            this.xm1.DataPropertyName = "xm1";
            this.xm1.HeaderText = "项 目";
            this.xm1.Name = "xm1";
            this.xm1.ReadOnly = true;
            this.xm1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.xm1.Width = 51;
            // 
            // jg1
            // 
            this.jg1.DataPropertyName = "jg1";
            this.jg1.HeaderText = "结 果";
            this.jg1.Name = "jg1";
            this.jg1.ReadOnly = true;
            this.jg1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.jg1.Width = 51;
            // 
            // xm2
            // 
            this.xm2.DataPropertyName = "xm2";
            this.xm2.HeaderText = "项 目";
            this.xm2.Name = "xm2";
            this.xm2.ReadOnly = true;
            this.xm2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.xm2.Width = 51;
            // 
            // jg2
            // 
            this.jg2.DataPropertyName = "jg2";
            this.jg2.HeaderText = "结 果";
            this.jg2.Name = "jg2";
            this.jg2.ReadOnly = true;
            this.jg2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.jg2.Width = 51;
            // 
            // xm3
            // 
            this.xm3.DataPropertyName = "xm3";
            this.xm3.HeaderText = "项 目";
            this.xm3.Name = "xm3";
            this.xm3.ReadOnly = true;
            this.xm3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.xm3.Width = 51;
            // 
            // jg3
            // 
            this.jg3.DataPropertyName = "jg3";
            this.jg3.HeaderText = "结 果";
            this.jg3.Name = "jg3";
            this.jg3.ReadOnly = true;
            this.jg3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.jg3.Width = 51;
            // 
            // cmbYs
            // 
            this.cmbYs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYs.FormattingEnabled = true;
            this.cmbYs.Location = new System.Drawing.Point(279, 5);
            this.cmbYs.Name = "cmbYs";
            this.cmbYs.Size = new System.Drawing.Size(119, 23);
            this.cmbYs.TabIndex = 11;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(207, 9);
            this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(67, 15);
            this.label53.TabIndex = 7;
            this.label53.Text = "医生签名";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(8, 9);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(67, 15);
            this.label52.TabIndex = 8;
            this.label52.Text = "检查日期";
            // 
            // dtpJcrq
            // 
            this.dtpJcrq.Location = new System.Drawing.Point(80, 4);
            this.dtpJcrq.Name = "dtpJcrq";
            this.dtpJcrq.Size = new System.Drawing.Size(117, 24);
            this.dtpJcrq.TabIndex = 9;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(485, 5);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 12;
            this.btn_close.Text = "关闭(&E)";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(404, 5);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 13;
            this.btn_save.Text = "保存(&S)";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Form_zybwz
            // 
            this.ClientSize = new System.Drawing.Size(566, 510);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dgvZz);
            this.Controls.Add(this.cmbYs);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.dtpJcrq);
            this.Name = "Form_zybwz";
            this.Text = "问诊";
            this.Load += new System.EventHandler(this.Form_zybwz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvZz;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jg1;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm2;
        private System.Windows.Forms.DataGridViewTextBoxColumn jg2;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm3;
        private System.Windows.Forms.DataGridViewTextBoxColumn jg3;
        private System.Windows.Forms.ComboBox cmbYs;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.DateTimePicker dtpJcrq;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
    }
}
