using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Common.Database
{
    /// <summary>
    /// 功能描述:提供对所有数据库操作的接口
    /// 修改日期:2012/3/21
    /// </summary>
    public abstract class DbBase
    {

        
        
        protected string _conStr;//连接字符串
        

        /// <summary>
        /// 
        /// </summary>
        public DbBase() { }
       
        /// <summary>
        /// 连接数据库并执行一条sql语句
        /// </summary>
        /// <param name="strCmd">当前要执行的sql语句</param>
        /// <returns></returns>
        public abstract  bool ExSql(string strCmd);

        public abstract void SetConnectString(string connectString);
        
        
        /// <summary>
        /// 执行一条select语句并返回响应的数据集
        /// </summary>
        /// <param name="strCmd">当前要执行的sql语句</param>
        /// <returns>数据集</returns>
        public abstract  DataSet reDs(string strCmd);
        
        /// <summary>
        /// 将datatable中的数据插入到"dbtableName"表中
        /// </summary>
        /// <param name="dt">要插入的数据集</param>
        /// <param name="dbTableName">数据库中表的名称</param>
        public abstract void BatchInsert(DataTable dt,string dbTableName);

        public abstract bool ExistData(string strCmd);

        public abstract object reDataReader(string strCmd);

    }
}