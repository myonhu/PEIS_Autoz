using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PEIS.zybtj
{
    class TjZybRyxxBiz:Base
    {
        private StringBuilder sql;

        /// <summary>
        /// 插入职业病人员信息
        /// </summary>
        /// <param name="ryxx"></param>
        /// <param name="sqls"></param>
        public void InsertRyxx(TjZybRyxx ryxx, List<string> sqls)
        {
            sql = new StringBuilder("insert into TJ_ZYB_RYXX(TJBH,TJCS,XM,XB,mz,SFZH,CSNYR,csd,DW,DWDH,dwdz,gz,GH,BH,zgl,jsgl,ygzdwjgz,zybwhjcs,TBRQ,LX,dhqk,hy,jtbs,JWS,BM,ZDRQ,ZDDW,SFQY,CCNL,JQ,ZQ,TJNL,XYZN,"
                + "LCCS,ZCCS,SCCS,YCTC,SFXY,xysl,XYNS,SFYJ,YJSL,YJSJ,wjh,zyjcs,lcbx,xysjcjg,zdbz,zdjl,clyj,QT) values('");
            sql.Append(ryxx.Tjbh + "','");
            sql.Append(ryxx.Tjcs + "','");
            sql.Append(ryxx.Xm + "','");
            sql.Append(ryxx.Xb + "','");
            sql.Append(ryxx.Mz + "','");
            sql.Append(ryxx.Sfzh + "','");
            sql.Append(ryxx.Csnyr + "','");
            sql.Append(ryxx.Csd + "','");
            sql.Append(ryxx.Dw + "','");
            sql.Append(ryxx.Dwdh + "','");
            sql.Append(ryxx.Dwdz + "','");
            sql.Append(ryxx.Gz + "','");
            sql.Append(ryxx.Gh + "','");
            sql.Append(ryxx.Bh + "','");
            sql.Append(ryxx.Zgl + "','");
            sql.Append(ryxx.Jsgl + "','");
            sql.Append(ryxx.Ygzdwjgz + "','");
            sql.Append(ryxx.Zybwhjcs + "','");
            sql.Append(ryxx.Tbrq + "','");
            sql.Append(ryxx.Lx + "','");
            sql.Append(ryxx.Dhqk + "','");
            sql.Append(ryxx.Hy + "','");
            sql.Append(ryxx.Jtbs + "','");
            sql.Append(ryxx.Jws + "','");
            sql.Append(ryxx.Bm + "','");
            sql.Append(ryxx.Zdrq + "','");
            sql.Append(ryxx.Zddw + "','");
            sql.Append(ryxx.Sfqy + "','");
            sql.Append(ryxx.Ccnl + "','");
            sql.Append(ryxx.Jq + "','");
            sql.Append(ryxx.Zq + "','");
            sql.Append(ryxx.Tjnl + "','");
            sql.Append(ryxx.Xyzn + "','");
            sql.Append(ryxx.Lccs + "','");
            sql.Append(ryxx.Zccs + "','");
            sql.Append(ryxx.Sccs + "','");
            sql.Append(ryxx.Yctc + "','");
            sql.Append(ryxx.Sfxy + "','");
            sql.Append(ryxx.Xysl + "','");
            sql.Append(ryxx.Xyns + "','");
            sql.Append(ryxx.Sfyj + "','");
            sql.Append(ryxx.Yjsl + "','");
            sql.Append(ryxx.Yjsj + "','");
            //wjh,zyjcs,lcbx,xysjcjg,zdbz,zdjl,clyj
            sql.Append(ryxx.Wjh + "','");
            sql.Append(ryxx.Zyjcs + "','");
            sql.Append(ryxx.Lcbx + "','");
            sql.Append(ryxx.Xysjcjg + "','");
            sql.Append(ryxx.Zdbz + "','");
            sql.Append(ryxx.Zdjl + "','");
            sql.Append(ryxx.Clyj + "','");
            sql.Append(ryxx.Qt + "')");

            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 更新职业病人员信息
        /// </summary>
        /// <param name="ryxx"></param>
        /// <param name="sqls"></param>
        public void Update(TjZybRyxx ryxx, List<string> sqls)
        {
            sql = new StringBuilder("update TJ_ZYB_RYXX set xm='"+ryxx.Xm+"'");
            //TJBH,TJCS,
            //,,,,,,,,,,,,,,,,,,,
           
            sql.Append(",xb='" + ryxx.Xb + "'");
            sql.Append(",mz='" + ryxx.Mz + "'");
            //sql.Append(",SFZH='" + ryxx.Sfzh + "'");
            sql.Append(",CSNYR='" + ryxx.Csnyr + "'");
            sql.Append(",csd='" + ryxx.Csd + "'");
            sql.Append(",DW='" + ryxx.Dw + "'");
            sql.Append(",DWDH='" + ryxx.Dwdh + "'");
            sql.Append(",dwdz='" + ryxx.Dwdz + "'");
            sql.Append(",gz='" + ryxx.Gz + "'");
            sql.Append(",GH='" + ryxx.Gh + "'");
            sql.Append(",BH='" + ryxx.Bh + "'");
            sql.Append(",zgl='" + ryxx.Zgl + "'");
            sql.Append(",jsgl='" + ryxx.Jsgl + "'");
            sql.Append(",ygzdwjgz='" + ryxx.Ygzdwjgz + "'");
            sql.Append(",zybwhjcs='" + ryxx.Zybwhjcs + "'");
            sql.Append(",TBRQ='" + ryxx.Tbrq + "'");
            sql.Append(",LX='" + ryxx.Lx + "'");
            sql.Append(",dhqk='" + ryxx.Dhqk + "'");
            sql.Append(",jtbs='" + ryxx.Jtbs + "'");
            sql.Append(",JWS='" + ryxx.Jws + "'");
            sql.Append(",LCCS='" + ryxx.Lccs + "'");
            sql.Append(",ZCCS='" + ryxx.Zccs + "'");
            sql.Append(",SCCS='" + ryxx.Sccs + "'");
            //,,,,,,,,,,,,,,,,,,,,
            sql.Append(",YCTC='" + ryxx.Yctc + "'");
            sql.Append(",SFXY='" + ryxx.Sfxy + "'");
            sql.Append(",xysl='" + ryxx.Xysl + "'");
            sql.Append(",XYNS='" + ryxx.Xyns + "'");
            sql.Append(",SFYJ='" + ryxx.Sfyj + "'");
            sql.Append(",YJSL='" + ryxx.Yjsl + "'");
            sql.Append(",YJSJ='" + ryxx.Yjsj + "'");
            sql.Append(",QT='" + ryxx.Qt + "'");
            sql.Append(",BM='" + ryxx.Bm + "'");
            sql.Append(",ZDRQ='" + ryxx.Zdrq + "'");
            sql.Append(",ZDDW='" + ryxx.Zddw + "'");
            sql.Append(",SFQY='" + ryxx.Sfqy + "'");
            sql.Append(",CCNL='" + ryxx.Ccnl + "'");
            sql.Append(",JQ='" + ryxx.Jq + "'");
            sql.Append(",ZQ='" + ryxx.Zq + "'");
            sql.Append(",TJNL='" + ryxx.Tjnl + "'");
            sql.Append(",XYZN='" + ryxx.Xyzn + "'");
            //,,,,,,
            //sql.Append(",hy='" + ryxx.Hy + "'");
            sql.Append(",wjh='" + ryxx.Wjh + "'");
            sql.Append(",zyjcs='" + ryxx.Zyjcs + "'");
            sql.Append(",lcbx='" + ryxx.Lcbx + "'");
            sql.Append(",xysjcjg='" + ryxx.Xysjcjg + "'");
            sql.Append(",zdbz='" + ryxx.Zdbz + "'");
            sql.Append(",zdjl='" + ryxx.Zdjl + "'");
            sql.Append(",clyj='" + ryxx.Clyj + "'");

            sql.Append(" where tjbh='"+ryxx.Tjbh+"' and tjcs='"+ryxx.Tjcs+"'");

            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 根据体检编号和体检次数获取职业病人员信息
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetTjZybRyxxByTjbhAndTjcs(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select TJBH,TJCS,XM,XB,mz,SFZH,CSNYR,csd,DW,DWDH,dwdz,gz,GH,BH,zgl,jsgl,ygzdwjgz,zybwhjcs,TBRQ,LX,dhqk,hy,jtbs,JWS,BM,ZDRQ,ZDDW,SFQY,CCNL,JQ,ZQ,TJNL,XYZN,"
                 + "LCCS,ZCCS,SCCS,YCTC,SFXY,xysl,XYNS,SFYJ,YJSL,YJSJ,QT,wjh,zyjcs,lcbx,xysjcjg,zdbz,zdjl,clyj from TJ_ZYB_RYXX where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据体检编号、体检次数判断是否已存在记录
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public bool HasExist(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select count(*) from TJ_ZYB_RYXX where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'");

            DataTable dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            if (dt.Rows.Count<=0)
            {
                return false;//不存在
            }
            string count=dt.Rows[0][0].ToString().Trim();
            if (Convert.ToDecimal(count)>0)
            {
                return true;//存在
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存健康档案
        /// </summary>
        /// <param name="ryxx">人员信息</param>
        /// <param name="sqls"></param>
        /// <returns></returns>
        public int SaveJkda(TjZybRyxx ryxx,TjZybZz zz,TjGyzz gyzz,TjZybGqf gqf)
        {
            List<string> sqls = sqls = new List<string>();
            if (HasExist(ryxx.Tjbh,ryxx.Tjcs))
            {
                Update(ryxx, sqls);
            }
            else
            {
                InsertRyxx(ryxx, sqls);
            }
            TjZybZzBiz zzBiz = new TjZybZzBiz();
            if (zzBiz.HasExist(zz.tjbh,zz.tjcs))
            {
                zzBiz.Update(zz, sqls);
            }
            else
            {
                zzBiz.Insert(zz, sqls);
            }
            TjGyzzBiz gyzzBiz = new TjGyzzBiz();
            gyzzBiz.Delete(gyzz.tjbh, gyzz.tjcs,sqls);
            gyzzBiz.Insert(gyzz, sqls);

            TjZybGqfBiz gqfBiz = new TjZybGqfBiz();
            if (gqfBiz.HasExist(gqf.tjbh))
            {
                gqfBiz.Update(gqf, sqls);
            }
            else
            {
                gqfBiz.Insert(gqf, sqls);
            }

            return base.SqlDBAgent.sqlupdate(sqls);
        }

        public int SaveJkda_zz(TjZybZz zz)
        {
            List<string> sqls = sqls = new List<string>();
          
            TjZybZzBiz zzBiz = new TjZybZzBiz();
            if (zzBiz.HasExist(zz.tjbh, zz.tjcs))
            {
                zzBiz.Update(zz, sqls);
            }
            else
            {
                zzBiz.Insert(zz, sqls);
            }
           
            return base.SqlDBAgent.sqlupdate(sqls);
        }
    }
}
