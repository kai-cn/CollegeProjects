using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GPA.GPALib.Algorithm
{
    class SixDegreeA
    {

        private Hashtable sxGraph;
        public SixDegreeA(Hashtable sxG)
        {
            this.sxGraph = sxG;
        }

        public double GetSixDegree()
        {
            double averageSixD = 0;
            List<int> sixDegreeList = new List<int>();
            HashSet<string> sourceDest = new  HashSet<string>();
            List<string[]> listSource = PickRandomIP(50);
            
            foreach (string[] source in listSource)
            {
                foreach (DictionaryEntry dest in sxGraph)
                {
                    if (!sourceDest.Contains(source[0].ToString() + dest.Key.ToString()) && !sourceDest.Contains(dest.Key.ToString() + source[0].ToString()))
                    {
                        sourceDest.Add(source[0].ToString() + dest.Key.ToString());
                        sourceDest.Add(dest.Key.ToString() + source[0].ToString());
                        sixDegreeList.Add(ComputeDegreeOfSeparation(source[0].ToString(), dest.Key.ToString()));
                    }
                }
            }

            int max = sixDegreeList.Max();
            for (int i = 0, len = sixDegreeList.Count; i < len; i++)
            {
                if (sixDegreeList[i] == -1)
                    sixDegreeList[i] = max + 1;

                averageSixD += sixDegreeList[i];

            }
            averageSixD = averageSixD * 1.0 / sixDegreeList.Count;
            return averageSixD;
        }

        public double CetClusCoef()
        {
            long allCount = ComputeSxPath();
            long exsitCount = ComputeExistPath();

            return exsitCount * 1.0 / allCount;

        }

        private long ComputeSxPath()
        {
            long allCount=0;
            for (int i = 0; i <  sxGraph.Count; i++)
            {
                 allCount += sxGraph.Count - i;
            }
            return allCount;
        }

        private long ComputeExistPath()
        {
            long existPath = 0;

            foreach (DictionaryEntry de in sxGraph)
            {
                existPath += (de.Value as List<string>).Count;
            }

            return existPath;
            
        }









        protected int ComputeDegreeOfSeparation(string sourceIP,string destIP)
        {
            ArrayList al = PathDegreeOfSeparation(sourceIP, destIP);
            if (al.Count == 0)
                return -1;
            else
                return al.Count;
        }
        
     
            

        protected ArrayList PathDegreeOfSeparation(string sourceIP, string destIP)
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
                return ipPath;
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

        

        private List<string[]> PickRandomIP(int IPCount)
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
