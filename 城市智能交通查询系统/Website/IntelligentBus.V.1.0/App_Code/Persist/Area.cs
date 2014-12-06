using System;
using System.Collections.Generic;

using System.Web;

using System.Data;
using System.Collections;

namespace IntelligentBus.Persist
{
    public class Area
    {
        private NetUtil.DB.DbUtil dbUtil = NetUtil.DB.DbFactory.CreateDbUtil();
        private string selectSqlStr;


        public Area()
        { 
            selectSqlStr="select * from area";
        }

        public DataSet Select()
        {
            return dbUtil.Select(selectSqlStr);
        }

        public DataSet Select(int id)
        {
            return null;
        }
    }
}