using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    public partial class Form_nld : PEIS.MdiChildrenForm
    {
        ywszBiz ywszbiz = new ywszBiz();
        DataTable dt_TJ_JBFB_NL = null;
        public Form_nld()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_nld_Load(object sender, EventArgs e)
        {
            dt_TJ_JBFB_NL =ywszbiz.Get_TJ_JBFB_NL();
            dgv_nld.DataSource = dt_TJ_JBFB_NL;
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dt_TJ_JBFB_NL)) return;
            try
            {
                dgv_nld.Rows.Remove(dgv_nld.CurrentRow);
            }
            catch
            { 
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dt_TJ_JBFB_NL)) return;

            DataRow dr = dt_TJ_JBFB_NL.NewRow();
            dt_TJ_JBFB_NL.Rows.Add(dr);
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (object.Equals(null, dt_TJ_JBFB_NL)) return;
            ywszbiz.Update_TJ_JBFB_NL(dt_TJ_JBFB_NL);
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

