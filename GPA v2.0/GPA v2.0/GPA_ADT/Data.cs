using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Data;

using GPA.GPA_Config;




namespace GPA.GPA_ADT
{

     abstract class Data
    {

        
        protected string tableName ;
        protected DateTime beginTime;
        protected DateTime endTime;
        protected const string portAttr = "[peer/source_port]";
        protected const string ipAttr="[peer/source_ip]";
        protected DB db;
        protected XmlConfigure xmlConf;


        protected List<string> ipList;

        public List<string> IpList
        {
            get
            {
                return ipList;
            }
            set
            {
                ipList = value;
            }
        }

        protected void SetIpList(DataTable dt)
        {
            foreach (DataRow drow in dt.Rows)
            {
                ipList.Add(drow.ItemArray[0].ToString());
            }
        }

        

        public Data()
        {
            xmlConf = XmlConfigure.GetInstance();

            tableName = xmlConf.GetDBTableName();
            string[] begin=xmlConf.GetDateBeginTime().Split('/');
            string[] end=xmlConf.GetDateEndTime().Split('/');
            beginTime = new DateTime(Convert.ToInt32(begin[0]),Convert.ToInt32(begin[1]),Convert.ToInt32(begin[2]));
            endTime = new DateTime(Convert.ToInt32(end[0]), Convert.ToInt32(end[1]), Convert.ToInt32(end[2]));
            db = new DB();
            ipList = new List<string>();
        }

        abstract public string GetCommand();



        abstract public void Load();
        

    }
}