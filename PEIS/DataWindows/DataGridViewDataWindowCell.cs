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
    public class DataGridViewDataWindowCell : DataGridViewTextBoxCell
    {
        public override void InitializeEditingControl(int rowIndex, object
              initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            DataGridViewDataWindowEditingControl dataWindowControl =
                DataGridView.EditingControl as DataGridViewDataWindowEditingControl;
            dataWindowControl.PopupGridAutoSize = true;
            dataWindowControl.RowFilterVisible = false;
            DataGridViewDataWindowColumn dataWindowColumn =
                (DataGridViewDataWindowColumn)OwningColumn;
            dataWindowControl.DataSource = dataWindowColumn.DataSource;
            dataWindowControl.Text = (string)this.Value;
        }
        [Browsable(false)]
        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewDataWindowEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }
        private DataGridViewDataWindowEditingControl EditingDataWindow
        {
            get
            {
                DataGridViewDataWindowEditingControl dataWindowControl =
                    DataGridView.EditingControl as DataGridViewDataWindowEditingControl;

                return dataWindowControl;
            }
        }
    }
}
