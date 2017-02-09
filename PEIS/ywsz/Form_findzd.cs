using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_findzd : MdiChildrenForm
    {
        private string str_bh;
        private string str_keyword;
        private string str_tjlx;
        private string str_lclx;

        DataTable dt = null;
        public string Str_bh
        {
            get { return str_bh; }
            set { str_bh = value; }
        }
        public string Str_keyword
        {
            get { return str_keyword; }
            set { str_keyword = value; }
        }
        public Form_findzd(string tjlx,string lclx)
        {
            InitializeComponent();
            str_tjlx = tjlx;
            str_lclx = lclx;
        }

        void DataBind(string str_tjlx)
        {
            ywszBiz ywszbiz = new ywszBiz();
            if (str_tjlx == "" && str_lclx == "")
            {
                dt = ywszbiz.Get_TJ_SUGGESTION2();
            }
            else if (str_tjlx != "" && str_lclx == "")
            {
                dt = ywszbiz.Get_TJ_SUGGESTION3(str_tjlx);
            }
            else
            {
                dt = ywszbiz.Get_TJ_SUGGESTION1(str_tjlx, str_lclx);
            }
            if (dt.Rows.Count < 1)
            {
                this.ActiveControl = txt_pym;
                return;
            }
            this.dgv_zd.DataSource = dt;
            this.ActiveControl = dgv_zd;
        }
        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_select_Click(object sender, EventArgs e)
        {
            DataTable dt1 = dt.Copy();
            dt1.Rows.Clear();
            foreach (DataRow dr in dt.Select("pyjm like '%" + txt_pym.Text.Trim() + "%' or wbjm like '%" + txt_pym.Text.Trim() + "%'"))
            {
                DataRow dr1 = dt1.NewRow();
                dr1[0] = dr[0];
                dr1[1] = dr[1];
                dr1[2] = dr[2];
                dr1[3] = dr[3];
                dr1[4] = dr[4];
                dt1.Rows.Add(dr1);
            }
            this.dgv_zd.DataSource = dt1;
        }

        private void txt_pym_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_select_Click(null, null);
                this.ActiveControl = dgv_zd;
            }
        }

        private void Form_cjzd_Load(object sender, EventArgs e)
        {
            DataBind(str_tjlx);
            this.ActiveControl = txt_pym;
        }

        private void dgv_zd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Str_bh = dgv_zd.CurrentRow.Cells["bh"].Value.ToString().Trim();
            Str_keyword = dgv_zd.CurrentRow.Cells["keyword"].Value.ToString().Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void txt_pym_TextChanged(object sender, EventArgs e)
        {
            bt_select_Click(null, null);
        }
    }
}

