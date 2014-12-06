using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

using GPA.GPA_Config;
namespace GPA
{
    class BlockListDBInterface
    {
        private List<string> regionList;
        private List<long> firstIPList;
        private List<int> offsetList;
        private ArrayList blocklistIp;
        private Hashtable indexes;   //记录查询后的全部索引


        public BlockListDBInterface()
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

        public int IsBlockIP(string ip)
        {

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
    }
}
