using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;

using GPA.GPA_Config;

namespace GPA.GPA_Ftp
{
    class FtpClient
    {
      //  private string ftpServerIP;
     //   private string ftpRemotePath;
        private string ftpUserID;
        private string ftpPassword;
        private string ftpURI;
        private FtpLog ftpLog;
        private DirectoryInfo uploadDir;
        




        public FtpClient()
        {
            XmlConfigure xmlConf = XmlConfigure.GetInstance();
            
                
            ftpURI = xmlConf.GetFtpServer();
            ftpUserID = xmlConf.GetFtpUid();
            ftpPassword = xmlConf.GetFtpPwd();
            ftpLog = new FtpLog();
            uploadDir = new DirectoryInfo(xmlConf.GetFtpLocalPath());
            
        }

        private List<FileInfo> CreatefileList(DirectoryInfo dirInfo)
        {
            if (!dirInfo.Exists)
            {
                return null;
            }
            else
            {
                List<FileInfo> fileList;
                fileList = new List<FileInfo>();
                FileInfo[] fileInfoes = dirInfo.GetFiles();
                foreach (FileInfo file in fileInfoes)
                {
                    fileList.Add(file);
                }
                return fileList;
            }
        }



        private List<FileInfo> CreatefileList(string fileName, DirectoryInfo dirInfo)
        {
            if (!dirInfo.Exists)
            {
                return null;
            }
            else
            {
                List<FileInfo> fileList;
                fileList = new List<FileInfo>();
                FileInfo lastFileInfo = new FileInfo(fileName);
                FileInfo[] fileInfoes = dirInfo.GetFiles();
                foreach (FileInfo file in fileInfoes)
                {
                    fileList.Add(file);
                }
                if (fileList.Contains(lastFileInfo))
                {
                    for (int i = 0; i < fileList.IndexOf(lastFileInfo); i++)
                    {
                        fileList.Remove(fileList[i]);
                    }
                }
                return fileList;
            }            
        }

        private void Upload(FileInfo fileInfo)
        {

            string fileName = fileInfo.Directory.Parent.Name + @"/" + fileInfo.Directory.Name + @"/"+fileInfo.Name;
            FtpWebRequest reqFtp;
            
            reqFtp = (FtpWebRequest)FtpWebRequest.Create(ftpURI+fileName);
            reqFtp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFtp.KeepAlive = false;
            reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            reqFtp.UseBinary = true;
            reqFtp.ContentLength = fileInfo.Length;
            int buffLength=1024;
            byte[] buff = new byte[buffLength];
            int contentLength;
            FileStream fileStream = fileInfo.OpenRead();
            try
            {
                Stream stream = reqFtp.GetRequestStream();
                contentLength = fileStream.Read(buff, 0, buffLength);
                while (contentLength != 0)
                {
                    stream.Write(buff, 0, contentLength);
                    contentLength = fileStream.Read(buff, 0, buffLength);
                }
                stream.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                ftpLog.Write(ex.Message);
            }

        }


        private void MakeDir(string dirName)
        {
            FtpWebRequest ftpReq;

            try
            {
                ftpReq = (FtpWebRequest)FtpWebRequest.Create(ftpURI + dirName);
                ftpReq.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftpReq.KeepAlive = false;
                ftpReq.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftpReq.UseBinary = true;

                FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();

                Stream strm = ftpRes.GetResponseStream();

                ftpRes.Close();
                strm.Close();


            }
            catch(Exception ex)
            {
                ftpLog.Write(ex.Message);
                    
            }
        }

        public void Run()
        {
            Thread th = new Thread(Start);

            th.Start();
        }


        public void RemoveDir(string fileName)
        {
            FtpWebRequest ftpReq;

            try
            {
                ftpReq = (FtpWebRequest)FtpWebRequest.Create(ftpURI +fileName);
                ftpReq.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftpReq.KeepAlive = false;
                ftpReq.Method = WebRequestMethods.Ftp.RemoveDirectory;
                ftpReq.UseBinary = true;

                FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();

                Stream strm = ftpRes.GetResponseStream();

                ftpRes.Close();
                strm.Close();


            }
            catch (Exception ex)
            {
                ftpLog.Write(ex.Message);

            }
        }

        private void UploadDir(DirectoryInfo dirInfo)
        {
            MakeDir(dirInfo.Parent.Name+@"\"+dirInfo.Name);
            List<FileInfo> fileList = CreatefileList(dirInfo);

            for (int i = 0; i < fileList.Count; i++)
            {
                try
                {
                    Upload(fileList[i]);
                    ftpLog.Write(fileList[i].Name + "upload successfully:" + fileList[i].Directory + ":" + fileList[i].Name);
                }
                catch(Exception )
                {
                    i--;
                }
            }
            ftpLog.Close();

        }

        public void Start()
        {
            foreach (DirectoryInfo dataDir in uploadDir.GetDirectories())
            {
                MakeDir(dataDir.Name);
                foreach (DirectoryInfo di in dataDir.GetDirectories())
                {
                    UploadDir(di);
                }
            }
        }
    }
}
