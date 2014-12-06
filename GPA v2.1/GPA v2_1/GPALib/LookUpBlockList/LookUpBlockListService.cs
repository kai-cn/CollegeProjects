using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace GPA.GPALib.LookUpBlockList
{
    /// <summary>
    /// 为ip查询blocklist类型提供接口
    /// </summary>
    class LookUpBlockListService
    {
        private List<string> regionList;
        private List<long> firstIPList;
        private List<int> offsetList;
        private ArrayList blocklistIp;
        private Hashtable indexes;   //记录查询后的全部索引


        public  LookUpBlockListService()
        {
            blocklistIp = new ArrayList();
            indexes = new Hashtable();
        }


        public ArrayList BlocklistIP
        {
            get
            {
                return blocklistIp;
            }
        }

        /// <summary>
        /// 给定一个ip判定该ip是否属于该blocklist类型
        /// </summary>
        /// <param name="ip">ip字符串</param>
        /// <returns>如果返回-1则,ip不属于该blocklist类型,否则该ip属于该blocklist类型</returns>
        public int IsBlockIP(string ip)
        {
            if (firstIPList.Count == 0)
                return -1;

            long longIP = stringToLong(ip);
            int firstIndex = 0;
            int lastIndex = firstIPList.Count;
            int index = (firstIndex + lastIndex) / 2;

            while (true)
            {
                if (longIP < firstIPList[0] || longIP > firstIPList[firstIPList.Count - 1])
                    return -1;

                if (index >= firstIPList.Count - 1)
                {
                    if (longIP <= firstIPList[index] + offsetList[index] && longIP >= firstIPList[index])
                        return index;
                    else
                        return -1;
                }
                else
                {
                    if (longIP >= firstIPList[index] && longIP < firstIPList[index + 1])
                    {
                        if (longIP <= firstIPList[index] + offsetList[index])
                            return index;
                        else
                            return -1;
                    }
                    else
                    {
                        if (longIP >= firstIPList[index + 1])
                        {
                            firstIndex = index;
                            index = (firstIndex + lastIndex) / 2;

                        }
                        else
                        {
                            lastIndex = index;
                            index = (firstIndex + lastIndex) / 2;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 通过给定一个存储ip字符串的数组,获取ip数组中属于该blocklist类型的ip,并存储在数组中
        /// </summary>
        /// <param name="IPs">存储ip字符串的数组</param>
        /// <returns>属于该blocklist类型的ip,并存储在数组中</returns>
        protected ArrayList GetBlistIPs(List<string> IPs)
        {
            int index = 0;
            foreach (string myip in IPs)
            {
                index = IsBlockIP(myip);
                if (index != -1)
                {
                    if (!indexes.ContainsKey(index))
                        indexes.Add(index, 1);
                    else
                        indexes[index] = int.Parse(indexes[index].ToString()) + 1;

                    blocklistIp.Add(myip);
                }
            }
            return blocklistIp;
        }

        /// <summary>
        /// 将blocklist数据加载到内存中
        /// </summary>
        /// <param name="DBpath">blocklist数据库存放的路径</param>
        public void LoadDB(string DBpath)
        {
            regionList = new List<string>();
            firstIPList = new List<long>();
            offsetList = new List<int>();


            MatchCollection mc;
            long longIp;
            string strInfo = string.Empty;
            string str = string.Empty;

            StreamReader SReader = new StreamReader(new FileStream(DBpath, FileMode.Open, FileAccess.Read));
            strInfo = SReader.ReadToEnd();
            foreach (Match m in Regex.Matches(strInfo, @".+\d\n"))
            {
                str = m.ToString();
                regionList.Add(str.Substring(0, str.IndexOf(':')));
                mc = Regex.Matches(str, @"\d+\.\d+\.\d+\.\d+");
                longIp = stringToLong(mc[0].ToString());
                firstIPList.Add(longIp);

                offsetList.Add((int)(stringToLong(mc[1].ToString()) - longIp));
            }
            SReader.Close();
        }

        /// <summary>
        /// 给定ip字符串数组,需要取的排名长度n,返回排名n的ip段,以及该ip端对应的地区信息
        /// </summary>
        /// <param name="RankingLength">排名长度n</param>
        /// <param name="IPs"></param>
        /// <returns></returns>
        public string[] GetRanking(int RankingLength, List<string> IPs)
        {


            if (indexes.Count == 0)
            {
                GetBlistIPs(IPs);
            }

            int[] values = new int[indexes.Count];
            int[] keys = new int[indexes.Count];
            string[] Ranking = new string[RankingLength];

            indexes.Values.CopyTo(values, 0);
            indexes.Keys.CopyTo(keys, 0);

            Array.Sort(values, keys);

            if (RankingLength > indexes.Count)
            {
                RankingLength = indexes.Count;
            }

            for (int i = indexes.Count - 1; i > indexes.Count - 1 - RankingLength; i--)
            {
                Ranking[indexes.Count - 1 - i] = LongToString(firstIPList[keys[i]]) + "-" +
                    LongToString(firstIPList[keys[i]] + offsetList[keys[i]]) + "   " +
                    regionList[keys[i]].ToString();
            }

            return Ranking;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private long stringToLong(string ip)
        {
            long ipnum = 0;
            string[] address = ip.Split('.');

            for (int i = 0; i < 4; ++i)
            {
                long y = byte.Parse(address[i]);
                if (y < 0)
                {
                    y += 256;
                }
                ipnum += y << ((3 - i) * 8);
            }
            return ipnum;
        }

        private string LongToString(long ip)
        {
            return ((byte)(ip >> 24)).ToString() + '.' +
                ((byte)(ip >> 16)).ToString() + '.' +
                ((byte)(ip >> 8)).ToString() + '.' + ((byte)ip).ToString();
        }

        public string[] GetAddressSegment(string ip)
        {
            int index = IsBlockIP(ip);
            string[] str=new string[2]{"",""};


            if (index != -1)
            {
                str[0] = LongToString(firstIPList[index]) + "_" +
                    LongToString(firstIPList[index] + offsetList[index]);
                str[1] = regionList[index];
            }

            return str;

        }
    }
}
