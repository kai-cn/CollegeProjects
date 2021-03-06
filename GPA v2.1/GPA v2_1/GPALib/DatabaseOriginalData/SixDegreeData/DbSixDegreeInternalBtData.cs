﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Database;

namespace GPA.GPALib.DatabaseOriginalData
{
    class DbSixDegreeInternalBtData:DbSixDegreeDataBase
    {

        public DbSixDegreeInternalBtData(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
        base(ref dbBase, beginTime, endTime, isPartition) 
        {   }

        protected override string GetCommand()
        {
            string strSql;

            if (!_dbType.Contains("Oracle"))
            {
                strSql = string.Format(@"select  [tracker/server_ip],COUNT(distinct [peer/source_ip]) from {0}
                    where  CONVERT(char,time,23) between '{1}' and '{2}' and RIGHT([file_path/resource_link],48) not
                like '[a-z|0-9]%.torrent'   group by [tracker/server_ip] order by COUNT(distinct [peer/source_ip]) "
                    , _tableName, _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));
            }
            else
            {

                strSql = string.Format(@"select distinct resource_uri,server_ip,{0}
                     from {1}   where  peer_source='SX' and  regexp_like(SUBSTR(resource_uri,LENGTH(resource_uri)-48+1,48),'[a-z|0-9]{{40}}.torrent')
                    and  {2} between to_date('{3}','yyyy-mm-dd') and to_date('{4}','yyyy-mm-dd')
                    "
                                  , _ipAttr, _tableName, _insertion_time
                                 , _beginTime.ToString("yyyy-MM-dd"),_endTime.ToString("yyyy-MM-dd"));
            }
            return strSql;
        }

    }
}


