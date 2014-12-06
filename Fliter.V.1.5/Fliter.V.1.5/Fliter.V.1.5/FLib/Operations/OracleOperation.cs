using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NetUtil.db;

namespace Fliter.FLib.Operations
{
    class OracleOperation:OperationBase
    {
         
        public OracleOperation(AMDBUtil util):base(util)
        { 

        }

        public override DataSet SelectSpiderResource(string type)
        {
            string attribute = "torrent_path";
            string tableName = "spider_bt_resource";


            if (type.ToLower() == "emule")
            {
                attribute = "ed2k_link";
                tableName = "spider_emule_resource";
            }

            string sqlStr = string.Format("select distinct {0} from {1} where abd_flag=0", attribute, tableName);

            return dbUtil.Select(sqlStr);

        }

        public override DataSet SelectResourceDailyCount(string type)
        {
            string tableName = "bt_resource_daily";

            if (type.ToLower() == "emule")
            {
                tableName = "emule_resource_daily";
            }

            string strSql = string.Format("select count(*) from {0}", tableName);

            return dbUtil.Select(strSql); 
        }

        public override void InsertToResourceDaily(string type)
        {
            string targetTableName = "bt_resource_daily";
            string targetAttribute = "torrent_path";
            string sourceTableName = "spider_bt_resource";
            string sourceAttribute = "torrent_name";

            if (type.ToLower() == "emule")
            {
                targetTableName = "emule_resource_daily";
                targetAttribute = "ed2k_link";
                sourceTableName = "spider_emule_resource";
                sourceAttribute = "ed2k_link"; 
            }

            string strSql = string.Format("insert into {0}({1}) (select {2} from {3} where abd_flag=0)", targetTableName, targetAttribute, sourceAttribute, sourceTableName);

            dbUtil.ExecuteNonQueryCommand(strSql);   
        }

        public override void InsertToResourceLivePeriod(string type)
        {
            //string targetTableName = "resource_live_period";
            //string[] targetAttributes = { "resource_uri", "ip_count", "flag", "type" };

            string sourceTableName = "bt_resource_daily";
            string[] sourceAttributes = { "torrent_path", "bt" };

            if (type.ToLower() == "emule")
            {
                sourceTableName = "emule_resource_daily";
                sourceAttributes[0] = "ed2k_link";
                sourceAttributes[1] = "em";
            }

            string strSql = string.Format(@"insert into resource_live_period(resource_uri,ip_count,flag,type)
                                          select {0}.{1},0,0,{2} from {3} 
                                          where not exists( 
                                          select * from resource_live_period where {4}=resource_live_period.resource_uri)",
                                        sourceTableName, sourceAttributes[0], sourceAttributes[1], sourceTableName, sourceAttributes[0]);

            dbUtil.ExecuteNonQueryCommand(strSql);

                                
        }

        public override void UpdateSpiderResource(string type)
        {
            string targetTableName = "spider_bt_resource";
            string targetAttribute = "torrent_name";

            if (type.ToLower() == "emule")
            {
                targetAttribute = "spider_emule_resource";
                targetTableName = "ed2k_link";
            }

            string sqlStr=string.Format(@"update {0} set abd_flag=1 where exists
                                          (select * from resource_live_period where 
                                          (resource_live_period.flag>3 or resource_live_period.flag<-5)
                                           and resource_uri={1})",targetTableName,targetAttribute);

            dbUtil.ExecuteNonQueryCommand(sqlStr);
        }


        public override void DeleteResourceDaily(string type)
        {
            string tableName = "bt_resource_daily";

            if (type.ToLower() == "emule")
            {
                tableName = "emule_resource_daily";
            }

            string sqlStr = string.Format("delete from {0}", tableName);

            dbUtil.ExecuteNonQueryCommand(sqlStr);
        }
    }
}
