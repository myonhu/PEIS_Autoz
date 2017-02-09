using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace PEIS.xtgg
{
    public static class PrinterDoc
    {
        static public bool PrinterExists(PrintDocument prtdoc)
        {
            //PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;      //获取默认的打印机名    

            PrinterSettings.StringCollection snames = PrinterSettings.InstalledPrinters;

            foreach (string s in snames)
            {
                if (s.ToLower().Trim() == s.ToLower().Trim())
                {
                    return true;
                }
            }
            MessageBox.Show("没找到打印机！\n只有安装了打印机才能进行打印", "没找到打印机",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}
