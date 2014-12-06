using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace GPA.GPA_Config
{
     class XmlConfigure
    {

         //采用单例模式
         private static XmlConfigure instance;

         private static readonly object syncRoot = new object();

         private string xPath;

        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        private XmlNode xmlFtpConnectString;
        private XmlNode xmlFtpConfig;
        private XmlNode xmlDBConfig;
        private XmlNode xmlSqlConnectNode;
        private XmlNode xmlPath;
        private XmlNode xmlUpdate;
        private XmlNode xmlDate;
        private XmlNode xmlDBTable;
              
        private XmlConfigure()
        {
            
        }


        public static XmlConfigure GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new XmlConfigure();
                    }
                }
            }
            return instance;
        }

        public void Load(string xPath)
        {
            this.xPath = xPath;
            xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xPath);
                xmlNode = xmlDoc.SelectSingleNode("Configure");

                xmlSqlConnectNode = xmlNode.ChildNodes[0];
                xmlDBConfig = xmlNode.ChildNodes[1];
                XmlNode xmlFtpNode = xmlNode.ChildNodes[2];

                xmlFtpConnectString = xmlFtpNode.ChildNodes[0];
                xmlFtpConfig = xmlFtpNode.ChildNodes[1];


                xmlPath = xmlNode.ChildNodes[3];
                xmlUpdate = xmlNode.ChildNodes[4];
                xmlDate = xmlNode.ChildNodes[5];
                xmlDBTable = xmlNode.ChildNodes[6];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,null,MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }

        }

        public  string GetConnectString()
        {
            return xmlSqlConnectNode.InnerText;
        }

        public void SetConnectedString(string connectedStr)
        {
            xmlSqlConnectNode.InnerText = connectedStr;
        }

        public string GetFtpServer()
        {
            return xmlFtpConnectString.Attributes["server"].Value;
        }
        public void SetFtpServer(string server)
        {
            xmlFtpConnectString.Attributes["server"].Value = server;
        }


        public string GetFtpUid()
        {
            return xmlFtpConnectString.Attributes["uid"].Value;
        }
        public void SetFtpUid(string uid)
        {
            xmlFtpConnectString.Attributes["uid"].Value = uid;
        }

        public string GetFtpPwd()
        {
            return xmlFtpConnectString.Attributes["pwd"].Value;
        }
        public void SetFtpPwd(string pwd)
        {
            xmlFtpConnectString.Attributes["pwd"].Value=pwd;
        }

        public string GetFtpLocalPath()
        {
            return xmlFtpConfig.Attributes[0].Value;
        }
        public void SetFtpLocalPath(string localPath)
        {
            xmlFtpConfig.Attributes[0].Value = localPath;
        }

        public string GetBlockListDBPath()
        {
            return xmlDBConfig.Attributes[0].Value;
        }
        public void SetBlockListDBPath(string dbPath)
        {
            xmlDBConfig.Attributes[0].Value = dbPath;
        }

        public string GetBlockListLevel1Path()
        {
            return GetBlockListDBPath()+@"\"+xmlDBConfig.Attributes["Level1"].Value;
        }
        

        public string GetBlockListLevel2Path()
        {
            return GetBlockListDBPath() + @"\" + xmlDBConfig.Attributes["Level2"].Value;
        }

        public string GetBlockListHijackedPath()
        {
            return GetBlockListDBPath() + @"\" + xmlDBConfig.Attributes["Hijacked"].Value;
        }

        public string GetBlockListEduPath()
        {
            return GetBlockListDBPath() + @"\" + xmlDBConfig.Attributes["Edu"].Value;
        }

        public string GetBlockListBogonPath()
        {
            return GetBlockListDBPath() + @"\" + xmlDBConfig.Attributes["Bogon"].Value;
        }

        public string GetGeoLiteCityPath()
        {
            return xmlDBConfig.Attributes["GeoLiteCity"].Value;
        }
        public void SetGeoLiteCityPath(string path)
        {
            xmlDBConfig.Attributes["GeoLiteCity"].Value = path;
        }

        public string GetDataPath()
        {
            return xmlPath.Attributes["DataPath"].Value;
        }
        public void SetDataPath(string path)
        {
            xmlPath.Attributes["DataPath"].Value = path;
        }
         



        public string GetXmlPath()
        {
            return xmlPath.Attributes["xmlPath"].Value;
        }
        public void SetXmlPath(string path)
        {
            xmlPath.Attributes["xmlPath"].Value = path;
        }

        public string GetXmlUpdate()
        {
            return xmlUpdate.Attributes["Checked"].Value;
        }
        public void SetXmlUpdate(string update)
        {
            xmlUpdate.Attributes["Checked"].Value=update;
        }


        public string GetDateBeginTime()
        {
            return xmlDate.Attributes["beginTime"].Value;
        }
        public void SetDateBeginTime(string beginTime)
        {
            xmlDate.Attributes["beginTime"].Value = beginTime;
        }

        public string GetDateEndTime()
        {
            return xmlDate.Attributes["endTime"].Value;
        }
        public void SetDateEndTime(string endTime)
        {
            xmlDate.Attributes["endTime"].Value = endTime;
        }

        public string GetDateTimer()
        {
            return xmlDate.Attributes["interval"].Value;
        }
        public void SetDateTimer(string timer)
        {
            xmlDate.Attributes["interval"].Value = timer;
        }

        public string GetDBTableName()
        {
            return xmlDBTable.Attributes["tableName"].Value;
        }
        public void SetDBTableName(string tableName)
        {
            xmlDBTable.Attributes["tableName"].Value = tableName;
        }

        public void Save()
        {
            xmlDoc.Save(xPath);
        }
    }
}
