using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.main
{
    public partial class Form_yhqxsz_sort : PEIS.MdiChildrenForm
    {
        DataTable dt = new DataTable("xt_yhzqx");

        int sjid;
        int yhzid;
        public Form_yhqxsz_sort(int i_sjid, int i_yhzid)
        {
            InitializeComponent();
            sjid = i_sjid;
            yhzid = i_yhzid;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            xtggBiz xtggbiz = new xtggBiz();
            xtggbiz.Update_xt_yhzqx(dt, sjid, yhzid);
            this.DialogResult = DialogResult.OK;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    objyhqxszsort.UpdateYhzqx(i_sjid, i_yhzid, i + 1, Convert.ToInt16(dt.Rows[i]["qxid"]));
            //}
            //dt = objyhqxszsort.GetNewsList(i_sjid, i_yhzid);
            //this.dgYhqxsort.DataSource = dt;
            //gridViewColumnsSyle();
        }

        private void Form_yhqxsz_sort_Load(object sender, EventArgs e)
        {
            xtggBiz xtggbiz = new xtggBiz();
            dt = xtggbiz.Get_xt_yhzqx_sort(sjid, yhzid);
            dgYhqxsort.DataSource = dt;
        }

        private void btn_up_Click(object sender, EventArgs e)
        {

            try
            {
                int i = dgYhqxsort.CurrentCell.RowIndex; //获取当前所选择的记录行号
                object[] _rowData = dt.Rows[i].ItemArray;
                dt.Rows[i].ItemArray = dt.Rows[i - 1].ItemArray;
                dt.Rows[i - 1].ItemArray = _rowData; //记录上移一行
                this.dgYhqxsort.CurrentCell = this.dgYhqxsort[this.dgYhqxsort.CurrentCell.ColumnIndex, this.dgYhqxsort.CurrentCell.RowIndex - 1]; //选择的光标同时上移一行
            }
            catch { }
            {

            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dgYhqxsort.CurrentCell.RowIndex; //获取当前所选择的记录行号
                object[] _rowData = dt.Rows[i].ItemArray;
                dt.Rows[i].ItemArray = dt.Rows[i + 1].ItemArray;
                dt.Rows[i + 1].ItemArray = _rowData; //记录下移一行
                this.dgYhqxsort.CurrentCell = this.dgYhqxsort[this.dgYhqxsort.CurrentCell.ColumnIndex, this.dgYhqxsort.CurrentCell.RowIndex + 1];//选择的光标同时下移一行
            }
            catch { }
            {

            }
        }
    }
}

