using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace GPA
{
    class BlockList
    {
        private string region;
        private StreamReader SReader;
        string type;
        private List<string> regionList;
        private List<long> firstIPList;
        private List<int> offsetList;
        private ArrayList blocklistIp;
        private Hashtable indexes;   //记录查询后的全部索引
        


        public string Region
        {
            get
            {
                return region;
            }
        }


        public ArrayList BlocklistIP
        {
            get
            {
                return blocklistIp;
            }
        }


        public BlockList(string type)
        {
            this.type = type;
            init();
        }

        private static long stringToLong(string  ip)
        {
            long ipnum = 0;
            string[] address =ip.Split('.');

            for (int i = 0; i < 4; ++i)
            {
                long y =byte.Parse(address[i]);
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
                ((byte)(ip >> 16)).ToString() + '.' + ((byte)(ip >> 8)).ToString() + '.' + ((byte)ip).ToString();
        }

        private void init()
        { 
            indexes = new Hashtable();
            WriteToMemory();
        }


        private void WriteToMemory()
        {
            regionList = new  List<string>();
            firstIPList = new List<long>();
            offsetList = new List<int>();
            blocklistIp = new  ArrayList();

            MatchCollection mc;
            long longIp;
            string strInfo = string.Empty;
            string str=string.Empty;

            if(type=="Bogon")
                SReader = new StreamReader(new FileStream("bt_bogon.txt", FileMode.Open, FileAccess.Read));
            if(type=="Level1")
                SReader = new StreamReader(new FileStream("bt_level1.txt", FileMode.Open, FileAccess.Read));
            if(type=="Level3")
                SReader = new StreamReader(new FileStream("bt_level3.txt", FileMode.Open, FileAccess.Read));
            if(type=="Edu")
                SReader = new StreamReader(new FileStream("bt_edu.txt", FileMode.Open, FileAccess.Read));
           // SReader = new StreamReader(new FileStream("blocklist.txt",FileMode.Open,FileAccess.Read));
           // SReader = new StreamReader(new FileStream("guarding.txt", FileMode.Open, FileAccess.Read));
             


            #region iblockList
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
            #endregion




            //#region blocklist.txt,guarding.txt文件的读取

           // while (!SReader.EndOfStream)
            //{
            //    try
            //    {
            //        strInfo = SReader.ReadLine();

            //        #region 取得guarding.txt中的名称
            //        //string[] strArr;
            //        //strArr = strInfo.Split(',');
            //        //if (strArr.Length > 3)
            //        //{
            //        //    string tmp = "";
            //        //    for (int i = 2; i < strArr.Length - 1; i++)
            //        //    {
            //        //        tmp += strArr[i];
            //        //    }

            //        //    regionList.Add(tmp);
            //        //}
            //        //else
            //        //{
            //        //    regionList.Add(strArr[2]);
            //        //}

            //        //mc = Regex.Matches(strInfo, @"\d+\.\d+\.\d+\.\d+");
            //        //longIp = stringToLong(mc[0].ToString());
            //        //firstIPList.Add(longIp);
            //        //offsetList.Add((int)(stringToLong(mc[1].ToString()) - longIp));
            //        #endregion

            //        #region 取得blocklist.txt中的名称
            //        //regionList.Add(Regex.Match(strInfo, @"\w+, ", RegexOptions.RightToLeft).ToString());


            //        //mc = Regex.Matches(strInfo, @"\d+\.\d+\.\d+\.\d+");
            //        //longIp = stringToLong(mc[0].ToString());
            //        //firstIPList.Add(longIp);
            //        //offsetList.Add((int)(stringToLong(mc[1].ToString()) - longIp));
            //        #endregion
            //    }
            //    catch
            //    {

            //    }
            //}
            //#endregion

            

            SReader.Close();

        }

        public bool IsBlockIP(string ip)
        {
           
            long longIP=stringToLong(ip);
            int firstIndex=0;
            int lastIndex=firstIPList.Count;
            int index=(firstIndex+lastIndex)/2;

            while(true)
            {
                if (longIP < firstIPList[0] || longIP > firstIPList[firstIPList.Count - 1])
                    return false;
                
                if (index  >= firstIPList.Count-1)
                {
                    if (longIP <= firstIPList[index] + offsetList[index] && longIP >= firstIPList[index])
                    {
                        region = regionList[index];
                        if (!indexes.ContainsKey(index))
                        {
                            indexes.Add(index, 1);
                        }
                        else
                        {
                            indexes[index] = int.Parse(indexes[index].ToString()) + 1;
                        }
                        blocklistIp.Add(ip);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (longIP >= firstIPList[index] && longIP < firstIPList[index + 1])
                    {
                        if (longIP <= firstIPList[index] + offsetList[index])
                        {
                            region = regionList[index];
                            if (!indexes.ContainsKey(index))
                            {
                                indexes.Add(index, 1);
                            }
                            else
                            {
                                indexes[index] = int.Parse(indexes[index].ToString()) + 1;
                            }
                            blocklistIp.Add(ip);
                            return true;
                        }
                        else
                            return false;
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


        ///
        /// 参数为排名的个数
        /// 
        public string[] GetRanking(int RankingLength)
        {
            int[] values = new int[indexes.Count];
            int[] keys = new int[indexes.Count];
            string[] Ranking = new string[RankingLength];

            indexes.Values.CopyTo(values, 0);
            indexes.Keys.CopyTo(keys, 0);

            Array.Sort(values,keys);

            if (RankingLength > indexes.Count)
            {
                RankingLength = indexes.Count;
            }

            for (int i = indexes.Count - 1; i >indexes.Count-1-RankingLength; i--)
            {
                Ranking[indexes.Count-1-i]=LongToString(firstIPList[keys[i]])+"-"+
                    LongToString(firstIPList[keys[i]]+offsetList[keys[i]])+"   "+
                    regionList[keys[i]].ToString();
            }

            return Ranking;
        }
    }
}
