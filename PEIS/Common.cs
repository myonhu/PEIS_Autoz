using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace Common
{
    public class Common
    {

        /// <summary>
        /// 数据窗口过滤
        /// </summary>
        /// <param name="table">要过滤的数据窗口</param>
        /// <param name="filter">过滤字符串</param>
        /// <returns></returns>
        public static DataTable DataTableFilter(DataTable table,string filter)
        {
            DataView rowFilter = new DataView(table);
            rowFilter.RowFilter = filter;
            rowFilter.RowStateFilter = DataViewRowState.OriginalRows;
            
            return rowFilter.ToTable();
        }

        /// <summary>
        /// 为树添加图标
        /// </summary>
        /// <param name="tn"></param>
       public void AddImage(TreeNode tn)
        {
            foreach (TreeNode node in tn.Nodes)
            {
                if (node.Nodes.Count > 0)
                {

                    if (node.IsExpanded)
                    {
                        node.ImageIndex = 0;
                    }
                    else
                    {
                        node.ImageIndex = 1;
                    }
                    
                    AddImage(node);
                }
                else
                {

                    if (node.ForeColor == Color.Red)
                    {
                        node.ImageIndex = 3;
                    }
                    else
                    {
                        node.ImageIndex = 2;
                    }
                }
            }
        }

        /// <summary>
        /// 为树添加图标
        /// </summary>
        /// <param name="tn"></param>
        public void AddImage(TreeNode tn,string qybz)
        {
            foreach (TreeNode node in tn.Nodes)
            {
                if (node.Nodes.Count > 0)
                {

                    if (node.IsExpanded)
                    {
                        node.ImageIndex = 0;
                    }
                    else
                    {
                        node.ImageIndex = 1;
                    }

                    AddImage(node);
                }
                else
                {

                    if (qybz =="0")
                    {
                        node.ImageIndex = 3;
                    }
                    else
                    {
                        node.ImageIndex = 2;
                    }
                }
            }
        }

        /// <summary>
        /// 增加图片
        /// </summary>
        /// <param name="imagelist"></param>
        public void AddImages(ImageList imagelist)
        {
            
           
            Image zkjd = Image.FromFile(Application.StartupPath + @"\img\展开节点.ico");
            imagelist.Images.Add(zkjd);
            Image gbjd = Image.FromFile(Application.StartupPath + @"\img\关闭节点.ico");
            imagelist.Images.Add(gbjd);
            Image qy = Image.FromFile(Application.StartupPath + @"\img\启用.gif");
            imagelist.Images.Add(qy);
            Image ty = Image.FromFile(Application.StartupPath + @"\img\停用.gif");
            imagelist.Images.Add(ty);
            Image zh = Image.FromFile(Application.StartupPath + @"\img\组合.bmp");
            imagelist.Images.Add(zh);
            Image tc = Image.FromFile(Application.StartupPath + @"\img\套餐.bmp");
            imagelist.Images.Add(tc);
            Image xm = Image.FromFile(Application.StartupPath + @"\img\项目.bmp");
            imagelist.Images.Add(xm);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg"></param>
       public void WriteLog(string msg)
        {
            string path = Application.StartupPath + @"\Log";
            if (!Directory.Exists(path))//如果不存在路径，就创建
            {
                Directory.CreateDirectory(path);
            }
            string file = DateTime.Now.ToString("yyyy-MM-dd");
            path += @"\" + file + ".xxsoft";
            StreamWriter sw = null;
            if (!File.Exists(path))//如果不存在，创建文本
            {
                sw = new StreamWriter(path);

            }
            else
            {
                FileInfo fi = new FileInfo(path);
                sw = fi.AppendText();
            }
            sw.WriteLine(msg);
            sw.Close();
        }


        /// <summary>
        /// 加载印刷机
        /// </summary>
        /// <param name="cmb"></param>
        public void LoadCmbYsj(ComboBox cmbYsj)
        {
            cmbYsj.Items.Add("全部");
            cmbYsj.Items.Add("对开机");
            cmbYsj.Items.Add("六开机");
            cmbYsj.SelectedIndex = 0;
        }

        /// <summary>
        /// 将“2009-1-1”转换为“2009-01-01”的标准类型
        /// </summary>
        /// <param name="dt">要转换的datetime</param>
        /// <returns></returns>
        public string DateTimeChange(DateTime dt)
        {
            string year = dt.Year.ToString();
            string month = dt.Month.ToString();
            string day = dt.Day.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            if (day.Length < 2)
            {
                day = "0" + day;
            }
            string datetime = year + "-" + month + "-" + day;

            return datetime;
        }

        /// <summary>
        /// 将“2009-1-1”转换指定的日期类型
        /// </summary>
        /// <param name="dt">要转换的datetime</param>
        /// <returns></returns>
        public string DateTimeChange(DateTime dt,string sighn)
        {
            string year = dt.Year.ToString();
            string month = dt.Month.ToString();
            string day = dt.Day.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            if (day.Length < 2)
            {
                day = "0" + day;
            }
            string datetime = year + sighn + month +sighn + day;

            return datetime;
        }

        /// <summary>
        /// 将数字1转化为0001
        /// </summary>
        /// <param name="number">待转化数字</param>
        /// <returns></returns>
        public string ChangeNumber(int number)
        {
            
            string num = number.ToString();
            string str = "";
            for (int i = 0; i < 4 - (num.Length); i++)
            {
                str += "0";
            }

            return str + num;
        }

        /// <summary>
        /// 判断系统中是否存在打印机
        /// </summary>
        /// <returns>TRUE：存在打印机；FALSE：不存在打印机</returns>
        public bool PrinterExists()
        {
            //PrintDocument prtdoc = new PrintDocument();
            //string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;      //获取默认的打印机名    

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

        /// <summary>
        /// 判断输入的字符是否为数字类型
        /// </summary>
        /// <param name="sz">输入字符</param>
        /// <returns>-1：验证失败；否则返回验证数字</returns>
        public decimal Szyz(string sz)
        {
            sz = CharConverter(sz);
            if (System.Text.RegularExpressions.Regex.IsMatch(sz, @"^[0-9]+$"))
            {
                return Convert.ToDecimal(sz);
            }
            return -1;
        }

        /// <summary>
        /// 判断输入的字符是否为双精度类型；仅为正数
        /// </summary>
        /// <param name="sz">输入字符</param>
        /// <returns>-1：验证失败；否则返回验证数字</returns>
        public decimal DoubleYz(string sz)
        {
            sz = CharConverter(sz);
            if (System.Text.RegularExpressions.Regex.IsMatch(sz, @"^\d+(.\d+)?$"))
            {
                return Convert.ToDecimal(sz);
            }
            return -1;
        }

        /// <summary>
        /// 判断输入的字符是否为双精度类型；可为负数
        /// </summary>
        /// <param name="sz">输入字符</param>
        /// <returns>-1：验证失败；否则返回验证数字</returns>
        public decimal DoubleYzf(string sz)
        {
            sz = CharConverter(sz);
            if (System.Text.RegularExpressions.Regex.IsMatch(sz, @"^(\-)?\d+(.\d+)?$"))
            {
                return Convert.ToDecimal(sz);
            }
            return -1;
        }


        /// <summary>
        /// 如果传入的值为空，返回指定值
        /// </summary>
        /// <param name="old">需要更改的值</param>
        /// <returns></returns>
        public void Charge(ref string old, string n)
        {
            if (old == "")
            {
                old = n;
            }
        }

        /// <summary>
        /// 全角转为半角
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string CharConverter(string source)
        {
            if (source == "")
            {
                return "";
            }
            System.Text.StringBuilder result = new System.Text.StringBuilder(source.Length, source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] >= 65281 && source[i] <= 65373)
                {
                    result.Append((char)(source[i] - 65248));
                }
                else if (source[i] == 12288)
                {
                    result.Append("");
                }
                else
                {
                    result.Append(source[i]);
                }
            }
            return result.ToString();
        }

        

        /// <summary>
        /// 将DataTable中的数据装载到ListView中
        /// </summary>
        /// <param name="listView1">要装载的ListView</param>
        /// <param name="table">被装载的数据</param>
        public void LoadListView(ListView listView1, DataTable table)
        {
            if (table == null)
            {
                return;
            }
            listView1.Clear();
            foreach (DataColumn a in table.Columns)
            {
                listView1.Columns.Add(a.ToString().Trim());
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listView1.Items.Add(table.Rows[i][0].ToString().Trim());

                for (int j = 1; j < table.Columns.Count; j++)
                {
                    string a = table.Rows[i][j].ToString().Trim();
                    listView1.Items[i].SubItems.Add(a);
                    string b = listView1.Items[i].SubItems[j].Text;
                }
            }
            if (listView1.Columns.Count != 0)
            {
                for (int i = 0; i < listView1.Columns.Count; i++)
                {
                    listView1.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }

        /// <summary>
        /// 将DataTable中的数据装载到ListView中：带行标
        /// </summary>
        /// <param name="listView1">要装载的ListView</param>
        /// <param name="table">被装载的数据</param>
        public void LoadListViewHang(ListView listView1, DataTable table)
        {
            if (table == null)
            {
                return;
            }
            listView1.Clear();
            listView1.Columns.Add("行");
            foreach (DataColumn a in table.Columns)
            {
                listView1.Columns.Add(a.ToString().Trim());
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listView1.Items.Add(Convert.ToString(i + 1));

                for (int j = 0; j < table.Columns.Count; j++)
                {
                    string a = table.Rows[i][j].ToString().Trim();
                    listView1.Items[i].SubItems.Add(a);
                }
            }
            if (listView1.Columns.Count != 0)
            {
                for (int i = 0; i < listView1.Columns.Count; i++)
                {
                    listView1.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }

        /// <summary>
        /// 将ListView中的数据装载到DataTable中
        /// </summary>
        /// <param name="listView1">被装载的ListView</param>
        /// <param name="table">要装载的数据</param>
        public DataTable LoadDataTable(ListView listView1)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                DataColumn dc = new DataColumn(listView1.Columns[i].Text);
                table.Columns.Add(dc);
            }
            for (int x = 0; x < listView1.Items.Count; x++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < listView1.Columns.Count; j++)
                {
                    row[j] = listView1.Items[x].SubItems[j].Text;
                }
                table.Rows.Add(row);

            }
            return table;

        }

        /// <summary>
        /// 在指定DataGridView中插入多选框
        /// </summary>
        /// <param name="DataGridView1">在指定DataGridView</param>
        public void AddColumn(DataGridView DataGridView1)
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.HeaderText = "a";

                column.Name = "a";

                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = true;
                column.CellTemplate = new DataGridViewCheckBoxCell();
            }

            DataGridView1.Columns.Insert(0, column);
        }


        /// <summary>
        /// 将日期转换为字符串形式
        /// </summary>
        /// <param name="dt">指定日期</param>
        /// <returns>日期字符串 20101030</returns>
        public string GetTimeNow(DateTime dt)
        {
            string str = "";
            int year = dt.Year;
            str += year.ToString();
            int month = dt.Month;
            int day = dt.Day;
            if (month < 10)
            {
                str += "0" + month.ToString();
            }
            else
            {
                str += month.ToString();
            }
            if (day < 10)
            {
                str += "0" + day.ToString();
            }
            else
            {
                str += day.ToString();
            }
            return str;
        }

        /// <summary>
        /// 根据DataGridView创建DataTable
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public DataTable CerateTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                DataColumn dc = new DataColumn(dgvc.Name);
                dt.Columns.Add(dc);
            }
            return dt;
        }

        /// <summary>
        /// 定时关机
        /// </summary>
        /// <param name="time"></param>
        public void PCClose(string time)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("at "+time+" Shutdown -s");
            p.StandardInput.WriteLine("exit");
            p.Close(); 
        }

        /// <summary>
        /// 判断输入字符中是否存在汉字
        /// </summary>
        /// <param name="strData"></param>
        /// <returns>TRUE：没有汉字</returns>
        public bool HasHz(string strData)
        {
            if (strData=="")
            {
                return false;
            }
            int len = strData.Length;
            int iLen = 0;
            if (strData != null)
            {
                iLen = strData.Length;
                byte[] byteData = new byte[iLen * 2];
                try
                {
                    iLen = Encoding.Default.GetBytes(strData, 0, strData.Length, byteData, 0);
                }
                catch { }
            }
            if (len==iLen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 读取regvalue值
        /// </summary>
        /// <param name="strPatch"></param>
        /// <returns></returns>
        public string ReadLog(string strPatch)
        {
            string strLine = "";
            FileStream fs = null;
            StreamReader reader = null;
            try
            {
                fs = new FileStream(strPatch, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(fs, Encoding.GetEncoding("GB2312"));
                strLine = reader.ReadLine();
            }
            catch (Exception)
            {

                return "";
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }

            }

            return strLine;
        }

        /// <summary>
        /// 枚举系统打印机信息，第一个是默认打印机
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPrinterInfo()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                List<string> liststr = new List<string>();
                string defaultname = pd.PrinterSettings.PrinterName;//获取系统默认打印机
                liststr.Add(defaultname);
                //枚举打印机
                foreach (string str in PrinterSettings.InstalledPrinters)
                {
                    if (str != defaultname)
                    {
                        liststr.Add(str);
                    }
                }
                return liststr;
            }
            catch
            {
                return null;
            }
        }

            
    }
}
