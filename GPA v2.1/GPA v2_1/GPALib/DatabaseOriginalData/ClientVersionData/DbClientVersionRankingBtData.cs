using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Common.Database;


namespace GPA.GPALib.DatabaseOriginalData
{
    class DbClientVersionRankingBtData:DbClientVersionRankingDataBase
    {
        public DbClientVersionRankingBtData(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
            base(ref dbBase, beginTime, endTime, isPartition) 
        {            }


        /// <summary>
        /// 根据获取到的参数的不同返回不同的sql语言
        /// </summary>
        /// <returns>sql语言</returns>
        protected override string GetCommand()
        {
            string strSql;
            if (!_dbType.Contains("Oracle"))
            {
                strSql = string.Format(@"select distinct {0} from {1}  where type='bt' and
                CONVERT(char,time,23) between '{2}' and '{3}' and RIGHT([file_path/resource_link],48) not
                like '[a-z|0-9]%.torrent'", _ipAttr, _tableName, _beginTime.ToString("yyyy-mm-dd"), _endTime.ToString("yyyy-mm-dd"));
            }
            else
            {

                strSql = string.Format(@"select distinct client_ver,client_ip
                    from p2p_client_ver where type='bt'   and {0} between to_date('{1}','yyyy-mm-dd') 
                    and to_date('{2}','yyyy-mm-dd')"
                  , _insertion_time
                  , _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));
                
            }
            return strSql;
        }
    }
}
