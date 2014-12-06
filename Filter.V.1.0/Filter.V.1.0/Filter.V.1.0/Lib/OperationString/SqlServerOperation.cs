using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filter.Lib.OperationString
{
    public class SqlServerOperation:OperationBase
    {
        public  SqlServerOperation()
        {
            /*BT*/
            distinct_TorPath_from_SBR = @"select distinct torrent_name from 
            spider_bt_resource where abd_flag=0";

            write_SBR_into_BRD = @"insert into bt_resource_daily(torrent_path)
            (select torrent_name from spider_bt_resource where abd_flag=0)";

            update_RLP_from_BRD = @"insert into resource_live_period(resource_uri
            ,ip_count,flag,type) select bt_resource_daily.torrent_path,0,0,'Bt' from
            bt_resource_daily where not exists 
            (select resource_uri,ip_count,flag,type,time from
            resource_live_period,bt_resource_daily where resource_uri=bt_resource_daily.torrent_path) ";

            delete_from_BRD = @"delete from bt_resource_daily";

            remark_SBR_flag = @"  update spider_bt_resource set abd_flag=1
            where exists 
            (select resource_uri from resource_live_period,spider_bt_resource 
            where (resource_live_period.flag>3 or resource_live_period.flag<-5) and 
            resource_uri=spider_bt_resource.torrent_name )";


            /*eMule*/
            distinct_ed2k_link_SER = @"select distinct ed2k_link 
            from spider_emule_resource and abd_flag=0 ";

            write_SER_into_ERD = @"insert into emule_resource_daily(ed2k_link)
            (select ed2k_link from spider_emule_resource where abd_flag=0)";

            update_RLP_from_ERD = @"insert into resource_live_period
            ([file_path/resource_link],ip_count,flag,source_type) 
            select emule_resource_daily.ed2k_link,0,0,'em' from
            emule_resource_daily
            where not exists 
            (select * from resource_live_period 
            where emule_resource_daily.ed2k_link=resource_live_period.[file_path/resource_link])";

            delete_from_ERD = @"delete from emule_resource_daily";

            remark_SER_flag = @"update spider_emule_resource set abd_flag=1
            where exists 
            (select [file_path/resource_link] from resource_live_period 
            where (resource_live_period.flag>3 or resource_live_period.flag<-5) and
            [file_path/resource_link]=spider_emule_resource.ed2k_link)";

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
            path_count_days_from_POD = @"select [file_path/resource_link],COUNT([peer/source_ip]),days,type from
            (select distinct [peer/source_ip] ,[file_path/resource_link],
            Convert(char,time,23)as days,type  from p2p_original_data )
            as dayLink where days!=CONVERT(varchar(100),getdate(),23) group by [file_path/resource_link],days,type";

            getOldTime = @"select distinct time from resource_live_period";
#endif

            all_from_RLP = @"select * from resource_live_period";

            delete_from_POD = @" delete from p2p_original_data where convert(char,time,23)!=convert(char,GETDATE(),23)";

            delete_from_RLP_flag = @"delete from resource_live_period where flag>3 or flag<-5";

            delete_from_RLP = @"delete from resource_live_period";

            Set_time = @"update resource_live_period set time='" + DateTime.Now.Date.AddDays(-1).ToString() + "'";
        }
    }
}
