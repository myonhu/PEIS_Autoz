namespace PEIS.jkgl
{
    partial class Form_label
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.myBarCodeControl3 = new BarcodeLib.MyBarCodeControl();
            this.myBarCodeControl2 = new BarcodeLib.MyBarCodeControl();
            this.myBarCodeControl1 = new BarcodeLib.MyBarCodeControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.myBarCodeControl3);
            this.panel1.Controls.Add(this.myBarCodeControl2);
            this.panel1.Controls.Add(this.myBarCodeControl1);
            this.panel1.Font = new System.Drawing.Font("宋体", 8F);
            this.panel1.Location = new System.Drawing.Point(32, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // myBarCodeControl3
            // 
            this.myBarCodeControl3.BackColor = System.Drawing.Color.White;
            this.myBarCodeControl3.Location = new System.Drawing.Point(450, 4);
            this.myBarCodeControl3.Name = "myBarCodeControl3";
            this.myBarCodeControl3.Size = new System.Drawing.Size(200, 91);
            this.myBarCodeControl3.TabIndex = 2;
            // 
            // myBarCodeControl2
            // 
            this.myBarCodeControl2.BackColor = System.Drawing.Color.White;
            this.myBarCodeControl2.Location = new System.Drawing.Point(230, 4);
            this.myBarCodeControl2.Name = "myBarCodeControl2";
            this.myBarCodeControl2.Size = new System.Drawing.Size(200, 91);
            this.myBarCodeControl2.TabIndex = 1;
            // 
            // myBarCodeControl1
            // 
            this.myBarCodeControl1.BackColor = System.Drawing.Color.White;
            this.myBarCodeControl1.Location = new System.Drawing.Point(0, 4);
            this.myBarCodeControl1.Name = "myBarCodeControl1";
            this.myBarCodeControl1.Size = new System.Drawing.Size(200, 91);
            this.myBarCodeControl1.TabIndex = 0;
            // 
            // Form_label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 383);
            this.Controls.Add(this.panel1);
            this.Name = "Form_label";
            this.Text = "Form_label";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private BarcodeLib.MyBarCodeControl myBarCodeControl3;
        private BarcodeLib.MyBarCodeControl myBarCodeControl2;
        private BarcodeLib.MyBarCodeControl myBarCodeControl1;

    }
}