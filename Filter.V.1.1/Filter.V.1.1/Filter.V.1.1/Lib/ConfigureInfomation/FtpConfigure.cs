using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GPA.GPALib.ConfigureInfomation
{
    /// <summary>
    /// Ftp相关的配置信息
    /// </summary>
    class FtpConfigure
    {

        private XmlNode _ftpConnectString;  //ftp的连接字符串包括帐号,密码,端口,地址
        private XmlNode _ftpUploadFilePath;       //本地需要上传文件的路径



        /// <summary>
        /// ftp服务器的地址
        /// </summary>
        public string FtpServerUri {
            get { return  _ftpConnectString.Attributes["server_uri"].Value; }
            set { _ftpConnectString.Attributes["server_uri"].Value = value; }
        }

        

        /// <summary>
        /// ftp服务器的用户名
        /// </summary>
        public string FtpUserID {
            get { return _ftpConnectString.Attributes["uid"].Value; }
            set { _ftpConnectString.Attributes["uid"].Value = value; }
        }

        /// <summary>
        /// ftp服务器的密码
        /// </summary>
        public string FtpPWD {
            get { return _ftpConnectString.Attributes["pwd"].Value; }
            set { _ftpConnectString.Attributes["pwd"].Value = value; }
        }

        /// <summary>
        /// ftp服务器本地需要上传文件的路径
        /// </summary>
        public string FtpUploadFilePath {
            get { return _ftpUploadFilePath.Attributes["local_path"].Value; }
            set { _ftpUploadFilePath.Attributes["local_path"].Value = value; }
        }


        /// <summary>
        /// 对ftp各参数配置
        /// </summary>
        /// <param name="ftpNode"></param>
        public FtpConfigure(ref XmlNode ftpNode)
        {
            try
            {
                _ftpConnectString = ftpNode.SelectSingleNode("ftpConnectString");
                _ftpUploadFilePath = ftpNode.SelectSingleNode("ftpUploadFilePath");
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }


        

        
    }
}
