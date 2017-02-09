using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PEIS.tjjg;

namespace PEIS.jyjk
{
    class JyjkBiz:Base
    {
        private StringBuilder sql;
        private List<string> sqls;
        private tjjgBiz jgBiz = new tjjgBiz();

        /// <summary>
        /// 获取检验机型
        /// </summary>
        /// <returns></returns>
        public DataTable GetJyjx()
        {
            sql = new StringBuilder("select bh,mc from jy_jyjx where tybz=0");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 根据条件获取体检登记信息
        /// </summary>
        /// <param name="djrq"></param>
        /// <param name="djlsh"></param>
        /// <param name="tjbh"></param>
        /// <returns></returns>
        public DataTable GetDjxx(string djlsh, string tjbh)
        {
            sql = new StringBuilder("select djlsh,tjbh,xm,xb,nl,sfzh,dwmc,rylb,gz,whysmc tcmc from v_tj_tjdjb where 1=1");
            if (djlsh!="")
            {
                sql.Append(" and djlsh='"+djlsh+"'");
            }
            //if (tjbh!="")
            //{
            //    sql.Append(" and tjbh='"+tjbh+"'");
            //}

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取检验登记信息
        /// </summary>
        /// <param name="jyjx"></param>
        /// <param name="djrq"></param>
        /// <returns></returns>
        public DataTable GetJyDjxx(string jyjx,string djrq,string djlsh,int sffb)
        {
            sql = new StringBuilder("select a.djid,a.djrq,a.djlsh,a.tjbh,a.xm,a.xb,a.nl,a.sfzh,a.dwmc,a.rylb,a.jyjx,b.djid bc,b.sffb,a.gz,a.whys  from jy_jydj a left join v_jy_sffb b on a.djid=b.djid where a.jyjx='" + jyjx + "'");
            if (djrq!="")
            {
                sql.Append(" and a.djrq>='" + djrq + " 00:00:00' and a.djrq<='" + djrq + " 23:59:59'");
            }
            if (djlsh!="")
            {
                sql.Append(" and a.djlsh='" + djlsh + "'");
            }
            switch (sffb)
            {
                case 0: sql.Append(" and isnull(b.sffb,0)=0"); break;//未发布
                case 1: sql.Append(" and isnull(b.sffb,0)<>0"); break;//已发布
                default:
                    break;
            }
            sql.Append("order by a.djid desc");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 判断是否已登记
        /// </summary>
        /// <param name="jyjx"></param>
        /// <param name="djlsh"></param>
        /// <returns></returns>
        public bool HasExist(string jyjx, string djlsh)
        {
            sql=new StringBuilder("select count(*) from jy_jydj where jyjx='"+jyjx+"' and djlsh='"+djlsh+"'");
            DataTable dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            if (dt.Rows.Count<=0)
            {
                return false;
            }

            string count=dt.Rows[0][0].ToString().Trim();
            if (Convert.ToInt32(count)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 插入检验登记信息
        /// </summary>
        /// <param name="jydj"></param>
        /// <returns></returns>
        public void Insert(Jydj jydj,List<string> sqls)
        {
            sql = new StringBuilder("insert into jy_jydj(djrq,jyjx,djlsh,tjbh,xm,xb,nl,sfzh,dwmc,rylb) values('");
            sql.Append(jydj.Djrq + "','");
            sql.Append(jydj.Jyjx + "','");
            sql.Append(jydj.Djlsh + "','");
            sql.Append(jydj.Tjbh + "','");
            sql.Append(jydj.Xm + "','");
            sql.Append(jydj.Xb + "','");
            sql.Append(jydj.Nl + "','");
            sql.Append(jydj.Sfzh + "','");
            sql.Append(jydj.Dwmc + "','");
            sql.Append(jydj.Rylb + "')");

            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 插入检验登记信息
        /// </summary>
        /// <param name="jydj"></param>
        /// <returns></returns>
        public int Insert(Jydj jydj)
        {
            sql = new StringBuilder("insert into jy_jydj(djrq,jyjx,djlsh,tjbh,xm,xb,nl,sfzh,dwmc,jcys,shrq,shys,gz,whys,rylb) values('");
            sql.Append(jydj.Djrq + "','");
            sql.Append(jydj.Jyjx + "','");
            sql.Append(jydj.Djlsh + "','");
            sql.Append(jydj.Tjbh + "','");
            sql.Append(jydj.Xm + "','");
            sql.Append(jydj.Xb + "','");
            sql.Append(jydj.Nl + "','");
            sql.Append(jydj.Sfzh + "','");
            sql.Append(jydj.Dwmc + "','");
            sql.Append(jydj.Jcys + "','");
            sql.Append(jydj.Shrq + "','");
            sql.Append(jydj.Shys + "','");
            sql.Append(jydj.Gz + "','");
            sql.Append(jydj.Tcmc + "','");
            sql.Append(jydj.Rylb + "')");

            return base.SqlDBAgent.sqlupdate(sql.ToString());
        }


        /// <summary>
        /// 插入检验登记信息
        /// </summary>
        /// <param name="jydjs"></param>
        /// <returns></returns>
        public int InsertJydjxx(List<Jydj> jydjs)
        {
            sqls = new List<string>();
            for (int i = 0; i < jydjs.Count; i++)
            {
                Insert(jydjs[i], sqls);
            }

            return base.SqlDBAgent.sqlupdate(sqls);
        }

        /// <summary>
        /// 插入检验项目表
        /// </summary>
        /// <param name="xmbh"></param>
        /// <param name="jyjx"></param>
        /// <param name="xmmc"></param>
        /// <param name="xmsx"></param>
        /// <returns></returns>
        public int InsertJyxmb(string xmbh, string jyjx, string xmmc, string xmsx,string dy,string xy,string spy,string xpy,string dw,string mrjg)
        {
            sql = new StringBuilder("insert into jy_xmb(xmbh,jyjx,xmmc,xmsx,dy,xy,spy,xpy,dw,mrz,tybz) values('");
            sql.Append(xmbh + "','");
            sql.Append(jyjx + "','");
            sql.Append(xmmc + "','");
            sql.Append(xmsx + "','");
            sql.Append(dy + "','");
            sql.Append(xy + "','");
            sql.Append(spy + "','");
            sql.Append(xpy + "','");
            sql.Append(dw+ "','");
            sql.Append(mrjg + "','");
            sql.Append( "0')");
            sql = sql.Replace("''", "null");
            return base.SqlDBAgent.sqlupdate(sql.ToString());
        }

        /// <summary>
        /// 更新检验项目表
        /// </summary>
        /// <param name="xmbh"></param>
        /// <param name="tybz"></param>
        /// <param name="xmmc"></param>
        /// <param name="xmsx"></param>
        /// <returns></returns>
        public int UpdateJyxmb(string xmbh, bool tybz,string xmsx,string dy,string xy,string spy,string xpy,string xmmc,string bl,string xssx,string dw,string mrjg)
        {
            string ty;
            if (tybz)
            {
                ty = "1";
            }
            else
            {
                ty = "0";
            }
            sql = new StringBuilder("update jy_xmb set tybz='"+ty+"',xmsx='"+xmsx+"',dy='"+dy+"',xy='"+xy+"',spy='"+spy+"',xpy='"+xpy+"',xmmc='"+xmmc+"',bl='"+bl+"',xssx='"+xssx+"',dw='"+dw+"',mrz='"+mrjg+"'");
            sql.Append(" where xmbh='"+xmbh+"'");
            sql = sql.Replace("''", "null");

            return base.SqlDBAgent.sqlupdate(sql.ToString());
        }

        /// <summary>
        /// 判断检验结果是否已存在
        /// </summary>
        /// <param name="djlsh"></param>
        /// <returns></returns>
        public bool HasJyjgExist(string djlsh, string jyjx)
        {
            sql = new StringBuilder("select count(*) from v_jy_xmjg where jyjx='"+jyjx+"' and djlsh='"+djlsh+"'");
            DataTable dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            if (dt.Rows.Count<=0)
            {
                return false;
            }
            string count=dt.Rows[0][0].ToString().Trim();
            if (Convert.ToInt32(count)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取检验项目结果
        /// </summary>
        /// <param name="jyjx"></param>
        /// <param name="djlsh"></param>
        /// <returns></returns>
        public DataTable GetJyxmjg(string jyjx, string djlsh)
        {            
            if (HasJyjgExist(djlsh,jyjx))
            {
                //如果存在
                sql = new StringBuilder("select xmbh,jyjx,xmmc,xmsx,jg,dy,xy,spy,xpy,isnull(bl,1) bl,xssx,dw,mrz from v_jy_xmjg where jyjx='" + jyjx + "'");
                sql.Append(" and djlsh='"+djlsh+"'");
            }
            else
            {
                sql = new StringBuilder("select xmbh,jyjx,xmmc,xmsx, jg=mrz,dy,xy,spy,xpy,isnull(bl,1) bl,xssx,dw,mrz from jy_xmb where jyjx='" + jyjx + "' AND TYBZ=0");
            }

            sql.Append(" order by xssx");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 插入检验结果表
        /// </summary>
        /// <param name="jyjg"></param>
        /// <param name="sql"></param>
        public void InsertJyjg(Jyjgb jyjg, List<string> sqls)
        {
            sql = new StringBuilder("insert into jy_jyjgb(djlsh,xmbh,djid,jg) values('");
            sql.Append(jyjg.Djlsh + "','");
            sql.Append(jyjg.Xmbh + "','");
            sql.Append(jyjg.Djid + "','");
            sql.Append(jyjg.Jg + "')");

            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 更新检验结果
        /// </summary>
        /// <param name="jyjg"></param>
        /// <param name="sqls"></param>
        public void UpdateJyjg(Jyjgb jyjg, List<string> sqls)
        {
            sql = new StringBuilder("update jy_jyjgb set jg='" + jyjg.Jg + "', djid='" + jyjg.Djid + "' where xmbh='" + jyjg.Xmbh + "' and djlsh='" + jyjg.Djlsh + "' ");

            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 判断检验结果是否已存在
        /// </summary>
        /// <param name="djlsh"></param>
        /// <returns></returns>
        public bool HasXmbhExist(string djlsh, string xmbh)
        {
            sql = new StringBuilder("select count(*) from jy_jyjgb where xmbh='" + xmbh + "' and djlsh='" + djlsh + "'");
            DataTable dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            string count = dt.Rows[0][0].ToString().Trim();
            if (Convert.ToInt32(count) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存检验结果
        /// </summary>
        /// <param name="jyjgs"></param>
        /// <returns></returns>
        public int SaveJyjg(List<Jyjgb> jyjgs)
        {
            sqls = new List<string>();
            for (int i = 0; i < jyjgs.Count; i++)
            {
                if (HasXmbhExist(jyjgs[i].Djlsh,jyjgs[i].Xmbh))//如果存在，则更新
                {
                    UpdateJyjg(jyjgs[i], sqls);
                }
                else
                {
                    InsertJyjg(jyjgs[i], sqls);
                }
            }

            return base.SqlDBAgent.sqlupdate(sqls);
        }

        /// <summary>
        /// 获取检验结果
        /// </summary>
        /// <param name="djlsh"></param>
        /// <returns></returns>
        public DataTable GetJyjg(string djlsh,string jyjx)
        {
            sql = new StringBuilder("select djlsh,xmbh,jg,dy,xy,djid from v_jy_xmjg where djlsh in(" + djlsh + ") and jyjx='"+jyjx+"'");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 更新检验结果
        /// </summary>
        /// <param name="jyjg"></param>
        /// <param name="sqls"></param>
        public void UpdateJg(Jyjgb jyjg, List<string> sqls)
        {
            sql = new StringBuilder("update a set jg='" + jyjg.Jg + "' from tj_tjjlmxb a join tj_tjjlb b on a.xh=b.xh "
                +"join TJ_JGXMDZB c on a.tjxm=c.tjmxxm ");
            sql.Append(" join tj_tjdjb d on b.tjbh=d.tjbh and b.tjcs=d.tjcs where djlsh='"+jyjg.Djlsh+"' and gjc='"+jyjg.Xmbh+"' and tjlx='06'");

            sqls.Add(sql.ToString());
        }

        /// <summary>
        /// 更新检查医生日期
        /// </summary>
        /// <param name="jyjg"></param>
        /// <param name="sqls"></param>
        private void Update_jcys(Jyjgb jyjg, List<string> sqls)
        {
            sql = new StringBuilder("update b set b.jcys='" + Program.userid + "',b.jcrq=getdate() from tj_tjjlmxb a join tj_tjjlb b on a.xh=b.xh");
            sql.Append(" join TJ_JGXMDZB c on a.tjxm=c.tjmxxm join tj_tjdjb d on b.tjbh=d.tjbh and b.tjcs=d.tjcs ");
            sql.Append("  where djlsh='" + jyjg.Djlsh + "' and gjc='" + jyjg.Xmbh + "' and tjlx='06'");
            sqls.Add(sql.ToString());
        }


        /// <summary>
        /// 保存阳性、进入小结等
        /// </summary>
        /// <param name="yqlx">仪器类型</param>
        /// <param name="value">结果值</param>
        /// <param name="key">结果编号</param>
        /// <param name="tjbh">体检编号</param>
        /// <param name="sqls"></param>
        private void Update_sfyc(Jyjgb jyjg, List<string> sqls)
        {
            sql = new StringBuilder("update a set a.jrxj=case when a.jg='阴性' or a.jg between dy1 and xy1 then 0 else 1 end ,a.mcjrxj=case when a.jg='阴性' or a.jg between dy1 and xy1 then 0 else 1 end ,a.sfyx=case when a.jg='阴性' or a.jg between dy1 and xy1 then 0 else 1 end  "
                    + " from tj_tjjlmxb a join tj_tjjlb b on a.xh=b.xh join TJ_JGXMDZB c on a.tjxm=c.tjmxxm join tj_tjdjb d on b.tjbh=d.tjbh and b.tjcs=d.tjcs  "
                    + " join v_jy_xmjg e on c.gjc=e.xmbh  and d.djlsh=e.djlsh  ");

            sql.Append("where d.djlsh='" + jyjg.Djlsh + "' and gjc='" + jyjg.Xmbh + "'");
            sqls.Add(sql.ToString());

            #region 取体检中的参考值
            //sql = new StringBuilder("select xb,nl,gz from jy_jydj where djid='" + jyjg.Djid + "'");
            //DataTable dt = new DataTable();
            //dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            //if (dt.Rows.Count == 0)
            //{
            //    return;
            //}
            //string xb = dt.Rows[0]["xb"].ToString().Trim();
            //string nl = dt.Rows[0]["nl"].ToString().Trim();
            //string gzmc = dt.Rows[0]["gz"].ToString().Trim();

            //sql = new StringBuilder("select bzdm gzid from xt_zdxm where zdflbm='19' and xmmc='" + gzmc + "'");
            //dt = new DataTable();
            //if (dt.Rows.Count == 0)
            //{
            //    return;
            //}
            //string gzid = dt.Rows[0]["gzid"].ToString().Trim();

            //string tjxm = GetTjxm(jyjg.Xmbh);
            //if (tjxm == "")
            //{
            //    return;
            //}
            //if (nl == "")
            //{
            //    nl = "0";
            //}
            //dt = new DataTable();
            //dt = jgBiz.Get_pro_get_ckz("06", tjxm, xb, Convert.ToInt32(nl), gzid);
            //decimal xx = 0, sx = 0, jg = 0;
            //string jrxj = "0", mcjrxj = "0", sfyx = "0";
            //if (dt.Rows.Count > 0)
            //{
            //    string ckz = dt.Rows[0][0].ToString().Trim();
            //    try
            //    {
            //        xx = Convert.ToDecimal(ckz.Split('—')[0]);
            //        sx = Convert.ToDecimal(ckz.Split('—')[1]);
            //        try
            //        {
            //            jg = Convert.ToDecimal(jyjg.Jg.Trim());
            //            if (jg >= xx && jg <= sx)
            //            {
            //                jrxj = "0";
            //                mcjrxj = "0";
            //                sfyx = "0";
            //            }
            //            else
            //            {
            //                jrxj = "1";
            //                mcjrxj = "1";
            //                sfyx = "1";
            //            }
            //        }
            //        catch
            //        {
            //            if (jyjg.Jg == "阴性")
            //            {
            //                jrxj = "0";
            //                mcjrxj = "0";
            //                sfyx = "0";
            //            }
            //            else
            //            {
            //                jrxj = "1";
            //                mcjrxj = "1";
            //                sfyx = "1";
            //            }

            //        }
            //    }
            //    catch
            //    {
            //        if (jyjg.Jg == "阴性")
            //        {
            //            jrxj = "0";
            //            mcjrxj = "0";
            //            sfyx = "0";
            //        }
            //        else
            //        {
            //            jrxj = "1";
            //            mcjrxj = "1";
            //            sfyx = "1";
            //        }
            //    }
            //}
            //else
            //{
            //    if (jyjg.Jg == "阴性")
            //    {
            //        jrxj = "0";
            //        mcjrxj = "0";
            //        sfyx = "0";
            //    }
            //    else
            //    {
            //        jrxj = "1";
            //        mcjrxj = "1";
            //        sfyx = "1";
            //    }
            //}

            //sql = new StringBuilder("update a set a.jrxj='" + jrxj + "' ,a.mcjrxj='" + mcjrxj + "' ,a.sfyx='" + sfyx + "'  "
            //        + " from tj_tjjlmxb a join tj_tjjlb b on a.xh=b.xh join TJ_JGXMDZB c on a.tjxm=c.tjmxxm join tj_tjdjb d on b.tjbh=d.tjbh and b.tjcs=d.tjcs  "
            //        + " join v_jy_xmjg e on c.gjc=e.xmbh  and d.djlsh=e.djlsh  ");

            //sql.Append("where d.djlsh='" + jyjg.Djlsh + "' and gjc='" + jyjg.Xmbh + "'");
            //sqls.Add(sql.ToString());
            #endregion
        }

        /// <summary>
        /// 从对照表中获取体检项目
        /// </summary>
        /// <param name="gjc"></param>
        /// <returns></returns>
        public string GetTjxm(string gjc)
        {
            sql = new StringBuilder("select tjmxxm from TJ_JGXMDZB where gjc='"+gjc+"'");
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            if (dt.Rows.Count<=0)
            {
                return "";
            }

            return dt.Rows[0][0].ToString().Trim();
        }

        /// <summary>
        /// 判断输入字符中是否存在汉字
        /// </summary>
        /// <param name="strData"></param>
        /// <returns>TRUE：没有汉字</returns>
        public bool HasHz(string strData)
        {
            if (strData == "")
            {
                return false;
            }
            int len = strData.Length;
            int iLen = 0;
            if (strData != null)
            {
                iLen = strData.Length;
                byte[] byteData = new byte[iLen * 2];
                try
                {
                    iLen = Encoding.Default.GetBytes(strData, 0, strData.Length, byteData, 0);
                }
                catch { }
            }
            if (len == iLen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新发布状态
        /// </summary>
        /// <param name="djlsh"></param>
        /// <param name="xmbh"></param>
        /// <param name="sqls"></param>
        public void UpdateJyfb(string djlsh, string xmbh, List<string> sqls)
        {
            sql = new StringBuilder("update jy_jyjgb set sffb=1 where djlsh='"+djlsh+"' and xmbh='"+xmbh+"'");

            sqls.Add(sql.ToString());
        }

        Common.Common comn = new Common.Common();

        /// <summary>
        /// 检验结果发布
        /// </summary>
        /// <param name="jyjgs"></param>
        /// <returns></returns>
        public int JyjgFb(List<Jyjgb> jyjgs,System.Windows.Forms.ProgressBar pb)
        {
            sqls = new List<string>();
            //pb.Minimum = 0;
            //pb.Maximum = jyjgs.Count-1;
            for (int i = 0; i < jyjgs.Count; i++)
            {
                UpdateJg(jyjgs[i], sqls);
                Update_jcys(jyjgs[i], sqls);
                //if (comn.DoubleYzf(jyjgs[i].Jg) != -1)
                //{
                //    Update_sfyc(jyjgs[i], sqls);
                //}
                UpdateJyfb(jyjgs[i].Djlsh, jyjgs[i].Xmbh, sqls);
                //pb.Value = i;
            }
          
            

            return base.SqlDBAgent.sqlupdate(sqls,pb);
        }

        ///// <summary>
        ///// 清空结果
        ///// </summary>
        ///// <param name="djlsh"></param>
        ///// <param name="jyjx"></param>
        ///// <returns></returns>
        //public int Qkjg(string djlsh, string jyjx)
        //{
        //    sql = new StringBuilder("delete from ");
        //}

        /// <summary>
        /// 插入项目结果
        /// </summary>
        /// <param name="xmbh"></param>
        /// <param name="jg"></param>
        /// <returns></returns>
        public int InsertXmjg(string xmbh, string jg)
        {
            sql = new StringBuilder("insert into jy_xmjg(xmbh,jgmc) values('"+xmbh+"','"+jg+"')");
            return base.SqlDBAgent.sqlupdate(sql.ToString());
        }

        /// <summary>
        /// 删除项目结果
        /// </summary>
        /// <param name="xmbh"></param>
        /// <param name="jg"></param>
        /// <returns></returns>
        public int DeleteXmjg(string xmbh, string jg)
        {
            sql = new StringBuilder("delete from jy_xmjg where xmbh='"+xmbh+"' and jgmc='"+jg+"'");
            return base.SqlDBAgent.sqlupdate(sql.ToString());
        }

        /// <summary>
        /// 获取项目结果
        /// </summary>
        /// <param name="xmbh"></param>
        /// <returns></returns>
        public DataTable GetXmjg(string xmbh)
        {
            sql = new StringBuilder("select xmbh,jgmc from jy_xmjg where xmbh='"+xmbh+"'");
            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 判断项目是否存在结果
        /// </summary>
        /// <param name="xmbh"></param>
        /// <returns></returns>
        public bool HasResult(string xmbh)
        {
            sql = new StringBuilder("select count(*) from jy_xmjg where xmbh='" + xmbh + "'");
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql.ToString());
            if (dt.Rows.Count<=0)
            {
                return false;//不存在
            }

            string count=dt.Rows[0][0].ToString().Trim();
            if (Convert.ToInt32(count)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取BC5300检验结果
        /// </summary>
        /// <returns></returns>
        public DataTable GetJyjg(string djlsh, string tjbh, string jyrq)
        {
            sql = new StringBuilder("select SampleID,name,patientno,WBC,Bas#,Bas_Percent,Neu#,Neu_Percent,Eos#,Eos_Percent,Lym#,Lym_Percent,Mon#,Mon_Percent,ALY#,ALY_Percent,LIC#,LIC_Percent,RBC,HGB,MCV,MCH,MCHC,RDW_CV,RDW_SD,HCT,PLT,MPV,PDW,PCT from SampleInfoTable where patientno='" + djlsh + "' ");
            return base.SqlDBAgent2.GetDataTable(sql.ToString());

        }

        /// <summary>
        /// 根据条件查询人员信息
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="djlsh"></param>
        /// <param name="xm"></param>
        /// <returns></returns>
        public DataTable GetTjyfbxx(string from, string to, string djlsh, string xm,string tjdw)
        {
            sql = new StringBuilder("select 0 xz,djlsh,xm,xb,nl,tjbh,tjcs from v_tj_tjdjb where djlsh in(select distinct djlsh from jy_jyjgb) and tjrq>'" + from + "' and tjrq<='" + to + "'");
            if (djlsh!="")
            {
                sql.Append(" and djlsh like '%"+djlsh+"%'");
            }
            if (xm!="")
            {
                sql.Append(" and xm like '%"+xm+"%'");
            }
            if (tjdw!="")
            {
                sql.Append(" and dwbh='"+tjdw+"'");
            }
            sql.Append(" order by djlsh desc");

            return base.SqlDBAgent.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 获取BC3000结果
        /// </summary>
        /// <param name="djlsh"></param>
        /// <returns></returns>
        public DataTable GetBC3000Jg(string djlsh)
        {
            sql = new StringBuilder("select ItemCode,strValue,Unit from tblTestResult a join tblSpecimenInfo b on a.SpecimenID=b.SpecimenID and Convert(varchar(10),InspectDate,120)=Convert(varchar(10),InspectTime,120)  where PatientID='" + djlsh + "'");

            return base.SqlDBAgentBC3000.GetDataTable(sql.ToString());
        }

        /// <summary>
        /// 体检人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_tjryxx(string tjrq1, string tjrq2, string xm, string djlsh)
        {
            string strSql;
            if (xm == "" && djlsh == "")
            {
                strSql = "select distinct xz,tjbh,djlsh,djrq,xm,xb,nl,dwmc from v_jy_jybgdy where shrq>='" + tjrq1 + "' and shrq<'" + tjrq2 + "'";
            }
            else
            {
                strSql = "select distinct xz,tjbh,djlsh,djrq,xm,xb,nl,dwmc from v_jy_jybgdy where xm like '%" + xm + "%' or djlsh like '%" + djlsh + "%'";
            }
            return base.SqlDBAgent.GetDataTable(strSql);
        }
    }

}
