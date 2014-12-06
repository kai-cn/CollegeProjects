using System;
using System.Collections.Generic;

using System.Web;


using System.Data;
using System.Data.SqlClient;
/// <summary>
///SqlServerDbUtil 的摘要说明
/// </summary>
namespace NetUtil.DB
{
    class SqlServerDbUtil : DbUtil
    {

        private SqlConnection con;
        private SqlCommand cmd;


        public SqlServerDbUtil(string connectionString)
        {
            //
            //TODO: 在此处添加构造函数逻辑

            //
            this.connectString = connectionString;

        }

        public override void SetConnectionString(string connectionStr)
        {
            this.connectString = connectionStr;
        }

        protected override object GetConnection()
        {
            return new SqlConnection(connectString);
        }


        public override void ExecNoQuery(string sqlStr)
        {
            con = GetConnection() as SqlConnection;

            try
            {
                con.Open();
                cmd = new SqlCommand(sqlStr, con);
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.LogManager.WriteLog(Log.LogManager.LogFile.Error, "ExecNoQuery: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public override DataSet Select(string sqlStr)
        {
            DataSet ds = new DataSet();
            con = GetConnection() as SqlConnection;
            SqlDataAdapter da = null;

            try
            {
                con.Open();
                da = new SqlDataAdapter(sqlStr, con);
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                Log.LogManager.WriteLog(Log.LogManager.LogFile.Error, "Select: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
    }
}
