using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PEIS.DataWindows
{
    public partial class DataWindowFilter : UserControl
    {
        public DataWindowFilter()
        {
            InitializeComponent();
        }
        public DataGridView DataGridView
        {
            set
            {
                dataGridView = value;
            }
            get
            {
                return dataGridView;
            }
        }
        public object DataSource
        {
            set
            {
                dataGridView.DataSource = value;
            }
        }
    }
}
