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
    public class RdlcPrintNew : IDisposable
    {
        //int width = 0;
        //int height = 0;
        //int displayFrequency = 0;
        //int bitsPerPel = 0;
        //bool bool_fbl=false;
        //Resolution resolution;//系统分辨率类

        public float Page_scale = 0;
        public int Page_x = 0;
        public int Page_y = 0;

        string PaperName = "";//纸张名字
        public string PageWidth = "";//纸张宽度
        public string PageHeight = "";//纸张高度
        string MarginTop = "";//上边距
        string MarginLeft = "";//左边距
        string MarginRight = "";//右边距
        string MarginBottom = "";//下边距
        string PagePrinter = "";//打印机
        private string printname = "";

        private bool hxdy = false;
        int m_PageIndex = 0;//需要打印的当前页 2012-08-14

        /// <summary>
        /// 获取一个值，指示是否为横向打印，默认为纵向
        /// </summary>
        public bool Hxdy
        {
           
            set { hxdy = value; }
        }
        /// <summary>
        /// 打印机名称
        /// </summary>
        public string PrinterName
        {
            get { return printname; }
            set { printname = value; }
        }
        
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private Stream CreateStream(string name, string fileNameExtension,
             Encoding encoding,
                 string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + XtNumber.Name.ToString() + "." + fileNameExtension,
                FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report, string PageName)
        {
            string deviceInfo="";
            if (PageName == "")//单据名称
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
            else
            {
                deviceInfo =
                  "<DeviceInfo>" +
                  "  <OutputFormat>EMF</OutputFormat>" +
                  "  <PageWidth>" + PageWidth + "</PageWidth>" +
                  "  <PageHeight>" + PageHeight + "</PageHeight>" +
                  "  <MarginTop>" + MarginTop + "</MarginTop>" +
                  "  <MarginLeft>" + MarginLeft + "</MarginLeft>" +
                  "  <MarginRight>" + MarginRight + "</MarginRight>" +
                  "  <MarginBottom>" + MarginBottom + "</MarginBottom>" +
                  "</DeviceInfo>";
            }
            Warning[] warnings;
            m_streams = new List<Stream>();
            try
            {
                //report.DisplayName = PageName;//
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
            //Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            //ev.Graphics.DrawImageUnscaledAndClipped(pageImage, new System.Drawing.Rectangle(0, 0, ev.PageBounds.Width, ev.PageBounds.Height));
            //m_currentPageIndex++;
            //ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
            if (m_PageIndex == 0)//没有指定页码打印所有的
            {
                Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
                //ev.Graphics.DrawImageUnscaledAndClipped(pageImage, new System.Drawing.Rectangle(0, 0, ev.PageBounds.Width, ev.PageBounds.Height));
                ev.Graphics.PageScale = Page_scale;
                ev.Graphics.DrawImage(pageImage, new System.Drawing.Rectangle(-40+ Page_x,  Page_y, ev.PageBounds.Width, ev.PageBounds.Height));
                m_currentPageIndex++;
                ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
            }
            else//指定页面后只打印指定页码
            {
                if (m_PageIndex > m_streams.Count)
                {
                    ev.HasMorePages = false;//当终止页数大于总页数
                    ev.Cancel = true;
                    MessageBox.Show("自定义页面填写有误,终止页数不能大于总页数，请检查！", "提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                while (m_currentPageIndex + 1 < m_PageIndex)
                {
                    m_currentPageIndex++;
                }
                Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
                ev.Graphics.DrawImageUnscaledAndClipped(pageImage, new System.Drawing.Rectangle(0, 0, ev.PageBounds.Width, ev.PageBounds.Height));
                ev.HasMorePages = false;
            }
        }

        private void Print(string DocumentName,bool DispalyPageSetupDialog)
        {
            if (m_streams == null || m_streams.Count == 0)
                return;
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = DocumentName;

            

            if (!PrinterExists())//检查是否有打印机
            {
                return;
            }
            if (PagePrinter != "")//打印机
            {
                bool IsExists = false;//设置打印机名称是否存在
                for (int x = 0; x < PrinterSettings.InstalledPrinters.Count; x++)
                {
                    if (PrinterSettings.InstalledPrinters[x].ToString() == PagePrinter)
                    {
                        printDoc.PrinterSettings.PrinterName = PrinterName == "" ? PagePrinter : PrinterName;
                        IsExists = true;
                        break;
                    }
                }
                if (!IsExists)
                {
                    MessageBox.Show("打印机：" + "【" + PagePrinter + "】不存在，请联系管理员！", "提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else if (PrinterName != "")
            {
                printDoc.PrinterSettings.PrinterName = PrinterName;
            }
            //PaperName = "A5";
            if (PaperName != "")//纸张名称：A4,A3
            {
                if (!Printer.FormInPrinter(printDoc.PrinterSettings.PrinterName, PaperName))//纸张不存在自己创建
                {
                    decimal width = Convert.ToDecimal(PageWidth.Replace("cm", "")) * 10;
                    decimal height = Convert.ToDecimal(PageHeight.Replace("cm", "")) * 10;
                    Printer.AddCustomPaperSize(printDoc.PrinterSettings.PrinterName,PaperName, width, height);
                }

                int index = 0;//纸张的索引
                bool IsExists = false;//打印机纸张是否存在该纸张名称
                for (int j = 0; j < printDoc.PrinterSettings.PaperSizes.Count; j++)
                {
                    if (printDoc.PrinterSettings.PaperSizes[j].PaperName == PaperName)
                    {
                        //MessageBox.Show(printDoc.PrinterSettings.PaperSizes[j].PaperName);
                        index = j;
                        IsExists = true;
                        break;
                    }
                }
                if (IsExists)
                {
                    printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 583, 827);
                    //printDoc.DefaultPageSettings.PaperSize = printDoc.PrinterSettings.PaperSizes[index];
                }
                else
                {
                    MessageBox.Show("打印机属性里面的纸张：【" + PaperName + "】不存在，请联系管理员！", "提示",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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

                if (hxdy)//横向打印
                {
                    printDoc.DefaultPageSettings.Landscape = true;
                }
                printDoc.Print();
                //if (bool_fbl)
                //{
                //    resolution.setResolution(width, height, displayFrequency, bitsPerPel);
                //}
            }
        }

        //private PrintWaiting pw = new PrintWaiting();

        /// <summary>
        /// 打印rdlc文件
        /// </summary>
        /// <param name="report">本地报表</param>
        /// <param name="DocumentName">打印文件名称</param>
        /// <param name="DispalyPageSetupDialog">是否显示打印设置对话框</param>
        /// <param name="PageName">打印单据的名字</param>
        public void Run(LocalReport report, string DocumentName, bool DispalyPageSetupDialog,string PageName)
        {
            //pw.StartThread();
            try
            {
                if (PageName != "")//取自定义纸张大小
                {
                    xtBiz xtbiz = new xtBiz();
                    DataTable dt = xtbiz.Get_Xt_ggdy(PageName);
                    if (dt.Rows.Count == 1)
                    {
                        PaperName = dt.Rows[0]["PaperName"].ToString();
                        //PageWidth = dt.Rows[0]["PageWidth"].ToString();
                        //PageHeight = dt.Rows[0]["PageHeight"].ToString();
                        string w = PageWidth;
                        string h = PageHeight;
                        MarginTop = dt.Rows[0]["MarginTop"].ToString();
                        MarginLeft = dt.Rows[0]["MarginLeft"].ToString();
                        MarginRight = dt.Rows[0]["MarginRight"].ToString();
                        MarginBottom = dt.Rows[0]["MarginBottom"].ToString();
                        PagePrinter = dt.Rows[0]["PagePrinter"].ToString();
                        if (PageWidth == "") PageWidth = "0cm";
                        if (PageHeight == "") PageHeight = "0cm";
                        if (MarginTop == "") MarginTop = "0cm";
                        if (MarginLeft == "") MarginLeft = "0cm";
                        if (MarginRight == "") MarginRight = "0cm";
                        if (MarginBottom == "") MarginBottom = "0cm";
                    }
                    else
                    {
                        MessageBox.Show("该单据纸张配置【" + PageName + "】没有设置，请联系管理员！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                Export(report, PageName);
                m_currentPageIndex = 0;
                Print(DocumentName, DispalyPageSetupDialog);
                //pw.StopThread();
            }
            catch
            { }
            finally
            {
                Dispose();
            }
        }


        /// <summary>
        /// 打印rdlc文件
        /// </summary>
        /// <param name="report">本地报表</param>
        /// <param name="DocumentName">打印文件名称</param>
        /// <param name="DispalyPageSetupDialog">是否显示打印设置对话框</param>
        /// <param name="PageName">打印单据的名字</param>
        /// <param name="PageFw">打印单据的范围</param>
        public void Run(LocalReport report, string DocumentName, bool DispalyPageSetupDialog, string PageName,string PageFw)
        {
            //pw.StartThread();
            try
            {
                if (PageName != "")//取自定义纸张大小
                {
                    xtBiz xtbiz = new xtBiz();
                    DataTable dt = xtbiz.Get_Xt_ggdy(PageName);
                    if (dt.Rows.Count == 1)
                    {
                        PaperName = dt.Rows[0]["PaperName"].ToString();
                        PageWidth = dt.Rows[0]["PageWidth"].ToString();
                        PageHeight = dt.Rows[0]["PageHeight"].ToString();
                        MarginTop = dt.Rows[0]["MarginTop"].ToString();
                        MarginLeft = dt.Rows[0]["MarginLeft"].ToString();
                        MarginRight = dt.Rows[0]["MarginRight"].ToString();
                        MarginBottom = dt.Rows[0]["MarginBottom"].ToString();
                        PagePrinter = dt.Rows[0]["PagePrinter"].ToString();
                        if (PageWidth == "") PageWidth = "0cm";
                        if (PageHeight == "") PageHeight = "0cm";
                        if (MarginTop == "") MarginTop = "0cm";
                        if (MarginLeft == "") MarginLeft = "0cm";
                        if (MarginRight == "") MarginRight = "0cm";
                        if (MarginBottom == "") MarginBottom = "0cm";
                    }
                    else
                    {
                        MessageBox.Show("该单据纸张配置【" + PageName + "】没有设置，请联系管理员！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                Export(report, PageName);
                if (PageFw == "")
                {
                    m_currentPageIndex = 0;
                    Print(DocumentName, DispalyPageSetupDialog);
                    //pw.StopThread();
                }
                else
                {
                    string[] str_fw = PageFw.Split('-');
                    int begin = 0;
                    int end = 0;
                    try
                    {
                        if (str_fw.Length == 1)
                        {
                            begin = Convert.ToInt32(str_fw[0]);
                            end = Convert.ToInt32(str_fw[0]);
                        }
                        else
                        {
                            begin = Convert.ToInt32(str_fw[0]);
                            end = Convert.ToInt32(str_fw[1]);
                        }
                        if (begin > end)
                        {
                            MessageBox.Show("该单据自定义打印页数填写有误，请检查！", "提示",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("该单据自定义打印页数填写有误，请检查！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    for (int i = begin; i <= end; i++)
                    {
                        m_PageIndex = i;
                        m_currentPageIndex = 0;
                        Print(DocumentName, DispalyPageSetupDialog);
                        //pw.StopThread();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                Dispose();
            }
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
        private bool PrinterExists()
        {
            try
            {
                PrinterSettings.StringCollection snames = PrinterSettings.InstalledPrinters;

                foreach (string s in snames)
                {
                    if (s.ToLower().Trim() == s.ToLower().Trim())
                    {
                        return true;
                    }
                }
                //if (bool_fbl)
                //{
                //    resolution.setResolution(1024, 768, 60, 32);
                //}
                MessageBox.Show("没找到打印机！\n只有安装了打印机才能进行打印", "没找到打印机",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch
            {
                return false;
            }

        }
    }
}
