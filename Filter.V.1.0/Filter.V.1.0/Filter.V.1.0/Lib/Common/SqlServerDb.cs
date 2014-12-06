using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Common.Database
{
    class SqlServerDb:DbBase
    {
        public  SqlServerDb(string conStr)
        {
            _conStr = conStr;
        }
        public  SqlConnection GetConnection()
        {
            return new SqlConnection(_conStr);
        }

        public override  bool ExSql(string strCmd)
        {
            bool bResult = false;
          
            SqlConnection con = GetConnection(); //连接数据库
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(strCmd, con);
                cmd.CommandTimeout = 0;
            
                cmd.ExecuteNonQuery();
                bResult = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                    
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            
            return bResult;
        }

        public override bool ExSql(string strCmd, bool isTransaction)
        {
            return false;
        }

        public override  DataSet reDs(string strCmd)
        {
            
            DataSet ds = new DataSet();

            SqlConnection con = GetConnection();
            try
            {

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(strCmd, con);

                da.SelectCommand.CommandTimeout = 0;
                    
                da.Fill(ds);

            }
            catch (Exception )
            {
              

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
             

             return ds;
        }

        public override DataSet reDs(string strCmd, bool isTransaction)
        {
            return null;
        }


        public override void BatchInsert(DataTable dt, string dbTableName)
        {
            
        }

        public override void BatchInsert(DataTable dt, string dbTableName, bool isTransaction)
        {
            
        }


        public override object reDataReader(string strCmd)
        {
            return null;
        }

        public override object BeginTransaction()
        {
            return null;
        }

        public override void EndTransaction()
        {
            
        }
    }
}
