namespace PEIS.ywsz
{
    partial class Form_zhxmxz
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tv_tjlxb = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tv_tjlxb);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 524);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "��������Ŀ";
            // 
            // tv_tjlxb
            // 
            this.tv_tjlxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_tjlxb.Location = new System.Drawing.Point(3, 20);
            this.tv_tjlxb.Name = "tv_tjlxb";
            this.tv_tjlxb.Size = new System.Drawing.Size(269, 501);
            this.tv_tjlxb.TabIndex = 0;
            this.tv_tjlxb.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_tjlxb_NodeMouseDoubleClick);
            // 
            // Form_zhxmxz
            // 
            this.ClientSize = new System.Drawing.Size(279, 528);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_zhxmxz";
            this.Text = "�����Ŀѡ��";
            this.Load += new System.EventHandler(this.Form_zhxmxz_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tv_tjlxb;
    }
}
