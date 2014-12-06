using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common.Database;

namespace  GPA.GPALib.DatabaseOriginalData
{
    /// <summary>
    /// 存储国外bt的数据集
    /// </summary>
    class DbIpPortForeignBtData:DbIpPortDataBase
    {

        public DbIpPortForeignBtData(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition):
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
                
                strSql = string.Format(@"select distinct {0} ,to_char( {1} ,'yyyy-mm-dd'),resource_uri
                    from {2}  where type='bt' and {3} between to_date('{4}','yyyy-mm-dd') 
                    and to_date('{5}','yyyy-mm-dd') and regexp_instr(resource_uri,'_')<>0 "
                    , _ipAttr, _insertion_time,_tableName, _insertion_time
                    , _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));
                
            }
            return strSql;
        }
    }
}
