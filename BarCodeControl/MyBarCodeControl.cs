using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarcodeLib
{
    public partial class MyBarCodeControl : UserControl
    {
        private int _barcode_w = 120;
        private int _barcode_h = 30;
        private bool showFooter;
        private bool showHeader;
        private string barCode = "1234567890";
        private string headText = "顶部";
        private string footText = "底部";
        BarcodeLib.TYPE type = TYPE.CODE128;
        //public MyBarCodeControl(BarcodeLib.TYPE _type, string _barcode, string _headtext, string _foottext)
        //{
        //    InitializeComponent();
        //    this.type = _type;
        //    this.headText = _headtext;
        //    this.footText = _foottext;
        //    this.barCode = _barcode;
        //    lblfooter.Text = _foottext;
        //    lblheader.Text = _headtext;
        //    CreateBarCodeImage();
        //}
        public MyBarCodeControl()
        {
            InitializeComponent();
            CreateBarCodeImage();
        }

        public MyBarCodeControl(int barcode_w, int barcode_h)
        {
            _barcode_w = barcode_w;
            _barcode_h = barcode_h;

            InitializeComponent();
            CreateBarCodeImage();
        }

        private void CreateBarCodeImage()
        {
            BarcodeLib.TYPE type = this.type;
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Bitmap bm = b.Encode(type, this.barCode, Color.Black, Color.White, _barcode_w, _barcode_h);
            //pictureBox1.Size = new System.Drawing.Size(270, 53);
            pictureBox1.Image = bm;
            Update();
        }

        [Description("文本编码"), DefaultValue(TYPE.CODE128), Category("Appearance")]
        public TYPE CodeStyle
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        [Description("显示底部文本"), DefaultValue(false), Category("Appearance")]
        public bool ShowFooter
        {
            get
            {
                return this.showFooter;
            }
            set
            {
                this.showFooter = value;
                lblfooter.Visible = this.showFooter;
            }
        }

        [Description("显示顶部文本"), DefaultValue(false), Category("Appearance")]
        public bool ShowHeader
        {
            get
            {
                return this.showHeader;
            }
            set
            {
                this.showHeader = value;
                lblheader.Visible = this.showHeader;
            }
        }

        [ DefaultValue("1234567890"),Description("条形码的值"), Browsable(true), Category("Appearance")]
        public string BarCode
        {
            get
            {
                return this.barCode;
            }
            set
            {
                //画图
                this.barCode = value;
                CreateBarCodeImage();
            }
        }

        [Description("顶部文本"), DefaultValue("顶部"), Category("Appearance")]
        public string HeadText
        {
            get
            {
                return this.headText;
            }
            set
            {
                this.headText = value;
                lblheader.Text = this.headText;
            }
        }

        [Description("底部文本"), DefaultValue("底部"), Category("Appearance")]
        public string FooterText
        {
            get
            {
                return this.footText;
            }
            set
            {
                this.footText = value;
                lblfooter.Text = this.footText;
            }
        }



        public void Draw(Graphics g, RectangleF rect)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            int width = (int)rect.X;
            foreach (Control c in this.panel1.Controls)
            {
                if (c is Label)
                {

                    Label lbl = c as Label;
                    if (lbl.Name == "lblheader")
                    {
                        width = width + width / 3;
                    }
                    g.DrawString(lbl.Text, new Font(lbl.Font.Name, lbl.Font.Size, lbl.Font.Style), Brushes.Black, new Point(lbl.Location.X + width, lbl.Location.Y));
                }
                else if (c is PictureBox)
                {
                    g.DrawImage(pictureBox1.Image, new Point(pictureBox1.Location.X + (int)rect.X / 2, pictureBox1.Location.Y));
                }
            }
        }

    }
}
