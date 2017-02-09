using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using PEIS.cxgl;
using System.Drawing;
namespace PEIS
{
    class mainBiz : Base
    {
        MainForm objmainForm = new MainForm();
       
        public MenuStrip GetMenuList(MenuStrip mMain, int yhzid,MainForm mainForm)
        {
            objmainForm = mainForm;
            DataTable menuDataTable = new DataTable();
            //string strSql = "select yhzid,qxid,xt_yhzgnqx.sjqx,qxmc,ctmc,ctcs from xt_yhzgnqx join xt_gn on xt_yhzgnqx.gnid = xt_gn.gnid  where xt_yhzgnqx.sjqx = 0 and yhzid = " + yhzid + " order by xt_yhzgnqx.xssx";
            string strSql = "select a.yhzid,a.qxid,a.sjid sjqx,a.qxmc,b.ctmc,b.ctcs from xt_yhzqx a join xt_gn b on a.gnid = b.gnid  where a.sjid = 0 and a.yhzid = " + yhzid + " order by a.xssx";
            menuDataTable = base.SqlDBAgent.GetDataTable(strSql);
            if (menuDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < menuDataTable.Rows.Count; i++)
                {
                    Console.WriteLine(menuDataTable.Rows[i]["ctmc"].ToString());
                    if (menuDataTable.Rows[i][2].ToString() == "0")
                    {
                        ToolStripMenuItem mItem = new ToolStripMenuItem(menuDataTable.Rows[i]["qxmc"].ToString());
                        mItem.Name = menuDataTable.Rows[i]["ctmc"].ToString();
                        //mItem.Click += new EventHandler(menuItem_Click);
                        mMain.Items.Add(mItem);
                        CreateChildMenu(mItem, yhzid,  Convert.ToInt16(menuDataTable.Rows[i]["qxid"].ToString()));
                    }
                }
            }
            return mMain;
        }

        protected void CreateChildMenu(ToolStripMenuItem parentItem, int yhzid, int sjid)
        {
            string strSql;
            DataTable menuDataTable = new DataTable();
            //strSql = "select yhzid,qxid,xt_yhzgnqx.sjqx,qxmc,ctmc,ctcs from xt_yhzgnqx join xt_gn on xt_yhzgnqx.gnid = xt_gn.gnid where xt_yhzgnqx.sjqx = " + sjid + " and yhzid = " + yhzid + " order by xt_yhzgnqx.xssx";
            strSql = "select a.yhzid,a.qxid,a.sjid sjqx,a.qxmc,b.ctmc,b.ctcs from xt_yhzqx a join xt_gn b on a.gnid = b.gnid where a.sjid = " + sjid + " and a.yhzid = " + yhzid + " order by a.xssx";
            menuDataTable = base.SqlDBAgent.GetDataTable(strSql);

            for (int i = 0; i < menuDataTable.Rows.Count; i++)
            {
                ToolStripMenuItem mItem = new ToolStripMenuItem(menuDataTable.Rows[i]["qxmc"].ToString());
                mItem.Name = menuDataTable.Rows[i]["ctmc"].ToString();
                mItem.Click += new EventHandler(menuItem_Click);
                parentItem.DropDownItems.Add(mItem);
                CreateChildMenu(mItem, yhzid, Convert.ToInt16(menuDataTable.Rows[i]["qxid"].ToString()));  //递归显示出子节点 
            }
        }
        private void menuItem_Click(object sender, System.EventArgs e)
        {
            string[] formArg = null;
            ToolStripItem menuItem = (ToolStripItem)sender;

            //传视图
            string name = menuItem.Text;
            FormArg.Name = name;//窗体名称
            FormArg.Name = name;//窗体名称
            string sql = "select ctcs from xt_gn where gnmc='" + name + "'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                FormArg.Arg = dt.Rows[0][0].ToString();//视图名称
            }
            string formName = menuItem.Name;

