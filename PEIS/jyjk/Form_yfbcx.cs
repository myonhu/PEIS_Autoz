using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PEIS.jkgl;
using PEIS.tjdj;

namespace PEIS.jyjk
{
    public partial class Form_yfbcx : MdiChildrenForm
    {
        private DataTable dtDjry;
        private DataTable dtZhxm;
        private DataTable dtXmmx;
        private JyjkBiz jyjkBiz = new JyjkBiz();
        private Common.Common comn = new Common.Common();
        private LisBiz lisbiz = new LisBiz();
        private PrintWaiting pw = new PrintWaiting();
        private RdlcPrint rdlcPrint = new RdlcPrint();

        public Form_yfbcx()
        {
            InitializeComponent();
        }

        void LoadDgvDjry()
        {
            if (txt_tjdw.Text.Trim()=="")
            {
                txt_tjdw.Tag = "";
            }
            dtDjry = new DataTable();
            dtDjry = jyjkBiz.GetTjyfbxx(comn.DateTimeChange(dtp_rq1.Value.AddDays(-1)) + " 23:59:59", 
                comn.DateTimeChange(dtp_rq2.Value) + " 23:59:59", txt_djh.Text.Trim(), txt_xm.Text.Trim(),txt_tjdw.Tag.ToString());
            dg_djry.DataSource = dtDjry;

            lblCount.Text="共"+dg_djry.Rows.Count.ToString()+"人";
        }

        void LoadDgvZhxm(string tjbh, string tjcs)
        {
            dtZhxm = new DataTable();
            dtZhxm = lisbiz.Get_TJ_BBDJB(tjbh, tjcs);
            dg_djrymx.DataSource = dtZhxm;

        }

        void LoadDgvXmmx(string djlsh,string zhxm)
        {
            dtXmmx = new DataTable();
            dtXmmx = lisbiz.GetJyfbmx(djlsh, zhxm);
            dgvJyxmmx.DataSource = dtXmmx;
        }

        private void Form_yfbcx_Load(object sender, EventArgs e)
        {

        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            LoadDgvDjry();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_djry_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_djry.SelectedRows.Count<=0) return;
            DataGridViewRow dgr = dg_djry.SelectedRows[0];
            //string str_djlsh = dgr.Cells["djlsh"].Value.ToString();

            string str_tjbh = dgr.Cells["tjbh"].Value.ToString();
            string str_tjcs = dgr.Cells["tjcs"].Value.ToString();
            LoadDgvZhxm(str_tjbh, str_tjcs);
            cbxQx_CheckedChanged(null, null);

            if (dg_djrymx.SelectedRows.Count == 0)
            {
                return;
            }
        }


        private void dg_djrymx_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_djrymx.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow dgr = dg_djrymx.SelectedRows[0];
            string djlsh = dgr.Cells["bbbh"].Value.ToString().Trim();
            string zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();
            LoadDgvXmmx(djlsh, zhxm);
        }



        private void bt_dj_Click(object sender, EventArgs e)
        {
            //if (dgvJyxmmx.Rows.Count == 0)
            //{
            //    return;
            //}
            //add  双循环
            //for (int j = 0; j < dg_djry.Rows.Count; j++)
            //{
            //    string y = dg_djry.Rows[j].Cells["xz"].Value.ToString().Trim();  //人员选择标志
            //    if (y == "0") continue;
            //    dg_djry.Rows[j].Selected = true;

            //    for (int i = 0; i < dg_djrymx.Rows.Count; i++)
            //    {
            //        string x = dg_djrymx.Rows[i].Cells["x"].Value.ToString().Trim();
            //        if (x == "1")
            //        {
            //            //pw.StartThread();
            //            DataGridViewRow dgr = dg_djrymx.Rows[i];
            //            string zhxm = dgr.Cells["zhxm"].Value.ToString().Trim();
            //            string djlsh = dgr.Cells["bbbh"].Value.ToString().Trim();

            //            rdlcPrint.PrintJyjg_zhxm(djlsh, zhxm);
            //            //pw.StopThread();
            //        }
            //    }
            //}

            if (object.Equals(null, dg_djry.CurrentRow)) return;
            if (dg_djry.Rows.Count < 1) return;
            foreach (DataGridViewRow dgr in dg_djry.Rows)
            {
                if (dgr.Cells["xz"].Value.ToString().Trim() == "1")
                {
                    string djlsh = dgr.Cells["djlsh"].Value.ToString().Trim();/////add
                    for (int i = 0; i < dg_djrymx.Rows.Count; i++)
                    {
                        string x = dg_djrymx.Rows[i].Cells["x"].Value.ToString().Trim();
                        if (x == "1")
                        {
                            //pw.StartThread();
                            DataGridViewRow dgr2 = dg_djrymx.Rows[i];
                            string zhxm = dgr2.Cells["zhxm"].Value.ToString().Trim();
                            //string djlsh = dgr2.Cells["bbbh"].Value.ToString().Trim();

                            rdlcPrint.PrintJyjg_zhxm(djlsh, zhxm);
                            //pw.StopThread();
                        }
                    }
                }
            }
 
            
        }

        private void cbxQx_CheckedChanged(object sender, EventArgs e)
        {
            string qx = "0";
            if (cbxQx.Checked)
            {
                qx = "1";
            }
            else
            {
                qx = "0";
            }
            for (int i = 0; i < dg_djrymx.Rows.Count; i++)
            {
                string fb = dg_djrymx.Rows[i].Cells["sffb"].Value.ToString().Trim();
                if (fb=="0")//未发布的，没结果，不能打印
                {
                    continue;
                }
                dg_djrymx.Rows[i].Cells["x"].Value = qx;
            }
        }

        private void bt_tjdw_Click(object sender, EventArgs e)
        {
            Form_tjdw frm = new Form_tjdw();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txt_tjdw.Text = frm.str_tjdwmc;
                txt_tjdw.Tag = frm.str_tjdwid;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string qx = "0";
            if (checkBox1.Checked)  
            {
                qx = "1";
            }
            else
            {
                qx = "0";
            }
            for (int i = 0; i < dg_djry.Rows.Count; i++)
            {
                //string fb = dg_djry.Rows[i].Cells["xz"].Value.ToString().Trim();
                //if (fb == "1")//未发布的，没结果，不能打印
                //{
                    dg_djry.Rows[i].Cells["xz"].Value = qx;
                //}
                
            }
        }
    }
}