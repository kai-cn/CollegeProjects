using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;

namespace Fliter.FLib.Configuration
{
    class AppStringsManager
    {
        public static string GetCenterServerIP()
        {
            string centerServerIP = ConfigurationManager.AppSettings["CenterServerIP"];
            
            return centerServerIP;
        }

        public static void UpdateCenterServerIP(string centerServerIP)
        {
            bool isModified = false;

            if (ConfigurationManager.AppSettings["CenterSserverIP"] != null)
            {
                isModified = true;
            }

            if (isModified)
            {
                ConfigurationManager.AppSettings["CenterServerIP"] = centerServerIP;
            }

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
