namespace PEIS.jkgl
{
    partial class Form_jgagain
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
            this.txt_djlsh = new System.Windows.Forms.TextBox();
            this.bt_find = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_xm = new System.Windows.Forms.TextBox();
            this.txt_nl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_xb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_return = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_zhxm = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "�Ǽ���ˮ��:";
            // 
            // txt_djlsh
            // 
            this.txt_djlsh.Location = new System.Drawing.Point(204, 42);
            this.txt_djlsh.Name = "txt_djlsh";
            this.txt_djlsh.Size = new System.Drawing.Size(172, 24);
            this.txt_djlsh.TabIndex = 1;
            // 
            // bt_find
            // 
            this.bt_find.Location = new System.Drawing.Point(383, 42);
            this.bt_find.Name = "bt_find";
            this.bt_find.Size = new System.Drawing.Size(75, 23);
            this.bt_find.TabIndex = 2;
            this.bt_find.Text = "����(&C)";
            this.bt_find.UseVisualStyleBackColor = true;
            this.bt_find.Click += new System.EventHandler(this.bt_find_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "������";
            // 
            // txt_xm
            // 
            this.txt_xm.Location = new System.Drawing.Point(204, 82);
            this.txt_xm.Name = "txt_xm";
            this.txt_xm.ReadOnly = true;
            this.txt_xm.Size = new System.Drawing.Size(172, 24);
            this.txt_xm.TabIndex = 4;
            // 
            // txt_nl
            // 
            this.txt_nl.Location = new System.Drawing.Point(204, 121);
            this.txt_nl.Name = "txt_nl";
            this.txt_nl.ReadOnly = true;
            this.txt_nl.Size = new System.Drawing.Size(172, 24);
            this.txt_nl.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "���䣺";
            // 
            // txt_xb
            // 
            this.txt_xb.Location = new System.Drawing.Point(204, 161);
            this.txt_xb.Name = "txt_xb";
            this.txt_xb.ReadOnly = true;
            this.txt_xb.Size = new System.Drawing.Size(172, 24);
            this.txt_xb.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "�Ա�";
            // 
            // bt_return
            // 
            this.bt_return.Location = new System.Drawing.Point(167, 237);
            this.bt_return.Name = "bt_return";
            this.bt_return.Size = new System.Drawing.Size(222, 37);
            this.bt_return.TabIndex = 9;
            this.bt_return.Text = "�������»�ȡ���";
            this.bt_return.UseVisualStyleBackColor = true;
            this.bt_return.Click += new System.EventHandler(this.bt_return_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "��Ŀ��";
            // 
            // cmb_zhxm
            // 
            this.cmb_zhxm.FormattingEnabled = true;
            this.cmb_zhxm.Location = new System.Drawing.Point(204, 198);
            this.cmb_zhxm.Name = "cmb_zhxm";
            this.cmb_zhxm.Size = new System.Drawing.Size(172, 23);
            this.cmb_zhxm.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(593, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "˵����������Ŀ��Ϣ����Ҫ�ȴ����ݵ����»�ȡ����Լ10���ӣ���Ȼ���ٴε��룡����";
            // 
            // Form_jgagain
            // 
            this.ClientSize = new System.Drawing.Size(598, 286);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_zhxm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bt_return);
            this.Controls.Add(this.txt_xb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_nl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_xm);
            this.Controls.Add(this.bt_find);
            this.Controls.Add(this.txt_djlsh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Form_jgagain";
            this.Text = "����������»�ȡ";
            this.Load += new System.EventHandler(this.Form_jgagain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_djlsh;
        private System.Windows.Forms.Button bt_find;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_xm;
        private System.Windows.Forms.TextBox txt_nl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_xb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_return;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_zhxm;
        private System.Windows.Forms.Label label6;
    }
}
