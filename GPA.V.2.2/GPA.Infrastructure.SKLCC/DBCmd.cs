using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace GPA.Infrastructure.SKLCC
{
    public abstract class DBCmd
    {
        protected const string tableName = "p2p_original_data_bak";
        protected DateTime beginTime;
        protected DateTime endTime;
        protected string selectCommand;
        protected string webTableName;

        

        public DateTime BeginTime
        {
            get { return beginTime; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
        }

        public string SelectCommand
        {
            get {return selectCommand;}
        }

        public string WebTableName
        {
            get { return webTableName; }
        }

        
    }
}
