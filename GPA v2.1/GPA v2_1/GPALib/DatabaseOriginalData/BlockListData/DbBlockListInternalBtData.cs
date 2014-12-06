using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Common.Database;

namespace GPA.GPALib.DatabaseOriginalData
{
    class DbBlockListInternalBtData:DbBlockListDataBase
    {
        public DbBlockListInternalBtData(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
        base(ref dbBase, beginTime, endTime, isPartition) 
        {   }

        /// <summary>
        /// 根据获取到的参数的不同返回不同的sql语言
        /// </summary>
        /// <returns>sql语言</returns>
        protected override string GetCommand()
        {
            string strSql=null;

            if (!_dbType.Contains("Oracle"))
            {
                strSql = null;
            }
            else
            {
                strSql = string.Format(@"select distinct type_blocklist,ip from ip_map_geolocation_internal_bt
                where live_time between to_date('{0}','yyyy-mm-dd') 
                    and to_date('{1}','yyyy-mm-dd') ", _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));
            }
            return strSql;
        }
    }
}
