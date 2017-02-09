using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.main
{
    public partial class Form_yhzsz : PEIS.MdiChildrenForm
    {
        DataTable dt_xt_yhz = new DataTable("xt_yhz");
        public Form_yhzsz()
        {
            InitializeComponent();
        }
        private void DataBind()
        {
            xtggBiz xtggbiz = new xtggBiz();
            dt_xt_yhz = xtggbiz.Get_xt_yhz();
            if (object.Equals(dt_xt_yhz, null))
            {
                return;
            }
            dg_yhz.DataSource = dt_xt_yhz;
        }
        private void Form_yhzsz_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void bt_Insert_Click(object sender, EventArgs e)
        {
            dt_xt_yhz.Rows.Add(dt_xt_yhz.NewRow());
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            xtggBiz xtggbiz = new xtggBiz();
            xtggbiz.Update_xt_yhz(dt_xt_yhz);
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_yhzsz_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dt_xt_yhz.GetChanges();
            if (object.Equals(dt, null))
            {
                return;
            }
            if (dt.Rows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("数据已更改，是否返回保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                {
                    e.Cancel = true;
                }
            }
        }
    }
}

