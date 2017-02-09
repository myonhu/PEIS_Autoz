using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS
{
    public partial class Form_waiting : MdiChildrenForm
    {
        private AxShockwaveFlashObjects.AxShockwaveFlash asf;

        public AxShockwaveFlashObjects.AxShockwaveFlash Asf
        {
            set { asf = value; }
        }

     

       
        public Form_waiting()
        {
            InitializeComponent();
        }

        private void Form_waiting_Load(object sender, EventArgs e)
        {
            //if (this.asf!=null)
            //{
            //    asf.Dock = DockStyle.Fill;
            //    this.Controls.Add(asf);
            //    string path = Application.StartupPath + "//flash/zbdy.swf";
            //    asf.Movie = path;
            //    asf.Menu = false;
            //    asf.Playing = true;
            //}

            //this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\zbdy.gif");
            //this.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}