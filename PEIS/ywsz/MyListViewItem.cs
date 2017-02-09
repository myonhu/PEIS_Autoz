using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.ywsz
{
    class MyListViewItem :ListViewItem
    {


        public MyListViewItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        private string str1;
        public string Str1
        {
            get { return str1; }
            set { str1 = value; }
        }

        private string str2;
        public string Str2
        {
            get { return str2; }
            set { str2 = value; }
        }

        private string str3;
        public string Str3
        {
            get { return str3; }
            set { str3 = value; }
        }

        private string str4;
        public string Str4
        {
            get { return str4; }
            set { str4 = value; }
        }
    }
}
