namespace PEIS
{
    partial class Form_xtjcsjinsert
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
            this.txt_xh = new System.Windows.Forms.TextBox();
            this.txt_bzdm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_xmmc = new System.Windows.Forms.TextBox();
            this.ck_sfty = new System.Windows.Forms.CheckBox();
            this.bt_ok = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "��    �ţ�";
            // 
            // txt_xh
            // 
            this.txt_xh.Location = new System.Drawing.Point(76, 36);
            this.txt_xh.Name = "txt_xh";
            this.txt_xh.ReadOnly = true;
            this.txt_xh.Size = new System.Drawing.Size(70, 24);
            this.txt_xh.TabIndex = 1;
            // 
            // txt_bzdm
            // 
            this.txt_bzdm.Location = new System.Drawing.Point(225, 36);
            this.txt_bzdm.Name = "txt_bzdm";
            this.txt_bzdm.Size = new System.Drawing.Size(107, 24);
            this.txt_bzdm.TabIndex = 3;
            this.txt_bzdm.Leave += new System.EventHandler(this.txt_bzdm_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "��׼���룺";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "��Ŀ���ƣ�";
            // 
            // txt_xmmc
            // 
            this.txt_xmmc.Location = new System.Drawing.Point(76, 68);
            this.txt_xmmc.Name = "txt_xmmc";
            this.txt_xmmc.Size = new System.Drawing.Size(256, 24);
            this.txt_xmmc.TabIndex = 5;
            // 
            // ck_sfty
            // 
            this.ck_sfty.AutoSize = true;
            this.ck_sfty.Location = new System.Drawing.Point(246, 8);
            this.ck_sfty.Name = "ck_sfty";
            this.ck_sfty.Size = new System.Drawing.Size(86, 19);
            this.ck_sfty.TabIndex = 6;
            this.ck_sfty.Text = "�Ƿ�ͣ��";
            this.ck_sfty.UseVisualStyleBackColor = true;
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(78, 108);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 7;
            this.bt_ok.Text = "ȷ��(&O)";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Location = new System.Drawing.Point(177, 108);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(75, 23);
            this.bt_exit.TabIndex = 8;
            this.bt_exit.Text = "�˳�(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "��    ��";
            // 
            // cmbLb
            // 
            this.cmbLb.FormattingEnabled = true;
            this.cmbLb.Location = new System.Drawing.Point(76, 6);
            this.cmbLb.Name = "cmbLb";
            this.cmbLb.Size = new System.Drawing.Size(164, 23);
            this.cmbLb.TabIndex = 9;
            // 
            // Form_xtjcsjinsert
            // 
            this.ClientSize = new System.Drawing.Size(347, 142);
            this.Controls.Add(this.cmbLb);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.ck_sfty);
            this.Controls.Add(this.txt_xmmc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_bzdm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_xh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "Form_xtjcsjinsert";
            this.Text = "�ֵ���ϸ���";
            this.Load += new System.EventHandler(this.Form_zdxmlr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_xh;
        private System.Windows.Forms.TextBox txt_bzdm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_xmmc;
        private System.Windows.Forms.CheckBox ck_sfty;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLb;
    }
}
