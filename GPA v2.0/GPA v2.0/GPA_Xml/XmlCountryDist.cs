using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using GPA.GPA_ADT;


namespace GPA.GPA_Xml
{
    class XmlCountryDist:XmlAnalysis
    {
        public override void CreateFile(Data data)
        {
            CountryDist countryDist = (CountryDist)data;

            string[] keysarray = new string[countryDist.CountryTable.Count];
            float[] valuesarray = new float[countryDist.CountryTable.Count];

            countryDist.CountryTable.Values.CopyTo(valuesarray, 0);
            countryDist.CountryTable.Keys.CopyTo(keysarray, 0);

            for (int i = 0; i < countryDist.CountryTable.Count; i++)
                valuesarray[i] = (float)Math.Round((valuesarray[i] / countryDist.IpCount * 100), 5);
            Array.Sort(valuesarray, keysarray);
            Array.Reverse(valuesarray);
            Array.Reverse(keysarray);

            for (int i = 0; i < valuesarray.Length; i++)
            {
                XmlElement xmlCountryInfo = CreateCountryInfoNode();
                xmlCountryInfo.ChildNodes[0].InnerText = keysarray[i].ToString();
                xmlCountryInfo.ChildNodes[1].InnerText = valuesarray[i].ToString() + "%";
                xmlNode.AppendChild(xmlCountryInfo);
            }

            xmlDoc.Save(uri);
            //throw new NotImplementedException();
        }


        protected XmlElement CreateCountryInfoNode()
        {
            XmlElement xmlCountryInfo = xmlDoc.CreateElement("CountryInfo");
            XmlElement xmlCountry = xmlDoc.CreateElement("Country");
            XmlElement xmlPercentage = xmlDoc.CreateElement("Percentage");

            xmlCountryInfo.AppendChild(xmlCountry);
            xmlCountryInfo.AppendChild(xmlPercentage);

            return xmlCountryInfo;
        }
    }
}
