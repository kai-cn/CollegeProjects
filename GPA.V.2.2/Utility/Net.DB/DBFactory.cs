using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

using GPA.Config;

namespace Utility.Net.DB
{
    public class DBFactory
    {
        public enum DBMode
        {
            LocalDB,

            RemoteWebDB,

            LocalWebDB
        }

        public static DBAdapter GetDBAdapter(DBMode mode)
        {
            
            
            string appSetting =ConfigManager.Config.AppSettings.Settings[mode.ToString()].Value;

            string conStr = ConfigManager.Config.ConnectionStrings.ConnectionStrings[mode.ToString()].ConnectionString;
            DBAdapter adapter= Assembly.Load("Utility").CreateInstance("Utility.Net.DB."+ appSetting) as DBAdapter;
            adapter.ConnectionString = conStr;
            return adapter;
        }

       
    }
}
