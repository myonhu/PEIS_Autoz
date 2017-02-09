using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PEIS.zybtj
{
    class TjGyzzBiz:Base
    {
        private StringBuilder sql;

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <param name="sqls"></param>
        public void Delete(string tjbh, string tjcs,List<string> sqls)
        {
            sql = new StringBuilder("delete from tj_zyb_gyzz where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'");

            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 获取高原症状
        /// </summary>
        /// <param name="tjbh"></param>
        /// <param name="tjcs"></param>
        /// <returns></returns>
        public DataTable GetGyzz(string tjbh, string tjcs)
        {
            sql = new StringBuilder("select tjbh,tjcs,zxcns,zxcxs,jynxcxs,one,two,three,four,five,six,senven,eight,"
                + "night,ten,tenone,tentwo,tenthree,tenfour,tenfive,tensix,tensenven,teneight,tennight,twenty,twentyone,twentytwo,twentythree,"
                + "twentyfour,twentyfive,twentysix,twentysenven,twentyeight,twentynight,threeten,threeone,threetwo,threethree,threefour,threefive,"
                + "threesix,threesenven,threeeight,threenight from tj_zyb_gyzz where tjbh='"+tjbh+"' and tjcs='"+tjcs+"'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="zz"></param>
        public void Insert(TjGyzz zz, List<string> sqls)
        {
            sql = new StringBuilder("insert into tj_zyb_gyzz(tjbh,tjcs,zxcns,zxcxs,jynxcxs,one,two,three,four,five,six,senven,eight,"
                +"night,ten,tenone,tentwo,tenthree,tenfour,tenfive,tensix,tensenven,teneight,tennight,twenty,twentyone,twentytwo,twentythree,"
                +"twentyfour,twentyfive,twentysix,twentysenven,twentyeight,twentynight,threeten,threeone,threetwo,threethree,threefour,threefive,"
                +"threesix,threesenven,threeeight,threenight) values('");
            sql.Append(zz.tjbh + "','");
            sql.Append(zz.tjcs + "','");
            sql.Append(zz.zxcns + "','");
            sql.Append(zz.zxcxs + "','");
            sql.Append(zz.jynxcxs + "','");

            sql.Append(zz.one + "','");
            sql.Append(zz.two + "','");
            sql.Append(zz.three + "','");
            sql.Append(zz.four + "','");
            sql.Append(zz.five + "','");
            sql.Append(zz.six + "','");
            sql.Append(zz.senven + "','");
            sql.Append(zz.eight + "','");
            sql.Append(zz.night + "','");
            sql.Append(zz.ten + "','");

            sql.Append(zz.tenone + "','");
            sql.Append(zz.tentwo + "','");
            sql.Append(zz.tenthree + "','");
            sql.Append(zz.tenfour + "','");
            sql.Append(zz.tenfive + "','");
            sql.Append(zz.tensix + "','");
            sql.Append(zz.tensenven + "','");
            sql.Append(zz.teneight + "','");
            sql.Append(zz.tennight + "','");
            sql.Append(zz.twenty + "','");

            sql.Append(zz.twentyone + "','");
            sql.Append(zz.twentytwo + "','");
            sql.Append(zz.twentythree + "','");
            sql.Append(zz.twentyfour + "','");
            sql.Append(zz.twentyfive + "','");
            sql.Append(zz.twentysix + "','");
            sql.Append(zz.twentysenven + "','");
            sql.Append(zz.twentyeight + "','");
            sql.Append(zz.twentynight + "','");
            sql.Append(zz.threeten + "','");

            sql.Append(zz.threeone + "','");
            sql.Append(zz.threetwo + "','");
            sql.Append(zz.threethree + "','");
            sql.Append(zz.threefour + "','");
            sql.Append(zz.threefive + "','");
            sql.Append(zz.threesix + "','");
            sql.Append(zz.threesenven + "','");
            sql.Append(zz.threeeight + "','");
            sql.Append(zz.threenight + "')");

            sqls.Add(sql.ToString());
        }
    }
}