            if (formName.Length <= 0)
            {
                return;
            }
            try
            {
                Type Dlg;
                if (formName.Substring(0, 4) == "MZGL")
                {
                    Assembly assembly = Assembly.LoadFrom(Application.StartupPath + @"/MZGL.dll");
                    Dlg = assembly.GetType(formName);
                }
                else if (formName.Substring(0, 4) == "MZYS")
                {
                    Assembly assembly = Assembly.LoadFrom(Application.StartupPath + @"/MZYS.dll");
                    Dlg = assembly.GetType(formName);
                }
                else
                {
                    Dlg = Type.GetType(formName);
                }
                if (!ShowChildrenForm(menuItem.Name))
                {
                    Form f = (Form)Dlg.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, formArg);
                    f.MdiParent = objmainForm;
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //判断窗体是否以打开
        private bool ShowChildrenForm(string Formname)
        {
            int i;
            //依次检测当前窗体的子窗体
            for (i = 0; i < objmainForm.MdiChildren.Length; i++)
            {
                //判断当前子窗体的Text属性值是否与传入的字符串值相同
                if (objmainForm.MdiChildren[i].Name == Formname)
                {
                    //如果值相同则表示此子窗体为想要调用的子窗体，激活此子窗体并返回true值
                    objmainForm.MdiChildren[i].Activate();
                    return true;
                }
            }
            //如果没有相同的值则表示要调用的子窗体还没有被打开，返回false值
            return false;
        }
        /////////////////////////////////////////////*********************************************************************************////////////////////////////////
        /// <summary>
        /// 获取系统字典属性
        /// </summary>
        /// <returns></returns>
        public DataTable Get_xt_zdsx()
        {
            string strSql;
            strSql = "select distinct flsx from xt_zdfl order by flsx";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取系统字典分类
        /// </summary>
        /// <param name="flsx">字典分类属性</param>
        /// <returns></returns>
        public DataTable Get_xt_zdfl(string flsx)
        {
            string strSql;
            strSql = "select zdflbm,ltrim(rtrim(zdflmc)) zdflmc from xt_zdfl where flsx='" + flsx + "' order by zdflbm";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 获取字典项目
        /// </summary>
        /// <param name="zdflbm">字典分类编码</param>
        /// <returns></returns>
        public DataTable Get_xt_zdxm(string zdflbm)
        {
            string strSql;
            strSql = "select xh,bzdm,xmmc,lb lbbh,tybz from xt_zdxm where zdflbm='" + zdflbm + "' order by xh";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 删除字典明细项目
        /// </summary>
        /// <param name="zdflbm">字典分类编码</param>
        /// <param name="xh">序号</param>
        /// <returns></returns>
        public int Delete_xt_zdxm(string zdflbm, string xh)
        {
            string strSql;
            strSql = "delete xt_zdxm where zdflbm='" + zdflbm + "' and xh='" + xh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        /// <summary>
        /// 判断项目名称是否已存在
        /// </summary>
        /// <param name="xmmc"></param>
        /// <param name="zdflbm"></param>
        /// <returns></returns>
        public bool HasExist(string xmmc, string zdflbm)
        {
            string strSql = "select count(*) from xt_zdxm where zdflbm='"+zdflbm+"' and xmmc ='"+xmmc+"'";
            DataTable dt = new DataTable();
            dt = base.SqlDBAgent.GetDataTable(strSql);
            if (dt.Rows.Count<=0)
            {
                return false;//不存在
            }

            string count=dt.Rows[0][0].ToString().Trim();
            if (count == "") count = "0";
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
        /// 添加字典项目内容
        /// </summary>
        /// <param name="zdflbm">字典分类编码</param>
        /// <param name="xmmc">项目名称</param>
        /// <param name="bzdm">标准代码</param>
        /// <param name="tybz">停用标志</param>
        /// <returns></returns>
        public int Insert_xt_zdxm(string zdflbm, string xmmc, string bzdm, string tybz,string lb)
        {
            string strSql;
            strSql = "select isnull(max(xh)+1,1) from xt_zdxm where zdflbm='" + zdflbm + "'";
            string str_xh = base.SqlDBAgent.sqlvalue(strSql).ToString();
            strSql = "insert xt_zdxm(zdflbm,xh,xmmc,bzdm,tybz,lb) select '" + zdflbm + "','" + str_xh + "','" + xmmc + "','" + bzdm + "','" + tybz + "','"+lb+"'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        /// <summary>
        /// 添加字典项目内容
        /// </summary>
        /// <param name="zdflbm">字典分类编码</param>
        /// <param name="xmmc">序号</param>
        /// <param name="xmmc">项目名称</param>
        /// <param name="bzdm">标准代码</param>
        /// <param name="tybz">停用标志</param>
        /// <returns></returns>
        public int Update_xt_zdxm(string zdflbm, string xh, string xmmc, string bzdm, string tybz,string lb)
        {
            string strSql;
            strSql = "update xt_zdxm set xmmc='" + xmmc + "',bzdm='" + bzdm + "',tybz='" + tybz + "',lb='"+lb+"' where zdflbm='" + zdflbm + "' and xh='" + xh + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        /// <summary>
        /// 增加图片
        /// </summary>
        /// <param name="imagelist"></param>
        public void AddImages(ImageList imagelist)
        {
            Image zkjd = Image.FromFile(Application.StartupPath + @"\img\a.bmp");
            imagelist.Images.Add(zkjd);
            Image gbjd = Image.FromFile(Application.StartupPath + @"\img\b.bmp");
            imagelist.Images.Add(gbjd);
            Image qy = Image.FromFile(Application.StartupPath + @"\img\启用.gif");
            imagelist.Images.Add(qy);
            Image ty = Image.FromFile(Application.StartupPath + @"\img\停用.gif");
            imagelist.Images.Add(ty);
            Image zh = Image.FromFile(Application.StartupPath + @"\img\c.bmp");
            imagelist.Images.Add(zh);
            Image tc = Image.FromFile(Application.StartupPath + @"\img\d.bmp");
            imagelist.Images.Add(tc);
            Image xm = Image.FromFile(Application.StartupPath + @"\img\e.bmp");
            imagelist.Images.Add(xm);

            //Image five = Image.FromFile(Application.StartupPath + @"\img\video.jpg");
            //imagelist.Images.Add(five);
        }

        /// <summary>
        /// 为树添加图标
        /// </summary>
        /// <param name="tn"></param>
        public void AddImage(TreeNode tn)
        {
            foreach (TreeNode node in tn.Nodes)
            {
                if (node.Nodes.Count > 0)
                {

                    if (node.IsExpanded)
                    {
                        node.ImageIndex = 0;
                    }
                    else
                    {
                        node.ImageIndex = 1;
                    }

                    AddImage(node);
                }
                //else
                //{

                //    if (node.ForeColor == Color.Blue)
                //    {
                //        node.ImageIndex = 2;
                //    }
                //    else
                //    {
                //        node.ImageIndex = 3;

                //    }
                //}
            }
        }
    }
}
