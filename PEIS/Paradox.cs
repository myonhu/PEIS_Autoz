using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Sybase.Data.AseClient;
using System.Data.Odbc;

namespace PEIS
{
    public class Paradox
    {

        private string str_constr = "";
       

        public Paradox()
        {
            str_constr = System.Configuration.ConfigurationManager.AppSettings["sqlanywhere"].ToString();
        }

       
        public DataTable GetResult_odbc(string sql)
        {
            
            OdbcConnection conn = new OdbcConnection(str_constr);
            DataTable dt = new DataTable();           
            OdbcDataAdapter da = null;
           
            try
            {                
                da = new OdbcDataAdapter(sql, conn);
                da.Fill(dt);
            }
            catch(System.Exception ex)
            {
                throw ex;
            }

            return dt;
        }
       


    }
}
