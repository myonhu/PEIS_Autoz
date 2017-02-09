using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PEIS.cxbb
{
    class Gztjb:Base
    {
        private StringBuilder sql;

        public DataTable GetHzb()
        {
            sql = new StringBuilder("select xm,dws,rs,fcrs,jccwy,gyzcry,wwdws,wwrs,jkrs,rcs from v_gztjb");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取路内单位数-职业健康检查
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetDws(string from, string to)
        {
            sql = new StringBuilder("select distinct dwbh from v_tj_tjdjb where lx='路内' and lbbh='01' and dwbh<>'9999'");
            sql.Append(" and tjrq>'"+from+"' and tjrq<='"+to+"'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 获取路内体检人数-职业健康检查
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetRs(string from, string to)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路内' and lbbh='01' and dwbh<>'9999'");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 获取复查人数-职业健康体检
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetFcrs(string from, string to)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路内' and lbbh='01' and dwbh<>'9999' and fcgy is not null");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 获取机车乘务员人数
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetJccwy(string from, string to)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路内' and lbbh='03' and dwbh<>'9999'");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 获取高原值乘人员数量
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetGyzcry(string from, string to)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路内' and lbbh='02' and dwbh<>'9999'");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 获取路外单位数
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetLwDws(string from, string to)
        {
            sql = new StringBuilder("select distinct dwbh from v_tj_tjdjb where lx='路外'  and dwbh<>'9999'");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 获取路外体检人数
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetLwRs(string from, string to)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路外' and dwbh<>'9999'");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 按危害因素类别获取人数
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="lb"></param>
        /// <returns></returns>
        public int GetRs(string from, string to, int lb,bool fc)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路内' and lbbh='01' and dwbh<>'9999' and lb='"+lb+"'");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");
            if (fc)//查询复查人数
            {
                sql.Append(" and fcgy is not null");
            }
            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 按危害因素查询人数
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="whys"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        public int GetRs(string from, string to, string whys, bool fc)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路内' and lbbh='01' and dwbh<>'9999' and whysmc='" + whys + "'");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");
            if (fc)//查询复查人数
            {
                sql.Append(" and fcgy is not null");
            }
            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 获取人次数
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="whys"></param>
        /// <returns></returns>
        public int GetRcs(string from, string to, string whys)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路内' and lbbh='01' and dwbh<>'9999' and whysmc like'%" + whys + "%'");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 获取健康人数
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetJkrs(string from, string to)
        {
            sql = new StringBuilder("select djlsh from v_tj_tjdjb where lx='路内'  and dwbh<>'9999' and (zs like '%各项结果未见明显异常%' or zs like '%所查项目%'or zs like '%各项结果未见异常%')");
            sql.Append(" and tjrq>'" + from + "' and tjrq<='" + to + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString()).Rows.Count;
        }

        /// <summary>
        /// 工作统计表
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetGztjb(string from, string to)
        {
            DataTable dtHzb = new DataTable();
            dtHzb = GetHzb();
            dtHzb.Rows.Clear();
            //,,,,,,,
            DataRow row = dtHzb.NewRow();
            row["xm"] = "总计";
            row["dws"] = GetDws(from, to).ToString();
            row["rs"] = GetRs(from, to).ToString();//重新修改
            row["rcs"] = "";
            row["fcrs"] = GetFcrs(from, to).ToString();
            row["jccwy"] = GetJccwy(from, to).ToString();
            row["gyzcry"] = GetGyzcry(from, to).ToString();
            row["wwdws"] = GetLwDws(from, to).ToString();
            row["wwrs"] = GetLwRs(from, to).ToString();
            row["jkrs"] = GetJkrs(from, to).ToString();
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "一、粉尘合计";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, 1, false).ToString();
            row["rcs"] = GetRs(from, to, 1, false).ToString();
            row["fcrs"] = GetRs(from, to,1,true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] ="/";
            row["wwdws"] = "/";
            row["wwrs"] ="/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "1、矽尘";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "矽尘", false).ToString();
            row["rcs"] = GetRcs(from, to, "矽尘").ToString();
            row["fcrs"] = GetRs(from, to, "矽尘", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "2、其他";
            row["dws"] = "/";
            row["rs"] = (GetRs(from, to, 1, false) - GetRs(from, to, "矽尘", false)).ToString();
            row["rcs"] = (GetRs(from, to, 1, false) - GetRcs(from, to, "矽尘")).ToString();
            row["fcrs"] = (GetRs(from, to, 1, true) - GetRs(from, to, "矽尘", true)).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "二、毒物合计";
            row["dws"] = "/";
            row["rs"] = (GetRs(from, to, 2, false) + GetRs(from, to, 3, false) + GetRs(from, to, 4, false) + GetRs(from, to, 5, false)).ToString();
            row["rcs"] = (GetRs(from, to, 2, false) + GetRs(from, to, 3, false) + GetRs(from, to, 4, false) + GetRs(from, to, 5, false)).ToString();
            row["fcrs"] = (GetRs(from, to, 2, true) + GetRs(from, to, 3, true) + GetRs(from, to, 4, true) + GetRs(from, to, 5, true)).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "1级毒物合计";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, 2, false).ToString();
            row["rcs"] = GetRs(from, to, 2, false).ToString();
            row["fcrs"] = GetRs(from, to, 2, true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "①苯";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "苯", false).ToString();
            row["rcs"] = GetRcs(from, to, "苯").ToString();
            row["fcrs"] = GetRs(from, to, "苯", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "②锰";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "锰", false).ToString();
            row["rcs"] = GetRcs(from, to, "锰").ToString();
            row["fcrs"] = GetRs(from, to, "锰", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "③其他";
            row["dws"] = "/";
            row["rs"] = (GetRs(from, to, 2, false) - GetRs(from, to, "苯", false) - GetRs(from, to, "锰", false)).ToString();
            row["rcs"] = (GetRs(from, to, 2, false) - GetRcs(from, to, "苯") - GetRcs(from, to, "锰")).ToString();
            row["fcrs"] = (GetRs(from, to, 2, true) - GetRs(from, to, "苯", true) - GetRs(from, to, "锰", true)).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "2级毒物合计";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, 3, false).ToString();
            row["rcs"] = GetRs(from, to, 3, false).ToString();
            row["fcrs"] = GetRs(from, to, 3, true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "①铅";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "铅", false).ToString();
            row["rcs"] = GetRcs(from, to, "铅").ToString();
            row["fcrs"] = GetRs(from, to, "铅", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "②其他";
            row["dws"] = "/";
            row["rs"] = (GetRs(from, to, 3, false) - GetRs(from, to, "铅", false)).ToString();
            row["rcs"] = (GetRs(from, to, 3, false) - GetRcs(from, to, "铅")).ToString();
            row["fcrs"] = (GetRs(from, to, 3, false) - GetRs(from, to, "铅", false)).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "3级毒物合计";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, 4, false).ToString();
            row["rcs"] = GetRs(from, to, 4, false).ToString();
            row["fcrs"] = GetRs(from, to, 4, true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "①强酸";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "强酸", false).ToString();
            row["rcs"] = GetRcs(from, to, "强酸").ToString();
            row["fcrs"] = GetRs(from, to, "强酸", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "②苯系物";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "苯系物", false).ToString();
            row["rcs"] = GetRcs(from, to, "苯系物").ToString();
            row["fcrs"] = GetRs(from, to, "苯系物", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "③其他";
            row["dws"] = "/";
            row["rs"] = (GetRs(from, to, 4, false) - GetRs(from, to, "强酸", false) - GetRs(from, to, "苯系物", false)).ToString();
            row["rcs"] = (GetRs(from, to, 4, false) - GetRcs(from, to, "强酸") - GetRcs(from, to, "苯系物")).ToString();
            row["fcrs"] = (GetRs(from, to, 4, true) - GetRs(from, to, "强酸", true) - GetRs(from, to, "苯系物", true)).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "4级毒物合计";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, 5, false).ToString();
            row["rcs"] = GetRs(from, to, 5, false).ToString();
            row["fcrs"] = GetRs(from, to, 5, true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "①氨";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "氨", false).ToString();
            row["rcs"] = GetRcs(from, to, "氨").ToString();
            row["fcrs"] = GetRs(from, to, "氨", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "①其他";
            row["dws"] = "/";
            row["rs"] = (GetRs(from, to, 5, false) - GetRs(from, to, "氨", false)).ToString();
            row["rcs"] = (GetRs(from, to, 5, false) - GetRcs(from, to, "氨")).ToString();
            row["fcrs"] = (GetRs(from, to, 5, true) - GetRs(from, to, "氨", true)).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "三、物理因素合计";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, 6, false).ToString();
            row["rcs"] = GetRs(from, to, 6, false).ToString();
            row["fcrs"] = GetRs(from, to,6, true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "1、噪声";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "噪声", false).ToString();
            row["rcs"] = GetRcs(from, to, "噪声").ToString();
            row["fcrs"] = GetRs(from, to, "噪声", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "2、高温";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "高温", false).ToString();
            row["rcs"] = GetRcs(from, to, "高温").ToString();
            row["fcrs"] = GetRs(from, to, "高温", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "3、噪声+高温";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "噪声+高温", false).ToString();
            row["rcs"] = GetRcs(from, to, "噪声+高温").ToString();
            row["fcrs"] = GetRs(from, to, "噪声+高温", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "4、其他";
            row["dws"] = "/";
            row["rs"] = (GetRs(from, to, 6, false) - GetRs(from, to, "噪声", false) - GetRs(from, to, "高温", false) - GetRs(from, to, "噪声+高温", false)).ToString();
            row["rcs"] = (GetRs(from, to, 6, false) - GetRcs(from, to, "噪声") - GetRcs(from, to, "高温") - GetRcs(from, to, "噪声+高温")).ToString();
            row["fcrs"] = (GetRs(from, to, 6, true) - GetRs(from, to, "噪声", true) - GetRs(from, to, "高温", true) - GetRs(from, to, "噪声+高温", true)).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "四、噪声+粉尘";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "噪声+粉尘", false).ToString();
            row["rcs"] = GetRcs(from, to, "噪声+粉尘").ToString();
            row["fcrs"] = GetRs(from, to, "噪声+粉尘", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            row = dtHzb.NewRow();
            row["xm"] = "五、苯+粉尘";
            row["dws"] = "/";
            row["rs"] = GetRs(from, to, "苯+粉尘", false).ToString();
            row["rcs"] = GetRcs(from, to, "苯+粉尘").ToString();
            row["fcrs"] = GetRs(from, to, "苯+粉尘", true).ToString();
            row["jccwy"] = "/";
            row["gyzcry"] = "/";
            row["wwdws"] = "/";
            row["wwrs"] = "/";
            row["jkrs"] = "/";
            dtHzb.Rows.Add(row);

            int zrs = Convert.ToInt32(dtHzb.Rows[1]["rs"].ToString().Trim()) + Convert.ToInt32(dtHzb.Rows[4]["rs"].ToString().Trim())
                + Convert.ToInt32(dtHzb.Rows[19]["rs"].ToString().Trim()) + Convert.ToInt32(dtHzb.Rows[25]["rs"].ToString().Trim())
                + Convert.ToInt32(dtHzb.Rows[25]["rs"].ToString().Trim());

            dtHzb.Rows[0]["rs"] = zrs.ToString();
            dtHzb.Rows[0]["rcs"] = zrs.ToString();

            return dtHzb;
        }

    }
}
