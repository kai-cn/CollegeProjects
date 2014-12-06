using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace GPA.GPA_ADT
{
    class SDofSDist:Data
    {

        private const int exCount = 10;
        private int graphCount;
        private List<ArrayList> successPath;
        private int canLinked;
        private int notLinked;
        private double averageSeparationDegree;




        public double AverageSeparationDegree
        {
            get
            {
                return averageSeparationDegree;
            }
        }

        public int NotLinked
        {
            get
            {
                return notLinked;
            }
        }

        public int CanLinked
        {
            get
            {
                return canLinked;
            }
        }

        public List<ArrayList> SuccessPath
        {
            get
            {
                return successPath;
            }
        }


        public int GraphCount
        {
            get
            {
                return graphCount;
            }
        }


        public override string GetCommand()
        {
            string sqlStr = @"select distinct [tracker/server_ip],[peer/source_ip] from " + tableName +
                @" where other='sx' and  " +
                "CONVERT(char,time,23) between '" + beginTime.ToString("yyyy-MM-dd") + "' and '" + endTime.ToString("yyyy-MM-dd") + "'";
            return sqlStr;
        }

        public SDofSDist()
        {
            //tableName = "p2p_original_data_bak";
            successPath = new List<ArrayList>();
        }

        public override void Load()
        {


            Hashtable sxGraph = GetSXGraph();
            graphCount = sxGraph.Count;
            canLinked = 0;/*能够相互连接的节点*/
            notLinked = 0;
            int SumSeparationDegree = 0;

            foreach (string[] source_dest_ip in PickRandomIP(1000, sxGraph))
            {
                ArrayList path = ComputeDegreeOfSeparation(source_dest_ip[0], source_dest_ip[1], sxGraph);
                if (path != null)
                {
                    SumSeparationDegree += path.Count - 2;
                    successPath.Add(path);
                    canLinked++;

                }
                else
                    notLinked++;
            }
            averageSeparationDegree = SumSeparationDegree * 1.0 / canLinked;
        }


        private Hashtable GetSXGraph()
        {

            DataTable dt = new DataTable();

            dt =db.reDs(GetCommand()).Tables[0];

            Hashtable ht = new Hashtable();
            /*将datatable中的数据放入hashtable中*/
            foreach (DataRow dr in dt.Rows)
            {

                if (!ht.Contains(dr[0].ToString()))
                {
                    ht.Add(dr[0].ToString(), new List<string>());
                }
            }

            /*将hashtable中的每一项对应的IP都取出*/
            foreach (DataRow dr in dt.Rows)
            {
                if (ht.Contains(dr[1].ToString()))
                {
                    List<string> tempList = (List<string>)ht[dr[0].ToString()];
                    if (tempList.IndexOf(dr[1].ToString()) == -1)
                        tempList.Add(dr[1].ToString());
                    ht[dr[0].ToString()] = tempList;
                }
            }

            return ht;
        }


        /*返回值,返回形成的路径,若无该路径则返回null*/
        public ArrayList ComputeDegreeOfSeparation(string sourceIP, string destIP, Hashtable sxGraph)
        {
            ArrayList ipPath = new ArrayList();
            if (sourceIP == destIP)
            {
                ipPath.Add(sourceIP);
            }

            Queue<string[]> waitingIP = new Queue<string[]>();
            Hashtable closeIp = new Hashtable();
            Hashtable openIp = new Hashtable();
            string currIP = sourceIP;




            closeIp.Add(currIP, currIP);
            /*利用hashtable来存储路径key:当前ip,value:前一个ip*/
            foreach (string ip in (List<string>)sxGraph[currIP])
            {
                waitingIP.Enqueue(new string[] { ip, currIP });
                openIp.Add(ip, 1);
            }

            while (waitingIP.Count != 0)
            {
                currIP = waitingIP.Peek()[0];
                closeIp.Add(currIP, waitingIP.Dequeue()[1]);
                openIp.Remove(currIP);

                List<string> tempList = (List<string>)sxGraph[currIP];

                foreach (string ip in tempList)
                {
                    if (!closeIp.Contains(ip) && !openIp.Contains(ip))
                    {
                        waitingIP.Enqueue(new string[] { ip, currIP });
                        openIp.Add(ip, 1);
                    }
                }

                if (currIP == destIP)
                {
                    break;
                }
            }

            if (waitingIP.Count == 0)
                return null;
            else
            {
                Stack<string> tempIpPath = new Stack<string>();/*倒叙*/
                tempIpPath.Push(destIP);
                while (currIP != sourceIP)
                {
                    currIP = closeIp[currIP].ToString();
                    tempIpPath.Push(currIP);
                }
                while (tempIpPath.Count != 0)
                {
                    ipPath.Add(tempIpPath.Pop());
                }
                return ipPath;
            }
        }



        private List<string[]> PickRandomIP(int IPCount, Hashtable sxGraph)
        {
            Random rd = new Random();
            List<string> sxGrp = new List<string>();
            List<string[]> randomData = new List<string[]>();

            if (sxGraph.Count <= 1)
                    return randomData;

            foreach (DictionaryEntry de in sxGraph)
            {
                sxGrp.Add(de.Key.ToString());
            }

            int ip_count = 1;
            List<string> randomDataIndex = new List<string>();
            
            while (ip_count <= IPCount)
            {
                int source_index = 0;
                int dest_index = 0;
                
                while (source_index == dest_index)
                {
                    source_index = rd.Next(0, sxGrp.Count - 1);
                    dest_index = rd.Next(0, sxGrp.Count - 1);
                }

                string source_dest = source_index.ToString() + "," + dest_index.ToString();
                string dest_source = dest_index.ToString() + "," + source_index.ToString();
                if (randomDataIndex.IndexOf(source_dest) == -1 && randomDataIndex.IndexOf(dest_source) == -1)
                {
                    randomDataIndex.Add(source_dest);
                    ip_count++;
                }

            }

            foreach (string str in randomDataIndex)
            {
                string[] data = str.Split(',');
                randomData.Add(new string[] { sxGrp[Convert.ToInt32(data[0])], sxGrp[Convert.ToInt32(data[1])] });
            }
            return randomData;
        }



    }
}
