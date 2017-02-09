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
    /// DataGridView���ݵ���
    /// </summary>
    public class DataGridViewExport
    {
        /// <summary>
        /// ��ListView�е����ݵ�����ָ����Excel�ļ���
        /// </summary>
        /// <param name="listView">System.Windows.Forms.ListView,ָ��Ҫ����������Դ</param>
        /// <param name="destFileName">ָ��Ŀ���ļ�·��</param>
        /// <param name="tableName">Ҫ�������ı�����</param>
        /// <param name="overWrite">ָ���Ƿ񸲸��Ѵ��ڵı�</param>
        /// <returns>�����ļ�¼������</returns>
        public static int ExportToExcel(DataGridView gridView, string destFileName, string tableName, bool overWrite)
        {
            //�õ��ֶ���
            string szFields = "";
            string szValues = "";
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                szFields += "[" + gridView.Columns[i].HeaderText + "],";
            }
            szFields = szFields.TrimEnd(',');
            //������������
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = DataGridViewExport.GetConnectionString(destFileName);
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            //�����ݿ�����
            try
            {
                connection.Open();
            }
            catch
            {
                throw new Exception("Ŀ���ļ�·������");
            }
            //�������ݿ��
            try
            {
                command.CommandText = DataGridViewExport.GetCreateTableSql("[" + tableName + "]", szFields.Split(','));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //�����������ɾ����������
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
                //ѭ����������------------------------------------------
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
                    //��ϳ�SQL��䲢ִ��
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
        //�õ������ַ���
        private static String GetConnectionString(string fullPath)
        {
            string szConnection;
            szConnection = "Provider=Microsoft.JET.OLEDB.4.0;Extended Properties=Excel 8.0;data source=" + fullPath;
            return szConnection;
        }
        //�õ��������SQL���
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
        /// ��Excel�ĵ�
        /// </summary>
        /// <param name="path">Excel�ĵ���·��������</param>
        public static void OpenExcel(string path)
        {
            System.Diagnostics.Process.Start(path);
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        }

        /// <summary>
        /// �ж��Ƿ�װExcel
        /// </summary>
        /// <returns>true����װ�ˣ�FALSE��û��װ</returns>
        public static bool IsExistsExcel()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            if (type == null)
            {
                MessageBox.Show("���ļ������δ��װExcel��\n��װ����ܴ�Excel�ĵ���", "�޷����ĵ�",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //MessageBox.Show(type);
            return true;
        }

        /// <summary>
        /// DataGridView����Excel�����������xls�ļ�
        /// </summary>
        public static void SaveAs(DataGridView dgvAgeWeekSex) //����µ���ť   ������Excel
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
                //д����
                for (int i = 0; i < dgvAgeWeekSex.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvAgeWeekSex.Columns[i].HeaderText;
                }

                sw.WriteLine(str);


                //д����
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
                        tempStr += "��" + dgvAgeWeekSex.Rows[j].Cells[k].Value == "" ? "" : dgvAgeWeekSex.Rows[j].Cells[k].Value.ToString();
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
        /// ��Excel����DataGridView�ؼ������ݵ�����Excel   
        /// </summary>   
        /// <param name="dgv">DataGridView���� </param>   
        /// <param name="isShowExcle">�Ƿ���ʾExcel���� </param>   
        /// <remarks>   
        /// add com "Microsoft Excel 11.0 Object Library"   
        /// using Excel=Microsoft.Office.Interop.Excel;   
        /// </remarks>   
        /// <returns> </returns>   
        public static bool DataGridviewShowToExcel(DataGridView dgv, bool isShowExcle)
        {
            #region  ��������
            if (dgv.Rows.Count == 0)
                return false;

            //��������Ի���   
            SaveFileDialog dlg = new SaveFileDialog();
            //ĬȻ�ļ���׺   
            dlg.DefaultExt = "xls ";
            //�ļ���׺�б�   
            dlg.Filter = "Excel�ļ�(*.xls)|*.xls";
            //ĬȻ·����ϵͳ��ǰ·��   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //�򿪱���Ի���   
            if (dlg.ShowDialog() == DialogResult.Cancel) return false;
            //�����ļ�·��   
            string fileNameString = dlg.FileName;
            //��֤strFileName�Ƿ�Ϊ�ջ�ֵ��Ч   
            if (fileNameString.Trim() == "") return false;

            //ArrayList arryList = new ArrayList();
            //foreach (DataGridViewColumn dgc in dgv.Columns)//ɾ�����ص���
            //{
            //    if (!dgc.Visible)
            //        arryList.Add(dgc);
            //}
            //for (int a = 0; a < arryList.Count; a++)
            //{
            //    dgv.Columns.Remove((DataGridViewColumn)arryList[a]);
            //}

            //����Excel����   
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcle;
            //�����ֶ�����   
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }
            }
            //�������   
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
                MessageBox.Show(error.Message, "���� ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                excel.Quit();
            }
            if (DialogResult.Yes == MessageBox.Show("�Ƿ�򿪸��ļ���", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
            {
                OpenExcel(fileNameString);
            }
            return true;
            #endregion  ��������
        }

    }
}
