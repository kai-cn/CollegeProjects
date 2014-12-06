using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utility.Net.DB;

namespace GPA.Infrastructure.SKLCC
{
    public sealed class DBProvider
    {
        private DBCmd cmd;
        private DBAdapter adapter;


        public DBProvider(DBCmd cmd)
        {
            this.cmd = cmd;
            
        }

        public DataSet SelectDataSet()
        {
            adapter = DBFactory.GetDBAdapter(DBFactory.DBMode.LocalDB);
            return  adapter.Select(cmd.SelectCommand);
        }

        public void InsertDataTable(DataTable dt)
        {
            adapter = DBFactory.GetDBAdapter(DBFactory.DBMode.LocalWebDB);
            adapter.BatchInsert(dt, cmd.SelectCommand);
        }
    }
}
