using System;
using System.Collections.Generic;

using System.Web;

using System.Data;

namespace IntelligentBus.Persist
{
    public class BusLine
    {
        private NetUtil.DB.DbUtil dbUtil = NetUtil.DB.DbFactory.CreateDbUtil();
        private string selectSqlStr;

        public BusLine()
        {
            selectSqlStr = "select * from BusLine";
        }
        public DataSet Select(string lineCode)
        {
            string strSql = string.Format("{0} where LineCode like '%{1}%'",selectSqlStr,lineCode);

            return dbUtil.Select(strSql);
        }

        public DataSet SelectByID(int id)
        {
            string strSql = string.Format("{0} where BusLineID='{1}'", selectSqlStr, id);

            return dbUtil.Select(strSql);
        }


    }
}