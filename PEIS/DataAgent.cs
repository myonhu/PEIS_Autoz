using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
using PEIS.xtgg;
namespace PEIS
{
    class DataAgent
    {
        private string i_strConn;
        private SqlConnection i_objConn;
        //取得数据库连接字符串
        public DataAgent(string strConn)
        {
            this.i_strConn = strConn;
        }
        //打开数据库
        private void OpenDataBase()
        {
            try
            {
                this.i_objConn = new SqlConnection();
                this.i_objConn.ConnectionString = this.i_strConn;
                if (this.i_objConn.State != ConnectionState.Open)
                {
                    this.i_objConn.Open();
                }
            }
            catch
            {
                Form_dbc frm = new Form_dbc();
                frm.ShowDialog();
                //MessageBox.Show("服务器数据库连接失败，请联系管理员！");
            }
        }
        //关闭数据库  
        private void CloseDataBase()
        {
            if (this.i_objConn != null)
            {
                if (this.i_objConn.State == ConnectionState.Open)
                {
                    this.i_objConn.Close();
                }
            }
        }
        //读取数据
        public DataTable GetDataTable(string strSqlStat)
        {
            try
            {
                this.OpenDataBase();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(strSqlStat.Trim(), this.i_objConn);
                DataSet objDataSet = new DataSet();
                objDataAdapter.Fill(objDataSet);

                return objDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                OnError(strSqlStat);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }
        //保存数据
        public DataTable Update(DataTable objDataTable, string strSqlStat)
        {
            try
            {
                this.OpenDataBase();
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(strSqlStat.Trim(), this.i_objConn);

                SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(objDataAdapter);
                objDataAdapter.Update(objDataTable.DataSet, objDataTable.TableName);

                return objDataTable;
            }
            catch (Exception ex)
            {
                OnError(strSqlStat);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }
        public int sqlupdate(string strSqlStat, SqlParameter[] objParameterName)
        {
            try
            {
                this.OpenDataBase();
                if (strSqlStat.Contains("insert"))
                    strSqlStat = strSqlStat.Replace("''", "null");//把空字符串传成NULL值----------------------------------------------------------------------------------------
                SqlCommand objCommand = new SqlCommand(strSqlStat.Trim(), this.i_objConn);
                objCommand.Parameters.AddRange(objParameterName);
                return objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                OnError(strSqlStat);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }
        //执行存储过程
        public Object GetPro(string proName, SqlParameter[] objParameterName)
        {

            //Object objReturn = 0;
            //this.OpenDataBase();
            //SqlCommand objCommand = new SqlCommand(proName, i_objConn);
            //objCommand.CommandType = CommandType.StoredProcedure;

            //objCommand.Parameters.AddRange(objParameterName);
            //objCommand.ExecuteNonQuery();
            //for (int i = 0; i < objParameterName.Length; i++)
            //{
            //    if (objParameterName[i].Direction == ParameterDirection.Output)
            //    {
            //        objReturn = objParameterName[i].Value;
            //    }
            //}
            //return objReturn;
            try
            {
                Object objReturn = 0;
                this.OpenDataBase();
                SqlCommand objCommand = new SqlCommand(proName, i_objConn);
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.AddRange(objParameterName);
                objCommand.ExecuteNonQuery();
                for (int i = 0; i < objParameterName.Length; i++)
                {
                    if (objParameterName[i].Direction == ParameterDirection.Output)
                    {
                        objReturn = objParameterName[i].Value;
                    }
                }
                return objReturn;
            }
            catch (Exception ex)
            {
                //OnError(strSqlStat);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }

        public int sqlupdate(string strSqlStat)
        {
            try
            {
                this.OpenDataBase();
                if (strSqlStat.Contains("insert"))
                    strSqlStat = strSqlStat.Replace("''", "null");//把空字符串传成NULL值----------------------------------------------------------------------------------------
                SqlCommand objCommand = new SqlCommand(strSqlStat.Trim(), this.i_objConn);

                return objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                OnError(strSqlStat);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }

        //public int sqlupdate(string strSqlStat,SqlParameter[] para)
        //{
        //    try
        //    {
        //        this.OpenDataBase();
        //        if (strSqlStat.Contains("insert"))
        //            strSqlStat = strSqlStat.Replace("''", "null");//把空字符串传成NULL值----------------------------------------------------------------------------------------
        //        SqlCommand objCommand = new SqlCommand(strSqlStat.Trim(), this.i_objConn);
        //        for (int i = 0; i < para.Length; i++)
        //        {
        //            objCommand.Parameters.Add(para[i]);
        //        }
        //        return objCommand.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        OnError(strSqlStat);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        this.CloseDataBase();
        //    }
        //}

        public int sqlupdate(string []strSqlStat)
        {
            int count = 0;
            this.OpenDataBase();
            SqlTransaction myTran;
            myTran = this.i_objConn.BeginTransaction();
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = this.i_objConn;
                objCommand.Transaction = myTran;
                for (int i = 0; i < strSqlStat.Length; i++)
                {
                    if (strSqlStat[i].Contains("insert"))
                        objCommand.CommandText = strSqlStat[i].Replace("''", "null");//把空字符串传成NULL值--------------------------------------------------------------
                    else
                        objCommand.CommandText = strSqlStat[i];
                    count = objCommand.ExecuteNonQuery();
                }
                myTran.Commit();
                return count;
            }
            catch (Exception ex)
            {
                myTran.Rollback();

                string str_error = "";
                for (int i = 0; i < strSqlStat.Length; i++)
                {
                    str_error = str_error + ";" + strSqlStat[i];
                }
                OnError(str_error);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }

        public int sqlupdate(ArrayList arrayList)
        {
            int count = 0;
            this.OpenDataBase();
            SqlTransaction myTran;
            myTran = this.i_objConn.BeginTransaction();
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = this.i_objConn;
                objCommand.Transaction = myTran;
                for (int i = 0; i < arrayList.Count; i++)
                {
                    if (arrayList[i].ToString().Contains("insert"))
                        objCommand.CommandText = arrayList[i].ToString().Replace("''", "null");//把空字符串传成NULL值------------------------------------------------
                    else
                        objCommand.CommandText = arrayList[i].ToString();
                    count = objCommand.ExecuteNonQuery();
                }
                myTran.Commit();
                return count;
            }
            catch (Exception ex)
            {
                myTran.Rollback();

                string str_error = "";
                for (int i = 0; i < arrayList.Count; i++)
                {
                    str_error = str_error + ";" + arrayList[i].ToString();
                }
                OnError(str_error);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }

        public int sqlupdate(List<string> arrayList)
        {
            int count = 0;
            this.OpenDataBase();
            SqlTransaction myTran;
            myTran = this.i_objConn.BeginTransaction();
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = this.i_objConn;
                objCommand.Transaction = myTran;
                for (int i = 0; i < arrayList.Count; i++)
                {
                    //if (arrayList[i].ToString().Contains("insert"))
                    objCommand.CommandText = arrayList[i].ToString().Replace("''", "null");//把空字符串传成NULL值------------------------------------------------
                    //else
                    //objCommand.CommandText = arrayList[i].ToString();
                    count = objCommand.ExecuteNonQuery();
                }
                myTran.Commit();
                return count;
            }
            catch (Exception ex)
            {
                myTran.Rollback();

                string str_error = "";
                for (int i = 0; i < arrayList.Count; i++)
                {
                    str_error = str_error + ";" + arrayList[i].ToString();
                }
                OnError(str_error);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }

        public int sqlupdate(List<string> arrayList,System.Windows.Forms.ProgressBar pb)
        {
            pb.Minimum = 0;
            pb.Maximum = arrayList.Count - 1;
            int count = 0;
            this.OpenDataBase();
            SqlTransaction myTran;
            myTran = this.i_objConn.BeginTransaction();
            try
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = this.i_objConn;
                objCommand.Transaction = myTran;
                for (int i = 0; i < arrayList.Count; i++)
                {
                    //if (arrayList[i].ToString().Contains("insert"))
                    objCommand.CommandText = arrayList[i].ToString().Replace("''", "null");//把空字符串传成NULL值------------------------------------------------
                    //else
                    //objCommand.CommandText = arrayList[i].ToString();
                    count = objCommand.ExecuteNonQuery();
                    pb.Value = i;
                }
                myTran.Commit();
                return count;
            }
            catch (Exception ex)
            {
                myTran.Rollback();

                string str_error = "";
                for (int i = 0; i < arrayList.Count; i++)
                {
                    str_error = str_error + ";" + arrayList[i].ToString();
                }
                OnError(str_error);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }

        //执行存储过程无返回值
        public void SetPro(string proName, SqlParameter[] objParameterName)
        {

            this.OpenDataBase();
            SqlCommand objCommand = new SqlCommand(proName, i_objConn);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.AddRange(objParameterName);
            objCommand.ExecuteNonQuery();
        }


        public DbType ToType(SqlDbType type)
        {
            switch (type)
            {
                case SqlDbType.BigInt:
                    return DbType.Int16;
                case SqlDbType.Binary:
                    return DbType.Byte;
                case SqlDbType.Bit:
                    return DbType.Boolean;
                case SqlDbType.Char:
                    return DbType.String;
                case SqlDbType.DateTime:
                    return DbType.DateTime;
                case SqlDbType.Decimal:
                    return DbType.Decimal;
                case SqlDbType.Image:
                    return DbType.Byte;
                case SqlDbType.Int:
                    return DbType.Int32;
                case SqlDbType.Money:
                    return DbType.Decimal;
                case SqlDbType.VarChar:
                    return DbType.String;
                case SqlDbType.Xml:
                    return DbType.String;
                default:
                    return DbType.Object;
            }
        }

        public object sqlvalue(string strSqlStat)
        {
            try
            {
                this.OpenDataBase();
                SqlCommand objCommand = new SqlCommand(strSqlStat.Trim(), this.i_objConn);
                return objCommand.ExecuteScalar();
            }
            catch(Exception ex)
            {
                OnError(strSqlStat);
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }
        private void OnError(string str_error)
        {
            //try
            //{
            //    this.OpenDataBase();
            //    SqlCommand objCommand = new SqlCommand("", this.i_objConn);
            //        //"insert xt_error(errortext,czy,czsj) select '" + str_error.Replace("'","|") + "','" + Program.username + "',getdate()", this.i_objConn);
            //    objCommand.ExecuteNonQuery();
            //    Form_error frm = new Form_error(str_error);
            //    frm.ShowDialog();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("错误日志记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    throw ex;
            //}
            //finally
            //{
            //    this.CloseDataBase();
            //}
        }

        public void WriteLog(string form, string str_error, string czy, string logtype)
        {
            try
            {
                this.OpenDataBase();
                SqlCommand objCommand = new SqlCommand(
                    "insert xt_log(table_name,event_content,czy,rq,bz) select '" + form + "','" + str_error + "','" + czy + "',getdate(),'" + logtype + "'", this.i_objConn);
                objCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseDataBase();
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。要求所有语句都要返回影响行数
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public bool ExecuteSqlTran(List<string> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(this.i_strConn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    bool issuccess = true;
                    foreach (string strsql in SQLStringList)
                    {
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            int n = cmd.ExecuteNonQuery();
                            if (n <= 0)
                            {
                                issuccess = false;
                                tx.Rollback();
                                break;
                            }
                        }
                    }
                    if (issuccess)
                    {
                        tx.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    tx.Rollback();
                    return false;
                }
            }
        }
    }
}
