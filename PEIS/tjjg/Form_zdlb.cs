using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjjg
{
    public partial class Form_zdlb : PEIS.MdiChildrenForm
    {
        DataTable dt = null;
        public Form_zdlb(DataTable dt_jbjlb)
        {
            InitializeComponent();
            dt = dt_jbjlb;
        }

        private void Form_zdlb_Load(object sender, EventArgs e)
        {
            dgv_jbjlb.DataSource = dt;
        }
    }
}

