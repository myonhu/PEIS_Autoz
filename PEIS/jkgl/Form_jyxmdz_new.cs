using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jkgl
{
    public partial class Form_jyxmdz_new : PEIS.MdiChildrenForm
    {
        string str_JykCode = "";//检验科代码
        xtBiz xtbiz = new xtBiz();
        LisBiz lisbiz = new LisBiz();
        DataTable dt_TJ_JGXMDZB;

        public Form_jyxmdz_new()
        {
            InitializeComponent();
        }
        private void DataBind()
        {
            str_JykCode = xtbiz.GetXtCsz("JykCode");//检验科代码

            DataTable dt_tj_lclxb = lisbiz.Get_TJ_LCLXB();
            foreach (DataRow dr in dt_tj_lclxb.Rows)
            {
                TreeNode node1 = new TreeNode(dr["mc"].ToString());
                string str_lclx = dr["lclx"].ToString();

                DataTable dt_tj_tjxmb = lisbiz.Get_TJ_TJXMB(str_JykCode, str_lclx);
                foreach (DataRow drs in dt_tj_tjxmb.Rows)
                {
                    TreeNode node2 = new TreeNode();
                    node2.Text = drs["mc"].ToString();
                    node2.Tag = drs["tjxm"].ToString();
                    node1.Nodes.Add(node2);
                }

                tv_jyxm.Nodes.Add(node1);
            }
        }
        private void frm_jyxmdz_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void tv_jyxm_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (object.Equals(e.Node.Tag, null))
                return;
            txt_tjxmmc.Text = e.Node.Text;
            txt_tjxtbh.Text = e.Node.Tag.ToString();

            dt_TJ_JGXMDZB = lisbiz.Get_TJ_JGXMDZB(e.Node.Tag.ToString());
            dgv_jgxmdzb.DataSource = dt_TJ_JGXMDZB;
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            string tjmxxm = txt_tjxtbh.Text.Trim();
            LisBiz lisbiz1 = new LisBiz();
            lisbiz1.str_Delete_TJ_JGXMDZB(tjmxxm);
            dt_TJ_JGXMDZB.AcceptChanges();
            foreach (DataRow dr in dt_TJ_JGXMDZB.Rows)
            {
                string jyjx = dr["jyjx"].ToString().Trim();
                string gjc = dr["gjc"].ToString().Trim();
                string sm = dr["sm"].ToString().Trim();
                if (jyjx != "" && gjc != "")
                    lisbiz1.str_Insert_TJ_JGXMDZB(tjmxxm, jyjx, gjc, sm);
            }
            lisbiz1.Exec_ArrayList();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}