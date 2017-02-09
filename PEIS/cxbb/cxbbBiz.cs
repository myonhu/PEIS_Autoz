using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace PEIS.cxbb
{
    class cxbbBiz: Base
    {
        ArrayList arryList = new ArrayList();
        public int Exec_ArryList()
        {
            if (arryList.Count == 0)
            {
                return 0;
            }
            return base.SqlDBAgent.sqlupdate(arryList);
        }
        /// <summary>
        /// sql语句
        /// </summary>
        /// <param name="strSql">sql语句</param>
        public void str_Sqltxt(string strSql)
        {
            arryList.Add(strSql);
        }

        public DataTable Get_pro_tj_tjxmjg(string dwbh, string bmbh, string begin, string end,string mbbh)
        {
            string strSql;
            strSql = "exec pro_tj_tjxmjg '" + dwbh + "','" + bmbh + "','" + begin + "','" + end + "','" + mbbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_pro_tj_tjxmjgyx(string dwbh, string bmbh, string begin, string end, string mbbh)
        {
            string strSql;
            strSql = "exec pro_tj_tjxmjgyx '" + dwbh + "','" + bmbh + "','" + begin + "','" + end + "','" + mbbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_pro_tj_yxjghz(string dwbh, string bmbh, string begin, string end, string rylb, string xb)
        {
            string strSql;
            strSql = "exec pro_tj_yxjghz '" + dwbh + "','" + bmbh + "','" + begin + "','" + end + "','" + rylb + "','" + xb + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_pro_tj_tjzcqd(string dwbh, string bmbh, string begin, string end, string rylb, string xb,string gz)
        {
            string strSql;
            strSql = "exec pro_tj_tjzcqd '" + dwbh + "','" + bmbh + "','" + begin + "','" + end + "','" + rylb + "','" + xb + "','"+ gz + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_JBMB_HD()
        {
            string strSql;
            strSql = "select bh,mbmc from TJ_JBMB_HD order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_JBMB_DT(string bh)
        {
            string strSql;
            strSql = "select a.jbbh,b.keyword from TJ_JBMB_DT a join TJ_SUGGESTION b on a.jbbh=b.bh and a.tjlx=b.tjlx where a.bh='" + bh + "'order by b.tjlx,b.bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_SUGGESTION()
        {
            string strSql;
            strSql = "select bh,keyword from TJ_SUGGESTION where jbbh=1 order by tjlx,bh";//参与统计的疾病
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_pro_tj_jbrstj(string dwbh, string bmbh, string begin, string end, string rylb, string xb,string jbbh)
        {
            string strSql;
            strSql = "exec pro_tj_jbrstj '" + dwbh + "','" + bmbh + "','" + begin + "','" + end + "','" + rylb + "','" + xb + "','" + jbbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_pro_tj_jbhztj(string dwbh, string bmbh, string begin, string end, string rylb, string xb, string jbbh)
        {
            string strSql;
            strSql = "exec pro_tj_jbhztj '" + dwbh + "','" + bmbh + "','" + begin + "','" + end + "','" + rylb + "','" + xb + "','" + jbbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_pro_tj_jbfbtj(string dwbh, string bmbh, string begin, string end, string rylb, string bljs, string jbbh)
        {
            string strSql;
            strSql = "exec pro_tj_jbfbtj '" + dwbh + "','" + bmbh + "','" + begin + "','" + end + "','" + rylb + "','" + bljs + "','" + jbbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_pro_tj_tjrstj(string dwbh, string bmbh, string begin, string end, string rylb)
        {
            string strSql;
            strSql = "exec pro_tj_tjrstj '" + dwbh + "','" + bmbh + "','" + begin + "','" + end + "','" + rylb + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_v_tj_sfxx(string dwbh, string begin, string end)
        {
            string strSql;
            strSql = "select  tjbh,tjcs,xm,xb,nl,sfrq,tjrq,sfh,czymc,ssje,ysje,yhxx,mc,dwbh from v_tj_sfxx  where (dwbh='" + dwbh + "'or '"+dwbh+"'='') and sfrq>='" + begin + "' and sfrq<'" + end +"' order by sfrq desc";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_v_tj_wsfxx(string dwbh, string begin, string end)
        {
            string strSql;
            strSql = "select  tjbh,tjcs,xm,xb,tjrq,dwmc,dwbh,sum(hj) hj from v_tj_wsffyxx  where (dwbh='" + dwbh + "'or '" + dwbh + "'='') and tjrq>='" + begin + "' and tjrq<'" + end + "' group by tjbh,tjcs,xm,xb,tjrq,dwmc,dwbh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_pro_tj_zybhzbb(string begin, string end, string dwbh, string bblx)
        {
            string strSql;
            strSql = "exec pro_bb_zybhz '" + begin + "','" + end + "','" + dwbh + "','" + bblx + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable GetRyxx(string begin, string end, string dwbh)
        {
            StringBuilder sql = new StringBuilder("select dwmc,dwbh,tjrq,tjbh,tjcs,xm,xb,nl,gz,rylb,dhqk,jsgl,zs,jy from v_jgtzs where tjrq>='"+begin+"' and tjrq<='"+end+"'");
            if (dwbh!="")
            {
                sql.Append(" and dwbh='"+dwbh+"'");
            }

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取操作日志记录
        /// </summary>
        public DataTable Get_Log(string ksrq, string jsrq, string czy)
        {
            string strSql;
            if (czy == "" || czy == null)
            {
                strSql = "select  a.id,a.event_content,bz,czy,rq from xt_log a where rq>='" + ksrq + " 00:00:00'  and rq<'" + jsrq + " 23:59:59' order by rq desc";

            }
            else
            {
                strSql = "select  a.id,a.event_content,bz,czy,rq  from xt_log a   where rq>='" + ksrq + " 00:00:00'  and rq<'" + jsrq + " 23:59:59' and czy='" + czy + "' order by rq desc";
            }

            return base.SqlDBAgent.GetDataTable(strSql);
        }
    }
}
