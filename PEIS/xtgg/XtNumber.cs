using System;
using System.Collections.Generic;
using System.Text;

namespace PEIS.xtgg
{
    public static class XtNumber
    {
        private static int number = 0;

        public static int Number
        {
            get { return XtNumber.number; }
            set { XtNumber.number = value; }
        }

        private static string name="";

        public static string Name
        {
            get { return XtNumber.name; }
            set { XtNumber.name = value; }
        }

    }
}
