using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace PEIS.main
{
    class xtggBiz :Base
    {
        /// <summary>
        /// 获取所有用户组信息
        /// </summary>
        /// <returns></returns>
        public DataTable Get_xt_yhz()
        {
            string strSql;
            strSql = "select yhzid,yhzmc,ms,xssx from xt_yhz order by xssx";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        /// <summary>
        /// 保存修改所有用户组信息
        /// </summary>
        /// <param name="objDataTable"></param>
        /// <returns></returns>
        public DataTable Update_xt_yhz(DataTable objDataTable)
        {
            string strSql;
            strSql = "select yhzid,yhzmc,ms,xssx from xt_yhz";
            return base.SqlDBAgent.Update(objDataTable, strSql);
        }
        //**********************************************
        public DataTable Get_xt_gn(int sjid)
        {
            string strSql;
            strSql = "select gnmc,ctmc,ctcs,gnid,sjid from xt_gn where sjid = " + sjid.ToString();
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Update_xt_gn(DataTable objDataTable)
        {
            string strSql;
            strSql = "select gnmc,ctmc,ctcs,gnid,sjid from xt_gn";
            return base.SqlDBAgent.Update(objDataTable, strSql);
        }

        public TreeNode GetTreeList()
        {

            TreeNode node = new TreeNode();
            node.Text = "系统功能";
            node.Name = "0";
            CreateChildTree(node, 0);
            return node;
        }

        protected void CreateChildTree(TreeNode parentNode, int parentID)        //创建树
        {
            string strSql;
            DataTable treeDataTable = new DataTable();
            strSql = "select gnmc,gnid from xt_gn where sjid = " + parentID.ToString();
            treeDataTable = base.SqlDBAgent.GetDataTable(strSql);

            for (int i = 0; i < treeDataTable.Rows.Count; i++)
            {
                TreeNode tNode = new TreeNode(treeDataTable.Rows[i][0].ToString());
                tNode.Name = treeDataTable.Rows[i][1].ToString();
                parentNode.Nodes.Add(tNode);
                CreateChildTree(tNode, Convert.ToInt16(treeDataTable.Rows[i][1].ToString()));  //递归显示出子节点 
            }
        }
        //*********************************************************************************************
        public DataTable Get_xt_yhzqx_sort(int sjid, int yhzid)
        {
            string strSql;
            strSql = "select qxid,qxmc,xssx from xt_yhzqx where sjid = " + sjid + " and yhzid = " + yhzid + " order by xssx";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Update_xt_yhzqx(DataTable objDataTable, int sjid, int yhzid)
        {
            string strSql;
            strSql = "select qxid,qxmc,xssx from xt_yhzqx where sjid = " + sjid + " and yhzid = " + yhzid + " order by xssx";
            return base.SqlDBAgent.Update(objDataTable, strSql);
        }
        //****************************************************************************************
        public DataTable Get_xt_yhzqx(int yhzid)
        {
            string strSql;
            strSql = "select xt_yhzqx.yhzid,gnid,sjid,xt_yhzqx.xssx,yhzmc,sm from xt_yhzqx, xt_yhz where xt_yhzqx.yhzid = xt_yhz.yhzid and xt_yhzqx.yhzid =" + yhzid.ToString();
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        public DataTable Update_xt_yhzqx(DataTable objDataTable)
        {
            string strSql;
            strSql = "select yhzid,gnid,sjid,xssx from xt_yhzqx";
            return base.SqlDBAgent.Update(objDataTable, strSql);
        }

        public void CreateChildTree1(TreeNodeCollection parentNode, int parentID, int yzhid)        //创建树
        {
            string strSql;
            DataTable treeDataTable = new DataTable();
            strSql = "select distinct a.gnid,gnmc,a.sjid ,case when b.gnid is null then 0 else 1 end gnbz ";
            strSql = strSql + "from xt_gn a left join xt_yhzqx b on a.gnid= b.gnid  and b.yhzid = " + yzhid + " where a.sjid = " + parentID; 

            treeDataTable = base.SqlDBAgent.GetDataTable(strSql);

            for (int i = 0; i < treeDataTable.Rows.Count; i++)
            {
                TreeNode tNode = new TreeNode(treeDataTable.Rows[i][1].ToString());
                tNode.Name = treeDataTable.Rows[i][0].ToString();

                if (treeDataTable.Rows[i][3].ToString() == "1")
                {
                    //tNode.Checked = true;
                    tNode.ForeColor = Color.Gray;
                }
                parentNode.Add(tNode);
                CreateChildTree1(tNode.Nodes, Convert.ToInt16(treeDataTable.Rows[i][0].ToString()), yzhid);  //递归显示出子节点 
            }
        }

        public TreeNode GetTreeList(int yhzid, string yhzmc)
        {

            TreeNode node = new TreeNode();
            node.Text = "用户组[" + yhzmc + "]功能";
            node.Tag = "0";
            node.Name = "0";
            CreateChildTree2(node, 0, yhzid);
            return node;

        }

        protected void CreateChildTree2(TreeNode parentNode, int parentID, int yhzid)        //创建树
        {
            string strSql;
            DataTable treeDataTable = new DataTable();
            strSql = "select gnid,qxmc,sjid,xssx,qxid from xt_yhzqx where yhzid = " + yhzid + " and sjid = " + parentID + " order by xssx";
            treeDataTable = base.SqlDBAgent.GetDataTable(strSql);

            for (int i = 0; i < treeDataTable.Rows.Count; i++)
            {
                TreeNode tNode = new TreeNode(treeDataTable.Rows[i]["qxmc"].ToString());
                tNode.Name = treeDataTable.Rows[i]["qxid"].ToString();
                tNode.Tag = treeDataTable.Rows[i]["gnid"].ToString();
                parentNode.Nodes.Add(tNode);
                CreateChildTree2(tNode, Convert.ToInt32(treeDataTable.Rows[i]["qxid"].ToString()), yhzid);  //递归显示出子节点 
            }
        }

        private string ls_gn = "";
        public void saveTreeView(TreeNodeCollection objTreeNode, int yhzid, int sjid)
        {
            treeViewToStr(objTreeNode);
            SqlParameter objyhzid = new SqlParameter();
            SqlParameter objgn = new SqlParameter();
            SqlParameter objsjid = new SqlParameter();
            objyhzid.ParameterName = "@yhzid";
            objgn.ParameterName = "@gnids";
            objsjid.ParameterName = "@sjqxid";

            objyhzid.SqlDbType = SqlDbType.Int;
            objyhzid.Value = yhzid;

            objgn.SqlDbType = SqlDbType.VarChar;
            objgn.Size = 8000;

            objgn.Value = ls_gn;
            objsjid.SqlDbType = SqlDbType.Int;
            objsjid.Value = sjid;
            SqlParameter[] objParameterName = new SqlParameter[] { objyhzid, objgn, objsjid };
            base.SqlDBAgent.SetPro("pro_xt_yhzgnqx_sc", objParameterName);

        }

        public int delTreeView(int qxid)
        {
            string strSql;
            strSql = "delete from xt_yhzqx where qxid = " + qxid;
            return base.SqlDBAgent.sqlupdate(strSql);
        }

        protected void treeViewToStr(TreeNodeCollection objTreeNode)
        {

            for (int i = 0; i < objTreeNode.Count; i++)
            {
                if (objTreeNode[i].Name != "0" && objTreeNode[i].Checked == true)
                {
                    ls_gn = ls_gn + objTreeNode[i].Name + ",";
                }
                treeViewToStr(objTreeNode[i].Nodes);
            }
        }

        public int udpate_xt_yhzqx_mc(int qxid, string qxmc)
        {
            string strSql;
            strSql = "update xt_yhzqx set qxmc = '" + qxmc + "' where qxid = " + qxid;
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        //***********************************************************************************
        public DataTable Get_xt_czy()
        {
            string strSql;
            strSql = "select czyid,czymc,czybm from xt_czy";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public DataTable Get_xt_czy(string czyid)
        {
            string strSql;
            strSql = "select czyid,czymc,yhzid,mm,czybm,rysx,tybz,ksid,bz from xt_czy where czyid='" + czyid + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        public int Insert_xt_czy(string czyid, string czymc, string czybm, string yhzid, string mm, string rysx, string tybz, string ksid,string bz)
        {
            string strSql;
            strSql = "delete xt_czy where czyid='" + czyid + "';";
            strSql = strSql + "insert xt_czy(czyid,czymc,czybm,yhzid,mm,rysx,tybz,ksid,bz) select '" + czyid + "','" + czymc + "','"
                + czybm + "','" + yhzid + "','" + mm + "','" + rysx + "','" + tybz + "','" + ksid + "','" + bz + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Delete_xt_czy(string czyid)
        {
            string strSql;
            strSql = "delete xt_czy where czyid='" + czyid + "'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public int Exists_xt_czy(string czyid)
        {
            string strSql;
            strSql = "select count(1) from tj_tjjlb where czy='" + czyid + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public int Exists_xt_czybm(string czybm)
        {
            string strSql;
            strSql = "select count(1) from xt_czy where czybm='" + czybm + "'";
            return Convert.ToInt32(base.SqlDBAgent.sqlvalue(strSql));
        }
        public int Insert_Reg(string reg, string mac, string yymc)
        {
            string strSql;
            strSql = "delete from xt_reg;";
            strSql = strSql + "insert xt_reg (reg,mac) select '" + reg + "','" + mac + "';";
            strSql = strSql + "update xt_cssz set csz='" + yymc + "' where csbm='TjDwMc'";
            return base.SqlDBAgent.sqlupdate(strSql);
        }
        public DataTable Get_xt_reg()
        {
            string strSql;
            strSql = "select reg from xt_reg";
            return base.SqlDBAgent.GetDataTable(strSql);
        }

        /// <summary>
        /// 获取医生科室设置权限
        /// </summary>
        /// <returns></returns>
        public DataTable Get_xt_ysksqx(string userID)
        {
            string strSql;
            strSql = "select * from xt_ysks where UserID='" + userID + "'";
            return base.SqlDBAgent.GetDataTable(strSql);
        }
        //-------------------------//

        private string AddKsString(string UserID, string PermissionsID)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            strSql1.Append("UserID,");
            strSql2.Append("'" + UserID + "',");
            strSql1.Append("KsID,");
            strSql2.Append("'" + PermissionsID + "',");
            strSql.Append("insert into xt_ysks(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();

        }
        private string DelKsString(string UserID, string KsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from xt_ysks ");
            strSql.Append(" where UserID='" + UserID + "' and KsID='" + KsID + "'");
            return strSql.ToString();
        }

        /// <summary>
        /// 保存数据医生科室配置
        /// </summary>
        public bool SaveYsKs(string UserID, IEnumerable<string> onlyDelPessision, IEnumerable<string> onlyAddPessision)
        {
            List<string> list = new List<string>();
            foreach (string item in onlyDelPessision)
            {
                list.Add(DelKsString(UserID, item));
            }
            foreach (string item in onlyAddPessision)
            {
                list.Add(AddKsString(UserID, item));
            }
            return base.SqlDBAgent.ExecuteSqlTran(list);
        }
    }
}
