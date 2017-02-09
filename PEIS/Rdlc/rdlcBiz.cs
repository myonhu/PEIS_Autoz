using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace PEIS.Rdlc
{
    class rdlcBiz :Base
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

        //public DataTable Get_Table(string strSql)
        //{
        //    return base.SqlDBAgent.GetDataTable(strSql);
        //}
        //public int Exec_Sql(string strSql)
        //{
        //    return base.SqlDBAgent.sqlupdate(strSql);
        //}
        public DataTable Get_tj_tjjlb_ks(string tjbh, string tjcs)// 检测项目增加科室by zhz
        {
            string strSql;
            strSql = "select c.xmlx,d.xm,c.tjbh,a.mc,b.dz,b.xb from v_tj_tjdjb d join tj_tjjlb c on d.tjbh=c.tjbh join tj_tjlxb a on c.lxbh=a.lxbh join tj_jkzyd b on a.lxbh=b.ksbh where c.tjbh = '" + tjbh + "' and c.tjcs='" + tjcs + "' and b.xb=d.xb order by c.lxbh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_tjjlb(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select a.xmlx,b.mc,b.lcyy,b.tsxx from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh where a.tjbh='" + tjbh + "' and a.tjcs='" + tjcs + "'order by b.tjlx,b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_v_tj_tjdjb(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select xxh from tj_tj_xxh where tjbh='" + tjbh + "'";
            DataTable dt = base.SqlDBAgent.GetDataTable(strSql);
            if (dt.Rows.Count > 0)
            {
                //添加x线编号
                strSql = "select djlsh,xm,xb,nl,csrq,hyzk,mz,tjrq,djrq,a.tjbh,tjcs,dwmc,bmmc,tjlb,lbbh,rylb,mobile,phone,address,a.sfzh,sykh,dwbh,bmbh,sumover,picture,barcode,xbcode,zs,jy,jcrq,jcys,tjjl,jktj,czy,tcmc,zjys,fcrq,fcgy,rylbcode,rylbmc,gz,whcd,whcdbm,gzbh,lx,whysmc,whys,lb,wyyslb,gl,zytjjl,zytjjy,tjbgwxts,b.xxh from v_tj_tjdjb a join tj_tj_xxh b on a.tjbh=b.tjbh where a.tjbh='" + tjbh + "' and a.tjcs='" + tjcs + "'";
            }
            else
                strSql = "select djlsh,xm,xb,nl,csrq,hyzk,mz,tjrq,djrq,tjbh,tjcs,dwmc,bmmc,tjlb,lbbh,rylb,mobile,phone,address,sfzh,sykh,dwbh,bmbh,sumover,picture,barcode,xbcode,zs,jy,jcrq,jcys,tjjl,jktj,czy,tcmc,zjys,fcrq,fcgy,rylbcode,rylbmc,gz,whcd,whcdbm,gzbh,lx,whysmc,whys,lb,wyyslb,gl,zytjjl,zytjjy,tjbgwxts from v_tj_tjdjb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_v_tj_fyxx(string tjbh, string tjcs)
        {
            string strSql;
            //strSql = "select * from v_tj_tjdjb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            strSql = "select isnull(sum(hj),0) hj,tjbh,tjcs from v_tj_fyxx  where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' group by tjbh,tjcs ";

            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_tj_sqdlx_hd(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "exec proc_get_tjsqd '" + tjbh + "','" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_TJBG_BZB(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "exec PROC_TJ_TJBG_BZBG '" + tjbh + "','" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_cytj_jkjcbg(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "exec Pro_cytj_jkjcbg '" + tjbh + "','" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取体检明细
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetTjmx(string tjbh, string tjcs,string zhlx)
        {
            string sql = "select TJBH,TJCS,DJLSH,XM,XB,CSNYR,PHONE,TJXMBH,TJXM,JG,MC,DW,ZCTS,LXBH,JCRQ,JCYS,CKZ,TS,XH,JGLX,sfyx,jcjylx from v_tjmx";
            sql += " where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and tjxmbh='" + zhlx + "'";

            return base.SqlDBAgent.GetDataTable(sql);
        }

        /// <summary>
        /// 获取体检记录
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetTjjl(string tjbh, string tjcs)
        {
            string sql = "select tjbh,tjcs,xj,jcrq,jcys,tjxmbh,mc from v_tjzh where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'";


            return base.SqlDBAgent.GetDataTable(sql);
        }

        /// <summary>
        /// 获取体检记录明细
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetTjjlmx(string tjbh, string tjcs)
        {
            string sql = "select tjbh,tjcs,djlsh,xm,xb,tjxmbh,jg,mc,dw,zcts,ckz,ts,xj,jcrq,jcys,zhmc from v_tjjlmx where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' order by disp_order,xmb_disp_order";

            return base.SqlDBAgent.GetDataTable(sql);
        }

        public DataTable Get_v_jy_jybgdy(string djlsh)
        {
            string strSql;
            //strSql = "select * from v_tj_tjdjb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            strSql = "select * from v_jy_jybgdy where djlsh='" + djlsh + "' order by ybh";

            return base.SqlDBAgent.GetDataTable(strSql);
        }
    }
}
