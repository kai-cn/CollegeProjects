using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filter.Lib.OperationString
{
    public class OracleOperation:OperationBase
    {
        public  OracleOperation()
        {
            /*BT*/
            distinct_TorPath_from_SBR = @"select distinct torrent_path from 
            spider_bt_resource where abd_flag=0";

            write_SBR_into_BRD = @"insert into bt_resource_daily(torrent_path)
            (select torrent_name from spider_bt_resource where abd_flag=0)";

            update_RLP_from_BRD = @"insert into resource_live_period(resource_uri
            ,ip_count,flag,type) 
            select bt_resource_daily.torrent_path,0,0,'bt' from
            bt_resource_daily
            where not exists 
            (select * from resource_live_period 
            where torrent_path=resource_live_period.resource_uri) ";


          


            delete_from_BRD = @"delete from bt_resource_daily";

            remark_SBR_flag = @" update spider_bt_resource set abd_flag=1
            where exists 
            (select * from resource_live_period
            where (resource_live_period.flag>3 or resource_live_period.flag<-5)and 
            resource_uri=torrent_name )";

            select_count_BRD = "select count(*) from bt_resource_daily";

            select_BRD = "select torrent_name,abd_flag from spider_bt_resource where abd_flag=0";


            /*eMule*/
            distinct_ed2k_link_SER = @"select distinct ed2k_link 
            from spider_emule_resource where abd_flag=0 ";

            write_SER_into_ERD = @"insert into emule_resource_daily(ed2k_link)
            (select ed2k_link from spider_emule_resource where abd_flag=0)";

            update_RLP_from_ERD = @"insert into resource_live_period
            (resource_uri,ip_count,flag,type) 
            select emule_resource_daily.ed2k_link,0,0,'em' from
            emule_resource_daily
            where not exists 
            (select * from
            resource_live_period where resource_uri=ed2k_link)";

            delete_from_ERD = @"delete from emule_resource_daily";

            remark_SER_flag = @"   update spider_emule_resource set abd_flag=1
            where exists 
            (select * from resource_live_period
            where (resource_live_period.flag>3 or resource_live_period.flag<-5) and
            resource_uri=ed2k_link)";

            select_count_ERD = "select count(*) from emule_resource_daily";
            select_ERD = "select ed2k_link,abd_flag from spider_emule_resource where abd_flag=0";
            /*Other*/

#if (p2p_original_data_bak)
            path_count_days_from_POD = @"select [file_path/resource_link],COUNT([peer/source_ip]) ip_count,days,type from
            (select distinct [peer/source_ip] ,[file_path/resource_link],
            Convert(char,time,23)as days,type  from p2p_original_data_bak)
            as dayLink where days between '2011-09-04' and '2011-09-14'
            group by [file_path/resource_link],days,type";

            startTime = new DateTime(2011, 9, 4);
            endTime = new DateTime(2011, 9, 14);
#else
            /*计算p2p_original_data_bak中的数据*/
            path_count_days_from_POD = @"select resource_uri,COUNT(peer_ip),days,type from
            (select distinct peer_ip ,resource_uri,
            to_char(insertion_time,'yyyy-mm-dd')  as days,type  from p2p_original_data)
            where days!=to_char(sysdate,'yyyy-mm-dd') group by resource_uri,days,type";

            getOldTime = @"select distinct time from resource_live_period";
#endif

            all_from_RLP = @"select * from resource_live_period";

            delete_from_POD = @"delete from p2p_original_data where to_date(insertion_time,'yyyy-mm-dd')!=to_date(sysdate,'yyyy-mm-dd')";

            delete_from_RLP_flag = @"delete from resource_live_period where flag>3 or flag<-5";

            delete_from_RLP = @"delete from resource_live_period";

            Set_time = string.Format(@"update resource_live_period set time=to_date('{0}','yyyy-mm-dd')", DateTime.Now.Date.AddDays(-1).ToString("yyyy-MM-dd"));

            getOldTimeFromOriginalData = "select insertion_time from p2p_original_data order by insertion_time";
        }
    }
}
