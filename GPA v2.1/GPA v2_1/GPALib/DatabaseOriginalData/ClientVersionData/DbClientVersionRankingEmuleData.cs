using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Common.Database;


namespace GPA.GPALib.DatabaseOriginalData
{
    class DbClientVersionRankingEmuleData:DbClientVersionRankingDataBase
    {
        public  DbClientVersionRankingEmuleData(ref DbBase dbBase, DateTime beginTime, DateTime endTime, bool isPartition) :
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
                strSql = "";
            }
            else
            {
                
                strSql = string.Format(@"select distinct client_ver,client_ip
                    from p2p_client_ver where type='em'   and {0} between to_date('{1}','yyyy-mm-dd') 
                    and to_date('{2}','yyyy-mm-dd')"
                    , _insertion_time
                    , _beginTime.ToString("yyyy-MM-dd"), _endTime.ToString("yyyy-MM-dd"));
                
            }
            return strSql;
        }
    }
}
