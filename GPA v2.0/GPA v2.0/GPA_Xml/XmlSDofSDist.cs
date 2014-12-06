using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

using GPA.GPA_ADT;


namespace GPA.GPA_Xml
{
    class XmlSDofSDist:XmlAnalysis
    {
        public override void CreateFile(Data data)
        {
            SDofSDist sdofs = (SDofSDist)data;

            string content=string.Empty;

            XmlElement sdofElem = CreateSDofSNode();

            sdofElem.ChildNodes[0].InnerText = sdofs.GraphCount.ToString();


            foreach(ArrayList al in sdofs.SuccessPath)
            {
                foreach (string str in al)
                    content+=str + "-";
                content+= "\r\n";
            }

            sdofElem.ChildNodes[1].InnerText=content;

            sdofElem.ChildNodes[2].Attributes["CanLinked"].Value = sdofs.CanLinked.ToString();
            sdofElem.ChildNodes[2].Attributes["NotLinked"].Value = sdofs.NotLinked.ToString();

            sdofElem.ChildNodes[3].InnerText=sdofs.AverageSeparationDegree.ToString();

            xmlNode.AppendChild(sdofElem);

            xmlDoc.Save(uri);


        }


        private XmlElement CreateSDofSNode()
        {
            XmlElement sdof = xmlDoc.CreateElement("SDofS");
            XmlElement count = xmlDoc.CreateElement("PeerCount");
            XmlElement path = xmlDoc.CreateElement("Path");
            XmlElement Linked = xmlDoc.CreateElement("Link");
            Linked.SetAttribute("CanLinked", null);
            Linked.SetAttribute("NotLinked", null);
            XmlElement Degree = xmlDoc.CreateElement("Degree");

            sdof.AppendChild(count);
            sdof.AppendChild(path);
            sdof.AppendChild(Linked);
            sdof.AppendChild(Degree);

            return sdof;

        }
    }
}
