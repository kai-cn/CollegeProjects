using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

using GPA.GPA_Config;

namespace GPA.GPA_ADT
{
    abstract class BlockListDist:Data
    {
        string[] blockRanking;
        string blockPercentage;
        //protected FileInfo blockListDB;
        BlockListDBInterface blDbInter;

        public string[] BlockRanking
        {
            get
            {
                return blockRanking;
            }
        }

        public string BlockPercentage
        {
            get
            {
                return blockPercentage;
            }
        }

        public void Bind(BlockListDBInterface interf)
        {
            blDbInter = interf;
        }
       

        
        public BlockListDist()
        {
            
            
        }

        public override void Load()
        {
            if (ipList.Count==0)
            {
                DataSet ds = db.reDs(GetCommand());
                SetIpList(ds.Tables[0]);
            }

            try
            {

                string dirName = xmlConf.GetBlockListDBPath();
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                blockRanking=blDbInter.GetRanking(10, ipList);
                blockPercentage=Math.Round(blDbInter.BlocklistIP.Count * 1.0 / ipList.Count * 100, 5).ToString() + "%";
            }
            catch (Exception)
            {
 
            }
          }
    }
}
