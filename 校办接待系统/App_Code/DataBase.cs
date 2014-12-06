using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// DataBase 的摘要说明
/// </summary>
namespace LLQ
{
    public class DataBase
    {
        protected SqlConnection conn;
        protected SqlCommand command;
        protected SqlDataAdapter da;
        protected SqlDataReader reader;
        protected DataSet set;

        public DataBase()
        {
            conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        }
        public DataBase(string connstr)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connstr;
        }

        public int ExecuteNonQuery(string NonQueryCmdStr)
        {
            Close();
            int result = -1;
            command = new SqlCommand(NonQueryCmdStr, conn);
            try
            {
                command.Connection.Open();
                result = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch
            {
                return -1;
            }
            return result;
        }
        public SqlDataReader GetSqlDataReader(string SelCmdStr)
        {
            Close();
            command = new SqlCommand(SelCmdStr, conn);
            try
            {
                command.Connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public DataSet GetDataSet(string SelCmdStr)
        {
            Close();
            set = new DataSet();
            da = new SqlDataAdapter(SelCmdStr, conn);
            try
            {
                da.Fill(set);
                if (set != null)
                    return set;
                else
                    return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public void Close()
        {
            if (reader != null && !reader.IsClosed)
            {
                reader.Close();
            }
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
    }
}