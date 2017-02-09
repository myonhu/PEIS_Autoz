using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PEIS.zybtj
{
    class TjZybZzBiz:Base
    {
        private StringBuilder sql;

        public void Insert(TjZybZz zz, List<string> sqls)
        {
            sql = new StringBuilder("insert into tj_zyb_zz(TJBH,TJCS,JCRQ,jcys,ZZ01 ,ZZ02 ,ZZ03 ,ZZ04 ,ZZ05 ,ZZ06 ,ZZ07 ,ZZ08 ,ZZ09 ,ZZ10 ,ZZ11 ,ZZ12 ,ZZ13 ,ZZ14 ,ZZ15 ,ZZ16 ,ZZ17 ,ZZ18 ,ZZ19 ,ZZ20 ,ZZ21 ,ZZ22 ,ZZ23 ,ZZ24 ,ZZ25 ,ZZ26 ,ZZ27 ,ZZ28 ,ZZ29 ,ZZ30 ,ZZ31 ,ZZ32 ,ZZ33 ,ZZ34 ,ZZ35 ,ZZ36 ,ZZ37 ,ZZ38 ,ZZ39 ,ZZ40 ,Zz41"
                +",zz42,zz43,zz44,zz45,zz46,zz47,zz48,zz49,zz50,zz51,zz52,zz53,zz54,zz55,zz56,zz57,zz58,zz59,zz60,zz61,zz62,zz63,zz64) values('");
            sql.Append(zz.tjbh.Trim() + "','");
            sql.Append(zz.tjcs + "','");
            sql.Append(zz.jcrq + "','");
            sql.Append(zz.jcys + "','");

            sql.Append(zz.zz01 + "','");
            sql.Append(zz.zz02 + "','");
            sql.Append(zz.zz03 + "','");
            sql.Append(zz.zz04 + "','");
            sql.Append(zz.zz05 + "','");
            sql.Append(zz.zz06 + "','");
            sql.Append(zz.zz07 + "','");
            sql.Append(zz.zz08 + "','");
            sql.Append(zz.zz09 + "','");
            sql.Append(zz.zz10 + "','");

            sql.Append(zz.zz11 + "','");
            sql.Append(zz.zz12 + "','");
            sql.Append(zz.zz13 + "','");
            sql.Append(zz.zz14 + "','");
            sql.Append(zz.zz15 + "','");
            sql.Append(zz.zz16 + "','");
            sql.Append(zz.zz17 + "','");
            sql.Append(zz.zz18 + "','");
            sql.Append(zz.zz19 + "','");
            sql.Append(zz.zz20 + "','");

            sql.Append(zz.zz21 + "','");
            sql.Append(zz.zz22 + "','");
            sql.Append(zz.zz23 + "','");
            sql.Append(zz.zz24 + "','");
            sql.Append(zz.zz25 + "','");
            sql.Append(zz.zz26 + "','");
            sql.Append(zz.zz27 + "','");
            sql.Append(zz.zz28 + "','");
            sql.Append(zz.zz29 + "','");
            sql.Append(zz.zz30 + "','");

            sql.Append(zz.zz31 + "','");
            sql.Append(zz.zz32 + "','");
            sql.Append(zz.zz33 + "','");
            sql.Append(zz.zz34 + "','");
            sql.Append(zz.zz35 + "','");
            sql.Append(zz.zz36 + "','");
            sql.Append(zz.zz37 + "','");
            sql.Append(zz.zz38 + "','");
            sql.Append(zz.zz39 + "','");
            sql.Append(zz.zz40 + "','");

            sql.Append(zz.zz41 + "','");
            sql.Append(zz.zz42 + "','");
            sql.Append(zz.zz43 + "','");
            sql.Append(zz.zz44 + "','");
            sql.Append(zz.zz45 + "','");
            sql.Append(zz.zz46 + "','");
            sql.Append(zz.zz47 + "','");
            sql.Append(zz.zz48 + "','");
            sql.Append(zz.zz49 + "','");
            sql.Append(zz.zz50 + "','");

            sql.Append(zz.zz51 + "','");
            sql.Append(zz.zz52 + "','");
            sql.Append(zz.zz53 + "','");
            sql.Append(zz.zz54 + "','");
            sql.Append(zz.zz55 + "','");
            sql.Append(zz.zz56 + "','");
            sql.Append(zz.zz57 + "','");
            sql.Append(zz.zz58 + "','");
            sql.Append(zz.zz59 + "','");
            sql.Append(zz.zz60 + "','");

            sql.Append(zz.zz61 + "','");
            sql.Append(zz.zz62 + "','");
            sql.Append(zz.zz63 + "','");
            sql.Append(zz.zz64 + "')");

            sqls.Add(sql.ToString());
        }

        public void Update(TjZybZz zz, List<string> sqls)
        {
            //TJBH,TJCS,JCRQ,jcys,ZZ01
            sql = new StringBuilder("update tj_zyb_zz set tjbh='"+zz.tjbh+"'");
            sql.Append(",tjcs='" + zz.tjcs + "'");
            sql.Append(",JCRQ='" + zz.jcrq + "'");
            sql.Append(",jcys='" + zz.jcys + "'");
            sql.Append(",ZZ01='" + zz.zz01 + "'");
            sql.Append(",ZZ02='" + zz.zz02 + "'");
            sql.Append(",ZZ03='" + zz.zz03 + "'");
            sql.Append(",ZZ04='" + zz.zz04 + "'");
            sql.Append(",ZZ05='" + zz.zz05 + "'");
            sql.Append(",ZZ06='" + zz.zz06 + "'");
            sql.Append(",ZZ07='" + zz.zz07 + "'");
            sql.Append(",ZZ08='" + zz.zz08 + "'");
            sql.Append(",ZZ09='" + zz.zz09 + "'");

            sql.Append(",ZZ10='" + zz.zz10 + "'");
            sql.Append(",ZZ11='" + zz.zz11 + "'");
            sql.Append(",ZZ12='" + zz.zz12 + "'");
            sql.Append(",ZZ13='" + zz.zz13 + "'");
            sql.Append(",ZZ14='" + zz.zz14 + "'");
            sql.Append(",ZZ15='" + zz.zz15 + "'");
            sql.Append(",ZZ16='" + zz.zz16 + "'");
            sql.Append(",ZZ17='" + zz.zz17 + "'");
            sql.Append(",ZZ18='" + zz.zz18 + "'");
            sql.Append(",ZZ19='" + zz.zz19 + "'");

            sql.Append(",ZZ20='" + zz.zz20 + "'");
            sql.Append(",ZZ21='" + zz.zz21 + "'");
            sql.Append(",ZZ22='" + zz.zz22 + "'");
            sql.Append(",ZZ23='" + zz.zz23 + "'");
            sql.Append(",ZZ24='" + zz.zz24 + "'");
            sql.Append(",ZZ25='" + zz.zz25 + "'");
            sql.Append(",ZZ26='" + zz.zz26 + "'");
            sql.Append(",ZZ27='" + zz.zz27 + "'");
            sql.Append(",ZZ28='" + zz.zz28 + "'");
            sql.Append(",ZZ29='" + zz.zz29 + "'");

            sql.Append(",ZZ30='" + zz.zz30 + "'");
            sql.Append(",ZZ31='" + zz.zz31 + "'");
            sql.Append(",ZZ32='" + zz.zz32 + "'");
            sql.Append(",ZZ33='" + zz.zz33 + "'");
            sql.Append(",ZZ34='" + zz.zz34 + "'");
            sql.Append(",ZZ35='" + zz.zz35 + "'");
            sql.Append(",ZZ36='" + zz.zz36 + "'");
            sql.Append(",ZZ37='" + zz.zz37 + "'");
            sql.Append(",ZZ38='" + zz.zz38 + "'");
            sql.Append(",ZZ39='" + zz.zz39 + "'");

            sql.Append(",ZZ40='" + zz.zz40 + "'");
            sql.Append(",ZZ41='" + zz.zz41 + "'");
            sql.Append(",ZZ42='" + zz.zz42 + "'");
            sql.Append(",ZZ43='" + zz.zz43 + "'");
            sql.Append(",ZZ44='" + zz.zz44 + "'");
            sql.Append(",ZZ45='" + zz.zz45 + "'");
            sql.Append(",ZZ46='" + zz.zz46 + "'");
            sql.Append(",ZZ47='" + zz.zz47 + "'");
            sql.Append(",ZZ48='" + zz.zz48 + "'");
            sql.Append(",ZZ49='" + zz.zz49 + "'");

            sql.Append(",ZZ50='" + zz.zz50 + "'");
            sql.Append(",ZZ51='" + zz.zz51 + "'");
            sql.Append(",ZZ52='" + zz.zz52 + "'");
            sql.Append(",ZZ53='" + zz.zz53 + "'");
            sql.Append(",ZZ54='" + zz.zz54 + "'");
            sql.Append(",ZZ55='" + zz.zz55 + "'");
            sql.Append(",ZZ56='" + zz.zz56 + "'");
            sql.Append(",ZZ57='" + zz.zz57 + "'");
            sql.Append(",ZZ58='" + zz.zz58 + "'");
            sql.Append(",ZZ59='" + zz.zz59 + "'");

            sql.Append(",ZZ60='" + zz.zz60 + "'");
            sql.Append(",ZZ61='" + zz.zz61 + "'");
            sql.Append(",ZZ62='" + zz.zz62 + "'");
            sql.Append(",ZZ63='" + zz.zz63 + "'");
            sql.Append(",ZZ64='" + zz.zz64 + "'");

            sql.Append(" where tjbh='"+zz.tjbh+"' and tjcs='"+zz.tjcs+"'");
            sqls.Add(sql.ToString());
            

        }

        public bool HasExist(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select count(*) from tj_zyb_zz where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'");
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

        public DataTable GetZz(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select TJBH,TJCS,JCRQ,jcys,ZZ01 ,ZZ02 ,ZZ03 ,ZZ04 ,ZZ05 ,ZZ06 ,ZZ07 ,ZZ08 ,ZZ09 ,ZZ10 ,ZZ11 ,ZZ12 ,ZZ13 ,ZZ14 ,ZZ15 ,ZZ16 ,ZZ17 ,ZZ18 ,ZZ19 ,ZZ20 ,ZZ21 ,ZZ22 ,ZZ23 ,ZZ24 ,ZZ25 ,ZZ26 ,ZZ27 ,ZZ28 ,ZZ29 ,ZZ30 ,ZZ31 ,ZZ32 ,ZZ33 ,ZZ34 ,ZZ35 ,ZZ36 ,ZZ37 ,ZZ38 ,ZZ39 ,ZZ40 ,Zz41"
                + ",zz42,zz43,zz44,zz45,zz46,zz47,zz48,zz49,zz50,zz51,zz52,zz53,zz54,zz55,zz56,zz57,zz58,zz59,zz60,zz61,zz62,zz63,zz64 from tj_zyb_zz where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public DataTable GetZybZz(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select tjbh,tjcs,jcrq,one,two,three,four,five,six,seven,eight,nine,ten,tenone,tentwo,tenthree,tenfour,tenfive,tensix,tenseven,teneight,tennine,Twenty,Twentyone,Twentytwo,Twentythree,Twentyfour,Twentyfive,Twentysix,Twentyseven,Twentyeight,Twentynine,Thirty,Thirtyone,"
                + "Thirtytwo, Thirtythree, Thirtyfour, Thirtyfive, Thirtysix, Thirtyseven,   Thirtyeight, Thirtynine, Forty, Fortyone, Fortytwo, Fortythree, Fortyfour, Fortyfive, Fortysix, Fortyseven,   Fortyeight, Fortynine,");
            sql.Append(" Fifty, Fiftyone, Fiftytwo, Fiftythree, Fiftyfour, Fiftyfive, Fiftysix, Fiftyseven,  Fiftyeight, Fiftynine,Sixty, Sixtyone,Sixtytwo,Sixtythree,Sixtyfour,convert(varchar(10),jcys,120) jcys ");
            sql.Append(" from v_zyb_zz");
            sql.Append(" where tjbh='" + tjbh + "' and tjcs='" + tjcs + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public DataTable GetTljc(string tjbh, string tjcs)
        {
            sql = new StringBuilder("exec Pro_zybtj_bg_cwjc '" + tjbh + "','" + tjcs + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取体征信息
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetTz(string tjbh, string tjcs)
        {
            //sql = new StringBuilder("exec Pro_zybtj_bg '"+tjbh+"','"+tjcs+"'");
           string sqlstr = "select xh,tjbh,tjcs,一般状况,脉率,血压,裸视力左,裸视力右,矫正视力左,矫正视力右,晶体,眼底,外耳,听力左,听力右,鼻,"
+"口腔,咽喉,心脏,肺,肝,脾,甲状腺,浅表淋巴结,皮肤黏膜,皮肤划纹症,膝反射,跟腱反射,肌力,肌张力,共济运动,感觉异常,三颤,"
+"病理反射,白细胞,中性,淋巴,单核,红细胞,血红蛋白,血小板,尿蛋白,尿糖,尿红细胞,尿白细胞,管型,ALT,HBsAg,乙肝二对半,"
+"胸透,高仟伏胸片,胸片,心电图,[B超-肝], [B超-胆], [B超-脾],[B超-肾],脑电图,听视觉诱发电位,神经肌电图,尿铅,尿砷,尿铬,尿锰,尿氟,血铅,尿氨基,血锌元,尿微球蛋白,"
+"全血胆碱脂酶,[PVC%],[PEV1%],[PEV1/FVC%] from tj_zyb_jkjcb where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'";
           return base.SqlDBAgent.GetDataTable(sqlstr);
            //return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        public DataTable GetTz_gy(string tjbh,string tjcs)
        {
            sql = new StringBuilder("exec Pro_zybtj_bg_gycw '" + tjbh + "','" + tjcs + "'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }
    }
}

