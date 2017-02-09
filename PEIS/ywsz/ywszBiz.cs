using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace PEIS.ywsz
{
    class ywszBiz:Base
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
            strSql = "select max(cast(isnull(" + column + ",0) as int))+1 from " + table + "";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        //**************************************************************
        public DataTable Get_tj_tjlxb()
        {
            string strSql;
            strSql = "select lxbh,mc from tj_tjlxb order by DISP_ORDER";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_tjlxb_jcjylx(string jcjylx)
        {
            string strSql;
            strSql = "select lxbh,mc from tj_tjlxb where jcjylx='" + jcjylx + "' order by DISP_ORDER";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_tjlxb(string lxbh)
        {
            string strSql;
            strSql = "select lxbh,disp_order,mc,jcjylx,ksxj,ksxx,bz from tj_tjlxb where lxbh='" + lxbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Update_tj_tjlxb(string lxbh,string disp_order,string mc,string jcjylx,string ksxj,string ksxx,string bz)
        {
            string strSql;
            strSql = "update tj_tjlxb set disp_order='" + disp_order + "',mc='" + mc + "',jcjylx='" + jcjylx + "',ksxj='" + ksxj + "',ksxx='" + ksxx + "',bz='" + bz + "' where lxbh='" + lxbh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Insert_tj_tjlxb(string lxbh, string disp_order, string mc, string jcjylx, string ksxj, string ksxx, string bz)
        {
            string strSql;
            strSql = "insert tj_tjlxb(lxbh,disp_order,mc,jcjylx,ksxj,ksxx,bz) select '" + lxbh + "','" + disp_order + "','" + mc + "','" + jcjylx + "','" + ksxj + "','" + ksxx + "','" + bz + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Delete_tj_tjlxb(string lxbh)
        {
            string strSql;
            strSql = "delete tj_tjlxb where lxbh='" + lxbh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        //*********************************************************************
        public DataTable Get_tj_lclxb()
        {
            string strSql;
            strSql = "select lclx,mc from tj_lclxb order by DISP_ORDER";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_lclxb(string lclx)
        {
            string strSql;
            strSql = "select lclx,mc,disp_order,bz from tj_lclxb where lclx='" + lclx + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Update_tj_lclxb(string lclx, string mc, string disp_order, string bz)
        {
            string strSql;
            strSql = "update tj_lclxb set mc='" + mc + "',disp_order='" + disp_order + "',bz='" + bz + "' where lclx='" + lclx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Insert_tj_lclxb(string lclx, string mc, string disp_order, string bz)
        {
            string strSql;
            strSql = "insert tj_lclxb(lclx,mc,disp_order,bz) select '" + lclx + "','" + mc + "','" + disp_order + "','" + bz + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Delete_tj_lclxb(string lclx)
        {
            string strSql;
            strSql = "delete tj_lclxb where lclx='" + lclx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        //**************************************************
        public DataTable Get_tj_tjxmb(string lxbh)
        {
            string strSql;
            strSql = "select tjxm,mc,isnull(qybz,0) qybz from tj_tjxmb where lxbh='" + lxbh + "' order by DISP_ORDER";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_tjxmb(string lxbh,string lclx)
        {
            string strSql;
            strSql = "select tjxm,mc,isnull(qybz,0) qybz from tj_tjxmb where lxbh='" + lxbh + "' and lclx='" + lclx + "' order by DISP_ORDER";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_tjxmbmx(string tjxm)
        {
            string strSql;
            strSql = "select lxbh,tjxm,mc,dj,disp_order,xb,lclx,dw,zcts,jglx,qybz,xxxz,sxxz from tj_tjxmb where tjxm='" + tjxm + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public string Get_proc_get_tjxmbh(string lxbh)//根据科室类型，获取体检项目编号
        {
            string strSql;
            strSql = "exec proc_get_tjxmbh '" + lxbh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }

        public int Update_tj_tjxmb(string lxbh, string tjxm, string mc, string dj, string disp_order, string xb, string lclx, string dw, 
            string zcts, string jglx, string qybz, string xxxz, string sxxz)
        {
            string strSql;
            strSql = "update tj_tjxmb set lxbh='" + lxbh + "',mc='" + mc + "',dj='" + dj + "',disp_order='" + disp_order + "',xb='" + xb + "',lclx='" + lclx
                + "',dw='" + dw + "',zcts='" + zcts + "',jglx='" + jglx + "',qybz='" + qybz + "',xxxz='" + xxxz + "',sxxz='" + sxxz + "' where tjxm='" + tjxm + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Insert_tj_tjxmb(string lxbh, string tjxm, string mc, string dj, string disp_order, string xb, string lclx, string dw,
            string zcts, string jglx, string qybz, string xxxz, string sxxz)
        {
            string strSql;
            strSql = "insert tj_tjxmb(lxbh,tjxm,mc,dj,disp_order,xb,lclx,dw,zcts,jglx,qybz,xxxz,sxxz) select '" + lxbh + "','" + tjxm + "','" + mc + "','" + dj
                + "','" + disp_order + "','" + xb + "','" + lclx + "','" + dw + "','" + zcts + "','" + jglx + "','" + qybz + "','" + xxxz + "','" + sxxz + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Delete_tj_tjxmb(string tjxm)
        {
            string strSql;
            strSql = "delete tj_tjxmb where tjxm='" + tjxm + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        //**************************************************
        public DataTable Get_tj_zhxm_hd(string tjlx)
        {
            string strSql;
            strSql = "select bh,mc,isnull(yxbz,0) yxbz from tj_zhxm_hd where tjlx='" + tjlx + "' order by DISP_ORDER";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_zhxm_hd(string tjlx,string lclx)
        {
            string strSql;
            strSql = "select bh,mc,isnull(yxbz,0) yxbz from tj_zhxm_hd where tjlx='" + tjlx + "' and lclx='" + lclx + "' order by DISP_ORDER";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_zhxm_hd1(string bh)
        {
            string strSql;
            strSql = "select tjlx,yxbz,bh,disp_order,mc,dj,lclx,zdym,pyjm,wbjm,lcyy,tsxx,zcxj,sfxybb,bblx,jcjylx,sflb from tj_zhxm_hd where bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public int Update_tj_zhxm_hd(string tjlx, string yxbz, string bh, string disp_order, string mc, string dj, string lclx, string zdym,
            string pyjm, string wbjm, string lcyy, string tsxx, string zcxj, string sfxybb, string bblx, string jcjylx, string sflb)
        {
            string strSql;
            strSql = "update tj_zhxm_hd set tjlx='" + tjlx + "',yxbz='" + yxbz + "',disp_order='" + disp_order + "',mc='" + mc + "',dj='" + dj + "',lclx='" + lclx
                + "',zdym='" + zdym + "',pyjm='" + pyjm + "',wbjm='" + wbjm + "',lcyy='" + lcyy + "',tsxx='" + tsxx + "',zcxj='" + zcxj + "',sfxybb='" + sfxybb
                + "',bblx='" + bblx + "',jcjylx='" + jcjylx + "',sflb='" + sflb + "' where bh='" + bh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Insert_tj_zhxm_hd(string tjlx, string yxbz, string bh, string disp_order, string mc, string dj, string lclx, string zdym,
            string pyjm, string wbjm, string lcyy, string tsxx, string zcxj, string sfxybb, string bblx, string jcjylx, string sflb)
        {
            string strSql;
            strSql = "insert tj_zhxm_hd(tjlx,yxbz,bh,disp_order,mc,dj,lclx,zdym,pyjm,wbjm,lcyy,tsxx,zcxj,sfxybb,bblx,jcjylx,sflb) select '" +
                tjlx + "','" + yxbz + "','" + bh + "','" + disp_order + "','" + mc + "','" + dj + "','" + lclx + "','" + zdym + "','" +
                pyjm + "','" + wbjm + "','" + lcyy + "','" + tsxx + "','" + zcxj + "','" + sfxybb + "','" + bblx + "','" + jcjylx + "','" + sflb + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Delete_tj_zhxm_hd(string bh)//明细表一起删除
        {
            string strSql;
            strSql = "delete tj_zhxm_hd where bh='" + bh + "';";
            strSql = strSql + "delete tj_zhxm_dt where bh='" + bh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        public DataTable Get_tj_tjxmb_bylxbh(string lxbh,string lclx)//根据科室ID和临床类型获取项目
        {
            string strSql;
            strSql = "select a.tjxm,a.mc,b.xmmc xb from tj_tjxmb a join xt_zdxm b on a.xb=b.bzdm where b.zdflbm=1 and a.lxbh='" + lxbh + "' and isnull(lclx,'')='" + lclx + "' and a.qybz=1 order by a.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_tj_zhxm_dt(string bh)
        {
            string strSql;
            strSql = "select tjxm from tj_zhxm_dt where bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public void str_Insert_tj_zhxm_dt(string bh, string tjlx, string tjxm, string flag)
        {
            string strSql;
            strSql = "insert tj_zhxm_dt(bh,tjlx,tjxm,flag) select '" + bh + "','" + tjlx + "','" + tjxm + "','" + flag + "'";
            arryList.Add(strSql);
        }

        public string Get_proc_get_tjzhxmbh(string lxbh)//根据科室类型，获取体检组合项目编号
        {
            string strSql;
            strSql = "exec proc_get_tjzhxmbh '" + lxbh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        //**************************************************
        public DataTable Get_TJ_SUGGESTION()
        {
            string strSql;
            strSql = "select '' bh,'' keyword union select bh,keyword from TJ_SUGGESTION";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_SUGGESTION(string tjlx,string lclx)
        {
            string strSql;
            strSql = "select '' bh,'' keyword union select bh,keyword from TJ_SUGGESTION where tjlx='" + tjlx + "' and isnull(lclx,'')='" + lclx + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_SUGGESTION1(string tjlx,string lclx)
        {
            string strSql;
            strSql = "select '' bh,'' mc,'' keyword,'' pyjm,'' wbjm union select a.bh,b.mc,a.keyword,a.pyjm,a.wbjm from TJ_SUGGESTION a join tj_tjlxb b on a.tjlx=b.lxbh where a.tjlx='" + tjlx + "' and isnull(a.lclx,'')='" + lclx + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_SUGGESTION2()
        {
            string strSql;
            strSql = "select '' bh,'' mc,'' keyword,'' pyjm,'' wbjm union select a.bh,b.mc,a.keyword,a.pyjm,a.wbjm from TJ_SUGGESTION a join tj_tjlxb b on a.tjlx=b.lxbh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_SUGGESTION3(string tjlx)
        {
            string strSql;
            strSql = "select '' bh,'' mc,'' keyword,'' pyjm,'' wbjm union select a.bh,b.mc,a.keyword,a.pyjm,a.wbjm from TJ_SUGGESTION a join tj_tjlxb b on a.tjlx=b.lxbh where a.tjlx='" + tjlx + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_TJXMB_XJ(string tjxm)//结果，项目是否小结
        {
            string strSql;
            strSql = "select lxbh,isnull(lclx,'') lclx,tjxm,sfxj,mcjrxj,xb,jglx from TJ_TJXMB where tjxm='" + tjxm + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_keyword_zf(string tjxm)//字符类型
        {
            string strSql;
            strSql = "select bh,mc,keyword,isnull(into_xj,0) into_xj,isnull(mcjrxj,0) mcjrxj,isnull(sfyx,0) sfyx,pyjm,wbjm,jglx,xb,tjlx,tjxm from tj_keyword where tjxm='" + tjxm + "' and jglx='00' order by bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_keyword_sz_all(string tjxm)//数字类型，男女共有
        {
            string strSql;
            strSql = "select bh,nlxx,nlsx,dy,spy,xy,xpy,mc,isnull(sfzc,0) sfzc,keyword,isnull(mcjrxj,0) mcjrxj,isnull(into_xj,0) into_xj,isnull(sfyx,0) sfyx,pyjm,wbjm,jglx,xb,tjlx,tjxm,whys from tj_keyword where tjxm='" + tjxm + "' and jglx='20' order by bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_keyword_sz_nx(string tjxm)//数字类型，男有
        {
            string strSql;
            strSql = "select bh,nlxx,nlsx,dy,spy,xy,xpy,mc,isnull(sfzc,0) sfzc,keyword,isnull(mcjrxj,0) mcjrxj,isnull(into_xj,0) into_xj,isnull(sfyx,0) sfyx,pyjm,wbjm,jglx,xb,tjlx,tjxm,whys from tj_keyword where tjxm='" + tjxm + "' and jglx='11' order by bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_keyword_sz_vx(string tjxm)//数字类型，女有
        {
            string strSql;
            strSql = "select bh,nlxx,nlsx,dy,spy,xy,xpy,mc,isnull(sfzc,0) sfzc,keyword,isnull(mcjrxj,0) mcjrxj,isnull(into_xj,0) into_xj,isnull(sfyx,0) sfyx,pyjm,wbjm,jglx,xb,tjlx,tjxm,whys from tj_keyword where tjxm='" + tjxm + "' and jglx='10' order by bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public void str_Insert_tj_keyword_zf(string bh, string mc, string keyword, string into_xj, string mcjrxj, string sfyx, string pyjm, string wbjm,
            string jglx, string xb, string tjlx, string tjxm)
        {
            string strSql;
            strSql = "insert tj_keyword(bh,mc,keyword,into_xj,mcjrxj,sfyx,pyjm,wbjm,jglx,xb,tjlx,tjxm) select '" + bh + "','" + mc + "','" + keyword + "','" + into_xj
                + "','" + mcjrxj + "','" + sfyx + "','" + pyjm + "','" + wbjm + "','" + jglx + "','" + xb + "','" + tjlx + "','" + tjxm + "'";
            arryList.Add(strSql);
        }
        public void str_Insert_tj_keyword_sz(string bh,string nlxx,string nlsx,string dy,string xy, string mc,string sfzc, string keyword,
            string mcjrxj, string into_xj, string sfyx, string pyjm, string wbjm, string jglx, string xb, string tjlx, string tjxm,string spy,string xpy,string whys)
        {
            string strSql;
            strSql = "insert tj_keyword(bh,nlxx,nlsx,dy,xy,mc,sfzc,keyword,mcjrxj,into_xj,sfyx,pyjm,wbjm,jglx,xb,tjlx,tjxm,spy,xpy,whys) select '" + bh + "','" + nlxx + "','" + nlsx + "','" + dy
                + "','" + xy + "','" + mc + "','" + sfzc + "','" + keyword + "','" + mcjrxj + "','" + into_xj + "','" + sfyx + "','" + pyjm + "','" + wbjm + "','" + jglx + "','" + xb 
                + "','" + tjlx + "','" + tjxm + "','"+spy+"','"+xpy+"','"+whys+"'";
            arryList.Add(strSql);
        }
        public void str_Update_tj_tjxmb(string lxbh,string tjxm, string sfxj, string mcjrxj)
        {
            string strSql;
            strSql = "update TJ_TJXMB set sfxj='" + sfxj + "',mcjrxj='" + mcjrxj + "' where lxbh='" + lxbh + "' and tjxm='" + tjxm + "'";
            arryList.Add(strSql);
        }
        //public void str_Update_tj_tjxmb2(string lxbh, string tjxm, string ckxx, string cksx, string pdts, string pgts)
        //{
        //    string strSql;
        //    strSql = "update TJ_TJXMB set ckxx='" + ckxx + "',cksx='" + cksx + "',pdts='" + pdts + "',pgts='" + pgts + "' where lxbh='" + lxbh + "' and tjxm='" + tjxm + "'";
        //    arryList.Add(strSql);
        //}

        //**************************************************
        public DataTable Get_TJ_SUGGESTION_All(string tjlx,string lclx)//
        {
            string strSql;
            strSql = "select bh,keyword,mc,jbbh,sfcjb,jynr,explain,pyjm,wbjm,zdym,icd,tjlx,isnull(lclx,'') lclx from TJ_SUGGESTION where tjlx='" + tjlx + "' and isnull(lclx,'')='" + lclx + "' order by keyword";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Delete_TJ_SUGGESTION(string bh, string tjlx, string lclx)
        {
            string strSql;
            strSql = "delete TJ_SUGGESTION where bh='" + bh + "' and tjlx='" + tjlx + "' and isnull(lclx,'')='" + lclx + "'";
            strSql = strSql + ";update TJ_KEYWORD set keyword=null where keyword='" + bh + "' and tjlx='" + tjlx + "'";//2012-08-17吴：删除诊断建议的同时，删除常见结果和该项的关联
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Insert_TJ_SUGGESTION(string bh, string keyword, string mc, string jbbh, string sfcjb, string jynr, string explain, string pyjm,
            string wbjm, string zdym, string icd, string tjlx, string lclx)
        {
            string strSql;
            strSql = "delete TJ_SUGGESTION where bh='" + bh + "' and tjlx='" + tjlx + "'";
            strSql = strSql + "insert TJ_SUGGESTION(bh,keyword,mc,jbbh,sfcjb,jynr,explain,pyjm,wbjm,zdym,icd,tjlx,lclx) select '" + bh + "','" + keyword + "','" + mc + "','" + jbbh
                + "','" + sfcjb + "','" + jynr + "','" + explain + "','" + pyjm + "','" + wbjm + "','" + zdym + "','" + icd + "','" + tjlx + "','" + lclx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        //**************************************************
        public DataTable Get_tj_tc_hd()
        {
            string strSql;
            strSql = "select bh,mc from tj_tc_hd order by cast(disp_order as int)";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_tc_hd(string bh)
        {
            string strSql;
            strSql = "select bh,disp_order,xb,mc,jc,bzjg,jg,tjywlx,bz from tj_tc_hd where bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_tc_dt(string tcbh)//套餐编号
        {
            string strSql;
            strSql = "select a.zhxm,b.mc from tj_tc_dt a join tj_zhxm_hd b on a.zhxm=b.bh where a.tcbh='" + tcbh + "' order by b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public void str_Delete_tj_tc_hd(string bh)
        {
            string strSql;
            strSql = "delete tj_tc_hd where bh='" + bh + "'";
            arryList.Add(strSql);
        }
        public void str_Delete_tj_tc_dc(string tcbh)
        {
            string strSql;
            strSql = "delete tj_tc_dt where tcbh='" + tcbh + "'";
            arryList.Add(strSql);
        }
        public void str_Insert_tj_tc_hd(string bh, string disp_order, string xb, string mc, string jc, string bzjg, string jg, string tjywlx,string bz)
        {
            string strSql;
            strSql = "delete tj_tc_hd where bh='" + bh + "';";
            strSql = strSql + "insert tj_tc_hd(bh,disp_order,xb,mc,jc,bzjg,jg,tjywlx,bz) select '" + bh + "','" + disp_order + "','" + xb + "','" + mc
                + "','" + jc + "','" + bzjg + "','" + jg + "','" + tjywlx + "','" + bz + "'";
            arryList.Add(strSql);
        }
        public void str_Insert_tj_tc_dc(string tcbh, string zhxm)
        {
            string strSql;
            strSql = "insert tj_tc_dt(tcbh,zhxm) select '" + tcbh + "','" + zhxm + "'";
            arryList.Add(strSql);
        }
        public DataTable Get_tj_zhxm_hd()
        {
            string strSql;
            strSql = "select bh,mc,tjlx,pyjm,wbjm,zdym from tj_zhxm_hd where yxbz=1 order by tjlx,disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public string Get_ZhxmJg(string bh)//获取所选项目的标准价格
        {
            string strSql;
            strSql = "select sum(isnull(dj,0)) jg from tj_zhxm_hd where 1=1 and bh in" + bh;
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        //***************************************************************************************
        //处理数据被引用，不能被删除

        public int Exists_Lclx(string lclx)
        {
            string strSql;
            strSql = "select count(1) from tj_tjxmb where lclx='" + lclx + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public int Exists_Lcbh(string lxbh)
        {
            string strSql;
            strSql = "select count(1) from tj_tjxmb where lxbh='" + lxbh + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public int Exists_Tjxm(string tjxm)
        {
            string strSql;
            strSql = "select count(1) from tj_zhxm_dt where tjxm='" + tjxm + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public int Exists_Tjzhxm(string tjzhxm)
        {
            string strSql;
            strSql = "select count(1) from tj_tjjlb where tjxmbh='" + tjzhxm + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        //***************************************************************************************
        public DataTable Get_tj_sqdlx_hd()
        {
            string strSql;
            strSql = "select flbh,flmc from tj_sqdlx_hd order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_sqdlx_hd(string flbh)
        {
            string strSql;
            strSql = "select flbh,disp_order,flmc,jcjylx,bblx,bz from tj_sqdlx_hd where flbh='" + flbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_zhxm_hd(string flbh, string tjlx, string lclx)
        {
            string strSql;
            strSql = "select bh,mc,tjlx from tj_zhxm_hd where tjlx='" + tjlx + "' and isnull(lclx,'')='" + lclx + "' and bh not in(select bh from tj_sqdlx_dt) order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Delete_tj_sqdlx_hd(string flbh)
        {
            string strSql;
            strSql = "delete tj_sqdlx_hd where flbh='" + flbh + "';";
            strSql = strSql + "delete tj_sqdlx_dt where flbh='" + flbh + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public void str_Insert_tj_sqdlx_hd(string flbh, string disp_order, string flmc, string jcjylx, string bblx, string bz)
        {
            string strSql;
            strSql = "delete tj_sqdlx_hd where flbh='" + flbh + "';";
            strSql = strSql + "insert tj_sqdlx_hd(flbh,disp_order,flmc,jcjylx,bblx,bz) select '" + flbh + "','" + disp_order + "','" + flmc + "','" + jcjylx
                + "','" + bblx + "','" + bz + "'";
            arryList.Add(strSql);
        }

        public int Delete_tj_sqdlx_dt(string flbh, string bh, string xh, string tjlx)
        {
            string strSql;
            strSql = "delete tj_sqdlx_dt where flbh='" + flbh + "' and bh='" + bh + "' and xh='" + xh + "' and tjlx='" + tjlx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Insert_tj_sqdlx_dt(string flbh, string bh, string xh, string tjlx)
        {
            string strSql;
            strSql = "insert tj_sqdlx_dt(flbh,bh,xh,tjlx) select '" + flbh + "','" + bh + "','" + xh + "','" + tjlx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public DataTable Get_tj_sqdlx_dt(string flbh)
        {
            string strSql;
            strSql = "select a.bh,b.mc,a.flbh,a.xh,a.tjlx from tj_sqdlx_dt a join tj_zhxm_hd b on a.bh=b.bh where a.flbh='" + flbh + "' order by b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public string Get_MaxXh_tj_sqdlx_dt(string flbh)
        {
            string strSql;
            strSql = "select isnull(max(xh),0)+1 from tj_sqdlx_dt where flbh='" + flbh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        //*******************************************************************************
        public DataTable Get_tj_jbmb_hd()
        {
            string strSql;
            strSql = "select bh,mbmc from tj_jbmb_hd order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_jbmb_hd(string bh)
        {
            string strSql;
            strSql = "select bh,disp_order,mbmc,bz from tj_jbmb_hd where bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_jbmb_dt(string bh)
        {
            string strSql;
            strSql = "select a.bh,b.keyword,a.xh,a.jbbh,a.tjlx from tj_jbmb_dt a join tj_suggestion b on a.jbbh=b.bh where a.bh='" + bh + "' order by b.bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_suggestion(string tjlx,string bh)
        {
            string strSql;
            strSql = "select bh jbbh,keyword,tjlx from tj_suggestion where tjlx='" + tjlx + "' and jbbh='1' and bh not in(select jbbh from tj_jbmb_dt where bh='" + bh + "') order by bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Insert_tj_jbmb_dt(string bh, string xh, string jbbh, string tjlx)
        {
            string strSql;
            strSql = "insert tj_jbmb_dt(bh,xh,jbbh,tjlx) select '" + bh + "','" + xh + "','" + jbbh + "','" + tjlx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public string Get_MaxXh_tj_jbmb_dt(string bh)
        {
            string strSql;
            strSql = "select isnull(max(xh),0)+1 from tj_jbmb_dt where bh='" + bh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        public int Delete_tj_jbmb_dt(string bh, string xh, string jbbh, string tjlx)
        {
            string strSql;
            strSql = "delete tj_jbmb_dt where bh='" + bh + "' and xh='" + xh + "' and jbbh='" + jbbh + "' and tjlx='" + tjlx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Delete_tj_jbmb_hd(string bh)
        {
            string strSql;
            strSql = "delete tj_jbmb_hd where bh='" + bh + "';";
            strSql = strSql + "delete tj_jbmb_dt where bh='" + bh + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public void str_Insert_tj_jbmb_hd(string bh, string disp_order, string mbmc, string bz)
        {
            string strSql;
            strSql = "delete tj_jbmb_hd where bh='" + bh + "';";
            strSql = strSql + "insert tj_jbmb_hd(bh,disp_order,mbmc,bz) select '" + bh + "','" + disp_order + "','" + mbmc + "','" + bz + "'";
            arryList.Add(strSql);
        }
        //*******************************************************************************

        public DataTable Get_tj_xmmb_hd()
        {
            string strSql;
            strSql = "select bh,mbmc from tj_xmmb_hd order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_xmmb_hd(string bh)
        {
            string strSql;
            strSql = "select bh,disp_order,mbmc,bz from tj_xmmb_hd where bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_xmmb_dt(string bh)
        {
            string strSql;
            strSql = "select a.bh,b.mc keyword,a.xh,a.xmbh jbbh,a.tjlx from tj_xmmb_dt a join (select tjxm jbbh,mc,lxbh tjlx,disp_order from tj_tjxmb where qybz=1 union select bh jbbh,'*'+mc mc,tjlx,disp_order from TJ_ZHXM_HD where yxbz=1) b on a.xmbh=b.jbbh where a.bh='" + bh + "' order by b.tjlx,b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_tjxmb1(string tjlx, string bh)
        {
            string strSql;
            strSql = "select * from (select tjxm jbbh,mc keyword,lxbh tjlx,disp_order from tj_tjxmb where qybz=1 union select bh jbbh,'*'+mc keyword,tjlx,disp_order from TJ_ZHXM_HD where yxbz=1) a where a.tjlx='" + tjlx + "' and jbbh not in(select xmbh from tj_xmmb_dt where bh='" + bh + "') order by a.tjlx,a.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Insert_tj_xmmb_dt(string bh, string xh, string xmbh, string tjlx)
        {
            string strSql;
            strSql = "insert tj_xmmb_dt(bh,xh,xmbh,tjlx) select '" + bh + "','" + xh + "','" + xmbh + "','" + tjlx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public string Get_MaxXh_tj_xmmb_dt(string bh)
        {
            string strSql;
            strSql = "select isnull(max(xh),0)+1 from tj_xmmb_dt where bh='" + bh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString();
        }
        public int Delete_tj_xmmb_dt(string bh, string xh, string jbbh, string tjlx)
        {
            string strSql;
            strSql = "delete tj_xmmb_dt where bh='" + bh + "' and xh='" + xh + "' and xmbh='" + jbbh + "' and tjlx='" + tjlx + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Delete_tj_xmmb_hd(string bh)
        {
            string strSql;
            strSql = "delete tj_xmmb_hd where bh='" + bh + "';";
            strSql = strSql + "delete tj_xmmb_dt where bh='" + bh + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public void str_Insert_tj_xmmb_hd(string bh, string disp_order, string mbmc, string bz)
        {
            string strSql;
            strSql = "delete tj_xmmb_hd where bh='" + bh + "';";
            strSql = strSql + "insert tj_xmmb_hd(bh,disp_order,mbmc,bz) select '" + bh + "','" + disp_order + "','" + mbmc + "','" + bz + "'";
            arryList.Add(strSql);
        }

        //*******************************************************************************
        public DataTable Get_tj_hsb_hd()
        {
            string strSql;
            strSql = "select bh,zhxmbh,mc,ms from tj_hsb_hd order by bh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_hsb_xmdz(string hsid)
        {
            string strSql;
            strSql = "select mc,dzm,bz,hsid,gjz from tj_hsb_xmdz where hsid='"+hsid+"' order by disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_hsb_dt(string hsid)
        {
            string strSql;
            strSql = "select xh,mc,ckz,zdbh,bh,bz from tj_hsb_dt where bh='" + hsid + "' order by xh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Update_tj_hsb_hd(string bh, string zhxmbh,string ms)
        {
            string strSql;
            strSql = "update tj_hsb_hd set zhxmbh='" + zhxmbh + "',ms='" + ms + "' where bh='" + bh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public DataTable Update_tj_hsb_xmdz(DataTable objDataTable)
        {
            string strSql;
            strSql = "select mc,dzm,bz,hsid,gjz from tj_hsb_xmdz";
            return base.SqlDBAgent.Update(objDataTable, strSql);
        }
        public DataTable Update_tj_hsb_dt(DataTable objDataTable)
        {
            string strSql;
            strSql = "select xh,mc,ckz,zdbh,bh,bz from tj_hsb_dt";
            return base.SqlDBAgent.Update(objDataTable, strSql);
        }
        //*******************************************************************************
        public DataTable Get_TJ_JBFB_NL()
        {
            string strSql;
            strSql = "select xh,mc,begin_age,end_age from TJ_JBFB_NL";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Update_TJ_JBFB_NL(DataTable objDataTable)
        {
            string strSql;
            strSql = "select xh,mc,begin_age,end_age from TJ_JBFB_NL";
            return base.SqlDBAgent.Update(objDataTable, strSql);
        }


        public void str_Delete_tjyw()
        {
            string strSql;
            strSql = "truncate table  dbo.TJ_SFB;truncate table  dbo.TJ_TFB;truncate table  dbo.TJ_TJDJB;truncate table  dbo.TJ_TJJLB;truncate table  dbo.TJ_TJJLMXB;";
            arryList.Add(strSql);
        }

        public DataTable Get_tj_tjlxbqx(string UserID)
        {
            string strSql;
            strSql = "select * from tj_tjlxb where LXBH in (select KsID from xt_ysks where  UserID='" + UserID + "') order by DISP_ORDER";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
    }
}
