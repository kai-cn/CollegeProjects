using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Configuration;

namespace NetUtil.Log
{
     public class LogManager
    {
        private static string logFilePath=string.Empty;

        public enum LogFile
        { 
            Error,
            Trace,
            Warning
        }

        public static string LogFilePath
        {
            get 
            {
                if ((logFilePath=ConfigurationManager.AppSettings["logLocation"]) == string.Empty)
                {
                    logFilePath= AppDomain.CurrentDomain.BaseDirectory;
                }
                return logFilePath;
            }
            set { logFilePath = value; }
        }

        public static void WriteLog(LogFile logFileType, string msg)
        {
            WriteLog(logFileType.ToString(), msg);
        }


        public static void WriteLog(string logFileType, string msg)
        { 
            string logFile=LogFilePath+logFileType+".txt";

            try
            {
                StreamWriter sw = File.AppendText(logFile);

                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss: ") + msg);

                sw.Close();
            }
            catch
            {
            }
                
        }

        

        
    }
}
