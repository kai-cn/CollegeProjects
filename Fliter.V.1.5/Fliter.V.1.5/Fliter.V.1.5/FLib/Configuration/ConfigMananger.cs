using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fliter.FLib.Configuration
{
    class ConfigMananger
    {

        public static string GetCenterServerIP()
        {
            return AppStringsManager.GetCenterServerIP();
        }

        public static void UpdateCenterServerIP(string centerServerIP)
        {
            AppStringsManager.UpdateCenterServerIP(centerServerIP);
        }

        public static string GetConnectionString(string conncetionName)
        {
            return DataBaseManager.GetConnectionString(conncetionName);
        }

        public static void UpdateConnectionString(string connectionName, string newConectionString)
        {
            DataBaseManager.UpdateConnectionString(connectionName, newConectionString);
        }
    }
}
