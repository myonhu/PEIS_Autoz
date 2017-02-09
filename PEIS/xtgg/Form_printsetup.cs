using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.xtgg
{
    public partial class Form_printsetup : PEIS.MdiChildrenForm
    {
        xtBiz xtbiz = new xtBiz();
        DataTable dt_ggdy = null;
        public Form_printsetup()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dt_ggdy.GetChanges())) return;
            xtbiz.Update_Table(dt_ggdy, "select ID,PageName,PaperName,PageWidth,PageHeight,MarginTop,MarginLeft,MarginRight,MarginBottom,PagePrinter,sm,tybz from xt_ggdy");
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dt_ggdy = xtbiz.Get_All_Xt_ggdy();
            dgv_ggdy.DataSource = dt_ggdy;
        }

        private void Form_printsetup_Load(object sender, EventArgs e)
        {
            dt_ggdy = xtbiz.Get_All_Xt_ggdy();
            dgv_ggdy.DataSource =dt_ggdy ;
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dgv_ggdy.CurrentRow)) return;
            DialogResult dlg = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (dlg == DialogResult.OK)
            {
                dgv_ggdy.Rows.Remove(dgv_ggdy.CurrentRow);
                try
                {
                    dgv_ggdy.CurrentCell = dgv_ggdy.Rows[dgv_ggdy.Rows.Count - 1].Cells[1];
                }
                catch
                {
 
                }
            }   
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            DataRow dr = dt_ggdy.NewRow();
            dt_ggdy.Rows.Add(dr);
            dgv_ggdy.CurrentCell = dgv_ggdy.Rows[dgv_ggdy.Rows.Count - 1].Cells[1];
        }
    }
}

