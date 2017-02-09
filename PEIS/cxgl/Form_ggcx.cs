using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.cxgl
{
    public partial class Form_ggcx : PEIS.MdiChildrenForm
    {
        private string strTable = "";
        private DataTable dt = null;
        private Command cmd = new Command();
        private string tj = "";//查询条件
        private string header = "";//要查询的字段
        private string tiaojian = "";
        private bool rqbz = true;//判断第二列是否是日期的标志；FALSE：不是；TRUE：是；
        private string rqz;//显示日期

        public Form_ggcx()
        {
            InitializeComponent();
        }

        private void Form_ghcx_Load(object sender, EventArgs e)
        {           
            strTable = FormArg.Arg.Trim();//接受视图
           
            this.label1.Text = rqz;
            if (strTable == "")
            {
                return;
            }
            this.Text = FormArg.Name;

            txtMain.Text = "";
            dt = new DataTable();
            cmbItems.Items.Clear();
            dt = cmd.GetTbHeader(strTable);
            if (object.Equals(dt,null))
            {
                return;
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                cmbItems.Items.Add(dt.Columns[i].ToString());
            }
            cmbItems.SelectedIndex = -1;

            if (dt.Columns[1].ToString().Trim().IndexOf('日') ==-1 |  dt.Columns[1].ToString().Trim().IndexOf('期')==-1)
            {
                rqbz = false;
                panel3.Visible = false;
            }
            else
            {
                this.rqz = dt.Columns[1].ToString().Trim();
                label1.Text = rqz;
            }

            cmbCzf.Items.Add("=");
            cmbCzf.Items.Add(">");
            cmbCzf.Items.Add(">=");
            cmbCzf.Items.Add("<");
            cmbCzf.Items.Add("<=");
            cmbCzf.Items.Add("<>");
            cmbCzf.SelectedIndex = -1;

            this.header = cmd.GetTableHeader(strTable);
            this.dtpBegin.Text = DateTime.Now.AddDays(-3).ToLongDateString();
            this.dtpEnd.Text = DateTime.Now.ToLongDateString();        

        }

        private void cmbCzf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItems.Text == "")
            {
                cmbCzf.SelectedIndex = -1;
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (cmbItems.Text == "")
            {
                return;
            }
            if (txtTjz.Text == "")
            {
                return;
            }

            tj = "and " + cmbItems.Text + cmbCzf.Text + "'" + txtTjz.Text + "' ";
            txtMain.Text = tj;

        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCzf.SelectedIndex = 0;
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            if (cmbItems.Text == "")
            {
                return;
            }
            if (txtTjz.Text == "")
            {
                return;
            }

            tj += "and " + cmbItems.Text + cmbCzf.Text + "'" + txtTjz.Text + "' ";
            txtMain.Text = tj;

        }

        private void btnH_Click(object sender, EventArgs e)
        {
            if (cmbItems.Text == "")
            {
                return;
            }
            if (txtTjz.Text == "")
            {
                return;
            }

            tj += "or " + cmbItems.Text + cmbCzf.Text + "'" + txtTjz.Text + "' ";
            txtMain.Text = tj;
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            if (cmbItems.Text == "")
            {
                return;
            }
            if (txtTjz.Text == "")
            {
                return;
            }
            tj = "";
            txtMain.Text = tj;
        }

        private void btnCx_Click(object sender, EventArgs e)
        {
            DateTime begin = Convert.ToDateTime(this.dtpBegin.Text.Trim());
            DateTime end = Convert.ToDateTime(this.dtpEnd.Text.Trim());
            end = end.AddDays(1);
            if (begin > end)
            {
                return;
            }
            string main = txtMain.Text.Trim();
            string begin1 = Command.DateTimeChange(begin);
            string end1 = Command.DateTimeChange(end);

            if (rqbz)
            {
                tiaojian = "and "+this.rqz+" between '" + begin1 + "' and '" + end1 + "'" + main;
            }
            else
            {
                tiaojian =  main;
            }

            dt = new DataTable();
            dt = cmd.GetInfo(strTable, header, tiaojian);  
            Command.LoadListView(listView1, dt);
            if (rqbz)
            {
                listView1.Columns[1].Text = this.rqz;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbItems.Text == "")
            {
                return;
            }
            DateTime begin = Convert.ToDateTime(this.dtpBegin.Text.Trim());
            DateTime end = Convert.ToDateTime(this.dtpEnd.Text.Trim());
            end = end.AddDays(1);
            if (begin > end)
            {
                return;
            }

            string main = txtMain.Text.Trim();
            string begin1 = Command.DateTimeChange(begin);
            string end1 = Command.DateTimeChange(end);
            if (rqbz)
            {
                tiaojian = "and "+this.rqz+" between '" + begin + "' and '" + end + "'" + main;
            }
            else
            {
                tiaojian = main;
            }

            dt = new DataTable();
            dt = cmd.GetInfo(strTable, cmbItems.Text, tiaojian);
            if (dt.Rows.Count==0)
            {
                return;
            }
            Form_Tjz frm = new Form_Tjz(dt);
            if (frm.ShowDialog()==DialogResult.OK)
            {
                txtTjz.Text = TongJiEntity.Tj;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count==0)
            {
                return;
            }
            saveFileDialog1.Filter = "Excel File|*.xls";
            saveFileDialog1.Title = "数据导出";
            this.saveFileDialog1.FileName = FormArg.Name;
            string path = string.Empty;
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                path = saveFileDialog1.FileName;
                ListViewExport.ExportToExcel(listView1, path, "1", true);
                if (ListViewExport.IsExistsExcel())
                {
                    if (DialogResult.Yes == MessageBox.Show("是否打开该文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
                    {
                        ListViewExport.OpenExcel(path);
                    }
                }
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                ListView lv = (ListView)sender;
                if (lv.Columns[e.Column].Tag == null)
                    lv.Columns[e.Column].Tag = true;
                bool tabK = (bool)lv.Columns[e.Column].Tag;
                if (tabK)
                    lv.Columns[e.Column].Tag = false;
                else
                    lv.Columns[e.Column].Tag = true;
                lv.ListViewItemSorter = new MyListViewSort(e.Column, lv.Columns[e.Column].Tag);
                //指定排序器并传送列索引与升序降序关键字
                lv.Sort();//对列表
            }
            catch
            { 
            }
        }
    }
}