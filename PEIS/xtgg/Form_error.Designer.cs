namespace PEIS
{
    partial class Form_error
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_error = new System.Windows.Forms.TextBox();
            this.bt_fs = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_error
            // 
            this.txt_error.Location = new System.Drawing.Point(3, 51);
            this.txt_error.Multiline = true;
            this.txt_error.Name = "txt_error";
            this.txt_error.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_error.Size = new System.Drawing.Size(510, 216);
            this.txt_error.TabIndex = 0;
            // 
            // bt_fs
            // 
            this.bt_fs.Location = new System.Drawing.Point(285, 273);
            this.bt_fs.Name = "bt_fs";
            this.bt_fs.Size = new System.Drawing.Size(221, 23);
            this.bt_fs.TabIndex = 1;
            this.bt_fs.Text = "����-����(&E)";
            this.bt_fs.UseVisualStyleBackColor = true;
            this.bt_fs.Click += new System.EventHandler(this.bt_fs_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(8, 273);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(200, 23);
            this.bt_exit.TabIndex = 3;
            this.bt_exit.Text = "�رճ���-���µ�¼(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ӧ�ó�������ʱ���������ڴ����Ƕ����Ĺ�����ɵĲ������Ǹ�⣬��ϣ������ʱ������ϵͳ����Ա������ϵ����ʱ�������ҹ�˾��\r\n                    " +
                "                      �ɶ�ŷ�׸߿Ƽ�";
            // 
            // Form_error
            // 
            this.ClientSize = new System.Drawing.Size(518, 303);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_fs);
            this.Controls.Add(this.txt_error);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_error";
            this.Text = "Ӧ�ó���������";
            this.Load += new System.EventHandler(this.Form_error_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_error;
        private System.Windows.Forms.Button bt_fs;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Label label1;
    }
}
