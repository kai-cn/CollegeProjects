using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace GPA.GPA_Ftp
{
    class FtpLog
    {
        //每个月建立一次日志文件
        private StreamReader sr;
        private StreamWriter sw;
        private string fileName;
        private string lastLine;


        public FtpLog()
        {
            fileName="FtpLog"+DateTime.Now.Year+"_"+DateTime.Now.Month+".txt";
            if(!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));

            lastLine = string.Empty;
            while (!sr.EndOfStream)
            {
                lastLine = sr.ReadLine();
            }
            sr.Close();
            sw=new StreamWriter(new FileStream(fileName,FileMode.Append,FileAccess.Write));
        }

        public void Write(string status)
        {
            sw.WriteLine(status);
        }

        public void Close()
        {
            sw.Close();
        }

        public string GetUploadDir()
        {
            if (lastLine != string.Empty)
            {
                return lastLine.Split(':')[2];
            }
            else
                return null;
        }

        public string GetUploadFile()
        {
            if (lastLine != string.Empty)
            {
                return lastLine.Split(':')[3];
            }
            else
                return null;
        }
            
    }
}
