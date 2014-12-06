using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GPA.GPALib.ConfigureInfomation
{

    public  enum blType
    {
        bt_ads,
        bt_bogon,
        bt_dshield,
        bt_edu,
        bt_hijacked,
        bt_iana_multicast,
        bt_level1,
        bt_level2,
        bt_level3,
        bt_microsoft,
        bt_proxy,
        bt_rangest,
        bt_spider,
        bt_spyware,
        bt_templist,
        bt_webexploit

    };

    class UpdateConfigure
    {
       

        private static UpdateConfigure xmlUpdate;

        private static readonly object obj=new object();


        private XmlDocument xmlDoc;
        private XmlNode xmlNode;
        private XmlNode xmlGeo;
        private XmlNode xmlBl;
            



        private UpdateConfigure()
        {
            
        }


        public static UpdateConfigure GetInstance()
        {
            if (xmlUpdate == null)
            {
                lock (obj)
                {
                    if (xmlUpdate == null)
                    {
                        xmlUpdate = new UpdateConfigure();
                    }
                }
            }
            return xmlUpdate;
        }


        public void Load(string path)
        {
            xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(path);
                xmlNode = xmlDoc.SelectSingleNode("update");
                
                
                

                xmlGeo = xmlNode.ChildNodes[0];
                xmlBl = xmlNode.ChildNodes[1];
            }
            catch (Exception e)
            {
                
            }

        }


        public Uri GetBlockListUri()
        {
            try
            {
                return new Uri(xmlBl.Attributes["uri"].Value);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public Uri GetGeoUri()
        {
            try
            {
                return new Uri(xmlGeo.Attributes["uri"].Value);
            }
            catch (Exception)
            {
                return null;
            }   
        }

        public string GetGeoVersion()
        {
            try
            {
                return xmlGeo.Attributes["version"].Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private int GetPosition(string str)
        {
            int index=0;
            foreach(XmlNode node in xmlNode.ChildNodes)
            {
                if(node.Value==str)
                    break;
                index++;
            }

            return index;
        }


        //public string GetAdsVersion()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_ads")].Value;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}


        //public string GetBogonVersion()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_bogon")].Value;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public string GetDshieldVersion()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_dshield")].Value;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public string GetEduVersion()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_edu")].Value;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public string GetHijackedVersion()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_hijacked")].Value;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}


        //public string GetIanaMulticastVersion()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_iana_multicast")].Value;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

       

        //public string GetLevel1Version()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_level1")].Value;
        //    }
        //    catch(Exception)
        //    {
        //        return null;
        //    }
        //}

        //public string GetLevel2Version()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_level2")].Value;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public string GetLevel3Version()
        //{
        //    try
        //    {
        //        return xmlBl.ChildNodes[GetPosition("bt_level3")].Value;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}


        public string GetBlVersion(blType type)
        {
            try
            {
                return xmlBl.ChildNodes[GetPosition(type.ToString())].Attributes["version"].Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetBlNumberofRanges(blType type)
        {
            try
            {
                return xmlBl.ChildNodes[GetPosition(type.ToString())].Attributes["numberOfRanges"].Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetBlNumberofIps(blType type)
        {
            try
            {
                return xmlBl.ChildNodes[GetPosition(type.ToString())].Attributes["NumberOfIps"].Value;
            }
            catch (Exception)
            {
                return null;
            }
        }
        


    }
}
