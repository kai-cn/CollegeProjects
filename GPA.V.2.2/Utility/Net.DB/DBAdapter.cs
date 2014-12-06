using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace Utility.Net.DB
{
    public abstract class DBAdapter
    {
        /// <summary>
        /// 数据库的连接字符串
        /// </summary>
        //protected string conStr;

        public string ConnectionString { get; set; }

        public abstract int ExecNonQuery(string strCmd);

        public abstract DataSet Select(string strCmd);

        public abstract void BatchInsert(DataTable dt, string tableName);

    }
}
