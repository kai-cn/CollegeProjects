using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Common.Xml
{
    /// <summary>
    /// 提供对xml文件的基本操作
    /// </summary>
    public class Xml
    {
        private XmlDocument _doc;
        private XmlNode _node;
        private string _path;

        public Xml()
        {
            _doc = new XmlDocument();
            
        }

        /// <summary>
        /// 根据路径创建文件
        /// </summary>
        /// <param name="path">文件名</param>
        public void CreateXmlFile(string path)
        {
            this._path = path;

            FileStream fileStream = new FileStream(_path, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sw.WriteLine("<Document>");
            sw.WriteLine("</Document>");
            sw.Close();

            using (Stream xmlStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                _doc.Load(xmlStream);
            }
            _node = _doc.SelectSingleNode("Document");
            
        }

        public void InsertXmlNode(XmlNode node)
        {
            _node.AppendChild(node);
        }

        public void Save()
        {
            _doc.Save(_path);
        }
    }
}
