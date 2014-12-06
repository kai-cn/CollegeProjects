using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Net.DB
{
    class SqlServerDB:DBAdapter
    {
        public SqlServerDB(string conStr)
        {
            ConnectionString = conStr;
        }

        public override int ExecNonQuery(string strCmd)
        {
            return 0;
        }

        public override System.Data.DataSet Select(string strCmd)
        {
            return null;
        }

        public override void BatchInsert(System.Data.DataTable dt, string tableName)
        {
            
        }
    }
}
