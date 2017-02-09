using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PEIS.main
{
    public partial class TextNumberControl : UserControl
    {
        public TextNumberControl()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            try
            {
                Convert.ToInt32(button.Text);
                if (txt_kl.Text.Length > 11) return;
                txt_kl.Text = txt_kl.Text + button.Text;
            }
            catch
            {
                if (button.Text == "Del")
                {
                    try
                    {
                        txt_kl.Text = txt_kl.Text.Substring(0, txt_kl.Text.Length - 1);
                    }
                    catch
                    {
                        txt_kl.Text = "";
                    }
                }
                else
                {
                    txt_kl.Text = "";
                }
            }
        }
    }
}
