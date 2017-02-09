using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace PEIS.DataWindows
{
    public class DataGridViewDataWindowColumn : DataGridViewColumn
    {
        private object m_dataSoruce = null;

        public DataGridViewDataWindowColumn()
            : base(new DataGridViewDataWindowCell())
        {
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewDataWindowCell)))
                {
                    throw new InvalidCastException("不是DataGridViewDataWindowCell");
                }
                base.CellTemplate = value;
            }
        }
        private DataGridViewDataWindowCell ComboBoxCellTemplate
        {
            get
            {
                return (DataGridViewDataWindowCell)this.CellTemplate;
            }
        }
        public Object DataSource
        {
            get
            {
                return m_dataSoruce;

            }
            set
            {
                if (ComboBoxCellTemplate != value)
                {

                    m_dataSoruce = value;

                }
            }
        }
    }
}
