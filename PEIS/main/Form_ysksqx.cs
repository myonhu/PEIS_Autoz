using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEIS.ywsz;

namespace PEIS.main
{
    public partial class Form_ysksqx : MdiChildrenForm
    {
        int mark = 0;
        List<string> listRoleID = new List<string>();
        public Form_ysksqx()
        {
            InitializeComponent();
        }

        private void Form_ysksqx_Load(object sender, EventArgs e)
        {
            dgv_czy.AutoGenerateColumns = false;
            xtggBiz xtggbiz = new xtggBiz();
            dgv_czy.DataSource = xtggbiz.Get_xt_czy();
            ywszBiz ywszbiz = new ywszBiz();
            //增加科室树
            DataTable kstable =  ywszbiz.Get_tj_tjlxb();
            if (kstable != null)
            {

                advTree1.ImageList = imageList1;
                advTree1.CheckBoxImageUnChecked = imageList1.Images[1];
                advTree1.CheckBoxImageChecked = imageList1.Images[2];
                advTree1.Nodes.Clear();
                DevComponents.AdvTree.Node nodeFather;
                nodeFather = new DevComponents.AdvTree.Node();
                nodeFather.Text = "科室已分权限";
                nodeFather.Tag = "";
                nodeFather.Name = "";
                nodeFather.ImageIndex = 0;
                nodeFather.CheckBoxVisible = true;
                advTree1.Nodes.Add(nodeFather);
                //
                for (int i = 0; i < kstable.Rows.Count; i++)
                {
                    DevComponents.AdvTree.Node nod = new DevComponents.AdvTree.Node();
                    nod.CheckBoxVisible = true;
                    nod.Text = kstable.Rows[i]["mc"].ToString();
                    nod.Tag = kstable.Rows[i]["lxbh"].ToString();
                    //nod.Name = plist[i].ToString();//利用name tag 是否相同 来判断是否父节点
                    nodeFather.Nodes.Add(nod);
                }
                advTree1.ExpandAll();
            }
        }

        private void dgv_czy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listRoleID.Clear();
            if (e.RowIndex >= 0)
            {

                xtggBiz biz = new xtggBiz();

                DataTable newDt = biz.Get_xt_ysksqx(dgv_czy.Rows[e.RowIndex].Cells["czybm"].Value.ToString());
                if (newDt != null)
                {
                    foreach (DataRow dr in newDt.Rows)
                    {
                        listRoleID.Add(dr["KsID"].ToString());
                    }
                }

                //递归判断是否节点在泛型中 有就选中
                isChecked(listRoleID, advTree1.Nodes[0].Nodes);
            }
        }

        //根据权限iD树形树打勾
        private void isChecked(List<string> listID, DevComponents.AdvTree.NodeCollection aNode)
        {
            foreach (DevComponents.AdvTree.Node node in aNode)
            {
                if (node.Tag.ToString() == "")//顶节点
                    continue;
                if (listID.Contains(node.Tag.ToString()))
                {
                    node.Checked = true;
                }
                else
                {
                    node.Checked = false;
                }
                if (node.Nodes.Count > 0)
                    isChecked(listID, node.Nodes);
            }
        }

        private void advTree1_AfterCheck(object sender, DevComponents.AdvTree.AdvTreeCellEventArgs e)
        {
            if (advTree1.SelectedNode != null && mark == 1)
            {
                SetNodeCheckStatus(advTree1.SelectedNode, advTree1.SelectedNode.Checked);

            }
        }

        private void advTree1_MouseDown(object sender, MouseEventArgs e)
        {
            if (advTree1.SelectedNode != null)
            {
                mark = 1;
            }
        }

        /// <summary>
        /// 设置节点下所有节点选中状态
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="Checked"></param>
        private void SetNodeCheckStatus(DevComponents.AdvTree.Node tn, bool Checked)
        {
            if (tn == null)
                return;
            foreach (DevComponents.AdvTree.Node tnChild in tn.Nodes)
            {
                tnChild.Checked = Checked;
                SetNodeCheckStatus(tnChild, Checked);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgv_czy.CurrentRow == null)
                return;
            SaveData(ref listRoleID, advTree1, 1);
        }

        private void SaveData(ref List<string> tmpList, DevComponents.AdvTree.AdvTree treeView, int typeClass)
        {
            List<string> delRoleID = new List<string>();
            List<string> addRoleID = new List<string>();
            FindDiff(ref addRoleID, treeView.Nodes[0].Nodes);
            //获取取消勾的节点
            IEnumerable<string> onlyDel = tmpList.Except(addRoleID);
            //获取新加入勾的节点
            IEnumerable<string> onlyAdd = addRoleID.Except(tmpList);
            if (onlyDel.Count() == 0 && onlyAdd.Count() == 0)
            {
                MessageBox.Show("没有修改任何权限", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            xtggBiz xtggbiz = new xtggBiz();
            bool isDone = xtggbiz.SaveYsKs(dgv_czy.CurrentRow.Cells["czybm"].Value.ToString(), onlyDel, onlyAdd);
            if (isDone)
            {
                tmpList = addRoleID;
                MessageBox.Show("保存功能权限成功");
            }
            else
            {
                MessageBox.Show("保存功能权限失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindDiff(ref List<string> addRoleID, DevComponents.AdvTree.NodeCollection aNode)
        {
            foreach (DevComponents.AdvTree.Node node in aNode)
            {
                if (node.Tag.ToString() == "")//顶节点
                    continue;
                if (node.Checked)
                {
                    addRoleID.Add(node.Tag.ToString());
                }
                if (node.Nodes.Count > 0)
                    FindDiff(ref addRoleID, node.Nodes);
            }
        }
    }
}
