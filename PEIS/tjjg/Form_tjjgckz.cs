using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjjg
{
    public partial class Form_tjjgckz : MdiChildrenForm
    {
        public string str_jg = "";//结果
        public string str_sfyx = "0";//是否阳性
        public string str_into_xj = "0";//进入小结
        public string str_mcjrxj = "0";//名称进入小结
        public string str_keyword = "";//诊断编号
        public bool bool_check = false;//是否选择个值
        string str_tjlx = "";//体检类型科室
        string str_tjxm = "";//体检项目ID
        tjjgBiz tjjgbiz = new tjjgBiz();
        int i = 1;
        public Form_tjjgckz(string jg,string tjlx,string tjxm,string text)
        {
            InitializeComponent();
            str_jg = jg;
            str_tjlx = tjlx;
            str_tjxm = tjxm;
            this.Text = this.Text + "【" + text + "】";
        }

        private void Form_tjjgckz_Load(object sender, EventArgs e)
        {
            new Common.Common().AddImages(imageList1);
            lv_keyword.SmallImageList = imageList1;
            lv_keyword.StateImageList = imageList1;
            lv_keyword.LargeImageList = imageList1;

            txt_jg.Text = str_jg;

            lv_keyword.Items.Clear();
            //lv_keyword.View = View.SmallIcon;
            DataTable dt = tjjgbiz.Get_TJ_KEYWORD(str_tjlx, str_tjxm);
            foreach (DataRow dr in dt.Rows)
            {
                MyListViewItem item = new MyListViewItem();
                item.Text = dr["mc"].ToString().Trim();
                item.Str_sfyx = dr["sfyx"].ToString().Trim();
                item.Str_into_xj = dr["into_xj"].ToString().Trim();
                item.Str_mcjrxj = dr["mcjrxj"].ToString().Trim();
                item.Str_keyword = dr["keyword"].ToString().Trim();
                item.ImageIndex = 5;
                lv_keyword.Items.Add(item);
            }
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            txt_jg.Text = "";
            str_jg = "";//结果
            str_sfyx = "0";//是否阳性
            str_into_xj = "0";//进入小结
            str_mcjrxj = "0";//名称进入小结
            str_keyword = "";//诊断编号
            bool_check = false;//是否选择个值
            i = 1;
        }

        private void bt_return_Click(object sender, EventArgs e)
        {
            str_jg = txt_jg.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lv_keyword_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyListViewItem item = (MyListViewItem)lv_keyword.GetItemAt(e.X, e.Y);
            if (object.Equals(null, item)) return;
            if (i == 1)
            {
                txt_jg.Text = item.Text.ToString().Trim();
            }
            else
            {
                txt_jg.Text = txt_jg.Text + item.Text.ToString().Trim();
            }
            i++;
            str_sfyx = item.Str_sfyx;
            str_into_xj = item.Str_into_xj;
            str_mcjrxj = item.Str_mcjrxj;
            str_keyword = item.Str_keyword;
            bool_check = true;//是否选择个值
        }

        private void lv_keyword_MouseClick(object sender, MouseEventArgs e)
        {
            lv_keyword_MouseDoubleClick(sender, e);

        }

        private void lv_keyword_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Close();
            }
        }
    }
}