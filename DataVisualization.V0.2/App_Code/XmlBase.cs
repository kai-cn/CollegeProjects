using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
///XmlBase 的摘要说明
/// </summary>
public class XmlBase
{
    XmlDocument xmlDoc;
    XmlNodeList xmlPointsList;

	public XmlBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
        xmlDoc = new XmlDocument();
        
	}

    public void  LoadXml(string xPath)
    {
        if (xPath != null)
        {
            xmlDoc.Load(xPath);

            XmlNode xmlNode=xmlDoc.SelectSingleNode("Document");

            xmlPointsList = xmlNode.ChildNodes;

        }
    }

    public List<XmlPoint> GetXmlPoints()
    {
        List<XmlPoint> listXmlPoint = new List<XmlPoint>();
        foreach (XmlNode xmlNode in xmlPointsList)
        {
            string ip = xmlNode.SelectSingleNode("name").InnerText;


            string point = xmlNode.SelectSingleNode("Point").SelectSingleNode("coordinates").InnerText;

            XmlPoint xmlPoint = new XmlPoint(ip, point);

            listXmlPoint.Add(xmlPoint);
        }

        return listXmlPoint;
    }
    
}