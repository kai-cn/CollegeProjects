using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

using GPA.GPA_ADT;

namespace GPA.GPA_Xml
{
    class XmlClusCoefDist:XmlAnalysis
    {
        public override void CreateFile(GPA_ADT.Data data)
        {
            ClusCoefDist clusCoef = (ClusCoefDist)data;

            XmlElement clusCoefElem = CreateClusCoefNode();

            clusCoefElem.Attributes["P"].Value = clusCoef.P.ToString();
            clusCoefElem.Attributes["AverageDegree"].Value = clusCoef.AverageDegree.ToString();
            clusCoefElem.Attributes["MaxDegree"].Value = clusCoef.MaxDegree.ToString();
            clusCoefElem.Attributes["ClusCoef"].Value = clusCoef.ClusCoef.ToString();

            xmlNode.AppendChild(clusCoefElem);

            xmlDoc.Save(uri);
        }

        public XmlElement CreateClusCoefNode()
        {
            XmlElement clusCoefElem = xmlDoc.CreateElement("ClusElem");
            clusCoefElem.SetAttribute("P", null);
            clusCoefElem.SetAttribute("AverageDegree", null);
            clusCoefElem.SetAttribute("MaxDegree", null);
            clusCoefElem.SetAttribute("ClusCoef", null);


            return clusCoefElem; 
        }
    }
}
