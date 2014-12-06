using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Oracle.DataAccess.Client;

namespace Utility.Net.DB
{
    class OracleDB:DBAdapter
    {
        public OracleDB(string connectStr)
        {
            ConnectionString = connectStr;
        }

        public OracleDB()
        {
 
        }

        private OracleConnection GetConnection()
        {
            try
            {
               return new OracleConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                Log.LogManager.WriteLog(Log.LogManager.LogFile.Error, ex.Message);
            }

            return null;
        }

        public override int ExecNonQuery(string strCmd)
        {
            int result=0;
            OracleConnection con = GetConnection(); //连接数据库
            OracleCommand cmd = null;

            try
            {

                con.Open();
                cmd = new OracleCommand(strCmd, con);
                cmd.CommandTimeout = 0;
                result= cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Utility.Log.LogManager.WriteLog(Log.LogManager.LogFile.Error, "OracleDB" + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return result;
        }

        public override System.Data.DataSet Select(string strCmd)
        {
            DataSet ds = new DataSet();
            OracleConnection con = GetConnection();
            OracleDataAdapter da = null;

            try
            {
                con.Open();
                da = new OracleDataAdapter(strCmd, con);
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                Utility.Log.LogManager.WriteLog(Log.LogManager.LogFile.Error, "OracleDB" + ex.Message);
            }
            finally
            {

                con.Close();
                con.Dispose();
            }
            return ds;
        }

        public override void BatchInsert(System.Data.DataTable dt, string tableName)
        {
            OracleConnection con = GetConnection();
            Oracle.DataAccess.Client.OracleBulkCopy bulkCopy = null;
            try
            {
                con.Open();
                bulkCopy = new Oracle.DataAccess.Client.OracleBulkCopy(con);
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BatchSize = dt.Rows.Count;
                bulkCopy.BulkCopyTimeout = 18000000;
                if (dt != null && dt.Rows.Count != 0)
                    bulkCopy.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                Utility.Log.LogManager.WriteLog(Log.LogManager.LogFile.Error, "OracleDB" + ex.Message);
            }
            finally
            {
                con.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }
        }
    }
}
