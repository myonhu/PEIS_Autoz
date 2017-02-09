using System;
using System.Collections.Generic;
using System.Text;

namespace PEIS.cxgl
{
    /// <summary>
    /// 窗体参数的设置
    /// </summary>
    public class FormArg
    {
        private static string arg;

        /// <summary>
        /// 窗体参数
        /// </summary>
        public static string Arg
        {
            get { return FormArg.arg; }
            set { FormArg.arg = value; }
        }

        private static string name;

        /// <summary>
        /// 窗体名称
        /// </summary>
        public static string Name
        {
            get { return FormArg.name; }
            set { FormArg.name = value; }
        }
    }
}
