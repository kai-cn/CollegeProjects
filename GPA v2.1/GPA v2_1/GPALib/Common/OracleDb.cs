using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

using Oracle.DataAccess.Client;

namespace Common.Database
{
    /// <summary>
    /// 提供对oracle数据库的各种操作,具体函数意义可参照DbBase
    /// </summary>
    class OracleDb:DbBase
    {

        public OracleDb(string connectStr)
        {
            _conStr = connectStr;
        }

        private OracleConnection GetConnection()
        {
            return new OracleConnection(_conStr);
        }

        public override void SetConnectString(string connectString)
        {
            _conStr = connectString;
        }


        public override bool ExSql(string strCmd)
        {
            bool bResult = false;
            OracleConnection con = GetConnection(); //连接数据库
            OracleCommand cmd = null;

            try
            {

                con.Open();
                cmd = new  OracleCommand(strCmd, con);
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                bResult = true;
            }
            catch (Exception )
            {
                
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            
            return bResult;
        }


        public override DataSet reDs(string strCmd)
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
            catch (Exception e)
            {

            }
            finally
            {
                
                con.Close();
                con.Dispose();
            }
            return ds;
        }

        public override void BatchInsert(DataTable dt,string dbTableName)
        {
            OracleConnection con = GetConnection();
            OracleBulkCopy bulkCopy = null ;
            //bulkCopy.
            try
            {
                con.Open();
                bulkCopy = new OracleBulkCopy(con);
                bulkCopy.DestinationTableName = dbTableName;
                bulkCopy.BatchSize = dt.Rows.Count;
                bulkCopy.BulkCopyTimeout = 18000000;
                //bulkCopy.
                if (dt != null && dt.Rows.Count != 0)
                    bulkCopy.WriteToServer(dt);
            }
            catch (Exception e )
            {
                
            }
            finally
            {
                con.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }

        }

        public override object reDataReader(string strCmd)
        {
            
            OracleConnection con = GetConnection();
            OracleDataReader dr = null;
            OracleCommand com=null;
            

            try
            {
                con.Open();
                com= new OracleCommand(strCmd,con);
                com.CommandTimeout=0;
                dr = com.ExecuteReader();
            }
            catch (Exception)
            {
                dr.Close();
                con.Close();
                con.Dispose();
            }
            finally
            {
                com.Dispose();
            }
            return dr;            
        }

        public override bool ExistData(string strCmd)
        {
            OracleConnection con = GetConnection();
            OracleDataReader dr = null;
            OracleCommand com = null;


            try
            {
                con.Open();
                com = new OracleCommand(strCmd, con);
                com.CommandTimeout = 0;
                dr = com.ExecuteReader();
            }
            catch (Exception e)
            {
                if(dr!=null)
                    dr.Close();
                con.Close();
                con.Dispose();
            }
            finally
            {
                com.Dispose();
            }
            if (dr == null)
                return false;

            if (dr.HasRows)
                return true;
            else
                return false;
        }


    }
}
