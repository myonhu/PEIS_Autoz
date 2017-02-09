using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PEIS.cxbb
{
    /// <summary>
    /// 职业健康结果通知书
    /// </summary>
    class Zyjk_tzs:Base
    {
        private StringBuilder sql;
        private DataTable dt;
        private DataTable dtHzmx;

        /// <summary>
        /// 获取基本信息
        /// </summary>
        /// <param name="dwbh"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetJbxx(string dwbh, string from, string to,string whys)
        {
            sql = new StringBuilder("select distinct tjbh,tjcs,xm,dwmc,xm,xb,nl,gz,dhqk as whys,jsgl zgl,mindate='',maxdate='', zh1='',zh2='',zh3='',zh4='',zh5='',zh6='',zh7='',zh8='',zh9='',zh10='',zh11='',jg='',zh12='',zh13='',zh14='',zh15='',zh16='',zh17='',rylb,sumover  from v_tjxm ");
            sql.Append(" where dwbh='"+dwbh+"' and tjrq>='"+from+"' and tjrq<='"+to+"' and dhqk='"+whys+"'");
            sql.Append("order by tjbh");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取汇总表
        /// </summary>
        /// <returns></returns>
        public DataTable GetHzb()
        {
            sql = new StringBuilder("select xh,tjbh,tjcs,dwmc,xm,xb,nl,gz,whys,zgl,mindate,maxdate,zh1,zh2,zh3,zh4,zh5,zh6,zh7,zh8,zh9,zh10,zh11,zh12,zh13,zh14,zh15,zh16,zh17,jg,lb from v_zyjk_jgtzs");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取组合项目信息
        /// </summary>
        /// <param name="dwbh"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetXmxx(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select tjbh,tjcs,mc from v_tjxm where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取某单位所检查的体检项目
        /// </summary>
        /// <param name="dwbh"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetZhxm_tz(string dwbh, string from, string to,string whys)
        {
            sql = new StringBuilder("select distinct mc,disp_order from v_tjxm ");
            sql.Append(" where dwbh='" + dwbh + "' and tjrq>='" + from + "' and tjrq<='" + to + "' and dhqk='"+whys+"'");
            sql.Append(" order by  disp_order");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取校正后的结果
        /// </summary>
        /// <param name="jg"></param>
        /// <returns></returns>
        public string GetJcjg(string jg)
        {
            sql = new StringBuilder("select dbo.fzybtzs('"+jg+"')");
            return base.SqlDBAgent.sqlvalue(sql.ToString()).ToString().Trim();
        }

        /// <summary>
        /// 获取建议内容
        /// </summary>
        /// <param name="tjbh"></param
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public string  GetJynr(string tjbh, string tjcs)
        {
            //sql = new StringBuilder("select jynr from tj_tjdjb a join tj_jbjlb d on a.tjbh=d.tjbh and a.tjcs=d.tjcs left join  TJ_SUGGESTION e on d.jbbh=e.bh ");
            //sql.Append(" where a.tjbh='"+tjbh+"' and a.tjcs='"+tjcs+"'");
            sql = new StringBuilder("select jy jynr from tj_tjdjb where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'");
            DataTable dtjy = new DataTable();
            dtjy = SqlDBAgent.GetDataTable(sql.ToString());
            if (dtjy.Rows.Count == 0)
            {
                return "";
            }
            return dtjy.Rows[0][0].ToString().Trim();
        }

        /// <summary>
        /// 获取体检最大最小日期
        /// </summary>
        /// <param name="dwbh"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetTjrq(string dwbh, string from, string to,string whys)
        {
            sql = new StringBuilder("select max(tjrq) maxdate,min(tjrq) mindate from v_tjxm ");
            sql.Append(" where  tjrq>='" + from + "' and tjrq<='" + to + "' and dhqk='"+whys+"'");
            if (dwbh!="")
            {
                sql.Append(" and dwbh='" + dwbh + "'");
            }
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public DataTable GetTjrq_new2(string dwbh, string from, string to)
        {
            sql = new StringBuilder("select max(tjrq) maxdate,min(tjrq) mindate from v_tjxm ");
            sql.Append(" where  tjrq>='" + from + "' and tjrq<='" + to + "'");
            if (dwbh != "")
            {
                sql.Append(" and dwbh='" + dwbh + "'");
            }
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public DataTable GetTjrq_new(string dwbh, string from, string to)
        {
            sql = new StringBuilder("select  max(tjrq) maxdate,min(tjrq) mindate from tj_tjjlb a join v_tj_tjdjb b on a.tjbh=b.tjbh ");
            sql.Append(" where  sumover=2  and tjrq>='" + from + "' and tjrq<='" + to + "'");
            if (dwbh != "")
            {
                sql.Append(" and dwbh='" + dwbh + "'");
            }
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }




        /// <summary>
        /// 获取体检组合项目结果
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetZhxmJg(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select mc,xj,bh from v_tjxm ");
            sql.Append(" where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 将数字转为中文形式
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string ChangeNumber(int number)
        {
            switch (number)
            {
                case 0: return "○";//"〇";○
                case 1: return "一";
                case 2: return "二";
                case 3: return "三";
                case 4: return "四";
                case 5: return "五";
                case 6: return "六";
                case 7: return "七";
                case 8: return "八";
                case 9: return "九";

                case 10: return "十";
                case 11: return "十一";
                case 12: return "十二";
                case 13: return "十三";
                case 14: return "十四";
                case 15: return "十五";
                case 16: return "十六";
                case 17: return "十七";
                case 18: return "十八";
                case 19: return "十九";


                case 20: return "二十";
                case 21: return "二十一";
                case 22: return "二十二";
                case 23: return "二十三";
                case 24: return "二十四";
                case 25: return "二十五";
                case 26: return "二十六";
                case 27: return "二十七";
                case 28: return "二十八";
                case 29: return "二十九";

                case 30: return "三十";
                case 31: return "三十一";
               
                default:
                    return "";
            }
        }

        /// <summary>
        /// 将日期转为中文形式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string ChangeTime(DateTime time)
        {
            string year = time.Year.ToString();
            char[] charYear = year.ToCharArray();
            string yearDx = "";
            for (int i = 0; i < charYear.Length; i++)
            {
                yearDx += ChangeNumber(Convert.ToInt32(charYear[i].ToString()));
            }
            string month = ChangeNumber(time.Month);
            string day = ChangeNumber(time.Day);

            return yearDx + "年" + month + "月" + day + "日";
        }

        /// <summary>
        /// 获取组合头子
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="dwbh"></param>
        /// <returns></returns>
        public DataTable GetHeader(string from, string to, string dwbh,string whys)
        {
            DataTable dtHeader = new DataTable();
            sql = new StringBuilder(" select z1,z2,z3,z4,z5,z6,z7,z8,z9,z10,z11,z12,z13,z14,z15,z16,z17 from v_zyjk_jgtzs_header");
            dtHeader = base.SqlDBAgent.GetDataTable(sql.ToString());
            dt = new DataTable();
            dt = GetZhxm_tz(dwbh, from, to, whys);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string mc = dt.Rows[i]["mc"].ToString().Trim();
                if (mc == "身高、体重、血压")
                {
                    mc = "血压(mmHg)";
                }
                if (mc.IndexOf("血常规") != -1)
                {
                    mc = "血常规";
                }


                dtHeader.Rows[0][i] = mc;
            }

            return dtHeader;
        }

        /// <summary>
        /// 获取汇总明细
        /// </summary>
        /// <param name="dwbh"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public DataTable GetHzmx( string from, string to,string dwbh,string whys)
        {
            //xh,tjbh,tjcs,dwmc,xm,xb,nl,gz,whys,zgl,mindate,maxdate,zh1,zh2,zh3,zh4,zh5,zh6,zh7,zh8,zh9,zh10,zh11,jg,zh12,zh13
            dtHzmx = new DataTable();
            dtHzmx = GetHzb();
            //,,,,,,,,,,,,zh1,zh2,zh3,zh4,zh5,zh6,zh7,zh8,zh9,zh10,zh11,,zh12,zh13
            //设置表头
            dt = new DataTable();
            dt = GetZhxm_tz(dwbh, from, to, whys);

            dtHzmx.Rows[0]["xh"] = "序号";
            dtHzmx.Rows[0]["tjbh"] = "tjbh";
            dtHzmx.Rows[0]["tjcs"] = "tjcs";
            dtHzmx.Rows[0]["dwmc"] = "dwmc";
            dtHzmx.Rows[0]["xm"] = "姓名";
            dtHzmx.Rows[0]["xb"] = "性别";
            dtHzmx.Rows[0]["nl"] = "年龄";
            dtHzmx.Rows[0]["gz"] = "工种";
            dtHzmx.Rows[0]["whys"] = "危害因素";
            dtHzmx.Rows[0]["zgl"] = "工龄";
            dtHzmx.Rows[0]["mindate"] = "mindate";
            dtHzmx.Rows[0]["maxdate"] = "maxdate";
            dtHzmx.Rows[0]["jg"] = "体检结果";
            dtHzmx.Rows[0]["lb"] = "类别";
            
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string mc=dt.Rows[j]["mc"].ToString().Trim();
                if (mc == "身高、体重、血压")
                {
                    mc = "血压(mmHg)";
                }
                if (mc.IndexOf("血常规") != -1)
                {
                    mc = "血常规";
                }

                dtHzmx.Rows[0][12 + j] = mc;
            }

            #region 设置内容
            dt = new DataTable();
            dt = GetJbxx(dwbh, from, to,whys);
            if (dt.Rows.Count<=0)
            {
                return dtHzmx;
            }
            //,,,,,,,,,,mindate,maxdate,,,,,,,,,,,,jg,,
            DataRow row;
            string tjbh, tjcs;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dtHzmx.NewRow();
                row["xh"] = (i + 1).ToString();
                tjbh = dt.Rows[i]["tjbh"].ToString().Trim();
                tjcs = dt.Rows[i]["tjcs"].ToString().Trim();
                row["tjbh"] = tjbh;
                row["tjcs"] = tjcs;
                row["dwmc"] = dt.Rows[i]["dwmc"].ToString().Trim();
                row["xm"] = dt.Rows[i]["xm"].ToString().Trim();
                row["xb"] = dt.Rows[i]["xb"].ToString().Trim();
                row["nl"] = dt.Rows[i]["nl"].ToString().Trim();
                row["gz"] = dt.Rows[i]["gz"].ToString().Trim();
                row["whys"] = dt.Rows[i]["whys"].ToString().Trim();
                row["zgl"] = dt.Rows[i]["zgl"].ToString().Trim();
                row["zh1"] = dt.Rows[i]["zh1"].ToString().Trim();
                row["zh2"] = dt.Rows[i]["zh2"].ToString().Trim();
                row["zh3"] = dt.Rows[i]["zh3"].ToString().Trim();
                row["zh4"] = dt.Rows[i]["zh4"].ToString().Trim();
                row["zh5"] = dt.Rows[i]["zh5"].ToString().Trim();
                row["zh6"] = dt.Rows[i]["zh6"].ToString().Trim();
                row["zh7"] = dt.Rows[i]["zh7"].ToString().Trim();
                row["zh8"] = dt.Rows[i]["zh8"].ToString().Trim();
                row["zh9"] = dt.Rows[i]["zh9"].ToString().Trim();
                row["zh10"] = dt.Rows[i]["zh10"].ToString().Trim();
                row["zh11"] = dt.Rows[i]["zh11"].ToString().Trim();
                row["zh12"] = dt.Rows[i]["zh12"].ToString().Trim();
                row["zh13"] = dt.Rows[i]["zh13"].ToString().Trim();
                row["zh14"] = dt.Rows[i]["zh14"].ToString().Trim();
                row["zh15"] = dt.Rows[i]["zh15"].ToString().Trim();
                row["zh16"] = dt.Rows[i]["zh16"].ToString().Trim();
                row["zh17"] = dt.Rows[i]["zh17"].ToString().Trim();
                row["lb"] = dt.Rows[i]["rylb"].ToString().Trim();
                dtHzmx.Rows.Add(row);

                #region 设置值
                DataTable dt2 = GetZhxmJg(tjbh, tjcs);
                for (int tem = 0; tem < dt2.Rows.Count; tem++)
                {
                    string zhmc = dt2.Rows[tem]["mc"].ToString().Trim();
                    string jg = dt2.Rows[tem]["xj"].ToString().Trim();
                    if (zhmc == "身高、体重、血压")
                    {
                        zhmc = "血压(mmHg)";
                        jg = jg.Split('：')[0];
                        string[] jgs = jg.Split(')');
                        if (jgs.Length>1)
                        {
                            jg = jgs[1];
                            jg = jg.Replace("血压","");
                        }
                        //jg = jg.Split(')')[1];
                    }
                    if (zhmc.IndexOf("血常规") != -1)
                    {
                        zhmc = "血常规";
                       
                    }
                    if (zhmc.IndexOf("听力")!=-1)//听力检测
                    {
                        string strJg = jg;
                        jg = jg.Replace("\n", " ");
                        StringBuilder strTl = new StringBuilder();
                        string[] tjs = jg.Split(' ');
                        for (int j = 0; j < tjs.Length; j++)
                        {
                            string[] strTls = tjs[j].Split('：');
                            if (strTls.Length>1)
                            {
                                try
                                {
                                    decimal tl = Convert.ToDecimal(strTls[1].Trim());
                                    if (tl > 25)
                                    {
                                        strTl.Append(tjs[j]);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                catch 
                                {
                                    continue;
                                }
                            }
                        }
                        jg = strTl.ToString();
                        jg = jg.Replace("平均听阈", "");
                        if (jg=="" && strJg!="")
                        {
                            jg = "正常";
                        }
                    }

                    if (dtHzmx.Rows[0]["zh1"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh1"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh2"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh2"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh3"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh3"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh4"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh4"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh5"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh5"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh6"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh6"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh7"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh7"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh8"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh8"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh9"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh9"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh10"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh10"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh11"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh11"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh12"].ToString().Trim()==zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh12"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh13"].ToString().Trim() == zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh13"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh14"].ToString().Trim() == zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh14"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh15"].ToString().Trim() == zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh15"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh16"].ToString().Trim() == zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh16"] = jg;
                    }
                    else if (dtHzmx.Rows[0]["zh17"].ToString().Trim() == zhmc)
                    {
                        dtHzmx.Rows[i + 1]["zh17"] = jg;
                    }
                #endregion
                    //设置建议内容
                    string sumover = dt.Rows[i]["sumover"].ToString().Trim();
                    string jy = "";
                    if (sumover=="0")//未检
                    {
                        jy = "未检";
                    }
                    else if (sumover == "1")//未总检
                    {
                        jy = "未主检";
                    }
                    else if (sumover=="2")//已总检
                    {
                        jy = GetJynr(tjbh, tjcs);
                    }
                    else
                    {
                        jy = "";
                    }
                    dtHzmx.Rows[i + 1]["jg"] = jy;
                   
                }
            }
            #endregion

            dtHzmx.Rows.RemoveAt(0);//删除头子

            return dtHzmx;
        }
    }
}
