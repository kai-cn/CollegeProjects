using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Common.Database;

namespace GPA.GPALib.DatabaseOriginalData
{
    class DbBlockListInternalEmuleData:DbBlockListDataBase
    {
        public DbBlockListInternalEmuleData(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
            base(ref dbBase, beginTime, endTime, isPartition) 
        {   }
        

        protected override string GetCommand()
        {
            string strSql;

            if (!_dbType.Contains("Oracle"))
            {
                strSql = null;
                    
            }
            else
            {
                strSql = strSql = string.Format(@"select distinct type_blocklist,ip from ip_map_geolocation_internal_em
                where live_time between to_date('{0}','yyyy-mm-dd') 
                    and to_date('{1}','yyyy-mm-dd') ", _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));
             }
            return strSql;
        }
    }
}
