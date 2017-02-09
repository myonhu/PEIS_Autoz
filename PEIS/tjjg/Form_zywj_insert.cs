using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.xtgg;
using PEIS.tjdj;

namespace PEIS.tjjg
{
    public partial class Form_zywj_insert : PEIS.MdiChildrenForm
    {
        public string str_tjbh = "";//体检编号
        public string str_tjcs = "";//体检次数
        string str_djlsh="";//登记流水号

        xtBiz xtbiz = new xtBiz();
        tjdjBiz tjdjbiz = new tjdjBiz();
        tjjgBiz tjjgbiz = new tjjgBiz();

        public Form_zywj_insert()
        {
            InitializeComponent();
        }

        public Form_zywj_insert(string tjbh,string tjcs)
        {
            InitializeComponent();
            str_tjbh = tjbh;
            str_tjcs = tjcs;
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (str_tjbh == "") return;
            DialogResult result = MessageBox.Show("您将删除姓名为【" + txt_xm.Text.Trim() + "】的登记信息,是否继续？", "删除登记信息",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No)
            {
                return;
            }
            //string str_delete = xtbiz.GetXtCsz("TjDelete");//0不做任何限制，可以删除；1录入了体检数据后不允许删除；2总检后不允许删除
            //int str_sumover = tjdjbiz.Get_SumOver(str_tjbh, str_tjcs);//0新录入 1录入数据了 2总检了
            //if (str_delete == "1" && str_sumover > 0)
            //{
            //    MessageBox.Show("已经录入了资料的人员不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (str_delete == "2" && str_sumover > 1)
            //{
            //    MessageBox.Show("已经总检的人员不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            tjdjbiz.Delete_TJ_TJDJB(str_tjbh, str_tjcs);
            MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            str_tjbh = "";
            str_tjcs = "";
            this.DialogResult = DialogResult.OK;
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (txt_xm.Text.Trim() == "")
            {
                MessageBox.Show("请填写姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_xm;
                return;
            }
            if (object.Equals(null, cmb_xb.SelectedValue))
            {
                MessageBox.Show("请选择性别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_xb;
                return;
            }
            try
            {
                Convert.ToInt32(txt_nl.Text);
            }
            catch
            {
                MessageBox.Show("请填写年龄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txt_nl;
                return;
            }
            //if (txt_nl.Text.Trim() == "")
            //{
            //    MessageBox.Show("请填写年龄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.ActiveControl = txt_nl;
            //    return;
            //}
            if (object.Equals(null, cmb_mz.SelectedValue))
            {
                MessageBox.Show("请选择民族！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = cmb_mz;
                return;
            }

            string tjrq = xtbiz.GetServerDate().ToString("yyyy-MM-dd");
            if (str_tjbh == "")
            {
                str_tjbh = xtbiz.GetHmz("tjbh", 1);
                str_tjcs="1";

                if (xtbiz.GetXtCsz("djlshgz") == "2")  //特殊规则YYMMDD+5位
                {
                    str_djlsh = xtbiz.GetHmz("djlsh", 1);
                }
                else
                {
                    str_djlsh = tjdjbiz.Get_proc_get_djlsh(tjrq,Program.userid);
                }
            }
            tjjgbiz.Insert_tj_tjdjb(str_djlsh, str_tjbh, str_tjcs, txt_xm.Text.Trim(), cmb_xb.SelectedValue.ToString(), txt_nl.Text.Trim(), cmb_mz.SelectedValue.ToString(), txt_mobile.Text.Trim(), "05",tjrq,txt_sfzh.Text.Trim());

            this.DialogResult = DialogResult.OK;
        }

        private void Form_zywj_insert_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            cmb_xb.DataSource = xtbiz.GetXtZd(1);//性别
            cmb_xb.DisplayMember = "xmmc";
            cmb_xb.ValueMember = "bzdm";
            cmb_xb.SelectedIndex = -1;

            cmb_mz.DataSource = xtbiz.GetXtZd(2);//民族
            cmb_mz.DisplayMember = "xmmc";
            cmb_mz.ValueMember = "bzdm";
            cmb_mz.SelectedIndex = -1;

            DataTable dt = tjdjbiz.Get_TJ_TJDJB(str_tjbh, str_tjcs);
            if (dt.Rows.Count < 1) return;
            str_djlsh = dt.Rows[0]["djlsh"].ToString().Trim();
            txt_xm.Text = dt.Rows[0]["xm"].ToString().Trim();
            cmb_xb.SelectedValue = dt.Rows[0]["xb"].ToString().Trim();
            txt_nl.Text = dt.Rows[0]["nl"].ToString().Trim();
            cmb_mz.SelectedValue = dt.Rows[0]["mz"].ToString().Trim();
            txt_mobile.Text = dt.Rows[0]["mobile"].ToString().Trim();
            txt_sfzh.Text = dt.Rows[0]["sfzh"].ToString().Trim();
        }
    }
}
