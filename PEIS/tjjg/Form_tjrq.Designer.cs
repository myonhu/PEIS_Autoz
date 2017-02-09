namespace PEIS.tjjg
{
    partial class Form_tjrq
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
            this.bt_qx = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.dtp_tjdjrq = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_qx
            // 
            this.bt_qx.Location = new System.Drawing.Point(170, 70);
            this.bt_qx.Name = "bt_qx";
            this.bt_qx.Size = new System.Drawing.Size(75, 23);
            this.bt_qx.TabIndex = 11;
            this.bt_qx.Text = "取消(&C)";
            this.bt_qx.UseVisualStyleBackColor = true;
            this.bt_qx.Click += new System.EventHandler(this.bt_qx_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(63, 70);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 10;
            this.bt_ok.Text = "确定(&O)";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // dtp_tjdjrq
            // 
            this.dtp_tjdjrq.CustomFormat = "yyyy-MM-dd";
            this.dtp_tjdjrq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_tjdjrq.Location = new System.Drawing.Point(153, 28);
            this.dtp_tjdjrq.Name = "dtp_tjdjrq";
            this.dtp_tjdjrq.Size = new System.Drawing.Size(107, 24);
            this.dtp_tjdjrq.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "登记体检日期：";
            // 
            // Form_tjrq
            // 
            this.ClientSize = new System.Drawing.Size(309, 118);
            this.Controls.Add(this.bt_qx);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.dtp_tjdjrq);
            this.Controls.Add(this.label1);
            this.Name = "Form_tjrq";
            this.Text = "体检日期选择";
            this.Load += new System.EventHandler(this.Form_tjrq_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_qx;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.DateTimePicker dtp_tjdjrq;
        private System.Windows.Forms.Label label1;
    }
}
