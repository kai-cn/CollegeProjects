using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GPA
{
    /// <summary>
    ///DB 的摘要说明
    /// </summary>
    public class DB
    {

        /// <summary>
        /// 配置连接字符串
        /// </summary>
        /// <returns></returns>
        /// 

        //数据库配置constr="server=192.168.130.146;uid=sklcc;pwd=sklcc503;database=sklcc_p2p(new)";
        private string conStr;

        public DB()
        {
            this.conStr = @"server=192.168.135.13;uid=sklcc;pwd=sklcc503;database=sklcc_p2p(new)";
        }

        public SqlConnection GetCon()
        {
            return new SqlConnection(conStr);
        }

        public bool ExSql(string P_str_cmdtxt)
        {
            SqlConnection con = GetCon(); //连接数据库
            con.Open();
            SqlCommand cmd = new SqlCommand(P_str_cmdtxt, con);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Dispose();
            }
        }

        public DataSet reDs(string P_str_cmdtxt)
        {
            SqlConnection con = GetCon();
            SqlDataAdapter da = new SqlDataAdapter(P_str_cmdtxt, con);
            DataSet ds = new DataSet();

            da.Fill(ds);
            return ds;
        }



    }
}