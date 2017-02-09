using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    class LisBiz : Base
    {
        public ArrayList arryList = new ArrayList();

        /// <summary>
        /// 执行数组
        /// </summary>
        /// <returns></returns>
        public int Exec_ArrayList()
        {
            if (arryList.Count == 0)
            {
                return 0;
            }
            return base.SqlDBAgent.sqlupdate(arryList);
        }
        /// <summary>
        /// 获取服务器日期
        /// </summary>
        /// <returns></returns>
        public string Get_ServerDate()
        {
            string strSql;
            strSql = "select getdate() select CONVERT(varchar(19), getdate(), 121)";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        /// <summary>
        /// 获取检验科室
        /// </summary>
        /// <returns></returns>
        public DataTable Get_TJ_TJLXB()
        {
            string strSql;
            strSql = "select lxbh,mc from TJ_TJLXB where jcjylx=0";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取检验类型
        /// </summary>
        /// <returns></returns>
        public DataTable Get_TJ_LCLXB()
        {
            string strSql;
            strSql = "select lclx,mc from TJ_LCLXB order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 根据检验科室、检验类型获取检验明细项目
        /// </summary>
        /// <param name="jyksid">检验科室ID</param>
        /// <param name="lclx">检验类型</param>
        /// <returns></returns>
        public DataTable Get_TJ_TJXMB(string jyksid, string lclx)
        {
            string strSql;
            strSql = "select tjxm,mc from TJ_TJXMB where lxbh in(" + jyksid + ") and lclx='" + lclx + "' order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取检验项目对照码
        /// </summary>
        /// <param name="TJMXXM">体检明细项目码</param>
        /// <returns></returns>
        public DataTable Get_TJ_JGXMDZB(string TJMXXM)
        {
            string strSql;
            strSql = "select TJMXXM,JYJX,GJC,SM from TJ_JGXMDZB where TJMXXM='" + TJMXXM + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取检验项目对照码
        /// </summary>
        /// <param name="TJMXXM">LIS明细项目码</param>
        /// <returns></returns>
        public DataTable Get_LIS_JGXMDZB(string GJC, string TJMXXM)
        {
            string strSql;
            strSql = "select a.TJMXXM,a.GJC,a.SM,b.mc from TJ_JGXMDZB a join tj_tjxmb b on a.TJMXXM=b.tjxm where a.GJC='" + GJC + "' and a.TJMXXM<>'" + TJMXXM + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 保存项目对照码
        /// </summary>
        /// <param name="TJMXXM">体检系统码</param>
        /// <param name="GJC">LIS系统码</param>
        /// <param name="SM">说明</param>
        /// <returns></returns>
        public int str_Insert_TJ_JGXMDZB(string TJMXXM, string GJC, string SM)
        {
            string strSql;
            strSql = "delete from TJ_JGXMDZB where tjmxxm='" + TJMXXM + "';";
            strSql = strSql + "insert TJ_JGXMDZB(TJMXXM,GJC,SM) select '" + TJMXXM + "','" + GJC + "','" + SM + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        public void str_Delete_TJ_JGXMDZB(string TJMXXM)
        {
            string strSql;
            strSql = "delete from TJ_JGXMDZB where tjmxxm='" + TJMXXM + "';";
            arryList.Add(strSql);
        }
        /// <summary>
        /// 保存项目对照码
        /// </summary>
        /// <param name="TJMXXM">体检系统码</param>
        /// <param name="GJC">检验机型</param>
        /// <param name="GJC">LIS系统码</param>
        /// <param name="SM">说明</param>
        /// <returns></returns>
        public void str_Insert_TJ_JGXMDZB(string TJMXXM, string JYJX, string GJC, string SM)
        {
            string strSql;
            strSql = "insert TJ_JGXMDZB(TJMXXM,JYJX,GJC,SM) select '" + TJMXXM + "','" + JYJX + "','" + GJC + "','" + SM + "';";
            arryList.Add(strSql);
        }

        public int DeleteTJ_JGXMDZB(string tjxmbh, string jyxmbh)
        {
            string sql = "delete from TJ_JGXMDZB where tjmxxm='"+tjxmbh+"' and gjc='"+jyxmbh+"'";

            return base.SqlDBAgent.sqlupdate(sql);
        }

        /// <summary>
        /// 获取体检登记人员信息
        /// </summary>
        /// <param name="zt">LIS申请登记状态：0全部 1未登记 2已登记</param>
        /// <param name="djlsh">登记流水号</param>
        /// <param name="xm">姓名</param>
        /// <param name="rq1">日期1</param>
        /// <param name="rq2">日期2</param>
        /// <returns></returns>
        public DataTable Get_TJ_TJDJB(int zt, string djlsh,string xm,string rq1,string rq2)
        {
            string strSql;
            strSql = "select distinct b.djlsh,b.xm,case b.xb when '1' then '男' when '0' then '女' else '不详' end as xb,b.nl,b.tjrq,b.sjcxxh,b.tjbh,b.tjcs from TJ_BBDJB a join TJ_TJDJB b on a.TJBH=b.TJBH and a.TJCS=b.TJCS where b.SUMOVER in(0,1) ";//SUMOVER 新登记：0  正在体检：1  总检：2
            if (zt == 0)
            {
            }
            else if (zt == 1)
            {
                strSql = strSql + "and a.djrq is null ";
            }
            else if (zt == 2)
            {
                strSql = strSql + "and a.djrq is not null ";
            }
            else
            {
                return null;
            }
            strSql = strSql + "and b.djlsh like '%" + djlsh + "%' and b.xm like '%" + xm + "%' and convert(char(8),b.tjrq,112) >='" + rq1 + "' and convert(char(8),b.tjrq,112) <='" + rq2 + "' order by b.djlsh desc";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取体检项目对照
        /// </summary>
        /// <param name="tjxmbh"></param>
        /// <returns></returns>
        public DataTable GetJyxmdz(string tjxmbh)
        {
            string sql = "select tjmxxm tjxmbh,gjc jyxmbh,xmmc jyxmmc,c.mc jyjx from TJ_JGXMDZB a left join jy_xmb b on a.gjc=b.xmbh left join jy_jyjx c on b.jyjx=c.bh where tjmxxm='"+tjxmbh+"'";

            return base.SqlDBAgent.GetDataTable(sql);
        }

        /// <summary>
        /// 根据登记流水号获取登记人员基本信息
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <returns></returns>
        public DataTable Get_TJ_TJDJB(string djlsh)
        {
            string strSql;
            strSql = "select djlsh,tjbh,xm,csnyr csrq,nl age,xb,convert(varchar(10),getdate(),121) date,convert(varchar(10),getdate(),108) time from TJ_TJDJB where djlsh='" + djlsh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 根据登记流水号获取登记人员基本信息
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <returns></returns>
        public DataTable Get_TJ_TJDJB1(string djlsh)
        {
            string strSql;
            strSql = "select xm,case xb when '1' then '男' when '0' then '女' else '不详' end as xb,nl,sumover from TJ_TJDJB where djlsh='" + djlsh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取检验标本信息
        /// </summary>
        /// <param name="tjbh">体检编号</param>
        /// <param name="tjcs">体检次数</param>
        /// <returns></returns>
        public DataTable Get_TJ_BBDJB(string tjbh,string tjcs)
        {
            string strSql;
            strSql = "select x='0',a.bbbh,a.mc,b.xmmc bblx,'检验科' zxks,a.djry,a.djrq,a.zhxm,sffb=case when exists(select * from v_jy_yfbxx where sffb=1 and djlsh= a.bbbh and tjzhxm=a.zhxm) then '1' else '0' end from TJ_BBDJB a join xt_zdxm b on a.BBLX=b.bzdm and b.zdflbm=6 ";
            strSql = strSql + "where a.tjbh='" + tjbh + "' and a.tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取检验发布明细
        /// </summary>
        /// <param name="djlsh"></param>
        /// <param name="zhxm"></param>
        /// <returns></returns>
        public DataTable GetJyfbmx(string djlsh, string zhxm)
        {
            string sql = "select distinct xssx, xmmc,jg ,dw,ckz,bz from v_jy_yfbxx where sffb=1 and djlsh='" + djlsh + "' and tjzhxm='" + zhxm + "' order by xssx";

            return base.SqlDBAgent.GetDataTable(sql);
        }

        /// <summary>
        /// 获取检验结果
        /// </summary>
        /// <param name="djlsh"></param>
        /// <param name="jyjx"></param>
        /// <returns></returns>
        public DataTable GetJyjg(string djlsh, string zhxm)
        {
            StringBuilder sql = new StringBuilder("select distinct xssx,tjbh,djlsh,djrq,brlx,ksmc,xm,xb,nl,dwmc,jcys,jcysmc,fbys,shrq,yblx,xmbh,xmsx,xmmc,jg,bz,ckz,dw,jyjx from v_jy_yfbxx");
            sql.Append(" where sffb=1 and djlsh='" + djlsh + "' and tjzhxm='" + zhxm + "' and xmmc<>''");
            sql.Append(" order by xssx");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 处理LIS申请
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <param name="tjbh">登记编号</param>
        /// <param name="djry">登记人员</param>
        /// <param name="tjcs">体检次数</param>
        /// <returns></returns>
        public string Exec_Proc_LisApply(string djlsh,string tjbh,string djry,string tjcs)
        {
            string strSql;
            strSql = "exec proc_lisapply '" + djlsh + "','" + tjbh + "','" + djry + "','" + tjcs + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        /// <summary>
        /// 获取已经体检LIS申请的名单，以方便结果导入
        /// </summary>
        /// <param name="rq1"></param>
        /// <param name="rq2"></param>
        /// <returns></returns>
        public DataTable Get_TJ_TJDJB(string rq1, string rq2)
        {
            string strSql;
            //strSql = "select distinct b.djlsh,b.xm,case b.xb when '1' then '男' when '0' then '女' else '不详' end as xb,b.nl,b.tjrq,b.sjcxxh,b.tjbh,b.tjcs from TJ_BBDJB a join TJ_TJDJB b on a.TJBH=b.TJBH and a.TJCS=b.TJCS where a.drbz=1 and b.SUMOVER in(0,1) ";//SUMOVER 新登记：0  正在体检：1  总检：2
            //strSql = strSql + " and convert(char(8),b.tjrq,112) >='" + rq1 + "' and convert(char(8),b.tjrq,112) <='" + rq2 + "' order by b.djlsh desc";
            strSql = "select distinct b.djlsh,b.xm,case b.xb when '1' then '男' when '0' then '女' else '不详' end as xb,b.nl,b.tjrq,b.sjcxxh,b.tjbh,b.tjcs from TJ_JYJGB a join TJ_TJDJB b on a.djlsh=b.djlsh where a.drbz=0 and b.SUMOVER in(0,1) ";//SUMOVER 新登记：0  正在体检：1  总检：2
            strSql = strSql + " and convert(char(8),b.tjrq,112) >='" + rq1 + "' and convert(char(8),b.tjrq,112) <='" + rq2 + "' order by b.djlsh desc";
            //没有完全导入完结果的人们名单 a.drbz is null
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取检验结果表
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <returns></returns>
        public DataTable Get_TJ_JYJGB(string djlsh)
        {
            string strSql;
            //strSql = "select djlsh,zhxmbh,zhxmmc,xmbh,xmmc,jg,dw,ckfw,zt,shr,shrq from TJ_JYJGB where djlsh='" + djlsh + "'";
            strSql = "select djlsh,zhxmbh,jyjx,zhxmmc,xmbh,xmmc,jg,dw,case isnull(ckfw,'') when '' then isnull(ckxx,'')+'-'+isnull(cksx,'') else ckfw end as ckfw,zt,shr,shrq from TJ_JYJGB where djlsh='" + djlsh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 执行LIS结果导入
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <returns></returns>
        public string Exec_Proc_LisInput(string djlsh)
        {
            string strSql;
            strSql = "exec proc_lisinput '" + djlsh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        /// <summary>
        /// 获取性别、姓名
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <returns></returns>
        public DataTable Get_TJ_DJINFO(string djlsh)
        {
            string strSql;
            strSql = "select djlsh,xm,case xb when '1' then '男' when '0' then '女' else '不详' end as xb,nl from TJ_TJDJB where djlsh='" + djlsh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取体检标本项目
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <returns></returns>
        public DataTable Get_TJ_BB(string djlsh)
        {
            string strSql;
            strSql = "select distinct bbbh,bblx from TJ_BBDJB where bbbh='" + djlsh + "' group by bbbh,bblx";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 按标本类型区标本内容，2个标本内容为一行
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <param name="bblx">标本类型编号</param>
        /// <returns></returns>
        public string Exec_Proc_tj_bbmx(string djlsh,string bblx)
        {
            string strSql;
            strSql = "exec proc_tj_bbmx '" + djlsh + "','" + bblx + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }

        /// <summary>
        /// 获取标本内容
        /// </summary>
        /// <param name="bbbh">登记流水号</param>
        /// <returns></returns>
        public DataTable Get_TJ_BBDJB(string bbbh)
        {
            string strSql;
            //strSql = "select '0000' zhxm,'全部项目' mc union select zhxm,mc from TJ_BBDJB where bbbh='" + bbbh + "'";
            strSql = "select '0000' zhxm,'全部项目' mc";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 插入检验结果表
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <param name="zhxmbh">组合项目编号</param>
        /// <param name="zhxmmc">组合项目名称</param>
        /// <param name="xmbh">项目编号</param>
        /// <param name="xmmc">项目名称</param>
        /// <param name="jg">结果</param>
        /// <param name="dw">单位</param>
        /// <param name="ckfw">参考范围</param>
        /// <param name="zt">状态</param>
        /// <param name="shr">审核人</param>
        /// <param name="shrq">审核日期</param>
        public void str_Insert_TJ_JYJGB(string djlsh, string zhxmbh, string zhxmmc, string xmbh, string xmmc, 
            string jg, string dw,string ckfw,string zt,string shr,string shrq)
        {
            string strSql;
            strSql = "insert TJ_JYJGB(djlsh,zhxmbh,zhxmmc,xmbh,xmmc,jg,dw,ckfw,zt,shr,shrq) select '"
                + djlsh + "','" + zhxmbh + "','" + zhxmmc + "','" + xmbh + "','" + xmmc + "','" + jg 
                + "','" + dw + "','" + ckfw + "','" + zt + "','"+ shr + "','" + shrq + "'";
            arryList.Add(strSql);
        }


        /// <summary>
        /// 获取组合项目
        /// </summary>
        /// <param name="jyksid">检验科室ID</param>
        /// <param name="lclx">检验类型</param>
        /// <returns></returns>
        public DataTable Get_TJ_ZHXM_HD(string jyksid, string lclx)
        {
            string strSql;
            strSql = "select bh,mc from TJ_ZHXM_HD where tjlx in(" + jyksid + ") and lclx='" + lclx + "' order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取检验组合项目对照码
        /// </summary>
        /// <param name="TJZHXM">体检组合项目ID</param>
        /// <returns></returns>
        public DataTable Get_TJ_JGZHXMDZB(string TJZHXM)
        {
            string strSql;
            strSql = "select TJZHXM,GJC,SM,SBID from TJ_JGZHXMDZB where TJZHXM='" + TJZHXM + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 保存组合项目对照码
        /// </summary>
        /// <param name="TJZHXM">体检系统码</param>
        /// <param name="GJC">LIS系统码</param>
        /// <param name="SM">说明</param>
        /// <param name="SBID">设备ID</param>
        /// <returns></returns>
        public int str_Insert_TJ_JGZHXMDZB(string TJZHXM, string GJC, string SM,string SBID)
        {
            string strSql;
            strSql = "delete TJ_JGZHXMDZB where TJZHXM='" + TJZHXM + "';";
            strSql = strSql + "insert TJ_JGZHXMDZB(TJZHXM,GJC,SM,SBID) select '" + TJZHXM + "','" + GJC + "','" + SM + "','" + SBID + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        /// <summary>
        /// 更新对照
        /// </summary>
        /// <returns></returns>
        public int Exec_Gxdzm()
        {
            string strSql;
            strSql = "update b set b.sbid=a.sbid from TJ_JGZHXMDZB a join TJ_BBDJB b on a.tjzhxm=b.zhxm where b.drbz is null;";
            strSql = strSql + " update b set b.xmbh_lis=a.gjc from TJ_JGXMDZB a join TJ_BBDJMXB b on a.tjmxxm=b.xmbh_tj join TJ_BBDJB c on c.bbbh=b.djlsh and c.zhxm=b.zhxmbh where isnull(c.drbz,0)=0";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        /// <summary>
        /// 重新获取数据结果
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <returns></returns>
        public int Exec_Return(string djlsh,string zhxm)
        {
            string strSql = "";
            if (zhxm == "0000")
            {
                //strSql = "delete TJ_JYJGB where djlsh='" + djlsh + "';";
                strSql = strSql + "update TJ_BBDJB set drbz=null where bbbh='" + djlsh + "'";
            }
            else
            {
                //strSql = "delete TJ_JYJGB where djlsh='" + djlsh + "'and zhxmbh='" + zhxm + "';";
                strSql = strSql + "update TJ_BBDJB set drbz=null where bbbh='" + djlsh + "'and zhxm='" + zhxm + "'";
            }
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        /// <summary>
        /// 根据组合项目获取项目明细
        /// </summary>
        /// <param name="zhxm"></param>
        /// <returns></returns>
        public DataTable GetXmmx(string zhxm)
        {
            string sql = "select tjxmmc,dw,ckz from v_tj_zhxmmx where tjzhxm='"+zhxm+"' order by tjxm";

            return base.SqlDBAgent.GetDataTable(sql);
        }

        /// <summary>
        /// 获取检验科分组信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_PGroup()
        {
            string strSql;
            strSql = "select SectionNo,ltrim(rtrim(str(SectionNo)))+'|'+ltrim(rtrim(CName)) as CName from PGroup where SectionNo>0";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public int Delete_TJ_YJJGB(string rq)
        {
            string strSql;
            strSql = "delete from TJ_JYJGB where convert(varchar(10),shrq,121)='" + rq + "';";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        //更改体检登记表已打印标签状态
        public void UpdatePrintLabel(string tjbh)
        {
            string sqlStr = "update tj_tjdjb set PrintLabel=1 where tjbh = '" + tjbh + "'";
            base.SqlDBAgent.sqlupdate(sqlStr);
        }
    }
}
