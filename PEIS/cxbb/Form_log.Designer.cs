namespace PEIS.cxbb
{
    partial class Form_log
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_select = new System.Windows.Forms.Button();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_begin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.event_content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_export = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_export);
            this.groupBox1.Controls.Add(this.bt_exit);
            this.groupBox1.Controls.Add(this.bt_select);
            this.groupBox1.Controls.Add(this.dtp_end);
            this.groupBox1.Controls.Add(this.dtp_begin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检索条件";
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(732, 34);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 49;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(552, 34);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(75, 23);
            this.bt_select.TabIndex = 48;
            this.bt_select.Text = "检索(&S)";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd";
            this.dtp_end.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(295, 35);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(116, 23);
            this.dtp_end.TabIndex = 39;
            // 
            // dtp_begin
            // 
            this.dtp_begin.CustomFormat = "yyyy-MM-dd";
            this.dtp_begin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_begin.Location = new System.Drawing.Point(141, 35);
            this.dtp_begin.Name = "dtp_begin";
            this.dtp_begin.Size = new System.Drawing.Size(116, 23);
            this.dtp_begin.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = "日志记录日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "至";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.event_content,
            this.bz,
            this.rq,
            this.czy});
            this.dataGridView1.Location = new System.Drawing.Point(2, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(864, 511);
            this.dataGridView1.TabIndex = 1;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.FillWeight = 24.83171F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // event_content
            // 
            this.event_content.DataPropertyName = "event_content";
            this.event_content.FillWeight = 116.0882F;
            this.event_content.HeaderText = "日志内容";
            this.event_content.Name = "event_content";
            this.event_content.ReadOnly = true;
            // 
            // bz
            // 
            this.bz.DataPropertyName = "bz";
            this.bz.FillWeight = 126.9036F;
            this.bz.HeaderText = "日志类型";
            this.bz.Name = "bz";
            this.bz.ReadOnly = true;
            // 
            // rq
            // 
            this.rq.DataPropertyName = "rq";
            this.rq.FillWeight = 116.0882F;
            this.rq.HeaderText = "日志日期";
            this.rq.Name = "rq";
            this.rq.ReadOnly = true;
            // 
            // czy
            // 
            this.czy.DataPropertyName = "czy";
            this.czy.FillWeight = 116.0882F;
            this.czy.HeaderText = "操作人员";
            this.czy.Name = "czy";
            this.czy.ReadOnly = true;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(642, 34);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 50;
            this.btn_export.Text = "导出(&P)";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // Form_log
            // 
            this.ClientSize = new System.Drawing.Size(870, 599);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_log";
            this.Text = "系统日志";
            this.Load += new System.EventHandler(this.Form_yxjghz_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_begin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_select;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn event_content;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn rq;
        private System.Windows.Forms.DataGridViewTextBoxColumn czy;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
