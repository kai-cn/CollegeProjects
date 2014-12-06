using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Database;

namespace GPA.GPALib.DatabaseOriginalData
{
    class DbSixDegreeForeignEmuleData:DbSixDegreeDataBase
    {
        public DbSixDegreeForeignEmuleData(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
            base(ref dbBase, beginTime, endTime, isPartition)
        { }

        protected override string GetCommand()
        {
            string strSql;

            if (!_dbType.Contains("Oracle"))
            {
                strSql = string.Format(@"select  [tracker/server_ip],COUNT(distinct [peer/source_ip]) from {0}
                    where  CONVERT(char,time,23) between '{1}' and '{2}' group by [tracker/server_ip]
                                            order by COUNT(distinct [peer/source_ip]) ", _tableName, _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));
            }
            else
            {
                strSql = string.Format(@"select distinct resource_uri,server_ip,{0}
                     from {1}  where type='em'  and peer_source='SX' and asciistr(resource_uri) not like '%\%'
                    and {2} between to_date('{3}','yyyy-mm-dd') and to_date('{4}','yyyy-mm-dd')
                    "
                , _ipAttr, _tableName, _insertion_time
               , _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));

            }
            return strSql;
        }
    }
}

