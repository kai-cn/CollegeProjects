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
        OracleTransaction _trans;
        OracleConnection _con;
        OracleCommand _cmd;
        OracleDataAdapter _da;

        public OracleDb(string connectStr)
        {
            _conStr = connectStr;
        }

        private OracleConnection GetConnection()
        {
            return new OracleConnection(_conStr);
        }


        public override bool ExSql(string strCmd)
        {
            bool bResult = false;
            
            try
            {
                
                _con = GetConnection(); //连接数据库
                _con.Open();
                
                _cmd = new  OracleCommand(strCmd, _con);
                _cmd.CommandTimeout = 0;
                _cmd.ExecuteNonQuery();
                bResult = true;
            }
            catch (Exception )
            {
                
            }
            finally
            {
                _cmd.Dispose();
                _con.Close();
                _con.Dispose();
            }
            
            return bResult;
        }

        public override bool ExSql(string strCmd, bool isTransaction)
        {
            try
            {
                
                _cmd = new OracleCommand(strCmd, _con);
                //_cmd.CommandTimeout = 0;
                _cmd.Transaction = _trans;
                
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public override DataSet reDs(string strCmd)
        {
            DataSet ds = new DataSet();
            
            OracleDataAdapter da = null;

            try
            {
                
                _con = GetConnection();
                _con.Open();
                
                da = new OracleDataAdapter(strCmd, _con);
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(ds);
            }
            catch (Exception)
            {

            }
            finally
            {
                da.Dispose();
                _con.Close();
                _con.Dispose();
            }
            return ds;
        }

        public override DataSet reDs(string strCmd, bool isTransaction)
        {
            DataSet ds = new DataSet();
            try
            {
                _da = new OracleDataAdapter(strCmd, _con);
                _da.SelectCommand.CommandTimeout = 0;
                
                _da.Fill(ds);
            }
            catch (Exception)
            {

            }
            return ds;
        }

        public override void BatchInsert(DataTable dt,string dbTableName)
        {
            _con = GetConnection();
            OracleBulkCopy bulkCopy = null ;
            try
            {
                _con.Open();
                bulkCopy = new OracleBulkCopy(_con);
                
                bulkCopy.DestinationTableName = dbTableName;
                bulkCopy.BatchSize = dt.Rows.Count;
                bulkCopy.BulkCopyTimeout = 18000;
                if (dt != null && dt.Rows.Count != 0)
                    bulkCopy.WriteToServer(dt);
            }
            catch (Exception )
            {
                
            }
            finally
            {
                _con.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }

        }

        public override void BatchInsert(DataTable dt, string dbTableName, bool isTransaction)
        {
            
            OracleBulkCopy bulkCopy = null;
            try
            {
                
                bulkCopy = new OracleBulkCopy(_con);
                bulkCopy.DestinationTableName = dbTableName;
                bulkCopy.BatchSize = dt.Rows.Count;
                bulkCopy.BulkCopyTimeout = 18000;
                if (dt != null && dt.Rows.Count != 0)
                    bulkCopy.WriteToServer(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (bulkCopy != null)
                    bulkCopy.Close();
            }
        }



        public override object reDataReader(string strCmd)
        {
            
            _con = GetConnection();
            OracleDataReader dr = null;
            try
            {
                _con.Open();
                _cmd= new OracleCommand(strCmd,_con);
                _cmd.CommandTimeout=0;
                dr = _cmd.ExecuteReader();
            }
            catch (Exception)
            {
                dr.Close();
                _con.Close();
                _con.Dispose();
            }
            finally
            {
                _cmd.Dispose();
            }
            return dr;            
        }

        public override object BeginTransaction()
        {
            _con = GetConnection();
            _cmd = new OracleCommand();
            _cmd.Connection = _con;
            

            try
            {
                _con.Open();
                _trans = _con.BeginTransaction(IsolationLevel.ReadCommitted);
                
                return _trans;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        public override void EndTransaction()
        {
            if(_trans!=null)
                _trans.Dispose();
            _con.Close();
            _con.Dispose();
        }



    }
}
