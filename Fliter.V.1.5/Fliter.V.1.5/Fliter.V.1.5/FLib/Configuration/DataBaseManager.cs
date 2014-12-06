using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Fliter.FLib.Configuration
{
     class DataBaseManager
    {
         public static string GetConnectionString(string conncetionName)
         {
             string connectionString = ConfigurationManager.ConnectionStrings[conncetionName].ConnectionString.ToString();

             return connectionString;
         }

         public static void UpdateConnectionString(string connectionName, string newConectionString)
         {
             bool isModified = false;

             if (ConfigurationManager.ConnectionStrings[connectionName] != null)
             {
                 isModified = true;
             }

             if (isModified)
             {
                 ConfigurationManager.ConnectionStrings[connectionName].ConnectionString = newConectionString;
             }

             ConfigurationManager.RefreshSection("ConnectionStrings");
         }
    }
}
