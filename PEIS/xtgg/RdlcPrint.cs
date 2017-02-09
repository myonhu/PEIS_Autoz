using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
namespace PEIS.xtgg
{
    public class RdlcPrint : IDisposable
    {
        int width = 0;
        int height = 0;
        int displayFrequency = 0;
        int bitsPerPel = 0;
        bool bool_fbl=false;
        Resolution resolution;//系统分辨率类

        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private Stream CreateStream(string name, string fileNameExtension,
             Encoding encoding,
                 string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + "." + fileNameExtension,
                FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report, string deviceInfo)
        {
            if (deviceInfo == "")
            {
               deviceInfo =
                  "<DeviceInfo>" +
                  "  <OutputFormat>EMF</OutputFormat>" +
                  "  <PageWidth>29.7cm</PageWidth>" +
                  "  <PageHeight>21cm</PageHeight>" +
                  "  <MarginTop>1cm</MarginTop>" +
                  "  <MarginLeft>1cm</MarginLeft>" +
                  "  <MarginRight>1cm</MarginRight>" +
                  "  <MarginBottom>1cm</MarginBottom>" +
                  "</DeviceInfo>";
            }
            Warning[] warnings;
            m_streams = new List<Stream>();
            try
            {
                report.Render("Image", deviceInfo, CreateStream, out warnings);
            }
            catch (Exception ex)
            {
                Exception innerEx = ex.InnerException;//取内异常。因为内异常的信息才有用，才能排除问题。   
                while (innerEx != null)
                {

                    MessageBox.Show(innerEx.Message);

                    innerEx = innerEx.InnerException;
                }
            }

            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, 0, 0);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print(string DocumentName,bool DispalyPageSetupDialog)
        {
            if (m_streams == null || m_streams.Count == 0)
                return;
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = DocumentName;
            if (!PrinterExists(printDoc))//检查是否有打印机
            {
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            if (DispalyPageSetupDialog)
            {
                PageSetupDialog pageDialog = new PageSetupDialog();
                pageDialog.Document = printDoc;
                if (pageDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            else
            {
                //int index = 0;
                //for (int i = 0; i < printDoc.PrinterSettings.PrinterResolutions.Count; i++)
                //{
                //    if (printDoc.PrinterSettings.PrinterResolutions[i].X == 300 && printDoc.PrinterSettings.PrinterResolutions[i].Y == 300)
                //    {
                //        index = i;
                //        break;
                //    }
                //}
                //printDoc.DefaultPageSettings.PrinterResolution = printDoc.PrinterSettings.PrinterResolutions[index];
                printDoc.Print();
                if (bool_fbl)
                {
                    resolution.setResolution(width, height, displayFrequency, bitsPerPel);
                }
            }
        }
        /// <summary>
        /// 打印rdlc文件
        /// </summary>
        /// <param name="report">本地报表</param>
        /// <param name="DocumentName">打印文件名称</param>
        /// <param name="deviceInfo">打印文件配置字符串</param>
        /// <param name="deviceInfo">是否显示打印设置对话框</param>
        public void Run(LocalReport report, string DocumentName, string deviceInfo, bool DispalyPageSetupDialog)
        {
            resolution = new Resolution();
            Resolution.DEVMODE devmode = new Resolution.DEVMODE();
            devmode = resolution.getResolution();
            width = devmode.dmPelsWidth;
            height = devmode.dmPelsHeight;
            displayFrequency = devmode.dmDisplayFrequency;
            bitsPerPel = devmode.dmBitsPerPel;
            if (width != 1024 && height != 768)
            {
                bool_fbl = true;
                resolution.setResolution(1024, 768, 60, 32);
            }
            Export(report, deviceInfo);
            m_currentPageIndex = 0;
            Print(DocumentName, DispalyPageSetupDialog);
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
        /// <summary>
        /// 判断系统中是否存在打印机
        /// </summary>
        /// <returns>TRUE：存在打印机；FALSE：不存在打印机</returns>
        private bool PrinterExists(PrintDocument prtdoc)
        {
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;      //获取默认的打印机名    

            PrinterSettings.StringCollection snames = PrinterSettings.InstalledPrinters;

            foreach (string s in snames)
            {
                if (s.ToLower().Trim() == s.ToLower().Trim())
                {
                    return true;
                }
            }
            if (bool_fbl)
            {
                resolution.setResolution(1024, 768, 60, 32);
            }
            MessageBox.Show("没找到打印机！\n只有安装了打印机才能进行打印", "没找到打印机",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}
