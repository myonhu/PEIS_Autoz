using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace PEIS
{
    class xtBiz : Base
    {

        /// <summary>
        /// 获取系统操作员
        /// </summary>
        /// <param name="rysx"></param>
        /// <returns></returns>
        public DataTable GetXtCzy(string rysx)
        {
            string strSql = "select czyid,czymc,czybm,yhzid from xt_czy where rysx='"+rysx+"' and tybz=0";

            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取系统当前时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDataNow()
        {
            string strSql = "select CONVERT(varchar(19), getdate(), 121) date";
            DataTable dt = base.SqlDBAgent.GetDataTable(strSql);
            return Convert.ToDateTime(dt.Rows[0][0].ToString().Trim());
        }

        /// <summary>
        /// 获取系统参数值
        /// </summary>
        /// <param name="csbm">参数编码</param>
        /// <returns></returns>
        public string GetXtCsz(string csbm)
        {
            string strSql;
            strSql = "select csz from xt_cssz where csbm='" + csbm + "'";
            String str= Convert.ToString(base.SqlDBAgent.sqlvalue(strSql));
            return str;
        }

        public string Getlx(string mc)
        {
            string sql = "select lclx from tj_suggestion where  mc='"+mc+"'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt.Rows.Count<=0)
            {
                return "";
            }
            return dt.Rows[0][0].ToString().Trim();
        }

        /// <summary>
        /// 获取系统字典数据
        /// </summary>
        /// <param name="zdflbm"></param>
        /// <returns></returns>
        public DataTable GetXtZd(int zdflbm)
        {
            string strSql;
            strSql = "select bzdm,xmmc from xt_zdxm where zdflbm='"+zdflbm+"' and tybz=0 order by xh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取系统字典数据--可以过滤
        /// </summary>
        /// <param name="zdflbm"></param>
        /// <param name="bzdm"></param>
        /// <returns></returns>
        public DataTable GetXtZd_filter(int zdflbm,string bzdm)
        {
            string strSql;
            strSql = "select bzdm,xmmc from xt_zdxm where zdflbm='" + zdflbm + "' and bzdm='"+bzdm+"' and tybz=0 order by xh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取系统参数ID
        /// </summary>
        /// <param name="hmfl">号码分类</param>
        /// <param name="num">号码个数</param>
        /// <returns></returns>
        public string GetHmz(string hmfl, int num)
        {
            if ("tjbh".Equals(hmfl) && num == 1)
            {
                return GetNewTjbh();
            }
            SqlParameter objHmfl = new SqlParameter();
            SqlParameter objHmsl = new SqlParameter();
            SqlParameter objHmz = new SqlParameter();

            objHmfl.Direction = ParameterDirection.Input;
            objHmsl.Direction = ParameterDirection.Input;
            objHmz.Direction = ParameterDirection.Output;

            objHmfl.Value = hmfl;
            objHmfl.SqlDbType = SqlDbType.VarChar;

            objHmsl.Value = num;
            objHmsl.SqlDbType = SqlDbType.Int;
            objHmz.SqlDbType = SqlDbType.VarChar;
            objHmfl.ParameterName = "@ywl";
            objHmsl.ParameterName = "@num";
            objHmz.ParameterName = "@ywh";
            objHmfl.Size = 20;
            objHmz.Size = 30;
            SqlParameter[] objParameterName = new SqlParameter[] { objHmfl, objHmsl, objHmz };

            return base.SqlDBAgent.GetPro("pro_gethmb", objParameterName).ToString();
        }

        public string GetNewTjbh()
        {
            string year = ""+DateTime.Now.Year;
            long max = long.Parse(GetMaxHmz(year).Substring(4));
            if (max != GetCountHmz(year))
            {
                for (int i = 1; i < max; i++)
                {
                    string tjbh = year + string.Format("{0:D5}", i);
                    if (!IsInTable(tjbh))
                        return tjbh;
                }
                
            }
            return year + string.Format("{0:D5}", max + 1);
        }
        /// <summary>
        /// 获取最大的体检编号
        /// </summary>
        /// <returns></returns>
        private string GetMaxHmz(string year)
        {
            string sqlStr = "select MAX(Tjbh) from tj_tjdjb where tjbh like '" + year + "%'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sqlStr);
            if (dt.Rows.Count <= 0)
            {
                return year+"00000";
            }
            if ("".Equals(dt.Rows[0][0].ToString().Trim()))
                return year+"00000";
            return dt.Rows[0][0].ToString().Trim();
        }

        private long GetCountHmz(string year)
        {
            string sqlStr = "select count(*) from tj_tjdjb where tjbh like '" + year + "%'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sqlStr);
            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            return long.Parse(dt.Rows[0][0].ToString().Trim());
        }
        /// <summary>
        /// 判断体检编号是否在表中
        /// </summary>
        /// <param name="tjbh">体检编号</param>
        /// <returns></returns>
        private bool IsInTable(string tjbh)
        {
            string sqlStr = "select count(*) from tj_tjdjb where tjbh = '"+ tjbh + "'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sqlStr);
            if (dt.Rows.Count <= 0)
            {
                return false;
            }
            int jj = int.Parse(dt.Rows[0][0].ToString().Trim());
            if (int.Parse(dt.Rows[0][0].ToString().Trim()) != 0)
                return true;
            return false;
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDate()
        {
            return Convert.ToDateTime( base.SqlDBAgent.GetDataTable("select getdate()").Rows[0][0].ToString());
        }

        /// <summary>
        /// 获取系统公共打印配置文件
        /// </summary>
        /// <param name="PageName">打印文件名字</param>
        /// <returns></returns>
        public DataTable Get_Xt_ggdy(string PageName)
        {
            string strSql;
            strSql = "select PaperName,PageWidth,PageHeight,MarginTop,MarginLeft,MarginRight,MarginBottom,PagePrinter from xt_ggdy where isnull(tybz,0)=0 and PageName='" + PageName + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取系统所有单据类型
        /// </summary>
        /// <returns></returns>
        public DataTable Get_All_Xt_ggdy()
        {
            string strSql;
            strSql = "select ID,PageName,PaperName,PageWidth,PageHeight,MarginTop,MarginLeft,MarginRight,MarginBottom,PagePrinter,sm,tybz from xt_ggdy order by ID";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 更新DataTable
        /// </summary>
        /// <param name="objDataTable"></param>
        /// <param name="objSql"></param>
        /// <returns></returns>
        public DataTable Update_Table(DataTable objDataTable, string objSql)
        {
            return base.SqlDBAgent.Update(objDataTable, objSql);
        }

        public DataTable Get_xt_cssz()
        {
            string strSql;
            strSql = "select id,csbm,csmc,csz,sm from xt_cssz";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Update_xt_cssz(DataTable objDataTable)
        {
            string strSql;
            strSql = "select id,csbm,csmc,csz,sm from xt_cssz";
            return base.SqlDBAgent.Update(objDataTable, strSql);
        }
        /// <summary>
        /// 获取拼音码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Get_Py(string str)
        {
            string strSql;
            strSql = "select dbo.fGetPy('" + str + "')";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        /// <summary>
        /// 获取五笔码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns> 
        public string Get_Wb(string str)
        {
            string strSql;
            strSql = "select dbo.fGetWb('" + str + "')";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }

        /// <summary>
        /// 根据体检日期和单位获取体检组合项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetTjxmByDwAndTjrq(string dw,string from ,string to)
        {
            string sql = "select distinct mc,disp_order from v_tjxm where tjrq>='" + from + "' and tjrq<='" + to + "'";
            if (dw!="")
            {
                sql += " and dwbh='" + dw + "'";
            }
            sql += " order by disp_order";
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public int GetTjrs(string dw, string from, string to)
        {
            string sql = "select count(*) from tj_tjdjb where  tjrq>='" + from + "' and tjrq<='" + to + "'";
            if (dw!="")
            {
                sql += " and dwbh='" + dw + "'";
            }
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt.Rows.Count<=0)
            {
                return 0;
            }
            return Convert.ToInt32(dt.Rows[0][0].ToString().Trim());
        }

        public DataTable GetTjhz(string dw, string from, string to)
        {
            string sql = "select dwmc,gz,isnull(whys,'') whys,count(*) rs,ycrs=sum(case when zs like '%各项结果未见明显异常%' or zs like '%所查项目%' or zs like '%各项结果未见异常%' or zs is null then 0 else 1 end),0 as zyjkyc "
                + "from v_jgtzs  where  tjrq>='" + from + "' and tjrq<='" + to + "'";
            if (dw!="")
            {
                sql += " and dwbh='" + dw + "'";
            }
            sql += "  group by dwmc,gz,whys";
            return base.SqlDBAgent.GetDataTable(sql);
        }

        public DataTable GetWjrs(string dw, string from, string to)
        {
            string sql = "select wjrs=sum(case when sumover='0' then 1 else 0 end),wzjrs=sum(case when sumover='1' then 1 else 0 end) "
                   + "from tj_tjdjb where   tjrq>='" + from + "' and tjrq<='" + to + "'";
            if (dw!="")
            {
                sql += " and dwbh='" + dw + "'";
            }
            sql += " group by dwbh";
            return base.SqlDBAgent.GetDataTable(sql);
        }

        public DataTable GetTjZhXm(string dw, string from, string to)
        {
            string sql = "select distinct b.mc,tjrq from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh join tj_zhxm_dt c on b.bh=c.bh " +
                  " join v_tj_tjdjb d on a.tjbh=d.tjbh and a.tjcs=d.tjcs " +
                 " where   tjrq>='" + from + "' and tjrq<='" + to + "'";
            if (dw != "")
            {
                sql += " and dwbh='" + dw + "'";
            }
            return base.SqlDBAgent.GetDataTable(sql);
        }

        public DataTable GetTjRsLb(string dw, string from, string to)
        {
            string sql = "select  count(distinct djlsh) as tjrs,rylb from tj_tjjlb a join v_tj_tjdjb b on a.tjbh=b.tjbh  "+
                        " where sumover=2  and tjrq>='" + from + "' and tjrq<='" + to + "'";
            if (dw != "")
            {
                sql += " and dwbh='" + dw + "'";
            }
            sql += " group by rylb";
            return base.SqlDBAgent.GetDataTable(sql);
        }

        public DataTable GetTjJkYcHz(string dw, string from, string to)
        {
            string sql = "select sum(jkycsr) jkycrs,sum(zyjkycsr) zyjkycrs,sum(jkycsr)+sum(zyjkycsr)+sum(zcsr) as zrs,gz,whysmc from ( " +
            "select  jkycbz,gz,whysmc,case when jkycbz='健康异常' then 1 else 0 end jkycsr,case when jkycbz='职业健康异常' then 1 else 0 end zyjkycsr,case when ltrim(rtrim(jkycbz))='' or ltrim(rtrim(jkycbz)) is null then 1 else 0 end zcsr from  " + 
            "v_tj_tjdjb d "+
            "where sumover=2 and tjrq>='" + from + "' and tjrq<='" + to + "'";
            if (dw != "")
            {
                sql += " and dwbh='" + dw + "') a group by gz,whysmc";
            }
            return base.SqlDBAgent.GetDataTable(sql);
        }

        public DataTable GetJkycXm(string gz, string whys,string dw,string from,string to)
        {
            string sql = "select xm from v_tj_tjdjb d " +
            "where sumover=2 and jkycbz='职业健康异常' and tjrq>='" + from + "' and tjrq<='" + to + "' and gz='" + gz + "' and whysmc='" + whys + "'";
            if (dw != "")
            {
                sql += " and dwbh='" + dw + "'";
            }
            return base.SqlDBAgent.GetDataTable(sql);
        }

        /// <summary>
        /// 获取系统字典标准代码
        /// </summary>
        /// <param name="zdflbm">字典分类编码</param>
        /// <param name="xmmc">项目名称</param>
        /// <returns></returns>
        public string Get_Xtzd_Bzdm(string zdflbm, string xmmc)
        {
            string strSql;
            strSql = "select bzdm from xt_zdxm where zdflbm='" + zdflbm + "' and xmmc='" + xmmc + "'";
            try
            {
                return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取系统字典标准代码
        /// </summary>
        /// <param name="zdflbm">字典分类编码</param>
        /// <param name="xmmc">项目名称</param>
        /// <returns></returns>
        public string Get_Xtzd_Bzdmxh(string zdflbm, int xh)
        {
            string strSql;
            strSql = "select xmmc from xt_zdxm where zdflbm='" + zdflbm + "' and bzdm=" + xh;
            try
            {
                return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 获取听力校对值
        /// </summary>
        /// <param name="nl">年龄</param>
        /// <param name="xb">性别</param>
        /// <param name="pl">频率</param>
        /// <param name="jg">检测结果</param>
        /// <returns></returns>
        public string GetTjjdz(string nl, string xb, int pl, string jg)
        {
            int jgint = Convert.ToInt32(jg);
            string strSql = "exec pro_tj_tl_compute '" + nl + "','" + xb + "','" + pl + "','" + jgint + "'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(strSql);
            if (dt.Rows.Count <= 0)
            {
                return "";
            }
            return dt.Rows[0][0].ToString().Trim();

            return null;
        }

        /// <summary>
        /// 根据工种查询危害因素
        /// </summary>
        /// <param name="gzid"></param>
        /// <returns></returns>
        public string GetWhysid(string gzid)
        {
            string sql = "select whysid from tj_zyb_gzwhys where gzid='"+gzid+"'";
            DataTable dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt.Rows.Count<=0)
            {
                return "";
            }
            return dt.Rows[0][0].ToString().Trim();
        }

        public int Insert(string gzid, string whysid)
        {
            string sql = "insert into tj_zyb_gzwhys(gzid,whysid) values('"+gzid+"','"+whysid+"')";
            return base.SqlDBAgent.sqlupdate(sql);
        }

        public int Delete(string gzid)
        {
            string sql = "delete from  tj_zyb_gzwhys where gzid='"+gzid+"' ";
            return base.SqlDBAgent.sqlupdate(sql);
        }

        public int ExecSql(string strsql)
        {
            string sql = strsql;
            return base.SqlDBAgent.sqlupdate(sql);
        }

    }
}
