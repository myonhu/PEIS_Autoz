using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PEIS.zybtj
{
    /// <summary>
    /// 职业健康档案
    /// </summary>
    class ZyjkdaBiz:Base
    {
        private StringBuilder sql;

        /// <summary>
        /// 获取体检类别
        /// </summary>
        /// <returns></returns>
        public DataTable GetTjlb()
        {
            sql = new StringBuilder("select '0' as bh,'全部' as mc union select bh,mc from TJ_TJLB");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取体检单位
        /// </summary>
        /// <returns></returns>
        public DataTable GetTjdw()
        {
            //sql = new StringBuilder("select '0' as bh,'全部' as mc union select bh,mc from TJ_dw where len(bh)<5");
            sql = new StringBuilder("select bh,mc from TJ_dw where len(bh)<5 and qybz=1");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据单位编号获取单位名称
        /// </summary>
        /// <param name="bh"></param>
        /// <returns></returns>
        public string GetDwmcByDwbh(string bh)
        {
            sql = new StringBuilder("select mc from TJ_dw where bh='"+bh+"'");
            DataTable dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            if (dt.Rows.Count<=0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0][0].ToString().Trim();
            }

            //return
        }

        /// <summary>
        /// 获取症状列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetZzList(int type)
        {
            sql = new StringBuilder("select zzbh,zzmc from TJ_ZYB_ZZList where type="+type);
            sql.Append("order by zzbh");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取民族
        /// </summary>
        /// <returns></returns>
        public DataTable GetMz()
        {
            sql = new StringBuilder("  SELECT  TJ_DMB_MZ.SZCode ,           TJ_DMB_MZ.ZMCode ,           TJ_DMB_MZ.MZMC     FROM TJ_DMB_MZ    ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取出生地
        /// </summary>
        /// <returns></returns>
        public DataTable GetCsd()
        {
            sql = new StringBuilder("  SELECT  TJ_DMB_DQ.Code ,           TJ_DMB_DQ.MingCheng ,           TJ_DMB_DQ.ZiMu     FROM TJ_DMB_DQ    ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取工种
        /// </summary>
        /// <returns></returns>
        public DataTable GetGz()
        {
            sql = new StringBuilder("  SELECT  TJ_ZYB_GZ.BH ,           TJ_ZYB_GZ.MC     FROM TJ_ZYB_GZ    ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取毒害名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDhmc()
        {
            sql = new StringBuilder("  SELECT  TJ_ZYB_YHYS.BH ,           TJ_ZYB_YHYS.MC     FROM TJ_ZYB_YHYS    ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取行业
        /// </summary>
        /// <returns></returns>
        public DataTable GetHy()
        {
            sql = new StringBuilder("  SELECT  TJ_ZYB_HY.BH ,           TJ_ZYB_HY.MC     FROM TJ_ZYB_HY    ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取病名
        /// </summary>
        /// <returns></returns>
        public DataTable GetBm()
        {
            sql = new StringBuilder("  SELECT  TJ_ZYB_BM.BH ,           TJ_ZYB_BM.MC     FROM TJ_ZYB_BM    ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取诊断标准
        /// </summary>
        /// <returns></returns>
        public DataTable GetZdbz()
        {
            sql = new StringBuilder("  SELECT  TJ_ZYB_ZDBZ.BH ,           TJ_ZYB_ZDBZ.MC     FROM TJ_ZYB_ZDBZ   ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取有害因素
        /// </summary>
        /// <returns></returns>
        public DataTable GetYhys()
        {
            sql = new StringBuilder("select bh,mc from TJ_ZYB_YHYS");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取防护措施
        /// </summary>
        /// <returns></returns>
        public DataTable GetFhcs()
        {
            sql = new StringBuilder("  SELECT  TJ_ZYB_FHCS.BH ,           TJ_ZYB_FHCS.MC     FROM TJ_ZYB_FHCS    ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取性别
        /// </summary>
        /// <returns></returns>
        public DataTable GetXb()
        {
            sql = new StringBuilder("select bzdm,xmmc from xt_zdxm where zdflbm='1'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取医生
        /// </summary>
        /// <returns></returns>
        public DataTable GetYs()
        {
            sql = new StringBuilder("select czyid,czymc from xt_czy where tybz=0 and rysx='医生'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取非职业病的行业
        /// </summary>
        /// <returns></returns>
        public DataTable GetFzybHy()
        {
            sql = new StringBuilder("  SELECT TJ_FWHY.BH,              TJ_FWHY.MC,              TJ_FWHY.YQRQ,              TJ_FWHY.BZ,              TJ_FWHY.ZHXGRQ,              TJ_FWHY.ZHXGR        FROM TJ_FWHY     ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }


        /// <summary>
        /// 获取分组套餐
        /// </summary>
        /// <returns></returns>
        public DataTable GetFztc()
        {
            sql = new StringBuilder(" select bh,mc from tj_dw where len(bh)=4 and qybz=1 order by bh desc  ");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取职业处理意见
        /// </summary>
        /// <returns></returns>
        public DataTable GetZybZdyj()
        {
            sql = new StringBuilder("select xh,xmmc,bzdm from xt_zdxm where zdflbm='25'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取职业处理意见
        /// </summary>
        /// <returns></returns>
        public DataTable GetZybZdyj(string nr)
        {
            sql = new StringBuilder("select xh,xmmc,bzdm from xt_zdxm where zdflbm='25' and xmmc like'%" + nr + "%'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }
    }
}
