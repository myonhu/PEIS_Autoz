using System;
using System.Collections.Generic;
using System.Text;

namespace PEIS
{
    class Base
    {
        private DataAgent i_objDBAgent;
        private DataAgent i_objDBAgent2;
        private DataAgent i_objDBAgentBC3000;

        protected DataAgent SqlDBAgent
        {
            get
            {
                if (this.i_objDBAgent == null)
                {
                    this.i_objDBAgent = this.CreateAgent();
                }
                return this.i_objDBAgent;
            }
            set
            {
                this.i_objDBAgent = value;
            }
        }

        protected DataAgent SqlDBAgent2
        {
            get
            {
                if (this.i_objDBAgent2 == null)
                {
                    this.i_objDBAgent2 = this.CreateAgent2();
                }
                return this.i_objDBAgent2;
            }
            set
            {
                this.i_objDBAgent2 = value;
            }
        }

        protected DataAgent SqlDBAgentBC3000
        {
            get
            {
                if (this.i_objDBAgentBC3000 == null)
                {
                    this.i_objDBAgentBC3000 = this.CreateAgentBC3000();
                }
                return this.i_objDBAgentBC3000;
            }
            set
            {
                this.i_objDBAgentBC3000 = value;
            }
        }

        private DataAgent CreateAgent()
        {

            string strConn = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            strConn = strConn + ";App=XXTJXT";
            return new DataAgent(strConn);
        }

        private DataAgent CreateAgent2()
        {
            string strConn = System.Configuration.ConfigurationManager.AppSettings["jyjk_sql"].ToString();
            strConn = strConn + ";App=XXTJXT2";
            return new DataAgent(strConn);
        }

        private DataAgent CreateAgentBC3000()
        {
            string strConn = System.Configuration.ConfigurationManager.AppSettings["bc3000_sql"].ToString();
            strConn = strConn + ";App=XXTJXT3";
            return new DataAgent(strConn);
        }


    
    }
}
