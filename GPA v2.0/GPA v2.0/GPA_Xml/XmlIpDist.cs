using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

using GPA.GPA_ADT;

namespace GPA.GPA_Xml
{
    class XmlIpDist:XmlAnalysis
    {
        private XmlElement xmlPlacemark;

        public override void CreateFile(Data data)
        {
            IPDist ipDist = (IPDist)data;

            for (int i = 0; i < ipDist.IpList.Count; i++)
            {
                xmlPlacemark = CreatePlacemarkNode();
                xmlPlacemark.ChildNodes[0].InnerText = ipDist.IpList[i].ToString();
                if(ipDist.CountryNameList[i]!=null)
                    xmlPlacemark.ChildNodes[1].ChildNodes[0].InnerText = ipDist.CountryNameList[i].ToString();
                if(ipDist.CityList[i]!=null)
                    xmlPlacemark.ChildNodes[1].ChildNodes[1].InnerText = ipDist.CityList[i].ToString();
                xmlPlacemark.ChildNodes[2].ChildNodes[0].InnerText = ipDist.LatList[i].ToString() + ',' + ipDist.LngList[i].ToString();
                xmlNode.AppendChild(xmlPlacemark);
            }

            xmlDoc.Save(uri);
        }

         protected XmlElement  CreatePlacemarkNode()
        {
            XmlElement xmlPlacemark = xmlDoc.CreateElement("Placemark");

            XmlElement xmlName = CreateLocationNode();
         //   XmlElement kmlName = kmlDoc.CreateElement("location");
            XmlElement xmlIP = xmlDoc.CreateElement("ip");
           // XmlElement kmlDescription = kmlDoc.CreateElement("description");
            XmlElement xmlPoint = CreatePointNode();

            xmlPlacemark.AppendChild(xmlIP);
            xmlPlacemark.AppendChild(xmlName);
           // kmlPlacemark.AppendChild(kmlDescription);
            xmlPlacemark.AppendChild(xmlPoint);
            return xmlPlacemark;
        }


         private XmlElement CreateLocationNode()
         {
             XmlElement xmlLocation = xmlDoc.CreateElement("location");
             XmlElement xmlCountry = xmlDoc.CreateElement("Country");
             XmlElement xmlCity = xmlDoc.CreateElement("City");
             xmlLocation.AppendChild(xmlCountry);
             xmlLocation.AppendChild(xmlCity);

             return xmlLocation;
         }

         private XmlElement CreatePointNode()
         {
             XmlElement xmlPoint = xmlDoc.CreateElement("Point");
             XmlElement xmlCoordinates = xmlDoc.CreateElement("coordinates");
             xmlPoint.AppendChild(xmlCoordinates);

             return xmlPoint;
         }
    }
}
