namespace PEIS.cxbb
{
    partial class Form_gztjb
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_print = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.dtp_begin = new System.Windows.Forms.DateTimePicker();
            this.bt_select = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.reportView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_print);
            this.panel1.Controls.Add(this.bt_exit);
            this.panel1.Controls.Add(this.dtp_begin);
            this.panel1.Controls.Add(this.bt_select);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtp_end);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 61);
            this.panel1.TabIndex = 0;
            // 
            // bt_print
            // 
            this.bt_print.Location = new System.Drawing.Point(502, 15);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(75, 23);
            this.bt_print.TabIndex = 58;
            this.bt_print.Text = "打印(&P)";
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(625, 15);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 57;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // dtp_begin
            // 
            this.dtp_begin.CustomFormat = "yyyy-MM-dd";
            this.dtp_begin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_begin.Location = new System.Drawing.Point(83, 15);
            this.dtp_begin.Name = "dtp_begin";
            this.dtp_begin.Size = new System.Drawing.Size(116, 23);
            this.dtp_begin.TabIndex = 49;
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(379, 15);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(75, 23);
            this.bt_select.TabIndex = 56;
            this.bt_select.Text = "检索(&S)";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 51;
            this.label6.Text = "体检日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 52;
            this.label7.Text = "至";
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd";
            this.dtp_end.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(219, 15);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(116, 23);
            this.dtp_end.TabIndex = 50;
            // 
            // reportView
            // 
            this.reportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportView.Location = new System.Drawing.Point(0, 61);
            this.reportView.Name = "reportView";
            this.reportView.Size = new System.Drawing.Size(944, 515);
            this.reportView.TabIndex = 1;
            // 
            // Form_gztjb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 576);
            this.Controls.Add(this.reportView);
            this.Controls.Add(this.panel1);
            this.Name = "Form_gztjb";
            this.Text = "工作统计表";
            this.Load += new System.EventHandler(this.Form_gztjb_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtp_begin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_select;
        private Microsoft.Reporting.WinForms.ReportViewer reportView;
    }
}