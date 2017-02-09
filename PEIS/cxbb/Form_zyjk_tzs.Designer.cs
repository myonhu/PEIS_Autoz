namespace PEIS.cxbb
{
    partial class Form_zyjk_tzs
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
            this.txt_tjdw = new System.Windows.Forms.TextBox();
            this.bt_tjdw = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_begin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_print = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_select = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_whys = new System.Windows.Forms.Button();
            this.txt_whys = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_tjdw
            // 
            this.txt_tjdw.Enabled = false;
            this.txt_tjdw.Location = new System.Drawing.Point(403, 21);
            this.txt_tjdw.Name = "txt_tjdw";
            this.txt_tjdw.Size = new System.Drawing.Size(163, 24);
            this.txt_tjdw.TabIndex = 50;
            // 
            // bt_tjdw
            // 
            this.bt_tjdw.Location = new System.Drawing.Point(569, 21);
            this.bt_tjdw.Name = "bt_tjdw";
            this.bt_tjdw.Size = new System.Drawing.Size(31, 23);
            this.bt_tjdw.TabIndex = 51;
            this.bt_tjdw.Text = "…";
            this.bt_tjdw.UseVisualStyleBackColor = true;
            this.bt_tjdw.Click += new System.EventHandler(this.bt_tjdw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 49;
            this.label2.Text = "体检单位：";
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd";
            this.dtp_end.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(209, 22);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(116, 23);
            this.dtp_end.TabIndex = 46;
            // 
            // dtp_begin
            // 
            this.dtp_begin.CustomFormat = "yyyy-MM-dd";
            this.dtp_begin.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_begin.Location = new System.Drawing.Point(73, 22);
            this.dtp_begin.Name = "dtp_begin";
            this.dtp_begin.Size = new System.Drawing.Size(116, 23);
            this.dtp_begin.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 47;
            this.label6.Text = "体检日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "至";
            // 
            // bt_print
            // 
            this.bt_print.Location = new System.Drawing.Point(798, 21);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(75, 23);
            this.bt_print.TabIndex = 55;
            this.bt_print.Text = "打印(&P)";
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(879, 21);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 54;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(717, 21);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(75, 23);
            this.bt_select.TabIndex = 53;
            this.bt_select.Text = "检索(&S)";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_whys);
            this.panel1.Controls.Add(this.txt_whys);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtp_begin);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.bt_print);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.bt_exit);
            this.panel1.Controls.Add(this.bt_select);
            this.panel1.Controls.Add(this.dtp_end);
            this.panel1.Controls.Add(this.txt_tjdw);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_tjdw);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 90);
            this.panel1.TabIndex = 56;
            // 
            // btn_whys
            // 
            this.btn_whys.Location = new System.Drawing.Point(569, 54);
            this.btn_whys.Name = "btn_whys";
            this.btn_whys.Size = new System.Drawing.Size(31, 23);
            this.btn_whys.TabIndex = 58;
            this.btn_whys.Text = "…";
            this.btn_whys.UseVisualStyleBackColor = true;
            this.btn_whys.Click += new System.EventHandler(this.btn_whys_Click);
            // 
            // txt_whys
            // 
            this.txt_whys.Location = new System.Drawing.Point(403, 54);
            this.txt_whys.Name = "txt_whys";
            this.txt_whys.Size = new System.Drawing.Size(163, 24);
            this.txt_whys.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 56;
            this.label1.Text = "危害因素：";
            // 
            // reportView
            // 
            this.reportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportView.Location = new System.Drawing.Point(0, 90);
            this.reportView.Name = "reportView";
            this.reportView.Size = new System.Drawing.Size(957, 506);
            this.reportView.TabIndex = 57;
            // 
            // Form_zyjk_tzs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 596);
            this.Controls.Add(this.reportView);
            this.Controls.Add(this.panel1);
            this.Name = "Form_zyjk_tzs";
            this.Text = "职业健康检查结果通知书";
            this.Load += new System.EventHandler(this.Form_zyjk_tzs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_tjdw;
        private System.Windows.Forms.Button bt_tjdw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_begin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_select;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportView;
        private System.Windows.Forms.Button btn_whys;
        private System.Windows.Forms.TextBox txt_whys;
        private System.Windows.Forms.Label label1;
    }
}