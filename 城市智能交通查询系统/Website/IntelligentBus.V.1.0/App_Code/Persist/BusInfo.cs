using System;
using System.Collections.Generic;
using System.Web;

using System.Data;

namespace IntelligentBus.Persist
{
 
    public class BusInfo
    {
        private NetUtil.DB.DbUtil dbUtil = NetUtil.DB.DbFactory.CreateDbUtil();
        private string selectSqlStr;

        public BusInfo()
        {
            selectSqlStr = "select * from BusInfo";
        }
        public DataSet Select(int BusLineID)
        {
            string strSql = string.Format("{0} where BusLineID={1}", selectSqlStr,BusLineID);

            return dbUtil.Select(strSql);
        }

        public DataSet SelectByID(int id)
        {
            string strSql = string.Format("{0} where BusInfoID={1}", selectSqlStr, id);

            return dbUtil.Select(strSql);
        }

    }
}
