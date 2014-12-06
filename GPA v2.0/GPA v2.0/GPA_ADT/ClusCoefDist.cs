using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace GPA.GPA_ADT
{
    class ClusCoefDist:Data
    {
        private double p;
        private SDofSDist sDs;
        private double averageDegree;
        private double maxDegree;
        private double clusCoef;

        public double ClusCoef
        {
            get
            {
                return clusCoef;
            }
        }

        public double MaxDegree
        {
            get
            {
                return maxDegree;
            }
        }


        public double AverageDegree
        {
            get
            {
                return averageDegree;
            }
        }


        public double P
        {
            get
            {
                return p;
            }
        }


        public ClusCoefDist()
        {
            sDs = new SDofSDist();
        }

        public override void Load()
        {
            Hashtable links = GetLinks();

            p = ComputePValue(links);
            string MaxPeer = GetMaxPeer(links);

            //Console.WriteLine("将进行1000次实验!");/*若所有节点数小于1000则去节点总数*/
            Hashtable randomIp = PickRandomIP(1000, links);

            int allDegree = 0;
            maxDegree = 0;
            int existsIP = 0;
            foreach (DictionaryEntry de in randomIp)
            {
                ArrayList al = sDs.ComputeDegreeOfSeparation((string)de.Key, MaxPeer, links);
                if (al != null)
                {
                    allDegree += al.Count;
                    existsIP++;
                    if (maxDegree < al.Count)
                        maxDegree = al.Count;
                }
            }

            averageDegree = allDegree * 1.0 / existsIP;
            
            

            double sum = 0;
            clusCoef = 0;
            foreach (DictionaryEntry de in randomIp)
            {
                clusCoef = ComputeClusCoef((List<string>)de.Value, links);
                if (double.IsNaN(clusCoef))
                    continue;
                sum += clusCoef;
               
            }
            clusCoef = sum / randomIp.Count;

        }




        public override string GetCommand()
        {
            return @"select distinct [tracker/server_ip],([peer/source_ip]) from "+tableName+
            @" where type='em' and CONVERT(char,time,23) between '" + beginTime.ToString("yyyy-MM-dd") +
            "' and '" + endTime.ToString("yyyy-MM-dd") + "'order by [tracker/server_ip]";

        }


        private double ComputePValue(Hashtable links)
        {
            int allLinksV = ComputeAllLinksV(links);
            int exitsLinkV = ComputeExistLinksV(links);

            return exitsLinkV * 1.0 / allLinksV;
        }

        private int ComputeAllLinksV(Hashtable links)
        {
            int allLinksV = 0;
            for (int i = 0; i < links.Count; i++)
            {
                allLinksV += links.Count - i;
            }
            return allLinksV;
        }

        private int ComputeAllLinksV(List<string> links)
        {
            int allLinksV = 0;
            for (int i = 0; i < links.Count; i++)
            {
                allLinksV += links.Count - i;
            }
            return allLinksV;
        }

        private int ComputeExistLinksV(Hashtable peer_ip)
        {
            List<string> list = new List<string>();
            foreach (DictionaryEntry de in peer_ip)
            {
                list.Add(de.Key.ToString());
            }
            return ComputeExistLinksV(list, peer_ip);

        }

        private int ComputeExistLinksV(List<string> links, Hashtable peer_ip)
        {
            int exsitCount = 0;
            Hashtable exsitLinked = new Hashtable();

            foreach (string str1 in links)
            {
                if (peer_ip.Contains(str1))
                {
                    foreach (string str2 in (List<string>)peer_ip[str1])
                    {
                        if (!links.Contains(str2))
                            continue;
                        if (!exsitLinked.Contains(str2 + "," + str1) && !exsitLinked.Contains(str1 + "," + str2))
                        {
                            exsitCount++;
                            exsitLinked.Add(str1 + "," + str2, 1);
                            exsitLinked.Add(str2 + "," + str1, 1);
                        }
                    }
                }
            }
            return exsitCount;
        }

        private double ComputeClusCoef(List<string> randomPeers, Hashtable peer_ip)
        {
            long allCount = 0;
            long exsitCount = 0;
            allCount = ComputeAllLinksV(randomPeers);
            exsitCount = ComputeExistLinksV(randomPeers, peer_ip);
            return exsitCount * 1.0 / allCount;

        }



        private Hashtable PickRandomIP(int IPCount, Hashtable sxGraph)
        {
            Random rd = new Random();
            List<string> sxGrp = new List<string>();
            Hashtable randomData = new Hashtable();

            foreach (DictionaryEntry de in sxGraph)
            {
                sxGrp.Add(de.Key.ToString());
            }

            int ip_count = 1;
            List<int> randomDataIndex = new List<int>();

            if (sxGrp.Count < 1000)
            {
                for (int i = 0; i < sxGraph.Count; i++)
                {
                    randomDataIndex.Add(i);
                }
            }
            else
            {
                while (ip_count <= IPCount)
                {
                    int index = rd.Next(0, sxGrp.Count - 1);
                    if (randomDataIndex.IndexOf(index) == -1)
                    {
                        randomDataIndex.Add(index);
                        ip_count++;
                    }
                }
            }

            foreach (int index in randomDataIndex)
            {
                randomData.Add(sxGrp[index], sxGraph[sxGrp[index]]);
            }
            return randomData;
        }



        private Hashtable GetLinks()
        {
            string strCmd = GetCommand();

            Hashtable ht = new Hashtable();

            DataTable dt = new DataTable();

            /*将hashtable中的每一项对应的IP都取出*/
            dt =db.reDs(strCmd).Tables[0];
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


        private string GetMaxPeer(Hashtable peer_ip)
        {
            int MaxCount = 0;
            string MaxPeer = string.Empty;
            foreach (DictionaryEntry de in peer_ip)
            {
                List<string> tempList = (List<string>)de.Value;
                if (MaxCount < tempList.Count)
                {
                    MaxCount = tempList.Count;
                    MaxPeer = (string)de.Key;
                }
            }
            return MaxPeer;
        }

    }
}
