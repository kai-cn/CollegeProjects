using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;


namespace GPA
{
    class Communtity_structure
    {
        private Hashtable inital;
        private Queue<Element> middle;
        private DB db;


        public class Element
        {
            public long presentIP;
            public long lastPeer;
        }

        public Communtity_structure()
        {
            inital = new Hashtable();
            middle = new Queue<Element>();
            db = new DB();
            
           
        }


        //获取节点给予的ip节点
        public DataTable GetIPsFromPeerIp(string ip)
        {
            DataSet ds = new DataSet();
            string cmdString=@"select [peer/source_ip] from p2p_original_data where [tracker/server_ip]='"+ip+"'";
            ds=db.reDs(cmdString);
            return ds.Tables[0];

        }


        //将dataTable中的数据放入到middle中
        public void DataTableToMiddle(long ip ,DataTable dt)
        {
            long longIp;
            Element e = new Element();
            e.lastPeer = ip;
            foreach (DataRow row in dt.Rows)
            {
                longIp=StringToLong(row.ToString());
                e.presentIP = longIp;
                middle.Enqueue(e);
            }
        }



        //创建以ip为中心的图
        //public Hashtable  CreateGraph(string ip)
        //{
        //    Element e = new Element();

        //    //初始化这张图,将原始的peer获取到ips作为原始数据存入queue中
        //    DataTable dt = new DataTable();
        //    dt = GetIPsFromPeerIp(ip);
        //    long longIp=StringToLong(ip);
        //    inital.Add(longIp, 0);
        //    DataTableToMiddle(longIp, dt);


        //    while(middle .Count<Element>()>0)
        //    {
        //        e = middle.Dequeue();
        //        dt=GetIPsFromPeerIp(LongToString(e.presentIP));
        //        if(!inital.Contains(e.presentIP))
        //            DataTableToMiddle(e.presentIP,dt);
        //        inital.Add(e.presentIP,e.lastPeer);
        //    }
        //    return 
        //}




        public long StringToLong(string strIp)
        {
            int i=24;
            long longIp=0;
            foreach (string str in strIp.Split('.'))
            {
                longIp += Convert.ToByte(str) << i;
                i = i - 8;
            }
            return longIp;
        }

        public string LongToString(long ip)
        {
            byte[] byteIp = new byte[4];
            byte y;
            for (int i = 0; i < 4; i++)
            {
                y =Convert.ToByte(ip >> (3-i)*8);
                byteIp[i] = y;
            }

            return (byteIp[0] + "." + byteIp[1] + "." + byteIp[2] + "." + byteIp[3]);
        }
    }
}
