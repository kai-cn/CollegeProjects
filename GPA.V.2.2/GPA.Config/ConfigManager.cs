using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace GPA.Config
{
    public class ConfigManager
    {
        private static Configuration config;

        public static DBConfig DBConf { get; set; }
        public static UpdateConfig UpdateConf { get; set; }
        public static LogConfig LogConf { get; set; }
        public static Configuration Config 
        {
            get { return config; }
            set { config = value; }
        }

       

        static ConfigManager()
        {
            string currPath = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = currPath.Substring(0, currPath.IndexOf("GPA.V.2.2") + 10) + @"\GPA.Presentation\bin\Debug\GPA.Presentation.exe";
            config = ConfigurationManager.OpenExeConfiguration(configPath);

            

            LoadDBConf();
            LoadLogConf();
            LoadUpdateConf();
            
        }

        private static void LoadDBConf()
        {

            DBConf = new DBConfig();
            //DBConf.OracleConnectionString=config.AppSettings.Settings[""]
        }

        private static void LoadUpdateConf()
        {
           UpdateConf= new UpdateConfig();
        }

        private static void LoadLogConf()
        {
           LogConf = new LogConfig();
        }

    }
}
