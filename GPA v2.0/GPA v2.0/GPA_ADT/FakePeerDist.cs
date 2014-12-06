using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Data;

using GPA.GPA_ADT.GPA_BlockListDist;
using GPA;

namespace GPA.GPA_ADT
{
    class FakePeerDist:Data
    {

        private Hashtable belongBogonPeers;
        private Hashtable belongLevel1Peers;
        private Hashtable belongHijackedPeers;
        private Hashtable belongLevel2Peers;


        private Hashtable selfPeers;


        public Hashtable SelfPeers
        {
            get
            {
                return selfPeers;
            }
        }

        public Hashtable BelongBogonPeers
        {
            get
            {
                return belongBogonPeers;
            }
        }

        public Hashtable BelongLevel1Peers
        {
            get
            {
                return belongLevel1Peers;
            }
        }

        public Hashtable BelongLevel2Peers
        {
            get
            {
                return belongLevel2Peers;
            }
        }

        public Hashtable BelongHijackedPeers
        {
            get
            {
                return belongHijackedPeers;
            }
        }



        public FakePeerDist()
        {
            //tableName = "p2p_original_data_bak";
            selfPeers = new Hashtable();
        }

        public override string GetCommand()
        {
            
            return @"select distinct [tracker/server_ip],[peer/source_ip] from "+tableName+
                " where  type='em' and other='sx'  and "+
                @"CONVERT(char,time,23) between '" + beginTime.ToString("yyyy-MM-dd") + "' and '" + endTime.ToString("yyyy-MM-dd") + "'"; 
        }

        public override void Load()
        {
            Hashtable allPeers = GetAllGraph();

            Hashtable fakePeers = PickUpFakePeers(allPeers);

            /*从blockList分析fakePeers的真实存在性*/

            BlockListDBInterface bldbi = new BlockListDBInterface();
            bldbi.LoadDB(xmlConf.GetBlockListBogonPath());

            belongBogonPeers = GetBelongBListPeers(bldbi, fakePeers, allPeers);

            bldbi.LoadDB(xmlConf.GetBlockListLevel1Path());

            belongLevel1Peers = GetBelongBListPeers(bldbi, fakePeers, allPeers);

            bldbi.LoadDB(xmlConf.GetBlockListHijackedPath());

            belongHijackedPeers = GetBelongBListPeers(bldbi, fakePeers, allPeers);

            bldbi.LoadDB(xmlConf.GetBlockListLevel2Path());
            belongLevel2Peers = GetBelongBListPeers(bldbi, fakePeers, allPeers);




            /*从fakePeers节点本身出发分析节点*/
            foreach (DictionaryEntry de in fakePeers)
            {
                double percent = AnalysisFakePeers(de.Key.ToString(), allPeers, fakePeers);
                selfPeers.Add(de.Key, percent);
                //Console.WriteLine(de.Value.ToString());
                //Console.WriteLine(de.Key.ToString() + "所拥有的连接上的IP在fakePeers中的数量为" + al.Count);
            }
            /*从地理位置分析该节点*/ 
        }


        private Hashtable GetAllGraph()
        {
            //string cmd = @"select distinct [tracker/server_ip],[peer/source_ip] from p2p_original_data";
            string cmd = GetCommand();
            DataTable dt = new DataTable();

            dt = db.reDs(cmd).Tables[0];

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
                List<string> tempList = (List<string>)ht[dr[0].ToString()];
                if (tempList.IndexOf(dr[1].ToString()) == -1)
                    tempList.Add(dr[1].ToString());
                ht[dr[0].ToString()] = tempList;
            }

            return ht;
        }


        private Hashtable PickUpFakePeers(Hashtable allPeers)
        {
            Hashtable fakePeers = new Hashtable();
            //StreamWriter sw = new StreamWriter(new FileStream("fakePeers.txt", FileMode.Create, FileAccess.Write));

            foreach (DictionaryEntry de in allPeers)
            {
                List<string> tempList = (List<string>)(de.Value);

                long noExitsPeersCount = 0;
                long PeersCount = 0;

                foreach (string str in tempList)
                {
                    if (!allPeers.Contains(str))
                    {
                        noExitsPeersCount++;
                    }
                    PeersCount++;
                }
                if (noExitsPeersCount * 1.0 / PeersCount >= 0.8 && PeersCount > 1)
                {
                    //Console.WriteLine("可能为fake peer的可疑节点的ip为：" + de.Key);
                    fakePeers.Add(de.Key, PeersCount.ToString()+@"/"+noExitsPeersCount.ToString());
                    //sw.WriteLine("可能为fake peer的可疑节点的ip为：" + de.Key);
                    //sw.WriteLine("连接不上的节点有:" + noExitsPeersCount.ToString() + ",总的节点数为：" + PeersCount.ToString());
                }
            }
            //sw.WriteLine("共有" + allPeers.Count + "个节点！");
            //sw.WriteLine("其中可疑的节点有" + fakePeers.Count + "个");
            //sw.Close();

            return fakePeers;
        }


        private Hashtable GetBelongBListPeers(BlockListDBInterface bl,Hashtable ht, Hashtable allPeers)
        {
            ArrayList alFPeers = new ArrayList();
            Hashtable belongList=new Hashtable();


            //StreamWriter sw = new StreamWriter(new FileStream(@"D:\fakePeer.txt", FileMode.Append, FileAccess.Write));
            foreach (DictionaryEntry de in ht)
            {
                List<string> al = (List<string>)allPeers[de.Key.ToString()];
                foreach (string str in al)
                    if (bl.IsBlockIP(str) != -1)
                    {
                        alFPeers.Add(str);
                    }
                belongList.Add(de.Key, al.Count.ToString() + "/" + alFPeers.Count.ToString());
                //sw.WriteLine(de.Key.ToString() + "共有" + al.Count + "个IP");
                //sw.WriteLine("属于" + blist + "的数量" + alFPeers.Count);
                alFPeers.Clear();
            }

            //Console.WriteLine("属于"+blist+"的数量" + alFPeers.Count);
            //foreach (string str in alFPeers)
            //{
            //    Console.WriteLine(str);
            //}
            //sw.Close();
            return belongList;
        }

        private double AnalysisFakePeers(string ip, Hashtable allPeers, Hashtable fakePeers)
        {
            double percent;
            ArrayList existPeers = new ArrayList(); /*能连上的IP在fakePeers中的个数*/
            ArrayList connectedPeers = GetConnectedPeers(ip, allPeers);
            foreach (string str in connectedPeers)
            {
                if (fakePeers.Contains(str))
                    existPeers.Add(str);
            }

            //existPeer是 fake peer连接上的节点中,在allpeer中存在的并且在fake peer中存在的节点
            percent = existPeers.Count * 1.0 / connectedPeers.Count;



            //Console.WriteLine("比例值:" + (existPeers.Count * 1.0 / connectedPeers.Count).ToString());

            //if (existPeers.Count * 1.0 / connectedPeers.Count > 0.6 && existPeers.Count * 1.0 / connectedPeers.Count != 1)
             //   Console.WriteLine();
            return percent;

        }


        private ArrayList GetConnectedPeers(string ip, Hashtable allPeers)
        {
            ArrayList connectedPeers = new ArrayList();
            List<string> tempList = (List<string>)allPeers[ip];

            foreach (string str in tempList)
            {
                if (allPeers.Contains(str))
                {
                    connectedPeers.Add(str);
                }
            }
            return connectedPeers;
        }

       
    }
}
