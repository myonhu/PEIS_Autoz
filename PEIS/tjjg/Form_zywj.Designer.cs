namespace PEIS.tjjg
{
    partial class Form_zywj
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
            System.Windows.Forms.Button bt_insert;
            System.Windows.Forms.Button bt_edit;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_zywj));
            this.bt_print = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.txt_nl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_xb = new System.Windows.Forms.ComboBox();
            this.txt_xm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_djlsh = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_ksjs = new PEIS.tjjg.MyTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_tzjg = new System.Windows.Forms.Label();
            bt_insert = new System.Windows.Forms.Button();
            bt_edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_insert
            // 
            bt_insert.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            bt_insert.ForeColor = System.Drawing.Color.Red;
            bt_insert.Location = new System.Drawing.Point(5, 1);
            bt_insert.Name = "bt_insert";
            bt_insert.Size = new System.Drawing.Size(33, 31);
            bt_insert.TabIndex = 48;
            bt_insert.Text = "增";
            bt_insert.UseVisualStyleBackColor = true;
            bt_insert.Click += new System.EventHandler(this.bt_insert_Click);
            // 
            // bt_edit
            // 
            bt_edit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            bt_edit.ForeColor = System.Drawing.Color.Red;
            bt_edit.Location = new System.Drawing.Point(38, 1);
            bt_edit.Name = "bt_edit";
            bt_edit.Size = new System.Drawing.Size(33, 31);
            bt_edit.TabIndex = 49;
            bt_edit.Text = "改";
            bt_edit.UseVisualStyleBackColor = true;
            bt_edit.Click += new System.EventHandler(this.bt_edit_Click);
            // 
            // bt_print
            // 
            this.bt_print.Location = new System.Drawing.Point(770, 5);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(73, 23);
            this.bt_print.TabIndex = 47;
            this.bt_print.Text = "打印(&P)";
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(694, 5);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(73, 23);
            this.bt_save.TabIndex = 46;
            this.bt_save.Text = "保存(&S)";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // txt_nl
            // 
            this.txt_nl.Location = new System.Drawing.Point(650, 5);
            this.txt_nl.Name = "txt_nl";
            this.txt_nl.ReadOnly = true;
            this.txt_nl.Size = new System.Drawing.Size(40, 24);
            this.txt_nl.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "年龄：";
            // 
            // cmb_xb
            // 
            this.cmb_xb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xb.Enabled = false;
            this.cmb_xb.FormattingEnabled = true;
            this.cmb_xb.Location = new System.Drawing.Point(561, 5);
            this.cmb_xb.Name = "cmb_xb";
            this.cmb_xb.Size = new System.Drawing.Size(41, 23);
            this.cmb_xb.TabIndex = 17;
            // 
            // txt_xm
            // 
            this.txt_xm.Location = new System.Drawing.Point(433, 5);
            this.txt_xm.Name = "txt_xm";
            this.txt_xm.ReadOnly = true;
            this.txt_xm.Size = new System.Drawing.Size(86, 24);
            this.txt_xm.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(521, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "性别：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(394, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "姓名：";
            // 
            // txt_djlsh
            // 
            this.txt_djlsh.Location = new System.Drawing.Point(276, 5);
            this.txt_djlsh.Name = "txt_djlsh";
            this.txt_djlsh.ReadOnly = true;
            this.txt_djlsh.Size = new System.Drawing.Size(115, 24);
            this.txt_djlsh.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(223, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 15);
            this.label22.TabIndex = 10;
            this.label22.Text = "流水号：";
            // 
            // txt_ksjs
            // 
            this.txt_ksjs.Location = new System.Drawing.Point(111, 5);
            this.txt_ksjs.Name = "txt_ksjs";
            this.txt_ksjs.Size = new System.Drawing.Size(112, 24);
            this.txt_ksjs.TabIndex = 3;
            this.txt_ksjs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ksjs_KeyDown);
            this.txt_ksjs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_ksjs_MouseDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(73, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 15);
            this.label18.TabIndex = 2;
            this.label18.Text = "检索：";
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(0, 54);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(844, 502);
            this.tabControl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 19);
            this.label1.TabIndex = 50;
            this.label1.Text = "请根据近一年的体验和感觉，回答以下问题：";
            // 
            // lbl_tzjg
            // 
            this.lbl_tzjg.AutoSize = true;
            this.lbl_tzjg.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_tzjg.ForeColor = System.Drawing.Color.Green;
            this.lbl_tzjg.Location = new System.Drawing.Point(500, 40);
            this.lbl_tzjg.Name = "lbl_tzjg";
            this.lbl_tzjg.Size = new System.Drawing.Size(210, 24);
            this.lbl_tzjg.TabIndex = 51;
            this.lbl_tzjg.Text = "您的体质结果为：";
            this.lbl_tzjg.Visible = false;
            // 
            // Form_zywj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(844, 556);
            this.Controls.Add(this.lbl_tzjg);
            this.Controls.Add(bt_edit);
            this.Controls.Add(bt_insert);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.txt_nl);
            this.Controls.Add(this.txt_ksjs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_xb);
            this.Controls.Add(this.txt_djlsh);
            this.Controls.Add(this.txt_xm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 100);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_zywj";
            this.Text = "藏医体质学问卷";
            this.Load += new System.EventHandler(this.Form_zywj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private MyTextBox txt_ksjs;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_djlsh;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmb_xb;
        private System.Windows.Forms.TextBox txt_xm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_tzjg;


    }
}