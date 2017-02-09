namespace PEIS.tjjg
{
    partial class Form_zywj_out
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_zywj_out));
            this.bt_save = new System.Windows.Forms.Button();
            this.txt_nl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_xb = new System.Windows.Forms.ComboBox();
            this.txt_xm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_djlsh = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl_ksjs = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.bt_exit = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_tzjg = new System.Windows.Forms.Label();
            this.txt_ksjs = new PEIS.tjjg.MyTextBox();
            this.SuspendLayout();
            // 
            // bt_save
            // 
            this.bt_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_save.Location = new System.Drawing.Point(544, 4);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(92, 33);
            this.bt_save.TabIndex = 46;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // txt_nl
            // 
            this.txt_nl.Location = new System.Drawing.Point(496, 6);
            this.txt_nl.Name = "txt_nl";
            this.txt_nl.ReadOnly = true;
            this.txt_nl.Size = new System.Drawing.Size(44, 29);
            this.txt_nl.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(445, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "年龄：";
            // 
            // cmb_xb
            // 
            this.cmb_xb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xb.Enabled = false;
            this.cmb_xb.FormattingEnabled = true;
            this.cmb_xb.Location = new System.Drawing.Point(404, 6);
            this.cmb_xb.Name = "cmb_xb";
            this.cmb_xb.Size = new System.Drawing.Size(40, 27);
            this.cmb_xb.TabIndex = 17;
            // 
            // txt_xm
            // 
            this.txt_xm.Location = new System.Drawing.Point(255, 6);
            this.txt_xm.Name = "txt_xm";
            this.txt_xm.ReadOnly = true;
            this.txt_xm.Size = new System.Drawing.Size(97, 29);
            this.txt_xm.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(352, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "性别：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(206, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "姓名：";
            // 
            // txt_djlsh
            // 
            this.txt_djlsh.Location = new System.Drawing.Point(73, 6);
            this.txt_djlsh.Name = "txt_djlsh";
            this.txt_djlsh.ReadOnly = true;
            this.txt_djlsh.Size = new System.Drawing.Size(135, 29);
            this.txt_djlsh.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(5, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 19);
            this.label22.TabIndex = 10;
            this.label22.Text = "流水号：";
            // 
            // lbl_ksjs
            // 
            this.lbl_ksjs.AutoSize = true;
            this.lbl_ksjs.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ksjs.Location = new System.Drawing.Point(730, 10);
            this.lbl_ksjs.Name = "lbl_ksjs";
            this.lbl_ksjs.Size = new System.Drawing.Size(104, 19);
            this.lbl_ksjs.TabIndex = 2;
            this.lbl_ksjs.Text = "快速检索：";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(0, 68);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1016, 673);
            this.tabControl.TabIndex = 0;
            // 
            // bt_exit
            // 
            this.bt_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_exit.Location = new System.Drawing.Point(639, 4);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(92, 33);
            this.bt_exit.TabIndex = 47;
            this.bt_exit.Text = "退出(&X)";
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(959, 4);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(55, 33);
            this.bt_ok.TabIndex = 48;
            this.bt_ok.Text = "确定";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 24);
            this.label1.TabIndex = 49;
            this.label1.Text = "请根据近一年的体验和感觉，回答以下问题：";
            // 
            // lbl_tzjg
            // 
            this.lbl_tzjg.AutoSize = true;
            this.lbl_tzjg.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_tzjg.ForeColor = System.Drawing.Color.Green;
            this.lbl_tzjg.Location = new System.Drawing.Point(575, 52);
            this.lbl_tzjg.Name = "lbl_tzjg";
            this.lbl_tzjg.Size = new System.Drawing.Size(249, 39);
            this.lbl_tzjg.TabIndex = 50;
            this.lbl_tzjg.Text = "您的体质结果为：";
            this.lbl_tzjg.Visible = false;
            // 
            // txt_ksjs
            // 
            this.txt_ksjs.Location = new System.Drawing.Point(817, 6);
            this.txt_ksjs.Name = "txt_ksjs";
            this.txt_ksjs.Size = new System.Drawing.Size(137, 29);
            this.txt_ksjs.TabIndex = 3;
            this.txt_ksjs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ksjs_KeyDown);
            this.txt_ksjs.Leave += new System.EventHandler(this.txt_ksjs_Leave);
            this.txt_ksjs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_ksjs_MouseDown);
            this.txt_ksjs.Enter += new System.EventHandler(this.txt_ksjs_Enter);
            // 
            // Form_zywj_out
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.lbl_tzjg);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.txt_nl);
            this.Controls.Add(this.txt_ksjs);
            this.Controls.Add(this.cmb_xb);
            this.Controls.Add(this.txt_djlsh);
            this.Controls.Add(this.txt_xm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl_ksjs);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("宋体", 14F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 100);
            this.Name = "Form_zywj_out";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "藏医体质学问卷";
            this.Load += new System.EventHandler(this.Form_zywj_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_zywj_out_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private MyTextBox txt_ksjs;
        private System.Windows.Forms.Label lbl_ksjs;
        private System.Windows.Forms.TextBox txt_djlsh;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmb_xb;
        private System.Windows.Forms.TextBox txt_xm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_tzjg;


    }
}