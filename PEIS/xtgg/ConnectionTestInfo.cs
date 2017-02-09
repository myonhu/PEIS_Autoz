using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PEIS.xtgg
{
    public class ConnectionTestInfo
    {
        private static SqlConnection mySqlConnection;  //mySqlConnection   is   a   SqlConnection   object 
        private static string ConnectionString = "";
        private static bool IsCanConnectioned = false;

        /// <summary>
        /// �����������ݿ��Ƿ�ɹ�
        /// </summary>
        /// <returns></returns>
        public  bool ConnectionTest(string constr)
        {
            //��ȡ���ݿ������ַ���
            ConnectionString = constr;
            //�������Ӷ���
            mySqlConnection = new SqlConnection(ConnectionString);
            //ConnectionTimeout ��.net 1.x �������� ��.net 2.0����ֻ�����ԣ�����Ҫ�������ַ�������
            //�磺server=.;uid=sa;pwd=;database=PMIS;Integrated Security=SSPI; Connection Timeout=30
            //mySqlConnection.ConnectionTimeout = 1;//�������ӳ�ʱ��ʱ��
            try
            {
                //Open DataBase
                //�����ݿ�
                mySqlConnection.Open();
                IsCanConnectioned = true;
            }
            catch
            {
                //Can not Open DataBase
                //�򿪲��ɹ� �����Ӳ��ɹ�
                IsCanConnectioned = false;
            }
            finally
            {
                //Close DataBase
                //�ر����ݿ�����
                mySqlConnection.Close();
            }
            //mySqlConnection   is   a   SqlConnection   object 
            if (mySqlConnection.State == ConnectionState.Closed || mySqlConnection.State == ConnectionState.Broken)
            {
                //Connection   is   not   available  
                return IsCanConnectioned;
            }
            else
            {
                //Connection   is   available  
                return IsCanConnectioned;
            }
        }
    }
}
