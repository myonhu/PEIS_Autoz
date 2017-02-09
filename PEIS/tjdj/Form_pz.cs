using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PEIS.tjdj
{
    public partial class Form_pz : PEIS.MdiChildrenForm
    {
        VideoClass vw;
        private int width;
        private int height;

        //private Image img;
        private string path;

        /// <summary>
        /// 获取图片路径
        /// </summary>
        public string Path
        {
            get { return path; }
           
        }

        ///// <summary>
        ///// 获取图片
        ///// </summary>
        //public Image Img
        //{
        //    get { return img; }
           
        //}

        public Form_pz(int width,int height)
        {
            InitializeComponent();
            this.width = width;
            this.height = height;
        }

      

        private void Form_pz_Load(object sender, EventArgs e)
        {
            vw = new VideoClass(panel1.Handle, panel1.Left, panel1.Top, panel1.Width, panel1.Height);
            vw.Start();
        }

        private void btnPz_Click(object sender, EventArgs e)
        {
            string path = @"c:\a.jpg";
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch
                {
                    path = @"c:\b.jpg";
                }
            }
            vw.GrabImage(path);
            vw.Stop();
            Image img = Image.FromFile(path);
            Image img2 = img.GetThumbnailImage(width, height, null, new IntPtr());
            Graphics g = Graphics.FromImage(img2);
            g.DrawImage(img2, new Point(10, 10));
            Bitmap bp = new Bitmap(img2);
            string returnPath = @"c:\e.jpg";
            file = new FileInfo(returnPath);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception ee)
                {
                    throw ee;
                }
            }
            try
            {
                bp.Save(returnPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            g.Dispose();
            bp.Dispose();
            img.Dispose();
            img2.Dispose();
             
            this.path = returnPath;
            this.DialogResult = DialogResult.Yes;
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            //pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            //panel1.

        }

       
    }
}