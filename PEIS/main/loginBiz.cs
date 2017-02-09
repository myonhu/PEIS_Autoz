using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PEIS
{
    class loginBiz : Base
    {
        xtBiz xt = new xtBiz();
        public DataTable GetNewsList(string rybm)
        {
            string strSql;
            strSql = "select czymc,yhzid,mm from xt_czy where czybm ='" + rybm + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable GetCzyInfo(string rybm)
        {
            string strSql;
            //strSql = "select rybm,ryid,rylx,rymc,a.ksid,ksmc,b.mm,yhzid,c.kssx from xt_ry a join xt_czy b on a.ryid=b.czyid join xt_ks c on a.ksid=c.ksid where b.czybm ='" + rybm + "'";
            //czyid,czymc,czybm,yhzid,mm,rysx,tybz,ksid

            strSql = "select czyid,czymc,czybm,yhzid,mm,rysx,tybz,ksid from xt_czy where czybm ='" + rybm + "' and tybz=0";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int UpdatePsd(string czyid, string password)
        {
            string strSql;
            strSql = "update xt_czy set mm='"+password+"' where czyid='" + czyid + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public string Get_Yhsl()
        {
            string strSql;
            strSql = "select count(distinct hostname) from master..sysprocesses where program_name='XXTJXT'";
            
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }

        public int Insert_fplog(string fph, string xm,string dwmc,string czy)
        {
            string strSql;
            strSql = "insert into xx_fplog(fph,xm,dwmc,czy) select '"+fph+"','"+xm+"','"+dwmc+"','"+czy+"'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        /// <summary>
        /// 获取体检登记表中的最大登记日期
        /// </summary>
        /// <returns></returns>
        public DateTime GetMaxDjrq()
        {
            string strSql = "select max(djrq) rq from tj_tjdjb";
            DataTable dt = base.SqlDBAgent.GetDataTable(strSql);
            if (dt.Rows.Count<=0)
            {
                return Convert.ToDateTime("1800-1-1");
            }
            string time=dt.Rows[0][0].ToString().Trim();
            if (time==null || time=="")
            {
                return Convert.ToDateTime("1800-1-1");
            }
            return Convert.ToDateTime(time);
        }

        /// <summary>
        /// 获取系统当前日期
        /// </summary>
        /// <returns></returns>
        public DateTime GetNowDate()
        {
            string strSql = "select CONVERT(varchar(19), getdate(), 121) rq";
            return Convert.ToDateTime(base.SqlDBAgent.GetDataTable(strSql).Rows[0][0].ToString().Trim());
        }

        //获取体检登记表的行数
        public int Get_Tjdjbsl()
        {
            string strSql;
            strSql = "select count(*) from tj_tjdjb";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql).ToString());
        }


        /// <summary>
        /// 记录日志--普通
        /// </summary>
        public void WriteLog(string form, string str_error, string czy)
        {
            string logbz = xt.GetXtCsz("writelogpt");
            if (logbz == "1")  //记录
            {
                base.SqlDBAgent.WriteLog(form, str_error, czy, "操作类日志");
            }
            else   //不记录
            {

            }
        }
        /// <summary>
        /// 记录日志--异常
        /// </summary>
        public void WriteLogErr(string form, string str_error, string czy)
        {
            string logbz = xt.GetXtCsz("writelogyc");
            if (logbz == "1")  //记录
            {
                base.SqlDBAgent.WriteLog(form, str_error, czy, "错误类日志");
            }
            else   //不记录
            {

            }
        }
    }
}
