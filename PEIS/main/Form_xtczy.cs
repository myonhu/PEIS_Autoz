using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.ywsz;
namespace PEIS.main
{
    public partial class Form_xtczy : MdiChildrenForm
    {
        public Form_xtczy()
        {
            InitializeComponent();
        }
        string str_zt = "Update";
        xtggBiz xtggbiz = new xtggBiz();
        ywszBiz ywszbiz = new ywszBiz();
        xtBiz xtbiz = new xtBiz();
        private void Form_xtczy_Load(object sender, EventArgs e)
        {
            dgv_czy.DataSource = xtggbiz.Get_xt_czy();

            cmb_yhz.DataSource = xtggbiz.Get_xt_yhz();//用户组
            cmb_yhz.DisplayMember = "yhzmc";
            cmb_yhz.ValueMember = "yhzid";

            cmb_rysx.DataSource = xtbiz.GetXtZd(13);//人员属性
            cmb_rysx.DisplayMember = "xmmc";
            cmb_rysx.ValueMember = "bzdm";

            cmb_ks.DataSource = ywszbiz.Get_tj_tjlxb();//科室
            cmb_ks.DisplayMember = "mc";
            cmb_ks.ValueMember = "lxbh";
        }

        private void dgv_czy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow dgr = dgv_czy.SelectedRows[0];
            string str_czyid = dgr.Cells["czyid"].Value.ToString().Trim();

            DataTable dt = xtggbiz.Get_xt_czy(str_czyid);
            txt_czyid.Text = dt.Rows[0]["czyid"].ToString().Trim();
            txt_czymc.Text = dt.Rows[0]["czymc"].ToString().Trim();
            txt_czybm.Text = dt.Rows[0]["czybm"].ToString().Trim();
            txt_mm.Text = dt.Rows[0]["mm"].ToString().Trim();
            txt_bz.Text = dt.Rows[0]["bz"].ToString().Trim();
            //cmb_rysx.SelectedValue = dt.Rows[0]["rysx"].ToString().Trim();
            cmb_rysx.Text = dt.Rows[0]["rysx"].ToString().Trim();
            cmb_yhz.SelectedValue = dt.Rows[0]["yhzid"].ToString().Trim();
            cmb_ks.SelectedValue = dt.Rows[0]["ksid"].ToString().Trim();

            string str_tybz = dt.Rows[0]["tybz"].ToString().Trim();
            if (str_tybz == "1") ckb_sfty.Checked = true; else ckb_sfty.Checked = false;
            
            str_zt = "Update";
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ClearControl()
        {
            txt_czyid.Text = "";
            txt_czymc.Text = "";
            txt_czybm.Text = "";
            txt_mm.Text = "";
            cmb_rysx.SelectedIndex = -1;
            cmb_yhz.SelectedIndex = -1;
            cmb_ks.SelectedIndex = -1;
            ckb_sfty.Checked = false;
        }
        private void bt_add_Click(object sender, EventArgs e)
        {
            ClearControl();
            str_zt = "Insert";
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (txt_czymc.Text.Trim() == "")
            {
                MessageBox.Show("请填写操作员名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_czymc;
                return;
            }
            if (txt_mm.Text.Trim() == "")
            {
                MessageBox.Show("请填写密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_mm;
                return;
            }
            if (object.Equals(null, cmb_yhz.SelectedValue))
            {
                MessageBox.Show("请选择用户组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_yhz;
                return;
            }
            if (str_zt == "Insert" && xtggbiz.Exists_xt_czybm(txt_czybm.Text.Trim()) > 0)
            {
                MessageBox.Show("该操作员编码已被使用，请修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_czybm;
                return;
            }
            if (txt_czyid.Text.Trim() == "")
            {
                txt_czyid.Text = ywszbiz.Get_MaxStr("xt_czy", "czyid");
            }
            string str_yhz="";
            if(!object.Equals(null,cmb_yhz.SelectedValue)) str_yhz=cmb_yhz.SelectedValue.ToString().Trim();
            string str_ks="";
            if(!object.Equals(null,cmb_ks.SelectedValue)) str_ks=cmb_ks.SelectedValue.ToString().Trim();
            string str_rysx = cmb_rysx.Text.Trim();
            string str_tybz="0";
            if(ckb_sfty.Checked) str_tybz="1";
            xtggbiz.Insert_xt_czy(txt_czyid.Text.Trim(), txt_czymc.Text.Trim(), txt_czybm.Text.Trim(), str_yhz, txt_mm.Text.Trim(), str_rysx, str_tybz, str_ks,txt_bz.Text.Trim());
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv_czy.DataSource = xtggbiz.Get_xt_czy();
            str_zt = "Update";
        }


        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (txt_czyid.Text.Trim() == "") return;
            if (Program.czylx!="系统"&&Program.czylx!="管理")
            {
                MessageBox.Show("您不是系统管理员，无权删除操作员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //检查是否引用
            if (xtggbiz.Exists_xt_czy(txt_czyid.Text.Trim()) > 0)
            {
                MessageBox.Show("该操作员被引用了，不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            xtggbiz.Delete_xt_czy(txt_czyid.Text.Trim());
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearControl();
            dgv_czy.DataSource = xtggbiz.Get_xt_czy();
            str_zt = "Update";
        }

    }
}