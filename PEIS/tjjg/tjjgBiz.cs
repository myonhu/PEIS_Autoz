using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace PEIS.tjjg
{
    class tjjgBiz : Base
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
        //********************************************************************
        public string Get_MaxStr(string table, string column)
        {
            string strSql;
            strSql = "select max(isnull(" + column + ",0))+1 from " + table + "";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        //********************************************************************
        public DataTable Get_Xt_CZY()
        {
            string strSql;
            strSql = "select czyid,czymc from xt_czy where tybz=0 ";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_Xt_YS()
        {
            string strSql;
            strSql = "select czyid,czymc from xt_czy where rysx in('医生','总检医生') and tybz=0 ";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_Xt_ZJYS()
        {
            string strSql;
            strSql = "select czyid,czymc from xt_czy where rysx='总检医生' and tybz=0 ";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_Xt_YS(string ksid)
        {
            string strSql;
            strSql = "select czyid,czymc from xt_czy where rysx in('医生','总检医生') and tybz=0 and ksid='" + ksid + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_Xt_YS_dxlr()
        {
            string strSql;
            strSql = "select czyid,czymc from xt_czy where rysx in('医生','总检医生') and tybz=0";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_Xt_YS_JZLR(string ksid)
        {
            string strSql;
            strSql = "select czyid,czymc from xt_czy where rysx in('医生','总检医生')  and tybz=0 and ksid='" + ksid + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_KEYWORD(string tjlx, string tjxm)
        {
            string strSql;
            strSql = "select mc,isnull(sfyx,0) sfyx,isnull(into_xj,0) into_xj,isnull(mcjrxj,0) mcjrxj,keyword from tj_keyword where tjlx='" + tjlx + "' and tjxm='" + tjxm + "' order by bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_V_TJ_TJDJB(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select dwmc,djlsh,tjbh,tjcs,xm,xb,nl,sfzh,picture,xbcode,zs,jy,jcrq,jcys,tjjl,jktj,czy,jkycbz,zytjjl,zytjjy,whysmc,gl from v_tj_tjdjb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_TJDJB(string fiter)//快速检索
        {
            string strSql;
            strSql = "select tjbh,tjcs,sumover,sfbz,isnull(dycs,0) dycs from tj_tjdjb where xm='" + fiter + "' or djlsh='" + fiter + "' or tjbh='" + fiter + "' or sykh='" + fiter + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_TJDJB(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select nl,xb,sumover from tj_tjdjb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取体检记录表
        /// </summary>
        /// <param name="tjbh">体检编号</param>
        /// <param name="tjcs">体检次数</param>
        /// <returns></returns>
        public DataTable Get_TJ_TJJLB(string tjbh, string tjcs)
        {
            string strSql;
            //strSql = "select b.mc,a.tjxmbh zhxm,a.xh,a.isover,a.xmlx,a.lxbh,a.zxks from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh where a.tjbh='" + tjbh + "' and a.tjcs='" + tjcs + "' order by b.tjlx,b.disp_order";
            strSql = "select b.mc,a.tjxmbh zhxm,a.xh,a.isover,a.xmlx,a.lxbh,a.zxks from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh where a.tjbh='" + tjbh + "' and a.tjcs='" + tjcs + "' order by b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 判断是否已保存小结
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <param name="zhxm"></param>
        /// <returns></returns>
        public bool HasSaved(string tjbh, string tjcs, string zhxm)
        {
            string sql = "select count(*) from tj_tjjlb where xj is not null and tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and tjxmbh='" + zhxm + "'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            string count = dt.Rows[0][0].ToString().Trim();
            if (Convert.ToInt32(count) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取体检记录表
        /// </summary>
        /// <param name="tjbh">体检编号</param>
        /// <param name="tjcs">体检次数</param>
        /// <param name="lxbh">科室编码</param>
        /// <returns></returns>
        public DataTable Get_TJ_TJJLB(string tjbh, string tjcs, string lxbh)
        {
            string strSql;
            strSql = "select b.mc,a.tjxmbh zhxm,a.xh,a.isover,a.xmlx,a.zxks from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh where a.tjbh='" + tjbh + "' and a.tjcs='" + tjcs + "'and lxbh='" + lxbh + "' order by b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取体检记录表
        /// </summary>
        /// <param name="tjbh">体检编号</param>
        /// <param name="tjcs">体检次数</param>
        /// <param name="xh">记录序号</param>
        /// <param name="tjzhxm">体检组合项目ID</param>
        /// <returns></returns>
        public DataTable Get_TJ_TJJLB(string tjbh, string tjcs, string xh, string tjzhxm)
        {
            string strSql;
            strSql = "select xj,jcrq,jcys,czy from tj_tjjlb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'and xh='" + xh + "' and tjxmbh='" + tjzhxm + "' and CZY is not null ";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取体检记录明细表
        /// </summary>
        /// <param name="xh">序号</param>
        /// <param name="tjxm">体检组合项目</param>
        /// <returns></returns>
        public DataTable Get_TJ_TJJLMXB(string xh, string tjzhxm)
        {
            string strSql;
            strSql = "select b.mc,a.jg,a.sfyx,a.jrxj,a.mcjrxj,b.dw,'' ckxx,'' cksx,a.ts,a.tjzhxm,a.tjxm,b.zcts zcjg,a.tjlx,'' ckz,a.xh,'' keyword,b.jglx from tj_tjjlmxb a join tj_tjxmb b on a.tjxm=b.tjxm where a.xh='" + xh + "' and a.tjzhxm='" + tjzhxm + "' order by b.disp_order";
            //strSql = " select b.mc,a.jg from tj_tjjlmxb a join tj_tjxmb b on a.tjxm = b.tjxm where a.xh = '3320' and a.tjzhxm = '4801' order by b.disp_order";
            //if (xh.Equals("3980") && tjzhxm.Equals("0722"))
            //    return Get_GQF_TJJLMXB(base.SqlDBAgent.GetDataTable(strSql));
            return base.SqlDBAgent.GetDataTable(strSql);
        }


        /// <summary>
        /// 获取参考值
        /// </summary>
        /// <param name="tjlx">体检类型</param>
        /// <param name="tjxm">体检项目ID</param>
        /// <param name="xb">性别</param>
        /// <param name="nl">年龄</param>
        /// <returns></returns>
        public DataTable Get_pro_get_ckz(string tjlx, string tjxm, string xb, int nl,string gz)
        {
            string strSql;
            strSql = "exec pro_get_ckz '" + tjlx + "','" + tjxm + "','" + xb + "','"+gz+"'," + nl;
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取参考值结果
        /// </summary>
        /// <param name="tjlx">体检类型</param>
        /// <param name="tjxm">体检项目ID</param>
        /// <param name="xb">性别</param>
        /// <param name="nl">年龄</param>
        /// <param name="jg">结果</param>
        /// <returns></returns>
        public string Get_pro_get_ckz_jg(string tjlx, string tjxm, string xb, int nl,double jg,string gz)
        {
            string strSql;
            strSql = "exec pro_get_ckz_jg '" + tjlx + "','" + tjxm + "','" + xb + "'," + nl + ",'"+gz+"'," + jg;
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        public DataTable Get_tj_jbjlb(string tjbh, string tjcs, string zhxmbh)
        {
            string strSql;
            strSql = "select jbmc,jbbh,tjxmbh from tj_jbjlb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and zhxmbh='" + zhxmbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public string Get_tj_jbjlb_jbbh(string tjbh, string tjcs, string tjlx, string zhxmbh, string tjxmbh)
        {
            string strSql;
            strSql = "select jbbh from tj_jbjlb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and tjlx='" + tjlx + "' and zhxmbh='" + zhxmbh + "' and tjxmbh='" + tjxmbh + "'";
            try
            {
                return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        public DataTable get_tj_suggestion(string tjlx,string bh)
        {
            string strSql;
            strSql = "select keyword,bh from tj_suggestion where tjlx='" + tjlx + "' and bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public string Get_tj_tjxmb_zcts(string tjxm)
        {
            string strSql;
            strSql = "select isnull(zcts,'') zcts from tj_tjxmb where tjxm='" + tjxm + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }

        public string Get_tj_suggestion_jbbh(string tjlx,string keyword)
        {
            string strSql;
            strSql = "select bh from tj_suggestion where tjlx='" + tjlx + "' and ltrim(rtrim(keyword))='" + keyword + "'";
            try
            {
                return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
            }
            catch
            {
                return "";
            }
        }
        public string Get_ZHXM_ZCXJ(string zhxm)
        {
            string strSql;
            strSql = "select zcxj from tj_zhxm_hd where bh='" + zhxm + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }

        public DataTable Get_TJ_HSB_HD(string zhxmbh)
        {
            string strSql;
            strSql = "select bh,mc from tj_hsb_hd where zhxmbh='" + zhxmbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public string Get_TJ_HSB_XMDZ_DZM(string mc)
        {
            string strSql;
            strSql = "select dzm from tj_hsb_xmdz where mc='" + mc + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        public string Get_pro_get_tzzs(decimal tzzs)//获取体重指数诊断
        {
            string strSql;
            strSql = "exec pro_get_tzzs " + tzzs;
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();//
        }
        public string Get_pro_get_xyzs(decimal ssy, decimal szy, int xyty)//获取血压指数诊断
        {
            string strSql;
            strSql = "exec pro_get_xyzs " + ssy + "," + szy + "," + xyty;
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        public int Exists_SGTZXY(string zhxmbh)//判断是否为肥胖，血压
        {
            string strSql;
            strSql = "select count(1) from tj_hsb_hd where zhxmbh='" + zhxmbh + "' and (mc like '%肥胖诊断功能%' or mc like '%血压诊断功能%')";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }

        public DataTable GetTjdjxx(string tjbh, string tjcs)
        {
            string strSql = "select tjlb,gz,rylb from v_tj_tjdjb where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'";

            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取乙肝两对半诊断
        /// </summary>
        /// <returns></returns>
        public string Get_TJ_HSB_DT(string bh,string ckz)
        {
            string strSql;
            strSql = "select mc+'|'+zdbh from tj_hsb_dt where bh='" + bh + "' and ckz='" + ckz + "'";
            try
            {
                return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
            }
            catch
            {
                return "|";
            }
        }
        public void str_Update_tj_tjjlb(string tjbh, string tjcs, string xh, string tjzhxm)
        {
            string strSql;
            strSql = "update tj_tjjlb set isover=0,jcrq=null,jcys=null,xj=null where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and xh='" + xh + "' and tjxmbh='" + tjzhxm + "'";
            arryList.Add(strSql);
        }
        public void str_Update_tj_tjjlmxb(string xh,string tjzhxm )
        {
            string strSql;
            strSql = "update a set a.jg=b.zcts,a.jcrq=null,a.jcys=null,a.jrxj=0,a.mcjrxj=0,a.sfyx=0,a.dw=null,a.ts=null,a.ckz=null from tj_tjjlmxb a join tj_tjxmb b on a.tjxm=b.tjxm where a.xh='" + xh + "' and a.tjzhxm='" + tjzhxm + "'";
            arryList.Add(strSql);
        }
        public void str_Delete_tj_jbjlb(string tjbh, string tjcs, string tjzhxm)
        {
            string strSql;
            strSql = "delete tj_jbjlb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and zhxmbh='" + tjzhxm + "'";
            arryList.Add(strSql);
        }
        public void str_Update_tj_tjjlb(string tjbh, string tjcs, string xh, string tjzhxm,string isover,string jcrq,string jcys,string xj,string czy)
        {
            string strSql;
            strSql = "update tj_tjjlb set isover='" + isover + "',jcrq='" + jcrq + "',jcys='" + jcys + "',xj='" + xj + "',czy='" + czy + "' where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and xh='" + xh + "' and tjxmbh='" + tjzhxm + "'";
            arryList.Add(strSql);
        }
        public void str_Update_tj_tjjlmxb(string xh, string tjxm, string jg,string tjzhxm, string tjlx, string jcrq, string jcys, string jrxj, string mcjrxj, string sfyx, string dw, string ckz, string ts)
        {
            string strSql;
            strSql = "update tj_tjjlmxb set jg='" + jg + "',jcrq='" + jcrq + "',jcys='" + jcys + "',jrxj='" + jrxj + "',mcjrxj='" + mcjrxj + "',sfyx='" + sfyx
                + "',dw='" + dw + "',ckz='" + ckz + "',ts='" + ts + "' where xh='" + xh + "' and tjxm='" + tjxm + "' and tjzhxm='" + tjzhxm + "'";
            arryList.Add(strSql);
        }
        public void str_Insert_tj_jbjlb(string jbxh,string tjbh,string tjcs,string djlsh,string tjlx,string zhxmbh,string tjxmbh,string jbbh,string jbmc,string jcys)
        {
            string strSql;
            strSql = "insert tj_jbjlb(jbxh,tjbh,tjcs,djlsh,tjlx,zhxmbh,tjxmbh,jbbh,jbmc,jcys) select '" + jbxh + "','" + tjbh + "','" + tjcs + "','" + djlsh
                + "','" + tjlx + "','" + zhxmbh + "','" + tjxmbh + "','" + jbbh + "','" + jbmc + "','" + jcys + "'";
            arryList.Add(strSql);
        }
        public void str_Update_tj_tjdjb(string tjbh, string tjcs,string sumover)
        {
            string strSql;
            strSql = "update tj_tjdjb set sumover='" + sumover + "' where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and sumover='0'";
            arryList.Add(strSql);
        }

        //*******************************************************
        public DataTable Get_TJ_TJJLB_WJXM(string tjbh, string tjcs)//未检项目
        {
            string strSql;
            strSql = "select b.mc from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh where a.tjbh='" + tjbh + "' and a.tjcs='" + tjcs + "' and a.isover=0";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Update_tj_tjdjb(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "update tj_tjdjb set sumover='1',jcrq=null,jcys=null,tjjl=null,jktj=null,zs=null,jy=null,fcrq=null,fcgy=null where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and sumover='2'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Update_tj_tjdjb_Dycs(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "update tj_tjdjb set dycs=isnull(dycs,0)+1 where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and sumover='2'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public void str_Update_tj_tjdjb(string tjbh, string tjcs, string jcrq, string jcys, string tjjl, string jktj, string zs, string jy, string czy, string jkycbz,string zytjjl,string zytjjy)
        {
            string strSql;
            strSql = "update tj_tjdjb set sumover='2',jcrq='" + jcrq + "',jcys='" + jcys + "',tjjl='" + tjjl + "',jktj='" + jktj + "',zs='" + zs + "',jy='" + jy + "',czy='" + czy + "',jkycbz='"+jkycbz+"',zytjjl='"+zytjjl+"',zytjjy='"+zytjjy+"' where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            arryList.Add(strSql);
        }
        public void str_Update_tj_tjdjb(string tjbh, string tjcs, string fcrq, string fcgy)
        {
            string strSql;
            strSql = "update tj_tjdjb set fcrq='" + fcrq + "',fcgy='" + fcgy + "' where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            arryList.Add(strSql);
        }
        public void str_Update_tj_jbjlb(string tjbh, string tjcs,string zjys)
        {
            string strSql;
            strSql = "update tj_jbjlb set zt=1,zjys='" + zjys + "' where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            arryList.Add(strSql);
        }
        public DataTable Get_TJ_JBJLB(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select a.jbbh,a.jbmc,a.zhxmbh,b.mc from tj_jbjlb a join tj_zhxm_hd b on a.zhxmbh=b.bh where a.tjbh='" + tjbh + "' and a.tjcs='" + tjcs + "' order by b.tjlx,b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_SUGGESTION_JYNR(string bh)
        {
            string strSql;
            strSql = "select mc,jynr from tj_suggestion where bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_TJJLB_XJ(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select b.mc,a.xj from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh where a.tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and a.isover=1 order by  b.tjlx,b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取体检项目明细，所有次数 by zhz
        /// </summary>
        /// <param name="tjbh"></param>
        /// <returns></returns>
        public DataTable Get_TJ_TJJLB_XJ(string tjbh)
        {
            string strSql;
            strSql = "select b.mc,a.xj from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh where a.tjbh='" + tjbh + "' and a.isover=1 order by  b.mc";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_TJJLB_JKYCBZ(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select jkycbz from tj_tjjlb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取正常结果
        /// </summary>
        /// <param name="xmbh"></param>
        /// <returns></returns>
        public string GetZcjg(string xmbh)
        {
            string strSql;
            strSql = "select zcts from tj_tjxmb where tjxm='"+xmbh+"'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(strSql);
            if (dt.Rows.Count<=0)
            {
                return "";
            }
            return dt.Rows[0][0].ToString().Trim();
        }

        /// <summary>
        /// 根据条件查询单位信息
        /// </summary>
        /// <param name="qy"></param>
        /// <param name="zjm"></param>
        /// <returns></returns>
        public DataTable GetDwxxByCondition(bool qy, string zjm)
        {
            StringBuilder sql = new StringBuilder("select bh,mc,dwfzr,lxdh,lxdz,yzbm,ywyy,yhzh,jjlx,hy,qygm,jzrs,scgrs,yhzyrs,bz from tj_dw where len(bh)=4 and bh<>'9999'");
            if (qy)
            {
                sql.Append(" and qybz=1");
            }
            if (zjm!="")
            {
                sql.Append(" and(mc like '"+zjm+"%' or pyjm like '"+zjm+"%' or wbjm like '"+zjm+"%')");
            }
            sql.Append("order by bh desc");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="maxdate"></param>
        /// <param name="sjdw"></param>
        /// <param name="tjrs"></param>
        /// <param name="tjxm"></param>
        /// <param name="tjjl"></param>
        /// <param name="sqls"></param>
        public void InsertSzTjbg(SzTjbg tjbg, List<string> sqls)
        {
            StringBuilder sql = new StringBuilder("insert into sz_tjbg(maxdate,mindate,rylb,bgid,sjdw,tjrs,tjxm,tjjl) values('");
            sql.Append(tjbg.Maxdate + "','");
            sql.Append(tjbg.Mindate + "','");
            sql.Append(tjbg.Rylb + "','");
            sql.Append(tjbg.Bgid + "','");
            sql.Append(tjbg.Sjdw + "','");
            sql.Append(tjbg.Tjrs + "','");
            sql.Append(tjbg.Tjxm + "','");
            sql.Append(tjbg.Tjjl + "')");

            sqls.Add(sql.ToString());
        }

        public void UpdateSzTjbg(SzTjbg tjbg, List<string> sqls)
        {
            StringBuilder sql = new StringBuilder("update  sz_tjbg set maxdate='"+tjbg.Maxdate+"',");
            sql.Append("tjrs='" + tjbg.Tjrs + "',");
            sql.Append("mindate='" + tjbg.Mindate + "',");
            sql.Append("rylb='" + tjbg.Rylb + "',");
            sql.Append("tjxm='" + tjbg.Tjxm + "',");
            sql.Append("tjjl='" + tjbg.Tjjl + "'");
            sql.Append(" where bgid='"+tjbg.Bgid+"'");

            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 插入明细
        /// </summary>
        /// <param name="bgid"></param>
        /// <param name="gz"></param>
        /// <param name="zrs"></param>
        /// <param name="jkycrs"></param>
        /// <param name="zyycrs"></param>
        /// <param name="sqls"></param>
        public void InsertSzTjbgMx(SzTjbgMx mx, List<string> sqls)
        {
            StringBuilder sql = new StringBuilder("insert into sz_tjbg_mx(bgid,gz,zrs,jkycrs,whys,zyycrs) values('");
            sql.Append(mx.Bgid + "','");
            sql.Append(mx.Gz + "','");
            sql.Append(mx.Zrs + "','");
            sql.Append(mx.Jkycrs + "','");
            sql.Append(mx.Whys + "','");
            sql.Append(mx.Zyycrs + "')");

            sqls.Add(sql.ToString());
        }

        public void DeleteSzTjbgMx(string bgid, List<string> sqls)
        {
            StringBuilder sql = new StringBuilder("delete from sz_tjbg_mx where bgid='"+bgid+"'");

            sqls.Add(sql.ToString());
        }

        public int Update(SzTjbg tjbg, List<SzTjbgMx> mxes)
        {
            List<string> sqls = new List<string>();
            UpdateSzTjbg(tjbg, sqls);
            DeleteSzTjbgMx(tjbg.Bgid,sqls);
            for (int i = 0; i < mxes.Count; i++)
            {
                InsertSzTjbgMx(mxes[i], sqls);
            }

            return base.SqlDBAgent.sqlupdate(sqls);
        }

        /// <summary>
        /// 插入体检报告设置
        /// </summary>
        /// <param name="tjbg"></param>
        /// <param name="mxes"></param>
        /// <returns></returns>
        public int Insert(SzTjbg tjbg, List<SzTjbgMx> mxes)
        {
            List<string> sqls = new List<string>();
            InsertSzTjbg(tjbg, sqls);
            for (int i = 0; i < mxes.Count; i++)
            {
                InsertSzTjbgMx(mxes[i], sqls);
            }

            return base.SqlDBAgent.sqlupdate(sqls);
        }

        /// <summary>
        /// 更新体检报告设置
        /// </summary>
        /// <param name="tjbg"></param>
        /// <param name="mxes"></param>
        /// <param name="type">-1:插入</param>
        /// <returns></returns>
        public int GxTjbgSz(SzTjbg tjbg, List<SzTjbgMx> mxes, int type)
        {
            int i = -1;
            if (type == -1)
            {
                i = Insert(tjbg, mxes);
            }
            else
            {
                i = Update(tjbg, mxes);
            }

            return i;
        }

        /// <summary>
        /// 获取体检报告设置信息
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="tjdw"></param>
        /// <returns></returns>
        public DataTable GetSzTjbg(string from, string to, string tjdw)
        {
            StringBuilder sql = new StringBuilder("select bgid,maxdate,mindate,sjdw,tjrs,tjxm,tjjl,gz,zrs,jkycrs,zyycrs,dwmc,rylb,whys from v_sz_tjbg ");
            sql.Append("where maxdate>='"+from+"' and maxdate<='"+to+"' and sjdw='"+tjdw+"'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public DataTable GetSzTjbgMx(string from, string to, string tjdw)
        {
            StringBuilder sql = new StringBuilder("select maxdate,sjdw,jg from v_sz_tjbg_mxfz ");
            sql.Append("where maxdate>='" + from + "' and maxdate<='" + to + "' and sjdw='" + tjdw + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }



        //中医体检
        public DataTable Get_XT_ZYWQ(string TZLX)
        {
            string strSql;
            strSql = "select TZLX,XH,WT,XX1,XX2 from XT_ZYWQ where TZLX='" + TZLX + "' order by XH";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_tj_zyjlmx(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select tjbh,tjcs,tzlx,xh,xxz from tj_zyjlmx where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public void str_Delete_tj_zyjlmx(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "delete tj_zyjlmx where  tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            arryList.Add(strSql);
        }

        public void str_Insert_tj_zyjlmx(string tjbh, string tjcs, string tzlx, string xh, string xxz)
        {
            string strSql;
            strSql = "insert tj_zyjlmx(tjbh,tjcs,tzlx,xh,xxz) select '" + tjbh + "','" + tjcs + "','" + tzlx + "','" + xh + "','" + xxz + "'";
            arryList.Add(strSql);
        }

        public void str_Exec_proc_tj_zyjl(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "exec proc_tj_zyjl '" + tjbh + "','" + tjcs + "'";
            arryList.Add(strSql);
        }

        public DataTable Get_TJ_ZYJL(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select tjbh,tjcs,isnull(tzjl,'') tzjl from TJ_ZYJL where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_v_tj_zyjgb(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select * from v_tj_zyjgb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public int Insert_tj_tjdjb(string djlsh,string tjbh, string tjcs,string xm,string xb,string nl,string mz,string mobile,string tjlb,string tjrq,string sfzh)
        {
            string strSql;
            strSql = "delete tj_tjdjb where  tjbh='" + tjbh + "' and tjcs='" + tjcs + "';";
            strSql = strSql + "insert tj_tjdjb(djlsh,tjbh,tjcs,xm,xb,nl,mz,mobile,tjlb,tjrq,djrq,jsfs,djry,sumover,sfzh)  select '" + djlsh + "','" + tjbh + "','" + tjcs + "','" + xm
                + "','" + xb + "','" + nl + "','" + mz + "','" + mobile + "','" + tjlb + "','" + tjrq + "',getdate(),'1','0','0','" + sfzh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        public DataTable GetGl(string tjbh)
        {
            string sql = "select GL from tj_tjdjb where tjbh='"+tjbh+"'";
            return base.SqlDBAgent.GetDataTable(sql);
        }

        public string GetGqfJg(string tjbh)
        {
            string sql = "select jg from tj_zyb_gqf where tjbh='"+tjbh + "'";
            return base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim();
        }

        public bool IsGfq(string zhxm)
        {
            string sql = "SELECT count(*) from TJ_ZHXM_DT a join TJ_TJXMB b on a.TJXM=b.TJXM WHERE b.MC='高仟伏胸片' and a.bh='" + zhxm + "'";
            string st = base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim();
            if (!"0".Equals(base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim()))
                return true;
            return false;
        }
    }

}
