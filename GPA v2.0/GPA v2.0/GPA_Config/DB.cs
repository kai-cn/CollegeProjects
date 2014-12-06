using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GPA.GPA_Config
{
    class DB
    {

        /// <summary>
        /// 配置连接字符串
        /// </summary>
        /// <returns></returns>
        /// 

        //数据库配置constr="server=192.168.130.146;uid=sklcc;pwd=sklcc503;database=sklcc_p2p(new)";
        private string conStr;
        private XmlConfigure xmlConf;

        public DB()
        {
            xmlConf =XmlConfigure.GetInstance();
           // xmlConf.Load("XMLDBConfig.xml");
           // this.conStr = @"server=192.168.130.146;uid=sklcc;pwd=sklcc503;database=sklcc_p2p(new)";
            this.conStr = xmlConf.GetConnectString();
        }
        public  SqlConnection GetCon()
        {
            return new SqlConnection(conStr);
        }

        public  bool ExSql(string P_str_cmdtxt)
        {
            bool bResult = false;
            while (!bResult)
            {
                SqlConnection con = GetCon(); //连接数据库
            
                con.Open();
                SqlCommand cmd = new SqlCommand(P_str_cmdtxt, con);
                cmd.CommandTimeout = 0;
                try
                {
                    cmd.ExecuteNonQuery();
                    bResult = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                finally
                {
                    con.Dispose();
                }
            }
            return bResult;
        }

        public  DataSet reDs(string P_str_cmdtxt)
        {
            
            DataSet ds = new DataSet();
            
            bool bResult=false;

             while(!bResult)
             {
                 SqlConnection con = GetCon();
                 try
                 {
                     
                     SqlDataAdapter da = new SqlDataAdapter(P_str_cmdtxt, con);

                     da.SelectCommand.CommandTimeout = 0;
                     

                     
                     da.Fill(ds);

                     bResult = true;
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);

                 }
                 finally
                 {
                     con.Dispose();
                 }
             }

             return ds;
        }



    }
}