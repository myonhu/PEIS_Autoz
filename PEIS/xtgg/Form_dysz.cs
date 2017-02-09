using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PEIS.xtgg
{
    public partial class Form_dysz : MdiChildrenForm
    {
        public Form_dysz()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_dysz_Load(object sender, EventArgs e)
        {
            PrinterSettings.StringCollection snames = PrinterSettings.InstalledPrinters;
            string str_def = Printer.GetDeaultPrinterName();
            foreach (string s in snames)
            {
                lbxPrinter.Items.Add(s);
            }
            label1.Text = "默认打印机："+str_def;
            
            
        }

        private void lbxPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Printer.SetPrinterToDefault(lbxPrinter.SelectedItem.ToString().Trim());
            label1.Text = "默认打印机：" + lbxPrinter.SelectedItem.ToString().Trim();
        }
    }
}