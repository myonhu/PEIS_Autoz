using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    public partial class Form_label : Form
    {

        public Form_label(string _header, string _footer, string _barcode, int _range)
        {
            InitializeComponent();
            SetValue(_header, _footer, _barcode, _range);
        }

        private void SetValue(string _header, string _footer, string _barcode, int _range)
        {
            myBarCodeControl2.Location = new System.Drawing.Point(myBarCodeControl2.Location.X + _range, myBarCodeControl2.Location.Y);
            myBarCodeControl3.Location = new System.Drawing.Point(myBarCodeControl3.Location.X + _range*2, myBarCodeControl3.Location.Y);

            //给控件赋值，后期用来打印
            foreach (Control c in panel1.Controls)
            {
                if (c is BarcodeLib.MyBarCodeControl)
                {
                    ((BarcodeLib.MyBarCodeControl)c).ShowFooter = true;
                    ((BarcodeLib.MyBarCodeControl)c).ShowHeader = true;
                    ((BarcodeLib.MyBarCodeControl)c).HeadText = _header;
                    ((BarcodeLib.MyBarCodeControl)c).FooterText = _footer;
                    ((BarcodeLib.MyBarCodeControl)c).BarCode = _barcode;

                }
            }
        }
    }
}
