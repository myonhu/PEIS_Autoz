using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PEIS.tjjg
{
    class MyListViewItem :ListViewItem
    {


        public MyListViewItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        private string str_sfyx;
        public string Str_sfyx
        {
            get { return str_sfyx; }
            set { str_sfyx = value; }
        }

        private string str_into_xj;
        public string Str_into_xj
        {
            get { return str_into_xj; }
            set { str_into_xj = value; }
        }

        private string str_mcjrxj;
        public string Str_mcjrxj
        {
            get { return str_mcjrxj; }
            set { str_mcjrxj = value; }
        }

        private string str_keyword;
        public string Str_keyword
        {
            get { return str_keyword; }
            set { str_keyword = value; }
        }
    }
}
