using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GPA
{
    class DB_spider_resource_daily:DB
    {
        //获取bt的torrent_path
        public DataTable GetTorrent_path()
        {
            DataSet ds = new DataSet();
            string cmdString = @"select distinct torrent_path from spider_bt_resource where abd_flag!=0 ";
            ds = reDs(cmdString);
            return ds.Tables[0];
        }




        //获取活跃的bt文件
        public DataTable GetHandledTorrent_path_live()
        {
            DataSet ds = new DataSet();
            string cmdString = @" 
             select torrent_path from spider_bt_resource where  exists 
            (select [file_path/resource_link] from 
            p2p_original_data where [file_path/resource_link]=torrent_path) 
            and abd_flag!=0 ";
            ds = reDs(cmdString);
            return ds.Tables[0];  
        }

        //获取不活跃的bt文件
        public DataTable GetHandledTorrent_path_not_live()
        {
            DataSet ds = new DataSet();
            string cmdString = @" 
            select torrent_path from spider_bt_resource where not exists 
            (select [file_path/resource_link] from 
            p2p_original_data where [file_path/resource_link]=torrent_path) 
            and abd_flag!=0";
            ds = reDs(cmdString);
            return ds.Tables[0];  
        }

        //将活跃BT的文件更新到Bt_resource_daily中
        public bool WriteIntoBt_resource_daily()
        {
            string cmdString=@"insert into bt_resource_daily(torrent_path)
                (select torrent_path from spider_bt_resource where  exists 
                (select [file_path/resource_link] from 
                p2p_original_data where [file_path/resource_link]=torrent_path))";
            return ExSql(cmdString);
        }

        //将不活跃的文件在spider_bt_resource中做标记
        public bool RemarkBt_resource_daily()
        {
            string cmdString = @"update spider_bt_resource set abd_flag=0 
                where not exists (select  torrent_path from bt_resource_daily  where
                spider_bt_resource.torrent_path=bt_resource_daily.torrent_path)";
            return ExSql(cmdString); 
        }

        //获取EM的ed2k_link
        public DataTable GetEd2k_link()
        {
            DataSet ds = new DataSet();
            string cmdString = @"select distinct ed2k_link from spider_emule_resource and abd_flag!=0 ";
            ds = reDs(cmdString);
            return ds.Tables[0];
        }

        //获取em活跃的文件
        public DataTable GetHandledEd2k_link_live()
        {
            DataSet ds = new DataSet();
            string cmdString = @"select ed2k_link from spider_emule_resource 
                    where  exists (select [file_path/resource_link] from 
                    p2p_original_data where [file_path/resource_link]=ed2k_link)
                    and abd_flag!=0";
            ds = reDs(cmdString);
            return ds.Tables[0];
        }


        //获取em不活跃的文件
        public DataTable GetHandledEd2k_link_not_live()
        {
            DataSet ds = new DataSet();
            string cmdString = @"select ed2k_link from spider_emule_resource 
                    where  exists (select [file_path/resource_link] from 
                    p2p_original_data where [file_path/resource_link]=ed2k_link) 
                    and abd_flag!=0";
            ds = reDs(cmdString);
            return ds.Tables[0]; 
        }

        //将活跃em的文件更新到emule_resource_daily中
        public bool WriteIntoEmule_resource_daily()
        {
            string cmdString = @"insert into emule_resource_daily(ed2k_link) 
                    (select ed2k_link from spider_emule_resource where  exists 
                    (select [file_path/resource_link] from 
                     p2p_original_data where [file_path/resource_link]=ed2k_link))";
            return  ExSql(cmdString);
        }


        //将不活跃em的文件在spider_emule_resource表中做标记
        public bool RemarkSpider_emule_resource()
        {
            string cmdString = @"update spider_emule_resource set abd_flag=0 
                where not exists (select ed2k_link  from emule_resource_daily where
                spider_emule_resource.ed2k_link=emule_resource_daily.ed2k_link)";
            return ExSql(cmdString);
        }




        //将p2p_original_data中的数据写入到p2p_original_data_bak中
        public bool WriteIntoP2p_original_data_bak()
        {
            string cmdString=@"insert into p2p_original_data_bak
                (time,type,[file_path/resource_link],infohash,[tracker/server_ip],
                [tracker/server_port],[peer/source_ip],[peer/source_port],ip,port,other)
                (select * from p2p_original_data)";
            return ExSql(cmdString);
        
        }

        //将p2p_original_data中的数据删除
        public bool DeleteP2p_original_data()
        {
            string cmdSring = @"delete from p2p_original_data";
            return ExSql(cmdSring);
        }
    }
}
