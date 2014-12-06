using System;
using System.Collections.Generic;

using System.Web;


using System.Configuration;
/// <summary>
///DbAdapter 的摘要说明
/// </summary>
/// 

namespace NetUtil.DB
{
    public class DbFactory
    {
	    public DbFactory()
	    {
		    //
		    //TODO: 在此处添加构造函数逻辑
		    //
	    }

        public static DbUtil CreateDbUtil()
        {
            DbUtil dbUtil = null;
            try
            {
                //string connectionString= ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

                string connectionString = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
                if (connectionString != null)
                {
                    //dbUtil = new MySqlDbUtil(connectionString);
                    dbUtil = new SqlServerDbUtil(connectionString);
                }

            }
            catch (Exception ex)
            {
                Log.LogManager.WriteLog(Log.LogManager.LogFile.Error, "ConfigurationManager: " + ex.Message);
            }

            return dbUtil;
        }
    }
}