using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using GPA.GPA_ADT;

namespace GPA.GPA_Xml
{
    class XmlBlockListDist:XmlAnalysis
    {
        public XmlBlockListDist()
        {
            
        }

        protected XmlElement CreateRankNode()
        {
            XmlElement rank = xmlDoc.CreateElement("Rank");
            return rank;
        }


        protected XmlElement CreatePercentageNode()
        {
            XmlElement percentage = xmlDoc.CreateElement("Percentage");
            return percentage;
        }


        public override void CreateFile(Data data)
        {
            BlockListDist blist = (BlockListDist)data;


            XmlElement xmlPercent = CreatePercentageNode();
            
            xmlPercent.InnerText = blist.BlockPercentage;
            xmlNode.AppendChild(xmlPercent);
            foreach (string str in blist.BlockRanking)
            {
                XmlElement xmlRanking = CreateRankNode();
                xmlRanking.InnerText = str;
                xmlNode.AppendChild(xmlRanking);
            }
            xmlDoc.Save(uri);
        }
    }
}
