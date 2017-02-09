using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace PEIS.cxgl
{
    /// <summary>
    /// ListView 数据导出
    /// </summary>
    public class ListViewExport
    {
        /// <summary>
        /// 将ListView中的数据导出到指定的Excel文件中
        /// </summary>
        /// <param name="listView">System.Windows.Forms.ListView,指定要导出的数据源</param>
        /// <param name="destFileName">指定目标文件路径</param>
        /// <param name="tableName">要导出到的表名称</param>
        /// <param name="overWrite">指定是否覆盖已存在的表</param>
        /// <returns>导出的记录的行数</returns>
        public static int ExportToExcel(ListView listView, string destFileName, string tableName, bool overWrite)
        {
            //得到字段名
            string szFields = "";
            string szValues = "";
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                szFields += "[" + listView.Columns[i].Text + "],";
            }
            szFields = szFields.TrimEnd(',');
            //定义数据连接
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = ListViewExport.GetConnectionString(destFileName);
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
                command.CommandText = ListViewExport.GetCreateTableSql("[" + tableName + "]", szFields.Split(','));
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
                        command.CommandText = ListViewExport.GetCreateTableSql("[" + tableName + "]", szFields.Split(','));
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
                for (int i = 0; i < listView.Items.Count; i++)
                {
                    szValues = "";
                    for (int j = 0; j < listView.Columns.Count; j++)
                    {
                        if (j >= listView.Items[i].SubItems.Count)
                        {
                            szValues += "'',";
                        }
                        else
                        {
                            szValues += "'" + listView.Items[i].SubItems[j].Text + "',";
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


    }
}
