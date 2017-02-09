using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Excel;
namespace PEIS.xtgg
{
    /// <summary>
    /// DataGridView数据导出
    /// </summary>
    public class DataGridViewExport
    {
        /// <summary>
        /// 将ListView中的数据导出到指定的Excel文件中
        /// </summary>
        /// <param name="listView">System.Windows.Forms.ListView,指定要导出的数据源</param>
        /// <param name="destFileName">指定目标文件路径</param>
        /// <param name="tableName">要导出到的表名称</param>
        /// <param name="overWrite">指定是否覆盖已存在的表</param>
        /// <returns>导出的记录的行数</returns>
        public static int ExportToExcel(DataGridView gridView, string destFileName, string tableName, bool overWrite)
        {
            //得到字段名
            string szFields = "";
            string szValues = "";
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                szFields += "[" + gridView.Columns[i].HeaderText + "],";
            }
            szFields = szFields.TrimEnd(',');
            //定义数据连接
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = DataGridViewExport.GetConnectionString(destFileName);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            //打开数据库连接
            try
            {
                connection.Open();
            }
            catch
            {
                throw new Exception("目标文件路径错误。");
            }
            //创建数据库表
            try
            {
                command.CommandText = DataGridViewExport.GetCreateTableSql("[" + tableName + "]", szFields.Split(','));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //如果允许覆盖则删除已有数据
                if (overWrite)
                {
                    try
                    {
                        command.CommandText = "DROP TABLE [" + tableName + "]";
                        command.ExecuteNonQuery();
                        command.CommandText = DataGridViewExport.GetCreateTableSql("[" + tableName + "]", szFields.Split(','));
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex1)
                    {
                        throw ex1;
                    }
                }
                else
                {
                    throw ex;
                }
            }
            try
            {
                //循环处理数据------------------------------------------
                int recordCount = 0;
                for (int i = 0; i < gridView.Rows.Count; i++)
                {
                    szValues = "";
                    for (int j = 0; j < gridView.Columns.Count; j++)
                    {
                        if (j >= gridView.Columns.Count)
                        {
                            szValues += "'',";
                        }
                        else
                        {
                            szValues += "'" + gridView.Rows[i].Cells[j].Value.ToString().Trim() + "',";
                        }
                    }
                    szValues = szValues.TrimEnd(',');
                    //组合成SQL语句并执行
                    string szSql = "INSERT INTO [" + tableName + "](" + szFields + ") VALUES(" + szValues + ")";
                    command.CommandText = szSql;
                    recordCount += command.ExecuteNonQuery();
                }
                connection.Close();
                return recordCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //得到连接字符串
        private static String GetConnectionString(string fullPath)
        {
            string szConnection;
            szConnection = "Provider=Microsoft.JET.OLEDB.4.0;Extended Properties=Excel 8.0;data source=" + fullPath;
            return szConnection;
        }
        //得到创建表的SQL语句
        private static string GetCreateTableSql(string tableName, string[] fields)
        {
            string szSql = "CREATE TABLE " + tableName + "(";
            for (int i = 0; i < fields.Length; i++)
            {
                //szSql += fields[i] + " VARCHAR(200),";
                szSql += fields[i] + " ntext,";
            }
            szSql = szSql.TrimEnd(',') + ")";
            return szSql;
        }
        /// <summary>
        /// 打开Excel文档
        /// </summary>
        /// <param name="path">Excel文档得路径及名称</param>
        public static void OpenExcel(string path)
        {
            System.Diagnostics.Process.Start(path);
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        }

        /// <summary>
        /// 判断是否安装Excel
        /// </summary>
        /// <returns>true：安装了；FALSE：没安装</returns>
        public static bool IsExistsExcel()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            if (type == null)
            {
                MessageBox.Show("您的计算机还未安装Excel，\n安装后才能打开Excel文档！", "无法打开文档",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //MessageBox.Show(type);
            return true;
        }

        /// <summary>
        /// DataGridView导出Excel：用流保存成xls文件
        /// </summary>
        public static void SaveAs(DataGridView dgvAgeWeekSex) //另存新档按钮   导出成Excel
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";

            saveFileDialog.ShowDialog();

            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string str = "";
            try
            {
                //写标题
                for (int i = 0; i < dgvAgeWeekSex.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvAgeWeekSex.Columns[i].HeaderText;
                }

                sw.WriteLine(str);


                //写内容
                for (int j = 0; j < dgvAgeWeekSex.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < dgvAgeWeekSex.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        //tempStr += dgvAgeWeekSex.Rows[j].Cells[k].Value.ToString();
                        tempStr += "" + dgvAgeWeekSex.Rows[j].Cells[k].Value == "" ? "" : dgvAgeWeekSex.Rows[j].Cells[k].Value.ToString();
                    }

                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }

        /// <summary>   
        /// 打开Excel并将DataGridView控件中数据导出到Excel   
        /// </summary>   
        /// <param name="dgv">DataGridView对象 </param>   
        /// <param name="isShowExcle">是否显示Excel界面 </param>   
        /// <remarks>   
        /// add com "Microsoft Excel 11.0 Object Library"   
        /// using Excel=Microsoft.Office.Interop.Excel;   
        /// </remarks>   
        /// <returns> </returns>   
        public static bool DataGridviewShowToExcel(DataGridView dgv, bool isShowExcle)
        {
            #region  导出操作
            if (dgv.Rows.Count == 0)
                return false;

            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀   
            dlg.DefaultExt = "xls ";
            //文件后缀列表   
            dlg.Filter = "Excel文件(*.xls)|*.xls";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return false;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == "") return false;

            //ArrayList arryList = new ArrayList();
            //foreach (DataGridViewColumn dgc in dgv.Columns)//删除隐藏的列
            //{
            //    if (!dgc.Visible)
            //        arryList.Add(dgc);
            //}
            //for (int a = 0; a < arryList.Count; a++)
            //{
            //    dgv.Columns.Remove((DataGridViewColumn)arryList[a]);
            //}

            //建立Excel对象   
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcle;
            //生成字段名称   
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }
            }
            //填充数据   
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (dgv.Columns[j].Visible)
                    {
                        if (dgv[j, i].ValueType == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "'" + dgv[j, i].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = dgv[j, i].Value.ToString();
                        }
                    }
                }
            }
            try
            {

                //excel.ActiveWorkbook.SaveAs(fileNameString, XlFileFormat.xlExcel9795, null, null, false, false, XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
                excel.ActiveWorkbook.SaveAs(fileNameString, XlFileFormat.xlWorkbookNormal, null, null, false, false, XlSaveAsAccessMode.xlExclusive, null, null, null, null, null);
                excel.DisplayAlerts = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                excel.Quit();
            }
            if (DialogResult.Yes == MessageBox.Show("是否打开该文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
            {
                OpenExcel(fileNameString);
            }
            return true;
            #endregion  导出操作
        }

    }
}
