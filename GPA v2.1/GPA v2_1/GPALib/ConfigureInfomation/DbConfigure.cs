using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GPA.GPALib.ConfigureInfomation
{
    /// <summary>
    /// 数据库的相关配置信息
    /// </summary>
    class DbConfigure
    {
        private XmlNode _dbConnectString;       //远程数据库的连接参数
        private XmlNode _dbFilePath;            //本地数据库的路径,包括geolite,blocklist数据库文件
        private XmlNode _dbSqlServerConnectString;  //sql server远程数据的连接参数
        private XmlNode _dbOracleConnectString;     //oracle远程数据的连接参数
        private XmlNode _dbWebSqlServerConnectString;   //实验室Sql Server数据库的连接参数

        /// <summary>
        /// oracle数据库的ip
        /// </summary>
        public string OracleServerIp {
            get { return _dbOracleConnectString.Attributes["server_ip"].Value; }
            set {  _dbOracleConnectString.Attributes["server_ip"].Value = value; }
        }

        /// <summary>
        /// oracle数据库的用户名
        /// </summary>
        public string OracleUserID {
            get { return _dbOracleConnectString.Attributes["uid"].Value; }
            set { _dbOracleConnectString.Attributes["uid"].Value = value; }
        }
        /// <summary>
        /// oracle数据库中sklcc_web表空间的用户名
        /// </summary>
        public string OracleWebUserID {
            get { return _dbOracleConnectString.Attributes["web_uid"].Value; }
            set { _dbOracleConnectString.Attributes["web_uid"].Value = value; }
        }


        /// <summary>
        /// oracle数据库的密码
        /// </summary>
        public string OraclePWD {
            get { return _dbOracleConnectString.Attributes["pwd"].Value; }
            set { _dbOracleConnectString.Attributes["pwd"].Value = value; }
        }

        /// <summary>
        /// oracle数据库的名称
        /// </summary>
        public string OracleDatabase
        {
            get { return _dbOracleConnectString.Attributes["server_name"].Value; }
            set { _dbOracleConnectString.Attributes["server_name"].Value = value; }
        }

        /// <summary>
        /// 获取oracle数据库连接字符串
        /// </summary>
        public string OracleConnectString
        {
            get {

                return string.Format(@"Data Source=
                (DESCRIPTION=
                (ADDRESS_LIST=
                (ADDRESS=(PROTOCOL=TCP)(HOST= {0} )(PORT= 1521 )))
                (CONNECT_DATA=(SERVICE_NAME={1})));
                 User ID={2};Password={3}",
                 OracleServerIp, OracleDatabase, OracleUserID, OraclePWD);
            }
        }

        public string OracleWebConnectString {
            get
            {
                return string.Format(@"Data Source=
                (DESCRIPTION=
                (ADDRESS_LIST=
                (ADDRESS=(PROTOCOL=TCP)(HOST= {0} )(PORT= 1521 )))
                (CONNECT_DATA=(SERVICE_NAME={1})));
                 User ID={2};Password={3}",
                 OracleServerIp, OracleDatabase, OracleWebUserID, OraclePWD);
            }
        }


        /// <summary>
        /// sql server服务器ip
        /// </summary>
        public string SqlServerServerIp {
            get {return _dbSqlServerConnectString.Attributes["server_ip"].Value; }
            set { _dbSqlServerConnectString.Attributes["server_ip"].Value = value; }
        }

        /// <summary>
        /// sql server服务器的用户名
        /// </summary>
        public string SqlServerUserID {
            get { return _dbSqlServerConnectString.Attributes["uid"].Value; }
            set { _dbSqlServerConnectString.Attributes["uid"].Value = value; }
        }

        /// <summary>
        /// sql server服务器的密码
        /// </summary>
        public string SqlServerPWD {
            get { return _dbSqlServerConnectString.Attributes["pwd"].Value; }
            set { _dbSqlServerConnectString.Attributes["pwd"].Value = value; }
        }

        /// <summary>
        /// sql server服务器的数据库名
        /// </summary>
        public string SqlServerDatabase {
            get { return _dbSqlServerConnectString.Attributes["database"].Value; }
            set { _dbSqlServerConnectString.Attributes["database"].Value = value; }
        }

        /// <summary>
        /// 连接sql server数据库的超时时间
        /// </summary>
        public string SqlServerConnectTimeout {
            get { return _dbSqlServerConnectString.Attributes["connect_timeout"].Value; }
            set { _dbSqlServerConnectString.Attributes["connect_timeout"].Value = value; }
        }

        /// <summary>
        /// 连接sql server数据库的配置字符串
        /// </summary>
        public string SqlServerConnectString {
            get {

                    return string.Format(@"server={0};uid={1};
                    pwd={2};database={3};Connect Timeout={4}", SqlServerServerIp,
                    SqlServerUserID, SqlServerPWD, SqlServerDatabase, 
                    SqlServerConnectTimeout);
            }
        }

        /// <summary>
        ///实验室网站 sql server服务器ip
        /// </summary>
        public string WebSqlServerServerIp
        {
            get { return _dbWebSqlServerConnectString.Attributes["server_ip"].Value; }
            set { _dbWebSqlServerConnectString.Attributes["server_ip"].Value = value; }
        }

        /// <summary>
        ///实验室网站 sql server服务器的用户名
        /// </summary>
        public string WebSqlServerUserID
        {
            get { return _dbWebSqlServerConnectString.Attributes["uid"].Value; }
            set { _dbWebSqlServerConnectString.Attributes["uid"].Value = value; }
        }

        /// <summary>
        ///实验室网站 sql server服务器的密码
        /// </summary>
        public string WebSqlServerPWD
        {
            get { return _dbWebSqlServerConnectString.Attributes["pwd"].Value; }
            set { _dbWebSqlServerConnectString.Attributes["pwd"].Value = value; }
        }

        /// <summary>
        ///实验室网站 sql server服务器的数据库名
        /// </summary>
        public string WebSqlServerDatabase
        {
            get { return _dbWebSqlServerConnectString.Attributes["database"].Value; }
            set { _dbWebSqlServerConnectString.Attributes["database"].Value = value; }
        }

        /// <summary>
        ///实验室网站 连接sql server数据库的超时时间
        /// </summary>
        public string WebSqlServerConnectTimeout
        {
            get { return _dbWebSqlServerConnectString.Attributes["connect_timeout"].Value; }
            set { _dbWebSqlServerConnectString.Attributes["connect_timeout"].Value = value; }
        }

        /// <summary>
        ///实验室网站 连接sql server数据库的配置字符串
        /// </summary>
        public string WebSqlServerConnectString
        {
            get
            {

                return string.Format(@"server={0};uid={1};
                    pwd={2};database={3};Connect Timeout={4}", WebSqlServerServerIp,
                WebSqlServerUserID, WebSqlServerPWD, WebSqlServerDatabase,
                WebSqlServerConnectTimeout);
            }
        }



        /// <summary>
        /// blocklist数据库文件的存放路径
        /// </summary>
        public string BlocklistFilePath {
            get { return _dbFilePath.Attributes["blocklist"].Value; }
            set { _dbFilePath.Attributes["blocklist"].Value = value; }
        }

        /// <summary>
        /// geolite city数据库文件的存放路径
        /// </summary>
        public string GeoLiteCity {
            get { return _dbFilePath.Attributes["geo_lite_city"].Value; }
            set { _dbFilePath.Attributes["geo_lite_city"].Value = value; }
        }

        /// <summary>
        /// 对database各参数配置
        /// </summary>
        /// <param name="dbNode"></param>
        public DbConfigure(ref XmlNode dbNode)
        {
            _dbConnectString = dbNode.SelectSingleNode("connectString");
            _dbFilePath = dbNode.SelectSingleNode("dbFilePath");

            _dbOracleConnectString = _dbConnectString.SelectSingleNode("oracle");
            _dbSqlServerConnectString = _dbConnectString.SelectSingleNode("sqlServer");

            _dbWebSqlServerConnectString = _dbConnectString.SelectSingleNode("web");

        }


    }
}
