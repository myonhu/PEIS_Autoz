namespace PEIS.jkgl
{
    partial class Form_codeprint_data
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
            this.panel = new System.Windows.Forms.Panel();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_print = new System.Windows.Forms.Button();
            this.bt_yl = new System.Windows.Forms.Button();
            this.txt_txm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(7, 34);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(577, 354);
            this.panel.TabIndex = 15;
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(494, 4);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 14;
            this.bt_exit.Text = "�˳�(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_print
            // 
            this.bt_print.Location = new System.Drawing.Point(402, 4);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(75, 23);
            this.bt_print.TabIndex = 13;
            this.bt_print.Text = "��ӡ(&P)";
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // bt_yl
            // 
            this.bt_yl.Location = new System.Drawing.Point(307, 4);
            this.bt_yl.Name = "bt_yl";
            this.bt_yl.Size = new System.Drawing.Size(75, 23);
            this.bt_yl.TabIndex = 12;
            this.bt_yl.Text = "Ԥ��(&Y)";
            this.bt_yl.UseVisualStyleBackColor = true;
            this.bt_yl.Click += new System.EventHandler(this.bt_yl_Click);
            // 
            // txt_txm
            // 
            this.txt_txm.Location = new System.Drawing.Point(82, 5);
            this.txt_txm.Name = "txt_txm";
            this.txt_txm.Size = new System.Drawing.Size(210, 24);
            this.txt_txm.TabIndex = 11;
            this.txt_txm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_txm_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "�����ţ�";
            // 
            // Form_codeprint_data
            // 
            this.ClientSize = new System.Drawing.Size(587, 395);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.bt_yl);
            this.Controls.Add(this.txt_txm);
            this.Controls.Add(this.label1);
            this.Name = "Form_codeprint_data";
            this.Text = "�����ӡ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.Button bt_yl;
        private System.Windows.Forms.TextBox txt_txm;
        private System.Windows.Forms.Label label1;
    }
}
