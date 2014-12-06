using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

using GPA.GPA_ADT;

namespace GPA.GPA_Xml
{
    abstract class XmlAnalysis
    {
        protected string uri;
        protected XmlDocument xmlDoc;
        protected XmlNode xmlNode;
        //protected string fileName;
        

        public void Load(string _uri)
        {
            this.uri = _uri;
            FileStream fileStream = new FileStream(uri, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sw.WriteLine("<Document>");
            sw.WriteLine("</Document>");
            sw.Close();


            xmlDoc = new XmlDocument();
            using (Stream xmlStream = new FileStream(uri, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                xmlDoc.Load(xmlStream);
            }
            xmlNode = xmlDoc.SelectSingleNode("Document");

        }

        abstract public void CreateFile(Data data);
    }
}
