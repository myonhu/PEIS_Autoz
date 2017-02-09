using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PEIS.cxgl
{
    class Command : Base
    {
        private DataTable dt = null;
        /// <summary>
        /// 以表格形式返回表头名称
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public DataTable GetTbHeader(string table)
        {
            string sql = "select * from " + table + " where 1=2";
            dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt == null)
            {
                return null;
            }
            if (dt.Columns.Count == 0)
            {
                return null;
            }
            else
            {
                return dt;
            }
        }

        /// <summary>
        /// 将“2009-1-1”转换为“2009-01-01”的标准类型
        /// </summary>
        /// <param name="dt">要转换的datetime</param>
        /// <returns></returns>
        public static string DateTimeChange(DateTime dt)
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
        /// 以字符串形式返回表头名称
        /// </summary>
        /// <param name="table">表名</param>
        /// <returns>表头</returns>
        public string GetTableHeader(string table)
        {
            string sql = "exec pro_getHeader '" + table + "'";
            dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0][0].ToString().Trim();
            }
        }
        /// <summary>
        /// 根据条件查询表table中的信息
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="header">要查询的字段</param>
        /// <param name="tj">查询条件</param>
        /// <returns>信息</returns>
        public DataTable GetInfo(string table, string header, string tj)
        {
            string sql = "select distinct " + header + " from " + table + " where 1=1 " + tj;
            //string sql = "select " + header + " from " + table + " where 1=1 " + tj;
            return base.SqlDBAgent.GetDataTable(sql);
        }
        /// <summary>
        /// 将DataTable中的数据装载到ListView中
        /// </summary>
        /// <param name="listView1">要装载的ListView</param>
        /// <param name="table">被装载的数据</param>
        public static void LoadListView(ListView listView1, DataTable table)
        {
            if (table == null)
            {
                return;
            }
            listView1.Clear();
            listView1.ListViewItemSorter = null;
            listView1.Columns.Add("行号");
            foreach (DataColumn a in table.Columns)
            {
                listView1.Columns.Add(a.ToString());
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listView1.Items.Add((i + 1).ToString());

                for (int j = 0; j < table.Columns.Count; j++)
                {
                    string a = table.Rows[i][j].ToString();
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
        public static DataTable LoadDataTable(ListView listView1)
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

    }
}
