﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Common.Database;

namespace GPA.GPALib.DatabaseOriginalData
{
    class DbPortRankingInternalEmuleData:DbPortRankingDataBase
    {
        public DbPortRankingInternalEmuleData(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
            base(ref dbBase, beginTime, endTime, isPartition) 
        {   }
        

        protected override string GetCommand()
        {
            string strSql;

            if (!_dbType.Contains("Oracle"))
            {
                strSql = string.Format(@"select distinct {0} from {1}  where type='em' and
                CONVERT(char,time,23) between ' {2} ' and ' {3} ' "
                    , _ipAttr, _tableName, _beginTime.ToString("yyyy-mm-dd"), _endTime.ToString("yyyy-mm-dd"));
            }
            else
            {
                strSql = string.Format(@"select distinct {0} ,{1}
                    from {2} where type='em' and {3} between to_date('{4}','yyyy-mm-dd') and to_date('{5}','yyyy-mm-dd')
                    and asciistr(resource_uri)  like '%\%'"
                    , _ipAttr, _portAttr, _tableName, _insertion_time
                    , _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));
             }
            return strSql;
        }
    }
}
