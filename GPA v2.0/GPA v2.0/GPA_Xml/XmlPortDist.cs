using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using GPA.GPA_ADT;

namespace GPA.GPA_Xml
{
    class XmlPortDist:XmlAnalysis
    {
        public override void CreateFile(Data data)
        {
            PortDist portDist = (PortDist)data;

            string[] keysarray = new string[portDist.PortTable.Count];
            float[] valuesarray = new float[portDist.PortTable.Count];

            portDist.PortTable.Keys.CopyTo(keysarray, 0);
            portDist.PortTable.Values.CopyTo(valuesarray, 0);

            for (int i = 0; i < keysarray.Length; i++)
                valuesarray[i] = (float)Math.Round((valuesarray[i] / portDist.IpCount * 100), 5);
            Array.Sort(valuesarray, keysarray);
            Array.Reverse(valuesarray);
            Array.Reverse(keysarray);

            for (int i = 0; i < valuesarray.Length; i++)
            {
                XmlElement xmlPortInfo = CreatePortInfoNode();
                xmlPortInfo.ChildNodes[0].InnerText = keysarray[i].ToString();
                xmlPortInfo.ChildNodes[1].InnerText = valuesarray[i].ToString() + "%";
                xmlNode.AppendChild(xmlPortInfo);
            }
            xmlDoc.Save(uri);
            //throw new NotImplementedException();
        }

        protected XmlElement CreatePortInfoNode()
        {
            XmlElement xmlPortInfo = xmlDoc.CreateElement("PortInfo");
            XmlElement xmlPortName = xmlDoc.CreateElement("Port");
            XmlElement xmlPercentage = xmlDoc.CreateElement("Percentage");

            xmlPortInfo.AppendChild(xmlPortName);
            xmlPortInfo.AppendChild(xmlPercentage);

            return xmlPortInfo;
        }

    }
}
