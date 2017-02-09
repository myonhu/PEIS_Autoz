using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace PEIS.tjdj
{
    class tjdjBiz : Base
    {
        ArrayList arryList = new ArrayList();
        StringBuilder sql;

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
        //**************************************************************
        public DataTable Get_tj_dw(int i, string str_bh,int qybz)
        {
            string strSql = "";
            if (qybz == 1)//启用
            {
                if (i == 0)
                {
                    strSql = "select bh,mc,qybz from v_tj_dw where len(bh)=4 and qybz=1 order by bh desc";
                }
                if (i == 1)
                {
                    strSql = "select bh,mc,qybz from v_tj_dw where len(bh)=8 and qybz=1 and bh like '" + str_bh + "%' order by bh desc";
                }
                if (i == 2)
                {
                    strSql = "select bh,mc,qybz from v_tj_dw where len(bh)=12 and qybz=1 and bh like '" + str_bh + "%' order by bh desc";
                }
                if (i == 3)
                {
                    strSql = "select bh,mc,qybz from v_tj_dw where len(bh)=16 and qybz=1 and bh like '" + str_bh + "%' order by bh desc";
                }
            }
            else//所有
            {
                if (i == 0)
                {
                    strSql = "select bh,mc,qybz from v_tj_dw where len(bh)=4 order by bh desc";
                }
                if (i == 1)
                {
                    strSql = "select bh,mc,qybz from v_tj_dw where len(bh)=8 and bh like '" + str_bh + "%' order by bh desc";
                }
                if (i == 2)
                {
                    strSql = "select bh,mc,qybz from v_tj_dw where len(bh)=12 and bh like '" + str_bh + "%' order by bh desc";
                }
                if (i == 3)
                {
                    strSql = "select bh,mc,qybz from v_tj_dw where len(bh)=16 and bh like '" + str_bh + "%' order by bh desc";
                }
            }
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_dw(string bh)
        {
            string strSql;
            strSql = "select bh,qybz,mc,pyjm,wbjm,dwfzr,lxdh,czdh,yzbm,lxdz,ywyy,yhzh,qyxz,jzrs,bz,jjlx,hy,qygm,scgrs,yhzyrs,lx from tj_dw where bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_v_tj_dw(string jm)
        {
            string strSql;
            strSql = "select bh,dbo.fGetTjdwmc(bh) mc,pyjm,wbjm from v_tj_dw where qybz=1 and (mc like '%" + jm + "%' or pyjm like '%" + jm + "%' or wbjm like '%" + jm + "%')";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public int Exists_tj_dw(string dwbh)
        {
            string strSql;
            strSql = "select count(1) from tj_tjdjb where dwbh like '" + dwbh + "%'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public int Delete_tj_dw(string bh)
        {
            string strSql;
            strSql = "delete tj_dw where bh like '" + bh + "%'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public string Get_proc_get_tjdwbh(string dwbh)
        {
            string strSql;
            strSql = "exec proc_get_tjdwbh '" + dwbh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        public int Insert_tj_dw(string bh, string qybz, string mc, string pyjm, string wbjm, string dwfzr, string lxdh, string czdh,
            string yzbm, string lxdz, string ywyy, string yhzh, string qyxz, string jzrs, string bz, string jjlx, string hy, string qygm, string scgrs, string yhzyrs,string lx)
        {
            string strSql;
            strSql = "delete tj_dw where bh='" + bh + "';";
            strSql = strSql + "insert tj_dw(bh,qybz,mc,pyjm,wbjm,dwfzr,lxdh,czdh,yzbm,lxdz,ywyy,yhzh,qyxz,jzrs,bz,jjlx,hy,qygm,scgrs,yhzyrs,lx) select '" + bh + "','" + qybz + "','" + mc + "','" + pyjm
                + "','" + wbjm + "','" + dwfzr + "','" + lxdh + "','" + czdh + "','" + yzbm + "','" + lxdz + "','" + ywyy + "','" + yhzh + "','" + qyxz + "','" + jzrs + "','" + bz + "',"
            +"'"+jjlx+"','"+hy+"','"+qygm+"','"+scgrs+"','"+yhzyrs+"','"+lx+"'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        //**************************************************************
        public DataTable Get_TJ_DW()
        {
            string strSql = "";
            strSql = "select bh,mc from tj_dw where len(bh)=4 and qybz=1 order by bh desc"; 
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_DWFZ_HD(string dwbh)
        {
            string strSql;
            strSql = "select bh,fzmc from TJ_DWFZ_HD where dwbh='" + dwbh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_DWFZ_HD(string dwbh,string bh)
        {
            string strSql;
            strSql = "select bh,fzmc,xb,zw,zc from TJ_DWFZ_HD where dwbh='" + dwbh + "' and bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Delete_TJ_DWFZ_HD(string dwbh, string bh)
        {
            string strSql;
            strSql = "delete TJ_DWFZ_DT where dwbh='" + dwbh + "' and fzbh='" + bh + "';";
            strSql = strSql + "delete TJ_DWFZ_HD where dwbh='" + dwbh + "' and bh='" + bh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public string Get_proc_get_tjdwfzbh(string dwbh)
        {
            string strSql;
            strSql = "exec proc_get_tjdwfzbh '" + dwbh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        public void str_Delete_TJ_DWFZ_HD(string bh, string dwbh)
        {
            string strSql;
            strSql = "delete TJ_DWFZ_DT where dwbh='" + dwbh + "' and fzbh='" + bh + "';";
            strSql = strSql + "delete TJ_DWFZ_HD where dwbh='" + dwbh + "' and bh='" + bh + "'";
            arryList.Add(strSql);
        }
        public void str_Insert_TJ_DWFZ_HD(string bh, string dwbh, string fzmc, string xb, string zw, string zc)
        {
            string strSql;
            strSql = "insert TJ_DWFZ_HD(bh,dwbh,fzmc,xb,zw,zc) select '" + bh + "','" + dwbh + "','" + fzmc + "','" + xb
                + "','" + zw + "','" + zc + "'";
            arryList.Add(strSql);
        }
        public void str_Insert_TJ_DWFZ_DT(string bh, string dwbh, string tjxm)
        {
            string strSql;
            strSql = "insert TJ_DWFZ_DT(fzbh,dwbh,tjxm) select '" + bh + "','" + dwbh + "','" + tjxm + "'";
            arryList.Add(strSql);
        }
        public DataTable Get_TJ_DWFZ_DT(string bh, string dwbh)//分组项目
        {
            string strSql;
            strSql = "select a.tjxm zhxm,b.mc from tj_dwfz_dt a join tj_zhxm_hd b on a.tjxm=b.bh where a.fzbh='" + bh + "' and dwbh='" + dwbh + "' order by b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_Exists_TJ_TJDJB(string xm, string sfzh)//同名确认
        {
            string strSql;
            strSql = "select tjbh,tjcs,djlsh from tj_tjdjb where xm='" + xm + "' or sfzh='" + sfzh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        //**************************************************************

        public string GetDwbh()
        {
            string sql = "select max(bh) bh from tj_dw where len(bh)=4 and bh <>'9999'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql);
            string bh;
            if (dt.Rows.Count<=0)
            {
                return "0001";
            }
            bh=dt.Rows[0][0].ToString().Trim();
            if (bh==null||bh=="")
            {
                return "0001";
            }
            decimal decBh = Convert.ToDecimal(bh)+1;
            bh = decBh.ToString();
            string str = "";
            for (int i = 0; i < 4-bh.Length; i++)
            {
                str += "0";
            }

            return str + bh;
        }

        public int Delete_TJ_TJDJB(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "delete tj_tjdjb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "';";
            strSql = strSql + "delete tj_zyjl where tjbh='" + tjbh + "' and tjcs='" + tjcs + "';";
            strSql = strSql + "delete tj_zyjlmx where tjbh='" + tjbh + "' and tjcs='" + tjcs + "';";
            strSql = strSql + "delete TJ_ZYB_RYXX where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <param name="tjrq"></param>
        /// <param name="djrq"></param>
        /// <param name="xm"></param>
        /// <param name="xb"></param>
        /// <param name="csrq"></param>
        /// <param name="nl"></param>
        /// <param name="hyzk"></param>
        /// <param name="sykh"></param>
        /// <param name="mz"></param>
        /// <param name="sfzh"></param>
        /// <param name="rylb"></param>
        /// <param name="phone"></param>
        /// <param name="mobile"></param>
        /// <param name="address"></param>
        /// <param name="tjlb"></param>
        /// <param name="djlsh"></param>
        /// <param name="dwbh"></param>
        /// <param name="fzbh"></param>
        /// <param name="picture"></param>
        /// <param name="sumover">登记状态</param>
        /// <param name="djry"></param>
        /// <param name="jsfs">接收方式</param>
        /// <returns></returns>
        public void str_Insert_TJ_TJDJB(string tjbh, string tjcs, string tjrq, string djrq, string xm, string xb, string csrq, string nl,
            string hyzk, string sykh, string mz, string sfzh, string rylb, string phone, string mobile, string address, string tjlb,
            string djlsh, string dwbh, string bmbh,string fzbh, string picture, string sumover,string djry,string jsfs,string whcd,string gz,string whys,string gl,string sfbz,string bzhy,string sszl,string jhgl)
        {
            string strSql;
            strSql = "insert tj_tjdjb(tjbh,tjcs,tjrq,djrq,xm,xb,csrq,nl,hyzk,sykh,mz,sfzh,rylb,phone,mobile,address,tjlb,djlsh,dwbh,bmbh,fzbh,picture,sumover,djry,jsfs,whcd,gz,whys,gl,sfbz,bzhy,sszl,jhgl,LoginIn,PrintLabel) select '" +
                tjbh + "','" + tjcs + "','" + tjrq + "','" + djrq + "','" + xm + "','" + xb + "','" + csrq + "','" + nl + "','" +
                hyzk + "','" + sykh + "','" + mz + "','" + sfzh + "','" + rylb + "','" + phone + "','" + mobile + "','" + address + "','" + tjlb + "','" +
                djlsh + "','" + dwbh + "','" + bmbh + "','" + fzbh + "','" + picture + "','" + sumover + "','" + djry + "','" + jsfs + "','"+whcd+"','"+gz+"','"+whys+"','"+gl+"','"+sfbz+"','"+bzhy+"','"+sszl+"','"+jhgl+"',0,0";
            arryList.Add(strSql);
        }

        /***********新增：mars**************/
        //插入 mode by zhz
        public int str_Insert_TJ_TJDJB(string tjbh, string tjcs, string tjrq, string djrq, string xm, string xb, string csrq, string nl,
           string hyzk, string sykh, string mz, string sfzh, string rylb, string phone, string mobile, string address, string tjlb,
           string djlsh, string dwbh, string bmbh, string fzbh, byte[] picture, string sumover, string djry, string jsfs, string whcd, string gz, string whys, string gl, string sfbz, string bzhy, string sszl,string jhgl,string LoginIn,string PrintLabel,string PrintZYD)
        {
            string strSql;
            strSql = "insert tj_tjdjb(tjbh,tjcs,tjrq,djrq,xm,xb,csrq,nl,hyzk,sykh,mz,sfzh,rylb,phone,mobile,address,tjlb,djlsh,dwbh,bmbh,fzbh,picture,sumover,djry,jsfs,whcd,gz,whys,gl,sfbz,bzhy,sszl,jhgl,LoginIn,PrintLabel,PrintZYD) values( '" +
                tjbh + "','" + tjcs + "','" + tjrq + "','" + djrq + "','" + xm + "','" + xb + "','" + csrq + "','" + nl + "','" +
                hyzk + "','" + sykh + "','" + mz + "','" + sfzh + "','" + rylb + "','" + phone + "','" + mobile + "','" + address + "','" + tjlb + "','" +
                djlsh + "','" + dwbh + "','" + bmbh + "','" + fzbh + "'," + "@pic" + ",'" + sumover + "','" + djry + "','" + jsfs + "','"+whcd+"','"+gz+"','"+whys+"','"+gl+"','"+sfbz+"','"+bzhy+"','"+sszl+"','"+jhgl+ "','" + LoginIn + "','" + PrintLabel + "','" + PrintZYD + "')";
            if (picture == null) picture = new byte[0];
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@pic", picture) };

            return base.SqlDBAgent.sqlupdate(strSql,para);
        }

        public int str_Insert_TJ_ZYB_RYXX(string tjbh, string tjcs, string xm, string xb, string sfzh, string csnyr, string dw, string dwdh,
          string gh, string bh, string tbtq, string lx, string jws, string bm, string zdrq, string zddw, string sfqy,
          string ccnl, string jq, string zq, string tjnl, string xyzn, string lccs, string zccs, string sccs, string yctc, string sfxy, string xyns, string sfyj, string yjsl, string yjsj, string qt,
            string jtbs,string dwdz,string gz,string ygzdwjgz,string zybwhjcs,string csd,string mz,string hy,string zgl,string jsgl,string dhqk,string xysl)
        {
            string strSql;
            strSql = "insert TJ_ZYB_RYXX(tjbh,tjcs,xm,xb,sfzh,csnyr,dw,dwdh,gh,bh,tbrq,lx,jws,bm,zdrq,zddw,sfqy,ccnl,jq,zq,tjnl,xyzn,lccs,zccs,sccs,yctc,sfxy,xyns,sfyj,yjsl,yjsj,qt,jtbs,dwdz,gz,ygzdwjgz,zybwhjcs,csd,mz,hy,zgl,jsgl,dhqk,xysl) values( '" +
                tjbh + "','" + tjcs + "','" + xm + "','" + xb + "','" + sfzh + "','" + csnyr + "','" + dw + "','" +
                dwdh + "','" + gh + "','" + bh + "','" + tbtq + "','" + lx + "','" + jws + "','" + bm + "','" + zdrq + "','" + zddw + "','" +
                sfqy + "','" + ccnl + "','" + jq + "','" + zq + "','" + tjnl + "','" + xyzn + "','" + lccs + "','" + zccs + "','" + sccs + "','" + yctc + "','" + sfxy + "','" + xyns + "','" + sfyj + "','" + yjsl + "','" + yjsj+
                "','" + qt + "','" + jtbs + "','" + dwdz + "','" + gz + "','" + ygzdwjgz + "','" + zybwhjcs + "','" + csd + "','" + mz + "','" + hy + "','" + zgl + "','" + jsgl + "','" + dhqk + "','" + xysl + "')";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        public int Update_TJ_ZYB_RYXX(string tjbh, string tjcs, string xm, string xb, string sfzh, string csnyr, string dw, string dwdh,
          string gh, string bh, string tbtq, string lx, string jws, string bm, string zdrq, string zddw, string sfqy,
          string ccnl, string jq, string zq, string tjnl, string xyzn, string lccs, string zccs, string sccs, string yctc, string sfxy, string xyns, string sfyj, string yjsl, string yjsj, string qt,
            string jtbs, string dwdz, string gz, string ygzdwjgz, string zybwhjcs, string csd, string mz, string hy, string zgl, string jsgl, string dhqk, string xysl)
        {
            string strSql;
            strSql = "update TJ_ZYB_RYXX set xm='" + xm + "',xb='" + xb + "',sfzh='" + sfzh + "',csnyr='" + csnyr + "',dw='" + dw + "',dwdh='" + dwdh
                + "',tbrq='" + tbtq + "',lx='" + lx + "',jws='" + bm + "',gz='" + gz + "',mz='" + mz
                + "',hy='" + hy + "',zgl='" + zgl + "',jsgl='" + jsgl + "',dhqk='"+ dhqk +"'"
                + " where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        //更新 mode by zhz
        public int Update_TJ_TJDJB(string tjbh, string tjcs, string tjrq, string xm, string xb, string csrq, string nl,
           string hyzk, string sykh, string mz, string sfzh, string rylb, string phone, string mobile, string address, string tjlb,
           string dwbh, string bmbh, string fzbh, byte[] picture, string whcd, string gz, string whys, string gl, string sfbz, string bzhy, string sszl,string jhgl, string LoginIn, string PrintLabel, string PrintZYD)
        {
            string strSql;
            strSql = "update tj_tjdjb set tjrq='" + tjrq + "',xm='" + xm + "',xb='" + xb + "',csrq='" + csrq + "',nl='" + nl + "',hyzk='" + hyzk
                + "',sykh='" + sykh + "',mz='" + mz + "',sfzh='" + sfzh + "',rylb='" + rylb + "',phone='" + phone + "',mobile='" + mobile + "',address='" + address
                + "',tjlb='" + tjlb + "',dwbh='" + dwbh + "',bmbh='" + bmbh + "',fzbh='" + fzbh + "',picture=@pic,whcd='" + whcd + "',gz='" + gz + "',whys='" + whys + "',gl='" + gl + "',sfbz='" + sfbz + "',bzhy='" + bzhy + "',sszl='" + sszl + "',jhgl='" + jhgl + "',LoginIn='" + LoginIn + "',PrintLabel='" + PrintLabel + "',PrintZYD='" + PrintZYD + "'"
                + " where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' ";
            if (picture == null) picture = new byte[0];
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@pic", picture) };
            
            return base.SqlDBAgent.sqlupdate(strSql, para);
        }
        /*************************/

        public int Update_TJ_TJDJB(string tjbh, string tjcs, string tjrq,string xm, string xb, string csrq, string nl,
            string hyzk, string sykh, string mz, string sfzh, string rylb, string phone, string mobile, string address, string tjlb,
            string dwbh, string bmbh, string fzbh, string picture,string bzhy,string sszl,string jhgl)
        {
            string strSql;
            strSql = "update tj_tjdjb set tjrq='" + tjrq + "',xm='" + xm + "',xb='" + xb + "',csrq='" + csrq + "',nl='" + nl + "',hyzk='" + hyzk
                + "',sykh='" + sykh + "',mz='" + mz + "',sfzh='" + sfzh + "',rylb='" + rylb + "',phone='" + phone + "',mobile='" + mobile + "',address='" + address +"',bzhy='"+bzhy+"',sszl='"+sszl
                + "',tjlb='" + tjlb + "',dwbh='" + dwbh + "',bmbh='" + bmbh + "',fzbh='" + fzbh + "',picture='" + picture +"',jhgl='"+jhgl
                + "' where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        //体检登记表（体检日期）by zhz
        public DataTable Get_TJ_TJDJB(string tjrq)
        {
            string strSql;
            strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh,bzhy,sszl,PrintLabel,LoginIn,PrintZYD from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and isnull(b.sfh,0)=isnull(b.ysfh,0) order by PrintZYD desc,PrintLabel desc,LoginIn desc";
            //strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh,bzhy,sszl,PrintLabel,LoginIn,PrintZYD from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and isnull(b.sfh,0)=isnull(b.ysfh,0) order by djlsh asc";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        //体检登记表（体检日期,单位名称）by zhz
        public DataTable Get_TJ_TJDJB_DWMC(string tjrq, string dwmc)
        {
            string strSql;
            strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh,bzhy,sszl,PrintLabel,LoginIn,PrintZYD from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and isnull(b.sfh,0)=isnull(b.ysfh,0) and dwmc = '" + dwmc + "' order by PrintZYD desc,PrintLabel desc,LoginIn desc";
            //strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh,bzhy,sszl,PrintLabel,LoginIn,PrintZYD from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and isnull(b.sfh,0)=isnull(b.ysfh,0) and dwmc = '" + dwmc + "' order by djlsh asc";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        //体检登记表（体检日期，登记号，姓名，收费标志，备注）
        public DataTable Get_TJ_TJDJB(string tjrq,string djh,string xm,string sfbz,string beizhu)
        {
            string strSql;
            if (sfbz == "1")  //已收费
            {
                strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where isnull(b.sfh,0)>0 and tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and (djlsh='" + djh + "' or a.tjbh='" + djh + "' or 1=1) and (xm like'%" + xm + "%' or 1=1) and isnull(b.sfh,0)=isnull(b.ysfh,0) order by djlsh asc";
            }
            else             //未收费
            {
                if (xm == "")
                {
                    if (djh == "")
                    {
                        strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where isnull(b.sfh,0)=0 and tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and  isnull(b.sfh,0)=isnull(b.ysfh,0) order by djlsh asc";
                    }
                    else
                    {
                        strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where isnull(b.sfh,0)=0 and tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and (djlsh='" + djh + "' or a.tjbh='" + djh + "') and  isnull(b.sfh,0)=isnull(b.ysfh,0) order by djlsh asc";
                    }
                }
                else
                {
                    if (djh == "")
                    {
                        strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where isnull(b.sfh,0)=0 and tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and  (xm like'%" + xm + "%') and isnull(b.sfh,0)=isnull(b.ysfh,0) order by djlsh asc";
                    }
                    else
                    {
                        strSql = "select djlsh,xm,xb,nl,tjrq,djrq,a.tjbh,a.tjcs,dwmc,bmmc,sumover,isnull(b.sfh,0) sfh from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where isnull(b.sfh,0)=0 and tjrq>='" + tjrq + "' and tjrq<='" + tjrq + "' and (djlsh='" + djh + "' or a.tjbh='" + djh + "') and (xm like'%" + xm + "%') and isnull(b.sfh,0)=isnull(b.ysfh,0) order by djlsh asc";
                    }
                }
                
            }
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable GetSsje(string sfh,string tjbh,string tjcs)
        {
            string strSql;
            strSql="select ysje,ssje,yhlx,yhxx from tj_sfb where sfh='"+sfh+"' and tjbh='"+tjbh+"' and tjcs='"+tjcs+"'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }



        public DataTable Get_TJ_TJDJB(string tjrq1, string tjrq2, string dwbh, string bmbh)
        {
            string strSql;
            if (bmbh == "")
            {
                strSql = "select xm '姓名',xb '性别',nl '年龄',csrq '出生日期',gz '工种',hyzk '婚姻状况',mobile '手机号码',phone '联系电话',sfzh '身份证号',bmmc '部门',"
                    + "rylb '人员类别',sykh '索引卡号',address '联系地址',mz '民族' from v_tj_tjdjb where tjrq>='"
                    + tjrq1 + "' and tjrq<='" + tjrq2 + "' and dwbh='" + dwbh + "' order by tjrq desc, djlsh";
            }
            else
            {
                strSql = "select xm '姓名',xb '性别',nl '年龄',csrq '出生日期',gz '工种',hyzk '婚姻状况',mobile '手机号码',phone '联系电话',sfzh '身份证号',bmmc '部门',"
                    + "rylb '人员类别',sykh '索引卡号',address '联系地址',mz '民族' from v_tj_tjdjb where tjrq>='"
                    + tjrq1 + "' and tjrq<='" + tjrq2 + "' and dwbh='" + dwbh + "' and isnull(bmbh,'')='" + bmbh + "' order by tjrq desc, djlsh";
            }
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_TJDJB(string tjrq1, string tjrq2, string xm, string dwbh, string bmbh, string xsfs,string ks)
        {
            //xsfs 0全部 1个人 2单位,  ZHZ delete KS科室字段 at 2016712  please add again.
            string strSql;
            if (xsfs == "1")
            {
                strSql = "select djlsh,xm,xb,nl,tjbh,tjcs,dwmc,sfzh,sumover,sfbz from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%'  and dwbh='9999' order by sumover,tjrq desc,djlsh,sumover desc";
            }
            else if (xsfs == "2")
            {
                if (bmbh == "")
                {
                    strSql = "select djlsh,xm,xb,nl,tjbh,tjcs,dwmc,sfzh,sumover,sfbz  from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%'and dwbh='" + dwbh + "' order by sumover,tjrq desc,djlsh desc";
                }
                else
                {
                    strSql = "select djlsh,xm,xb,nl,tjbh,tjcs,dwmc,sfzh,sumover,sfbz  from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and  dwbh ='" + dwbh + "' and isnull(bmbh,'')='" + bmbh + "' order by sumover,tjrq desc,djlsh desc";
                }
            }
            else
            {
                strSql = "select djlsh,xm,xb,nl,tjbh,tjcs,dwmc,sfzh,sumover,sfbz from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%'   order by sumover,tjrq,djlsh desc";
            }
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_TJDJB(string tjrq1, string tjrq2, string tjbh1,string tjbh2,string xm,string xb, string dwbh, string bmbh, string zjzt)
        {
            //zjzt 0全部 1未总检 2总检
            string strSql;
            if (tjbh1 != "" && tjbh2 != "")
            {
                if (dwbh != "")
                {
                    if (zjzt == "2")
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') and sumover in(2) order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') and sumover in(2) order by tjrq desc,djlsh desc";
                        }
                    }
                    else if (zjzt == "1")
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') and sumover in(0,1) order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') and sumover in(0,1) order by tjrq desc,djlsh desc";
                        }
                    }
                    else
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') order by tjrq desc,djlsh desc";
                        }

                    }
                }
                else
                {
                    if (zjzt == "2")
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and sumover in(2) order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and sumover in(2) order by tjrq desc,djlsh desc";
                        }
                    }
                    else if (zjzt == "1")
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and sumover in(0,1) order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and sumover in(0,1) order by tjrq desc,djlsh desc";
                        }
                    }
                    else
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and convert(dec(18,0),djlsh)>='" + tjbh1 + "' and convert(dec(18,0),djlsh)<='" + tjbh2 + "' and xm like '%" + xm + "%' order by tjrq desc,djlsh desc";
                        }
                    }
                }
            }
            else
            {
                if (dwbh != "")
                {
                    if (zjzt == "2")
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') and sumover in(2) order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') and sumover in(2) order by tjrq desc,djlsh desc";
                        }
                    }
                    else if (zjzt == "1")
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') and sumover in(0,1) order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') and sumover in(0,1) order by tjrq desc,djlsh desc";
                        }
                    }
                    else
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "'and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and dwbh='" + dwbh + "' and (isnull(bmbh,'')='" + bmbh + "' or bmbh='') order by tjrq desc,djlsh desc";
                        }
                    }
                }
                else
                {
                    if (zjzt == "2")
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and sumover in(2) order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and sumover in(2) order by tjrq desc,djlsh desc";
                        }
                    }
                    else if (zjzt == "1")
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' and sumover in(0,1) order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and sumover in(0,1) order by tjrq desc,djlsh desc";
                        }
                    }
                    else
                    {
                        if (xb != "%")
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' and xbcode='" + xb + "' order by tjrq desc,djlsh desc";
                        }
                        else
                        {
                            strSql = "select 0 selected,djlsh,xm,xb,nl,tjbh,tjcs,dycs,tjrq,dwmc,tcmc,sfzh,sumover,sfbz,tjlb,LoginIn,PrintLabel,PrintZYD from v_tj_tjdjb where tjrq>='" + tjrq1 + "' and tjrq<='" + tjrq2 + "' and xm like '%" + xm + "%' order by tjrq desc,djlsh desc";
                        }
                    }
                }
            }
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_TJDJB(string tjbh,string tjcs)
        {
            string strSql;
            strSql = "select djlsh,tjbh,tjcs,tjrq,xm,xb,csrq,nl,hyzk,sykh,mz,sfzh,rylb,phone,mobile,address,tjlb,dwbh,bmbh,fzbh,picture,sumover,whcd,gz,whys,gl,sfbz,bzhy,sszl,jhgl from tj_tjdjb where tjbh='" 
                + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public string Get_TJ_DW(string bh)
        {
            string strSql;
            strSql = "select mc from tj_dw where bh='" + bh + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        public int Get_SumOver(string tjbh, string tjcs)
        {
            string strSql;
            strSql = "select sumover from tj_tjdjb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return Convert.ToInt32((base.SqlDBAgent.sqlvalue(strSql).ToString().Trim()));
        }
        public DataTable Get_dt_tj_tjjlb(string tjbh, string tjcs)//体检项目
        {
            string strSql;
            strSql = "select a.tjxmbh zhxm,b.mc from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh where tjbh='"
                + tjbh + "' and tjcs='" + tjcs + "' order by b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取体检费用信息
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetTjfyxx(string tjbh,string tjcs)
        {
            string strSql;
            strSql = "select distinct a.tjxmbh zhxm,b.mc,a.xmdj,a.dzbl,hj=isnull(a.xmdj,0)*case when a.dzbl=0 then 1 else isnull(a.dzbl,1) end,case isnull(sfh,0) when 0 then 0 else 1 end sfh,a.CHARGED from tj_tjjlb a join tj_zhxm_hd b on a.tjxmbh=b.bh left join tj_sfb c on a.tjbh=c.tjbh and a.tjcs=c.tjcs where a.tjbh='"
                + tjbh + "' and a.tjcs='" + tjcs + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public int Delete_tj_tjjlb(string tjbh, string tjcs, string tjxmbh)
        {
            string strSql;
            strSql = "delete tj_tjjlb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and tjxmbh='" + tjxmbh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public void str_Delete_tj_tjjlb(string tjbh, string tjcs, string tjxmbh)
        {
            string strSql;
            strSql = "delete tj_tjjlb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and tjxmbh='" + tjxmbh + "'";
            arryList.Add(strSql);
        }
        //体检记录表 by zhz
        public void str_Insert_tj_tjjlb(string xh, string tjbh, string tjcs, string lxbh, string ydtjrq, string tjxmbh, string xmdj, string isover,
            string jsfs, string sflb, string zxks,string xmlx)
        {   
            string strSql;
            strSql = "insert tj_tjjlb(xh,tjbh,tjcs,lxbh,ydtjrq,tjxmbh,xmdj,isover,jsfs,sflb,zxks,xmlx) select '" +
                xh + "','" + tjbh + "','" + tjcs + "','" + lxbh + "','" + ydtjrq + "','" + tjxmbh + "','" + xmdj + "','" + isover + "','" +
                jsfs + "','" + sflb + "','" + zxks + "','" + xmlx + "'";
            arryList.Add(strSql);
        }
        public bool Existes_tj_tjjlb(string tjbh, string tjcs, string tjxmbh)//是否存在该组合项目ID
        {
            string strSql;
            strSql = "select count(1) from tj_tjjlb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and tjxmbh='" + tjxmbh + "'";
            int i = Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
            if (i > 0) 
                return true;
            else
                return false;
        }
        public DataTable Get_tj_dwfz_hd(string dwbh)//分组
        {
            string strSql;
            if (dwbh == "9999")
                //strSql = "select bh,fzmc mc from tj_dwfz_hd where dwbh=''";
                strSql="select bh,mc from tj_tc_hd order by cast(disp_order as int)";//表示个体体检基本套餐信息
            else
                strSql = "select bh,fzmc mc from tj_dwfz_hd where dwbh='" + dwbh.Substring(0, 4) + "'";//表示单位体检分组项目信息
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_dwfz_dt(string fzbh)//分组编号
        {
            string strSql;
            strSql = "select a.tjxm zhxm,b.mc from tj_dwfz_dt a join tj_zhxm_hd b on a.tjxm=b.bh where a.fzbh='" + fzbh + "' order by b.disp_order";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_tj_zhxm_hd(string bh)
        {
            string strSql;
            strSql = "select tjlx,jcjylx,dj,bh,sflb from tj_zhxm_hd where bh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_TJ_TJDJB_XM(string xm,string dwbh)
        {
            string strSql;
            strSql = "select 0 selected,a.djlsh,a.xm,e.xmmc xb,a.nl,a.sfzh,a.tjrq,isnull(c.mc,'个人体检') dwmc,d.mc bmmc,a.tjbh,a.tjcs from tj_tjdjb a join (select xm,tjbh,max(tjcs) as tjcs from tj_tjdjb where xm='"
                + xm + "' and dwbh='"+dwbh+"' group by xm,tjbh) as b on a.xm=b.xm and a.tjbh=b.tjbh and a.tjcs=b.tjcs left join tj_dw c on a.dwbh=c.bh left join tj_dw d on a.bmbh=d.bh join xt_zdxm e on a.xb=e.bzdm where e.zdflbm=1";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_TJDJB_ALL(string all)
        {
            string strSql;
            strSql = "select a.djlsh,a.xm,e.xmmc xb,a.nl,a.sfzh,a.tjrq,isnull(c.mc,'个人体检') dwmc,d.mc bmmc,a.tjbh,a.tjcs from tj_tjdjb a join (select xm,tjbh,max(tjcs) as tjcs from tj_tjdjb where xm='"
                + all + "' or tjbh='" + all + "' or djlsh='" + all + "' group by xm,tjbh) as b on a.xm=b.xm and a.tjbh=b.tjbh and a.tjcs=b.tjcs left join tj_dw c on a.dwbh=c.bh left join tj_dw d on a.bmbh=d.bh join xt_zdxm e on a.xb=e.bzdm where e.zdflbm=1";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_TJDJB_SFZH(string sfzh)
        {
            string strSql;
            strSql = "select 0 selected,a.djlsh,a.xm,e.xmmc xb,a.nl,a.sfzh,a.tjrq,isnull(c.mc,'个人体检') dwmc,c.mc bmmc,a.tjbh,a.tjcs from tj_tjdjb a join (select sfzh,tjbh,max(tjcs) as tjcs from tj_tjdjb where sfzh='"
                + sfzh + "' group by sfzh,tjbh) as b on a.sfzh=b.sfzh and a.tjbh=b.tjbh and a.tjcs=b.tjcs left join tj_dw c on a.dwbh=c.bh left join tj_dw d on a.bmbh=d.bh join xt_zdxm e on a.xb=e.bzdm where e.zdflbm=1";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Get_TJ_TJDJB_SFZH(string sfzh, string year)
        {
            string strSql;
            strSql = "select 0 selected,a.djlsh,a.xm,e.xmmc xb,a.nl,a.sfzh,a.tjrq,isnull(c.mc,'个人体检') dwmc,c.mc bmmc,a.tjbh,a.tjcs from tj_tjdjb a join (select sfzh,tjbh,max(tjcs) as tjcs from tj_tjdjb where sfzh='"
                + sfzh + "' and year(tjrq)='" + year + "' group by sfzh,tjbh) as b on a.sfzh=b.sfzh and a.tjbh=b.tjbh and a.tjcs=b.tjcs left join tj_dw c on a.dwbh=c.bh left join tj_dw d on a.bmbh=d.bh join xt_zdxm e on a.xb=e.bzdm where e.zdflbm=1";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public string Get_proc_get_djlsh(string tjrq,string czy)//根据体检日期，获取登记流水号
        {
            string strSql;
            strSql = "exec proc_get_djlsh '" + tjrq + "','" + czy + "'";
            return base.SqlDBAgent.sqlvalue(strSql).ToString().Trim();
        }
        public DataTable Get_TJ_TC_FZ(string bh)//获取套餐和分组项目信息
        {
            string strSql;
            //strSql = "select bh,fzmc mc from tj_dwfz_hd where dwbh='" + bh + "' union select convert(varchar(10),bh) bh,mc from tj_tc_hd";
            strSql = "select bh,fzmc mc from tj_dwfz_hd where dwbh='" + bh + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int CheckSex(string zhxm,string xb)
        {
            string strSql;
            strSql = "select count(1) from TJ_ZHXM_DT where bh='" + zhxm + "' and tjxm in(select tjxm from TJ_TJXMB where xb='" + xb + "' or xb='%')";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public int Exec_tj_tjdjb_Img(string column, string tjbh, string tjcs, byte[] image)
        {
            string strSql;
            if (column == "picture")
                strSql = "update tj_tjdjb set picture=@image where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            else if (column == "barcode")
                strSql = "update tj_tjdjb set barcode=@image where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            else
                return 0;

            SqlParameter sp_image = new SqlParameter("@image", SqlDbType.Image);
            sp_image.Value = image;

            SqlParameter[] objParameterName = new SqlParameter[] { sp_image };
            return base.SqlDBAgent.sqlupdate(strSql, objParameterName);
        }
        public int GetTjCounts()
        {
            string strSql;
            strSql = "select count(1) from tj_tjdjb";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }

        /// <summary>
        /// 获取操作员id
        /// </summary>
        /// <param name="zjm"></param>
        /// <returns></returns>
        public string GetCzyid(string zjm)
        {
            string sql = "select czyid from xt_czy where czybm='"+zjm+"' or czymc='"+zjm+"'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt.Rows.Count<=0)
            {
                return "";
            }
            return dt.Rows[0][0].ToString().Trim();
        }

        /// <summary>
        /// 根据条件获取体检登记信息
        /// </summary>
        /// <param name="djlsh">登记流水号</param>
        /// <param name="sfzh">身份证号</param>
        /// <param name="from">开始日期</param>
        /// <param name="to">结束日期</param>
        /// <param name="xm">姓名</param>
        /// <param name="dwbh">单位编号</param>
        /// <param name="tjlb">体检类别</param>
        /// <returns></returns>
        public DataTable GetTjdjxxByCondition(string djlsh, string sfzh, string from, string to, string xm, string dwbh, string tjlb)
        {
            sql = new StringBuilder("select '0' x  ,TJLB,XM,XB,SFZH,TJBH,djlsh,tjcs	 from v_tj_tjdjb where lbbh in('01','02','03') and tjrq>='" + from + "' and tjrq<='" + to + "' ");
            if (djlsh!="")
            {
                sql.Append(" and djlsh like '"+djlsh+"%'");
            }
            if (sfzh!="")
            {
                sql.Append(" and sfzh like '"+sfzh+"%'");
            }
            if (xm!="")
            {
                sql.Append(" and xm like '"+xm+"%'");
            }
            if (dwbh!="")
            {
                sql.Append(" and dwbh='"+dwbh+"'");
            }
            sql.Append(" order by tjbh desc");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据体检编号获取体检信息
        /// </summary>
        /// <param name="tjbh"></param>
        /// <returns></returns>
        public DataTable GetTjxxByTjbh(string tjbh)
        {
            sql = new StringBuilder("SELECT TJBH ,SFZH ,XM ,XB ,NL  ,ADDRESS ,PHONE ,TJCS ,DJLSH ,TJRQ,dwbh,csrq csnyr FROM TJ_TJDJB  where tjbh='"+tjbh+"'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public DataTable GetTjdjxx(string dwbh, string from, string to, string xm)
        {
            sql = new StringBuilder("  SELECT  0 as xz,a.TJBH ,a.TJCS ,a.XM ,a.XB,a.NL ,TJRQ ,jktj as tjbz,SFZH ,DJLSH,isnull(jkzbh,'0') jkzbh,isnull(a.gz,'0') gz,b.fzdw,b.fzrq,fzr,hy,hylx,ksxq,jsxq,hjd,xjd,dw,sfbz,b.gz bzgz,a.dwmc,bzhy,sszl,dycs     FROM v_tj_tjdjb a left join tj_jkzmb b on a.tjbh=b.tjbh and  a.tjcs=b.tjcs  where isnull(jktj,0)<>0");
            sql.Append(" and isnull(jktj,'0')='001' and tjrq>='"+from+"' and tjrq<='"+to+"'");
            if (dwbh!="")
            {
                sql.Append(" and dwbh='"+dwbh+"'");
            }
            if (xm!="")
            {
                sql.Append(" and a.xm like '%"+xm+"%'");
            }

            sql.Append(" order by a.tjbh desc");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public DataTable GetTjdjxx_jkzpldy(string dwbh, string from, string to, string xm)
        {
            sql = new StringBuilder("  SELECT  0 selected,a.TJBH ,a.TJCS ,a.XM ,a.XB,a.NL ,isnull(a.gz,'0') gz,b.gz bzgz,a.dwmc,bzhy,sszl,TJRQ ,SFZH ,DJLSH,b.fzdw,b.fzrq,fzr,sfbz,isnull(jkzbh,'0') jkzbh,hy,hylx,ksxq,jsxq,hjd,xjd,dw,jktj as tjbz,dycs    FROM v_tj_tjdjb a   join tj_jkzmb b on a.tjbh=b.tjbh and  a.tjcs=b.tjcs  where isnull(jktj,0)<>0");
            sql.Append(" and isnull(jktj,'0')='001' and tjrq>='" + from + "' and tjrq<='" + to + "'");
            if (dwbh != "")
            {
                sql.Append(" and dwbh='" + dwbh + "'");
            }
            if (xm != "")
            {
                sql.Append(" and a.xm like '%" + xm + "%'");
            }

            sql.Append(" order by a.tjbh desc");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 保存体检费用信息
        /// </summary>
        /// <param name="tjbh">体检编号</param>
        /// <param name="tjcs">体检次数</param>
        /// <param name="tjxmbh">体检项目编号</param>
        /// <param name="jsr">结算人</param>
        /// <param name="jsrq">结算日期</param>
        /// <param name="sjh">收费号</param>
        public void UpdateTjFyxx(Tjjlb tjjl,List<string> sqls)
        {
            sql = new StringBuilder("update tj_tjjlb set CHARGED='1'");
            sql.Append(",jsr='" + tjjl.Jsr + "'");
            sql.Append(",jsrq='"+tjjl.Jsrq+"'");
            sql.Append(",sjh='" + tjjl.Sjh + "'");
            sql.Append("where tjbh='" + tjjl.Tjbh + "' and tjcs='" + tjjl.Tjcs + "' and tjxmbh='" + tjjl.Tjxmbh + "'");
            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 保存体检费用信息
        /// </summary>
        /// <param name="tjjls"></param>
        /// <returns></returns>
        public int SaveTjfyxx(List<Tjjlb> tjjls)
        {
            List<string> sqls = new List<string>();
            for (int i = 0; i < tjjls.Count; i++)
            {
                UpdateTjFyxx(tjjls[i], sqls);
            }

           return base.SqlDBAgent.sqlupdate(sqls);
        }

        /// <summary>
        /// 体检独立收费
        /// </summary>
        /// <returns></returns>
        public int TjSf(string sfh,string tjbh,string tjcs,string sfy,decimal ysje,decimal ssje,int yhlx,decimal yhxx,string ysfh,string beizhu)
        {
            string sql = "";
            sql = "Insert into tj_sfb(sfh,tjbh,tjcs,sfy,ysje,ssje,yhlx,yhxx,ysfh,beizhu) values('" + sfh + "','" + tjbh + "','" + tjcs + "','" + sfy + "','" + ysje + "','" + ssje + "'," + yhlx + ",'" + yhxx + "','" + ysfh + "','"+beizhu+"')";
            return base.SqlDBAgent.sqlupdate(sql);
        }
        /// <summary>
        /// 体检退费更新收费表收费号
        /// </summary>
        /// <returns></returns>
        public int UpdateSfb(string sfh, string tjbh, string tjcs,string ysfh)
        {
            string sql = "";
            sql = "update tj_sfb set ysfh='" + ysfh + "' where sfh='" + sfh+"' and tjbh='"+tjbh +"' and tjcs='"+tjcs+"'";
            return base.SqlDBAgent.sqlupdate(sql);
        }

        /// <summary>
        /// 体检独立退费
        /// </summary>
        /// <returns></returns>
        public int TjTf(string tfdh, string sfy, decimal tfje, string tfyy, string ysfh)
        {
            string sql = "";
            sql = "Insert into tj_tfb(tfdh,tfry,tfje,tfyy,ysfh) values('" + tfdh + "','" + sfy + "','" + tfje + "','" + tfyy + "','" + ysfh + "')";
            return base.SqlDBAgent.sqlupdate(sql);
        }

        /// <summary>
        /// 体检健康证保存
        /// </summary>
        /// <returns></returns>
        public int TjJkzSave(string jkzbh,  string tjbh, string tjcs, string xm, string nl,string xb,string fzdw,string fzrq,string fzr,string hy,string hylx,string ksxq,string jsxq,string hjd,string xjd,string dw,string gz)
        {
            string sql = "";
            sql = "Insert into tj_jkzmb(jkzbh,tjbh,tjcs,xm,nl,xb,fzdw,fzrq,fzr,hy,hylx,ksxq,jsxq,hjd,xjd,dw,gz) values('" + jkzbh + "','" + tjbh + "','" + tjcs + "','" + xm + "','" + nl + "','" + xb + "','" + fzdw + "','" +
                fzrq + "','" + fzr + "','" + hy + "','" + hylx + "','" + ksxq + "','" + jsxq + "','" + hjd + "','" + xjd + "','" + dw + "','" + gz +"')";
            return base.SqlDBAgent.sqlupdate(sql);
        }
        /// <summary>
        /// 体检健康证更新
        /// </summary>
        /// <returns></returns>
        public int TjJkzSaveAs(string jkzbh2,string jkzbh, string tjbh, string tjcs, string xm, string nl, string xb, string fzdw, string fzrq, string fzr, string hy, string hylx, string ksxq, string jsxq, string hjd, string xjd, string dw)
        {
            string sql = "";
            sql = "Update tj_jkzmb set jkzbh='"+jkzbh2 + "',xm='" + xm + "',nl='" + nl + "',xb='" + xb + "',fzrq='" + fzrq + "',hy='" + hy + "',hylx='" + hylx + "',hjd='" + hjd + "',xjd='" +
                xjd + "',dw='" + dw + "' where jkzbh='"+jkzbh+"' and tjbh='"+tjbh+"' and tjcs='"+tjcs+"'";
            return base.SqlDBAgent.sqlupdate(sql);
        }

        /// <summary>
        /// 体检收费查询
        /// </summary>
        /// <returns></returns>
        public int TjSfCx(string tjbh, string tjcs)
        {
            string sql = "";
            sql = "select isnull(count(*),0) sl from tj_sfb where tjbh='" + tjbh + "' and tjcs='" + tjcs + "' and  sfh not in (select ysfh from tj_tfb) and ysje>0";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(sql));
        }

        /// <summary>
        /// 待办证人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_TJ_Bzryxx(string djh, string xm, string sfbz, string beizhu)
        {
            string strSql;
            if (sfbz == "1")  //已收费
            {
                strSql = "select djlsh djlsh_bz,xm xm_bz,xb xb_bz,nl nl_bz,tjrq tjrq_bz,djrq djrq_bz,a.tjbh tjbh_bz,a.tjcs tjcs_bz,dwmc dwmc_bz,bmmc bmmc_bz,sumover sumover_bz,isnull(b.sfh,0) sfh_bz from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where isnull(b.sfh,0)>0  and (djlsh='" + djh + "' or a.tjbh='" + djh + "' or 1=1) and (xm like'%" + xm + "%' or 1=1) and isnull(b.sfh,0)=isnull(b.ysfh,0) and sumover=2   order by djlsh asc";
            }
            else             //未收费
            {
                strSql = "select djlsh djlsh_bz,xm xm_bz,xb xb_bz,nl nl_bz,tjrq tjrq_bz,djrq djrq_bz,a.tjbh tjbh_bz,a.tjcs tjcs_bz,dwmc dwmc_bz,bmmc bmmc_bz,sumover sumover_bz,isnull(b.sfh,0) sfh_bz from v_tj_tjdjb a left join tj_sfb b on a.tjbh=b.tjbh and a.tjcs=b.tjcs where isnull(b.sfh,0)=0  and (djlsh='" + djh + "' or a.tjbh='" + djh + "' or 1=1) and (xm like'%" + xm + "%' or 1=1) and isnull(b.sfh,0)=isnull(b.ysfh,0) and sumover=2  order by djlsh asc";
            }
            return base.SqlDBAgent.GetDataTable(strSql);
        }


        /// <summary>
        /// 体检办证打印查询
        /// </summary>
        /// <returns></returns>
        public DataTable TjJkzbb(string jkzbh,string tjbh, string tjcs)
        {
            string sql = "";
            sql = "select jkzbh,a.xm,a.xb,a.nl,a.gz,case c.jktj when '001' then '合格' when '002' then '不合格' when '003' then '缺项' when '004' then '复查' when '005' then '已复查' else '' end jktj,a.fzrq,a.fzdw,a.dw,czymc as fzr,picture from tj_jkzmb a " +
                    "left join tj_tjdjb c on a.tjbh=c.tjbh and a.tjcs=c.tjcs "+
                    "left join xt_czy d on a.fzr=d.czyid "+
                    "where jkzbh='"+jkzbh+"' and a.tjbh='"+tjbh+"' and a.tjcs='"+tjcs+"'";
            return base.SqlDBAgent.GetDataTable(sql);
        }

        /// <summary>
        /// 体检健康证打印次数保存
        /// </summary>
        /// <returns></returns>
        public int TjJkzDycsSave(string jkzbh,string tjbh,string tjcs,int dycs)
        {
            string sql = "";
            sql = "update tj_jkzmb set dycs=dycs+" + dycs + " where jkzbh='" + jkzbh + "' and tjbh='" + tjbh + "' and tjcs='" + tjcs + "'";
            return base.SqlDBAgent.sqlupdate(sql);
        }

        /// <summary>
        /// 根据身份证计算年龄
        /// </summary>
        /// <returns></returns>
        public int GetNl(string sfzh)
        {
            string sql = "";
            if (sfzh.Length == 18)
            {
                sql = "select datediff(day,substring('" + sfzh + "',7,8),getdate())/365";
            }
            else if (sfzh.Length == 15) //15
            {
                sql = "select datediff(day,'19'+substring('" + sfzh + "',7,6),getdate())/365";
            }
            else//出生日期
            {
                sql = "select datediff(day,'" + sfzh + "',getdate())/365";
            }
            return Convert.ToInt16(base.SqlDBAgent.sqlvalue(sql));
        }

        /// <summary>
        /// 获取x线号，如果身份证已经产出了x线号，则返回改身份证号对应的x线号，如果没有产生过，则新生成一个
        /// </summary>
        /// <param name="sfzh">身份证号</param>
        /// <param name="isGfq">是否是高仟伏</param>
        /// <returns>x线号</returns>
        public string Get_New_Xxh(string sfzh,bool isGfq)
        {
            string sql = "select Max(xxhnum) from tj_tj_xxh";
            string str_max = base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim();
            str_max = "".Equals(str_max) ? "0" : str_max;
            long max = long.Parse(str_max);
            max++;
            if (isGfq)
                return "GX"+max.ToString().PadLeft(6, '0');
            return "X" + max.ToString().PadLeft(6, '0');
        }

        public string Get_Xxh(string sfzh,string tjbh)
        {
            string sql = "select xxh from tj_tj_xxh where sfzh='" + sfzh + "' or tjbh = '"+tjbh+"'";
            DataTable dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt.Rows.Count <= 0)
            {
                return "";
            }
            return dt.Rows[0][0].ToString().Trim();
        }

        private string ChangeXxhType(string xxh,bool isGqf)
        {
            xxh = xxh.Replace("GX","");
            xxh =xxh.Replace("X","");
            if (isGqf)
                return "GX"+ xxh;
            return "X" + xxh;

        }

        public void saveXxh(string tjbh,string sfzh,bool isGfq)
        {
            string xxh;
            string sql;
            long max=0;

            if (ExistXxhByTjbh(tjbh))
            {
                xxh = Get_Xxh(sfzh, "");
                xxh = ChangeXxhType(xxh, isGfq);

                string sql1 = "update tj_tj_xxh set xxh='"+xxh+"' where tjbh='"+tjbh+"'";
                base.SqlDBAgent.sqlupdate(sql1);
                return;
            }

            if (Exist_Xxh(sfzh))
            {
                xxh = Get_Xxh(sfzh,"");
                xxh = ChangeXxhType(xxh,isGfq);

                string sql1 = "select xxhnum from tj_tj_xxh where sfzh='"+sfzh+"'";
                string str_max =base.SqlDBAgent.GetDataTable(sql1).Rows[0][0].ToString().Trim() ;
                max = long.Parse(str_max);
                //如果存在相同体检编号的，则先删除
            }
            else
            {
                xxh = Get_New_Xxh(sfzh,isGfq);
                
                string sql1 = "select Max(xxhnum) from tj_tj_xxh";
                string str_max = base.SqlDBAgent.GetDataTable(sql1).Rows[0][0].ToString().Trim();
                str_max = "".Equals(str_max) ? "0" : str_max;
                max = long.Parse(str_max);
                max++;
            }

            sql = "insert tj_tj_xxh(sfzh,xxh,tjbh,xxhnum) values('" + sfzh + "','" + xxh + "','" + tjbh + "'," + max + ")";
            base.SqlDBAgent.sqlupdate(sql);
        }

        public bool Exist_Xxh(string sfzh)
        {
            string strSql;
            strSql = "select count(1) from tj_tj_xxh where sfzh='"+sfzh+ "'";
            int i = Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
            if (i > 0)
                return true;
            else
                return false;
            
        }

        public bool ExistXxhByTjbh(string tjbh)
        {
            string strSql;
            strSql = "select count(1) from tj_tj_xxh where tjbh='" + tjbh + "'";
            int i = Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
            if (i > 0)
                return true;
            else
                return false;
        }

        public bool IsNeedGfq(string zhxm)
        {
            string sql = "SELECT count(*) from TJ_ZHXM_DT a join TJ_TJXMB b on a.TJXM=b.TJXM WHERE (b.MC='高纤伏胸片' or b.MC='高仟伏胸片') and a.bh='"+zhxm+"'";
            string st = base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim();
            if (!"0".Equals(base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim()))
                return true;
            return false;
        }

        public bool NeedXhh(string zhxm)
        {
            string sql = "SELECT count(*) from TJ_ZHXM_DT a join TJ_TJXMB b on a.TJXM=b.TJXM WHERE a.bh='" + zhxm + "' and (tjlx='07' or tjlx='59')";
            string st = base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim();
            if (!"0".Equals(base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim()))
                return true;
            return false;
        }

        public void DeleteXxhByTjbh(string tjbh)
        {
            string sql = "DELETE FROM tj_tj_xxh where tjbh = '"+tjbh+"'";
            base.SqlDBAgent.sqlupdate(sql);
        }

        //更改体检登记表已打印指引单状态
        public void UpdatePrintZYD(string tjbh)
        {
            string sqlStr = "update tj_tjdjb set PrintZYD=1 where tjbh = '" + tjbh + "'";
            base.SqlDBAgent.sqlupdate(sqlStr);
        }
    }
}