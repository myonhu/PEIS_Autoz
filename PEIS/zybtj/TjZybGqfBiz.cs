using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PEIS.zybtj
{
    class TjZybGqfBiz : Base
    {

        public string GetXxh(string tjbh)
        {
            string sql = "select xxh from tj_tj_xxh where tjbh='"+tjbh+"'";
            return base.SqlDBAgent.GetDataTable(sql).Rows[0][0].ToString().Trim();
        }

        public DataTable GetGqf(string tjbh)
        {
            string sql = "select ph,xyy_xt,xyy_bbfwy,xyy_bbfwz,xyyjj,dyy_xyysf,dyy_dyysf,bw,xbm,mmzh,xmgh,xypl,fjfh,zd,sm,jg"+
                " from tj_zyb_gqf where tjbh = '" + tjbh + "'";
            return base.SqlDBAgent.GetDataTable(sql);
        }

        public bool HasExist(string tjbh)
        {
            string sql = "select count(*) from tj_zyb_gqf where tjbh='"+tjbh+"'";
            DataTable dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            if (dt.Rows.Count <= 0)
            {
                return false;//不存在
            }
            string count = dt.Rows[0][0].ToString().Trim();
            if (Convert.ToDecimal(count) > 0)
            {
                return true;//存在
            }
            else
            {
                return false;
            }
        }

        public void Update(TjZybGqf gqf, List<string> sqls)
        {
            StringBuilder sql = new StringBuilder("update tj_zyb_gqf set ph='"+gqf.ph+"',");
            sql.Append("xyy_xt='"+gqf.xyy_xt+"',");
            sql.Append("xyy_bbfwy='"+gqf.xyy_bbfwy+"',");
            sql.Append("xyy_bbfwz='"+gqf.xyy_bbfwz+"',");
            sql.Append("xyyjj='"+gqf.xyyjj+"',");
            sql.Append("dyy_xyysf='"+gqf.dyy_xyysf+"',");
            sql.Append("dyy_dyysf='"+gqf.dyy_dyysf+"',");
            sql.Append("bw='"+gqf.bw+"',");
            sql.Append("xbm='"+gqf.xbm+"',");
            sql.Append("mmzh='"+gqf.mmzh+"',");
            sql.Append("xmgh='"+gqf.xmgh+"',");
            sql.Append("xypl='"+gqf.xypl+"',");
            sql.Append("fjfh='"+gqf.fjfh+"',");
            sql.Append("zd='"+gqf.zd+"',");
            sql.Append("jg='"+gqf.jg+"'");
            sql.Append(" where tjbh='" + gqf.tjbh + "'");

            sqls.Add(sql.ToString());
        }

        public void Insert(TjZybGqf gqf, List<string> sqls)
        {
            StringBuilder sql = new StringBuilder("insert into tj_zyb_gqf(TJBH,ph,xyy_xt,xyy_bbfwy,xyy_bbfwz,xyyjj,dyy_xyysf,dyy_dyysf,"+
                "bw,xbm,mmzh,xmgh,xypl,fjfh,zd,sm,jg) values('");
            sql.Append(gqf.tjbh+"','");
            sql.Append(gqf.ph + "','");
            sql.Append(gqf.xyy_xt + "','");
            sql.Append(gqf.xyy_bbfwy + "','");
            sql.Append(gqf.xyy_bbfwz + "','");
            sql.Append(gqf.xyyjj + "','");
            sql.Append(gqf.dyy_xyysf + "','");
            sql.Append(gqf.dyy_dyysf + "','");
            sql.Append(gqf.bw + "','");
            sql.Append(gqf.xbm + "','");
            sql.Append(gqf.mmzh + "','");
            sql.Append(gqf.xmgh + "','");
            sql.Append(gqf.xypl + "','");
            sql.Append(gqf.fjfh + "','");
            sql.Append(gqf.zd + "','");
            sql.Append(gqf.sm + "','");
            sql.Append(gqf.jg + "')");
            sqls.Add(sql.ToString());
        }
    }
}
