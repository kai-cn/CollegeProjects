using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

using GPA.GPA_ADT;

namespace GPA.GPA_Xml
{
    class XmlFakePeersDist:XmlAnalysis
    {
        public override void CreateFile(GPA_ADT.Data data)
        {
            FakePeerDist fpDist = (FakePeerDist)data;
            XmlElement fakePeer = xmlDoc.CreateElement("FakePeer");
            xmlNode.AppendChild(fakePeer);
            XmlElement blockPeer = CreateBlockPeer(fpDist);
            fakePeer.AppendChild(blockPeer);
            XmlElement self = CreateSelf(fpDist);
            fakePeer.AppendChild(self);

            xmlDoc.Save(uri);
        }

        private XmlElement CreateBlockPeer(FakePeerDist fpDist)
        {
            XmlElement blockPeer = xmlDoc.CreateElement("BlockList");
            XmlElement bogon = CreateElem(fpDist.BelongBogonPeers, "Bogon");
            XmlElement level1 = CreateElem(fpDist.BelongLevel1Peers, "Level1");
            XmlElement level2 = CreateElem(fpDist.BelongLevel2Peers, "Level2");
            XmlElement hijacked = CreateElem(fpDist.BelongHijackedPeers, "hijacked");

            blockPeer.AppendChild(bogon);
            blockPeer.AppendChild(level1);
            blockPeer.AppendChild(level2);
            blockPeer.AppendChild(hijacked);

            return blockPeer;
        }

        private XmlElement CreateAttr(string name)
        {
            XmlElement blockPeer = xmlDoc.CreateElement(name);
            blockPeer.SetAttribute("IP", null);
            blockPeer.SetAttribute("Percent", null);

            return blockPeer;
        }




        private XmlElement CreateElem(Hashtable ht,string name)
        {
            XmlElement Peer = xmlDoc.CreateElement(name);


            foreach (DictionaryEntry de in ht)
            {
                XmlElement elem = CreateAttr(name+"Elem");
                elem.Attributes["IP"].Value = de.Key.ToString();
                elem.Attributes["Percent"].Value = de.Value.ToString();
                Peer.AppendChild(elem);
            }

            return Peer;
        }


        private XmlElement CreateSelf(FakePeerDist fpDist)
        {
            XmlElement self = xmlDoc.CreateElement("Self");
            XmlElement selfList = CreateElem(fpDist.SelfPeers, "SelfList");

            self.AppendChild(selfList);
            return self;
        }
    }
}
