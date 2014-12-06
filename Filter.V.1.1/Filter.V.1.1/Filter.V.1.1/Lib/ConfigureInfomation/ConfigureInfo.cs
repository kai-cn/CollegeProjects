using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GPA.GPALib.ConfigureInfomation
{
    /// <summary>
    /// 提供所有的配置信息
    /// </summary>
     class ConfigureInfo
    {

         
        private static ConfigureInfo _instance;   //采用单例模式
        private static readonly object _syncRoot = new object();    //用于同步线程

        private XmlDocument _doc;   //用于记录整个xml载入内存的实例
        private XmlNode _node;      //用于记录根节点信息

        private string _ConfigureFilePath;  //配置文件的路径


        private XmlNode _ftpNode;   //记录ftp节点信息
        private XmlNode _dbNode;    //记录database节点信息
        private XmlNode _other;     //记录other节点信息

        /// <summary>
        /// 其他配置信息
        /// </summary>
        private XmlNode _fileStoragePath;
        private XmlNode _programRunTime;

        
         /// <summary>
         /// 程序执行生成的xml文件存放的路径
         /// </summary>
        public string XmlFileStoragePath
        {
            get { return _fileStoragePath.Attributes["xml_path"].Value; }
            set { _fileStoragePath.Attributes["xml_path"].Value = value; }
        }

         /// <summary>
         /// 程序开始运行时间
         /// </summary>
        public string ProgramBeginTime {
            get { return _programRunTime.Attributes["begin_time"].Value ; }
            set { _programRunTime.Attributes["begin_time"].Value = value; }
        }
        
         /// <summary>
         /// 程序结束运行时间
         /// </summary>
        public string ProgramEndTime {
            get { return _programRunTime.Attributes["end_time"].Value; }
            set { _programRunTime.Attributes["end_time"].Value = value; }
        }
        
         /// <summary>
         /// 程序运行周期
         /// </summary>
        public string ProgramTimeInterval {
            get { return _programRunTime.Attributes["interval"].Value; }
            set { _programRunTime.Attributes["interval"].Value = value; }
        }


        private ConfigureInfo() { }

         /// <summary>
         /// 单例模式的实现,即只在内存中创建一个ConfigureInfomation的实例
         /// </summary>
         /// <returns></returns>
        public static ConfigureInfo  GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigureInfo();
                    }
                }
            }
            return _instance;
        }

         /// <summary>
         /// 加载配置文件
         /// </summary>
         /// <param name="xPath">配置文件的路径</param>
        public void Load(string xPath)
        {
            _ConfigureFilePath = xPath;

            _doc= new XmlDocument();

            try
            {
                _doc.Load(xPath);
                _node = _doc.SelectSingleNode("configure");

                _ftpNode = _node.SelectSingleNode("ftp");
                _dbNode = _node.SelectSingleNode("database");
                _other = _node.SelectSingleNode("other");

                _programRunTime = _other.SelectSingleNode("programRunTime");
                _fileStoragePath = _other.SelectSingleNode("fileStoragePath");

                
                
            }
            catch (Exception e)
            {
                throw e;
            }

        }

         /// <summary>
         /// 获取配置Ftp的类
         /// </summary>
         /// <returns>配置ftp的类</returns>
         public FtpConfigure GetFtpConfigure()
         {
             return new FtpConfigure(ref _ftpNode);
         }

         /// <summary>
         /// 获取配置database的类
         /// </summary>
         /// <returns>配置database的类</returns>
         public DbConfigure GetDbConfigure()
         {
             return new DbConfigure(ref _dbNode);
         }

         /// <summary>
         /// 修改文件后,修通过调用该方法保存文件
         /// </summary>
        public void Save()
        {
            _doc.Save(_ConfigureFilePath);
        }
    }
}
