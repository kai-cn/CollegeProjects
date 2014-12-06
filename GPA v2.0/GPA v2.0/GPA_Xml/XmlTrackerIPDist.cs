using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

using GPA.GPA_ADT;

namespace GPA.GPA_Xml
{
    class XmlTrackerIPDist:XmlAnalysis
    {
        public override void CreateFile(Data data)
        {
            TrackerIPDist trackerIp = (TrackerIPDist)data;

            foreach (DictionaryEntry de in trackerIp.PeersDegree)
            {
                XmlElement trackerIpElem = CreateTrackerIPElem();
                trackerIpElem.Attributes["TrackerIP"].Value = de.Key.ToString();
                trackerIpElem.Attributes["Count"].Value = de.Value.ToString();
                xmlNode.AppendChild(trackerIpElem);
            }

            xmlDoc.Save(uri);

        }

        public XmlElement CreateTrackerIPElem()
        {
            XmlElement trackerIpElem = xmlDoc.CreateElement("Tracker");
            trackerIpElem.SetAttribute("TrackerIP", null);
            trackerIpElem.SetAttribute("Count",null);

            return trackerIpElem;
        }
    }
}
