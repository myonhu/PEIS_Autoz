namespace PEIS.jkgl
{
    partial class Form_gxdz
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
            this.label1 = new System.Windows.Forms.Label();
            this.bt_gx = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "˵�����������˶�����ʱ����Ҫ���¶�����Ϣ��";
            // 
            // bt_gx
            // 
            this.bt_gx.Location = new System.Drawing.Point(118, 41);
            this.bt_gx.Name = "bt_gx";
            this.bt_gx.Size = new System.Drawing.Size(75, 23);
            this.bt_gx.TabIndex = 1;
            this.bt_gx.Text = "����(&G)";
            this.bt_gx.UseVisualStyleBackColor = true;
            this.bt_gx.Click += new System.EventHandler(this.bt_gx_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(209, 41);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 2;
            this.bt_exit.Text = "�˳�(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // Form_gxdz
            // 
            this.ClientSize = new System.Drawing.Size(410, 85);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_gx);
            this.Controls.Add(this.label1);
            this.Name = "Form_gxdz";
            this.Text = "���¶�����Ŀ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_gx;
        private System.Windows.Forms.Button bt_exit;
    }
}
