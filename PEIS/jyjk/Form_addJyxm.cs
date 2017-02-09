using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.jyjk
{
    public partial class Form_addJyxm : MdiChildrenForm
    {
        private string jyjxmc = "";
        private string jyjxbh = "";
        private string xmbh = "";
        private bool add;//判断是增加还是修改
        private string xmmc = "";
        private string xmsx = "";
        private string dy = "";
        private string xy = "";
        private string spy = "";
        private string xpy = "";
        private JyjkBiz jyjkBiz = new JyjkBiz();
        private Common.Common comn = new Common.Common();
        private bool SelectJg = false;//判断是否用于选择结果
        private string bl;
        private string xssx;

        public Form_addJyxm(string xmbh)
        {
            InitializeComponent();
            this.xmbh = xmbh;
            SelectJg = true;
        }

        private string strXmjg;

        /// <summary>
        /// 获取项目结果
        /// </summary>
        public string StrXmjg
        {
            get { return strXmjg; }
           
        }

        public Form_addJyxm(string jyjxmc,string jyjxbh)
        {
            InitializeComponent();
            this.jyjxbh = jyjxbh;
            this.jyjxmc = jyjxmc;
            add = true;
        }

        public Form_addJyxm(string xmbh,string jyjxmc,string xmmc,string xmsx,string dy,string xy,string spy,string xpy,string bl,string xssx,string dw,string mrz)
        {
            InitializeComponent();
            this.xmbh = xmbh;
            this.jyjxmc = jyjxmc;
            this.xmmc = xmmc;
            this.xmsx = xmsx;
            this.dy = dy;
            this.xy = xy;
            this.spy = spy;
            this.xpy = xpy;
            add = false;
            this.bl = bl;
            txtBl.Text = bl;
            this.xssx = xssx;
            txtXssx.Text = xssx;
            txtDw.Text = dw;
            txtMrjg.Text = mrz;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Clear()
        {
            txtXmbh.Text = "";
            txtXmmc.Text = "";
            txtXmsx.Text = "";
            cbxTy.Checked = false;
        }

        private void Form_addJyxm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtXssx;
            txtXssx.SelectAll();

            if (!add)
            {
                txtJyjq.Text = jyjxmc;
                txtXmbh.Text = xmbh;
                txtXmmc.Text = xmmc;
                txtXmsx.Text = xmsx;
                txtDy.Text = dy;
                txtXy.Text = xy;
                txtSpy.Text = spy;
                txtXpy.Text = xpy;

                LoadLbxXmjg(xmbh);
            }
            else
            {
                txtJyjq.Text = jyjxmc;
            }

            if (SelectJg)//选择结果来的
            {
                this.Text = "结果检索";
                lblxmjg.Visible = false;
                txtXmjg.Visible = false;
                lbxJg.Dock = DockStyle.Fill;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                //gbxJgmj.Location = gbxXmxx.Location;
                gbxXmxx.Visible = false;
                gbxJgmj.Dock = DockStyle.Fill;
                //this.Height = gbxJgmj.Height + 30;
                lbxJg.DoubleClick += new EventHandler(lbxJg_DoubleClick);
            }
        }

        void lbxJg_DoubleClick(object sender, EventArgs e)
        {
            if (lbxJg.SelectedItems.Count<=0)
            {
                return;
            }
            strXmjg = lbxJg.SelectedItems[0].ToString().Trim();
            this.DialogResult = DialogResult.Yes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            string xmbh = txtXmbh.Text.Trim();
            string bl = txtBl.Text.Trim();
            if (bl == "") bl = "1";
            if (comn.DoubleYz(bl)==-1)
            {
                MessageBox.Show("数字格式错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (add)//增加
            {
                if (txtXmmc.Text.Trim()=="")
                {
                    MessageBox.Show("项目名称不能为空！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                xtBiz xtBiz = new xtBiz();
                xmbh = xtBiz.GetHmz("jy_xmbh", 1);
                txtXmbh.Text = xmbh;
                i = jyjkBiz.InsertJyxmb(xmbh, this.jyjxbh, txtXmmc.Text.Trim(), txtXmsx.Text.Trim(),txtDy.Text.Trim(),
                    txtXy.Text.Trim(),txtSpy.Text.Trim(),txtXpy.Text.Trim(),txtDw.Text.Trim(),txtMrjg.Text.Trim());

            }
            else
            {
                i = jyjkBiz.UpdateJyxmb(xmbh, cbxTy.Checked, txtXmsx.Text.Trim(), txtDy.Text.Trim(), txtXy.Text.Trim(), txtSpy.Text.Trim(), 
                    txtXpy.Text.Trim(), txtXmmc.Text.Trim(),txtBl.Text.Trim(),txtXssx.Text.Trim(),txtDw.Text.Trim(),txtMrjg.Text.Trim());
            }

            if (i > 0)
            {
                MessageBox.Show("保存成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (add)
                {
                    Clear();
                }
                else
                {
                    this.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void txtDy_Leave(object sender, EventArgs e)
        {
            string dy = txtDy.Text.Trim();
            if (dy=="")
            {
                return;
            }
            dy = comn.CharConverter(dy);
            if (comn.DoubleYz(dy)==-1)
            {
                MessageBox.Show("数字格式错误！");
                this.ActiveControl = txtDy;
                txtDy.SelectAll();
                return;
            }
            txtDy.Text = dy;
        }

        private void txtXy_Leave(object sender, EventArgs e)
        {
            string xy = txtXy.Text.Trim();

            if (xy=="")
            {
                return;
            }
            xy = comn.CharConverter(xy);
            if (comn.DoubleYz(xy) == -1)
            {
                MessageBox.Show("数字格式错误！");
                this.ActiveControl = txtXy;
                txtXy.SelectAll();
            }
            txtXy.Text = xy;
        }

        void LoadLbxXmjg(string xmbh)
        {
            lbxJg.Items.Clear();
            DataTable dt = new DataTable();
            dt = jyjkBiz.GetXmjg(xmbh);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lbxJg.Items.Add(dt.Rows[i]["jgmc"].ToString().Trim());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string xmbh = txtXmbh.Text.Trim();
            if (xmbh=="")
            {
                MessageBox.Show("新增加的项目必须先保存！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            string jg = txtXmjg.Text.Trim();
            if (jg=="")
            {
                MessageBox.Show("项目结果不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int i = jyjkBiz.InsertXmjg(xmbh, jg);
            if (i>0)
            {
                LoadLbxXmjg(xmbh);
                txtXmjg.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string xmbh = txtXmbh.Text.Trim();
            if (xmbh=="")
            {
                return;
            }
            string jg = lbxJg.SelectedItems[0].ToString().Trim();
            DialogResult result = MessageBox.Show("是否删除结果【"+jg+"】？","删除",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result==DialogResult.No)
            {
                return;
            }
            int i = jyjkBiz.DeleteXmjg(xmbh, jg);
            if (i>0)
            {
                LoadLbxXmjg(xmbh);
            }
        }

        private void txtXpy_Leave(object sender, EventArgs e)
        {
            txtXpy.Text = comn.CharConverter(txtXpy.Text.Trim());
        }

        private void txtSpy_Leave(object sender, EventArgs e)
        {
            txtSpy.Text = comn.CharConverter(txtSpy.Text.Trim());
        }

        private void txtBl_Leave(object sender, EventArgs e)
        {
            string bl = txtBl.Text.Trim();
            bl = comn.CharConverter(bl);
            txtBl.Text = bl;
        }

        private void txtXssx_Leave(object sender, EventArgs e)
        {
            txtXssx.Text = comn.CharConverter(txtXssx.Text.Trim());
        }

       
    }
}