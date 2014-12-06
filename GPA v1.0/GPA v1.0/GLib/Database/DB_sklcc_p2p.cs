using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace GPA
{
    class DB_p2p_original_data  :DB
    {
        //获取全部bt的IP
        public DataTable GetAllBtIpInfo()
        {
            DataSet ds = new DataSet();
            string cmdString = @"select distinct [peer/source_ip] from p2p_original_data where type='Bt'";
            ds = reDs(cmdString);
            return ds.Tables[0];
        }

        //获取国内BT的IP
        public DataTable GetInternalBtIpInfo()
        {
            DataSet ds = new DataSet();
            string cmdString = @"select distinct [peer/source_ip] from p2p_original_data 
                       where type='Bt'and [file_path/resource_link] not like '[A-Z|a-z]+'";
            ds = reDs(cmdString);
            return ds.Tables[0];
        }


        //获取国外BT的IP
        public DataTable GetForeignBtIpInfo()
        {
            DataSet ds = new DataSet();
            string cmdString = @"select distinct [peer/source_ip] from p2p_original_data 
                       where type='Bt'and [file_path/resource_link]  like '[A-Z|a-z]+'";
            ds = reDs(cmdString);
            return ds.Tables[0]; 
        }


        //获取全部emule的IP
        public DataTable GetEmIpInfo()
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = GetCon();
            string cmdString = @"select distinct [peer/source_ip] from p2p_original_data where type='em'";
            ds = reDs(cmdString);
            return ds.Tables[0];
        }

        //获取全部bt的Port
        public DataTable GetAllBtPort()
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = GetCon();
            string cmdString = @"select distinct [peer/source_ip], [peer/source_port]  from p2p_original_data where  type='Bt'";
            ds = reDs(cmdString);
            return ds.Tables[0];
        }


        //获取国内bt的port
        public DataTable GetInternalBtPort()
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = GetCon();
            string cmdString = @"select distinct [peer/source_ip],[peer/source_port]  from p2p_original_data where  type='Bt' and [file_path/resource_link] not like '[A-Z|a-z]+'";
            ds = reDs(cmdString);
            return ds.Tables[0]; 
        }

        //获取国外bt的port
        public DataTable GetForeignBtPort()
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = GetCon();
            string cmdString = @"select distinct [peer/source_ip], [peer/source_port] from p2p_original_data where  type='Bt' [file_path/resource_link] not like '[A-Z|a-z]+'";
            ds = reDs(cmdString);
            return ds.Tables[0];  
        }


        //获取全部emule的port
        public DataTable GetAllEmPort()
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = GetCon();
            string cmdString = @"select distinct [peer/source_ip], [peer/source_port] from p2p_original_data where  type='em'";
            ds = reDs(cmdString);
            return ds.Tables[0];
 
        }

    }
}
