using System;
using System.Collections.Generic;

using System.Web;

using System.Data;

/// <summary>
///DbUtil 的摘要说明
/// </summary>
/// 

namespace NetUtil.DB
{

     public abstract class DbUtil
    {
        protected string connectString;

        public abstract void ExecNoQuery(string sqlStr);
        public abstract DataSet Select(string sqlStr);
        protected abstract object GetConnection();

        public abstract void SetConnectionString(string connectionStr);
        
    }
}