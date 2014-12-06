using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace Utility.Log
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
                if (logFilePath == string.Empty)
                {
                    logFilePath= AppDomain.CurrentDomain.BaseDirectory;
                }
                return logFilePath;
            }
            set { logFilePath = value; }
        }

        public static void SetLogFilePath(string filePath)
        {
            logFilePath = filePath;
        }

        public static void WriteLog(LogFile logFileType, string msg)
        {
            WriteLog(logFileType.ToString(), msg);
        }


        public static void WriteLog(string logFileType, string msg)
        {
            string dateString = DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString();
            string logFile=LogFilePath+"\\"+logFileType+"\\"+dateString+".txt";

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
