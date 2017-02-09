using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PEIS.zybtj
{
    class TjZybZysBiz:Base
    {
        private StringBuilder sql;

        /// <summary>
        /// 插入职业史
        /// </summary>
        /// <param name="zys"></param>
        /// <param name="sqls"></param>
        public int Insert(TjZybZys zys)
        {
            sql = new StringBuilder("insert into TJ_ZYB_ZYS(TJBH,QSRQ,ZZRQ,GZDW,CJ,GZ,YHYS,FHCS) values('");
            sql.Append(zys.Tjbh + "','");
            sql.Append(zys.Qsrq + "','");
            sql.Append(zys.Zzrq + "','");
            sql.Append(zys.Gzdw + "','");
            sql.Append(zys.Cj + "','");
            sql.Append(zys.Gz + "','");
            sql.Append(zys.Yhys + "','");
            sql.Append(zys.Fhcs + "')");

            return base.SqlDBAgent.sqlupdate(sql.ToString());
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="tjbh"></param>
        /// <returns></returns>
        public int Delete(string zysid)
        {
            sql = new StringBuilder("delete from TJ_ZYB_ZYS where zysid='"+zysid+"'");

            return base.SqlDBAgent.sqlupdate(sql.ToString());
        }

        /// <summary>
        /// 获取职业史
        /// </summary>
        /// <param name="tjbh"></param>
        /// <returns></returns>
        public DataTable GetZys(string tjbh)
        {
            sql = new StringBuilder("select zysid,tjbh,convert(varchar(10),qsrq,120) qsrq,convert(varchar(10),zzrq,120) zzrq,gzdw,cj,gz,yhys,fhcs from v_zyb_zys where tjbh='" + tjbh + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }
    }
}
