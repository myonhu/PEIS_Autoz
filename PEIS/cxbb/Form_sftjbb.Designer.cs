namespace PEIS.cxbb
{
    partial class Form_sftjbb
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
            this.bt_print = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_select = new System.Windows.Forms.Button();
            this.txt_tjdw = new System.Windows.Forms.TextBox();
            this.bt_tjdw = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_begin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.reportView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_print);
            this.groupBox1.Controls.Add(this.bt_exit);
            this.groupBox1.Controls.Add(this.bt_select);
            this.groupBox1.Controls.Add(this.txt_tjdw);
            this.groupBox1.Controls.Add(this.bt_tjdw);
            this.groupBox1.Controls.Add(this.label2);
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
            // bt_print
            // 
            this.bt_print.Location = new System.Drawing.Point(621, 29);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(75, 23);
            this.bt_print.TabIndex = 52;
            this.bt_print.Text = "打印(&P)";
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(736, 29);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 49;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(497, 29);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(75, 23);
            this.bt_select.TabIndex = 48;
            this.bt_select.Text = "检索(&S)";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // txt_tjdw
            // 
            this.txt_tjdw.Location = new System.Drawing.Point(85, 48);
            this.txt_tjdw.Name = "txt_tjdw";
            this.txt_tjdw.Size = new System.Drawing.Size(239, 24);
            this.txt_tjdw.TabIndex = 43;
            // 
            // bt_tjdw
            // 
            this.bt_tjdw.Location = new System.Drawing.Point(331, 48);
            this.bt_tjdw.Name = "bt_tjdw";
            this.bt_tjdw.Size = new System.Drawing.Size(25, 23);
            this.bt_tjdw.TabIndex = 44;
            this.bt_tjdw.Text = "…";
            this.bt_tjdw.UseVisualStyleBackColor = true;
            this.bt_tjdw.Click += new System.EventHandler(this.bt_tjdw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 42;
            this.label2.Text = "体检单位：";
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd";
            this.dtp_end.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(240, 16);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(116, 23);
            this.dtp_end.TabIndex = 39;
            // 
            // dtp_begin
            // 
            this.dtp_begin.CustomFormat = "yyyy-MM-dd";
            this.dtp_begin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_begin.Location = new System.Drawing.Point(86, 16);
            this.dtp_begin.Name = "dtp_begin";
            this.dtp_begin.Size = new System.Drawing.Size(116, 23);
            this.dtp_begin.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = "收费日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "至";
            // 
            // reportView
            // 
            this.reportView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportView.Location = new System.Drawing.Point(2, 85);
            this.reportView.Name = "reportView";
            this.reportView.Size = new System.Drawing.Size(864, 570);
            this.reportView.TabIndex = 1;
            // 
            // Form_sftjbb
            // 
            this.ClientSize = new System.Drawing.Size(870, 651);
            this.Controls.Add(this.reportView);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_sftjbb";
            this.Text = "体检收费统计报表";
            this.Load += new System.EventHandler(this.Form_yxjghz_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_begin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_tjdw;
        private System.Windows.Forms.Button bt_tjdw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_select;
        private Microsoft.Reporting.WinForms.ReportViewer reportView;
        private System.Windows.Forms.Button bt_print;
    }
}
