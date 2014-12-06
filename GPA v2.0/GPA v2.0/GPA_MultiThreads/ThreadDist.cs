using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Forms;

using GPA.GPA_ADT;
using GPA.GPA_Xml;
using GPA.GPA_Config;

namespace GPA.GPA_MultiThreads
{
    public delegate void DelgFunc();

     abstract class ThreadDist
    {
        //protected Thread th;
        protected Data[] Dists;
        protected XmlConfigure xmlConf;
        protected XmlAnalysis xmlAnalysis;
        protected string path;
        private DelgFunc DelFunc;

        public ThreadDist()
        {
            xmlConf = XmlConfigure.GetInstance();
            string begin=xmlConf.GetDateBeginTime().Replace("/","");
            string end=xmlConf.GetDateEndTime().Replace("/","");
            path = xmlConf.GetXmlPath()+begin+"_"+end+"\\";
        }

        private void Run(AsyncCallback asCal)
        {
            //ThreadStart ts = new ThreadStart(Start);
            //th = new Thread(ts);
            //th.Start();
            DelFunc = new DelgFunc(Start);

            IAsyncResult iasyResult = DelFunc.BeginInvoke(asCal, null);

           // Start();
        }

        private void CreateDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }


        

        public void Start()
        {
            string name=Dists[0].GetType().Namespace;
            string[] ns=name.Split('.');
            path = path + ns[ns.Length - 1]+"\\";
            CreateDir(path);

            if (name == "GPA.GPA_ADT.GPA_BlockListDist")
            {
                DirectoryInfo dirInfo = new DirectoryInfo(xmlConf.GetBlockListDBPath());

                foreach (FileInfo fileInfo in dirInfo.GetFiles())
                {

                    BlockListDBInterface blistDb = new BlockListDBInterface();
                    blistDb.LoadDB(fileInfo.FullName);

                    for (int i = 0; i < Dists.Length; i++)
                    {
                        ((BlockListDist)Dists[i]).Bind(blistDb);
                        Dists[i].Load();
                        string xPath = path +fileInfo.Name+"_"+Dists[i].GetType().Name+".xml";
                        xmlAnalysis.Load(xPath);
                        xmlAnalysis.CreateFile(Dists[i]);
                    }
                }
            }
            else
            {

                for (int i = 0; i < Dists.Length; i++)
                {
                    Dists[i].Load();
                    string xPath = path + Dists[i].GetType().Name + ".xml";
                    xmlAnalysis.Load(xPath);

                    xmlAnalysis.Load(xPath);

                    xmlAnalysis.CreateFile(Dists[i]);
                }
            }
        }
    }
}
