using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string xPath;
    XmlBase xml;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.SetMarkers.AutoPostBack = true;
            Load();

        }
    }

    protected void SetMarkers_SelectedIndexChanged(object sender, EventArgs e)
    {


    }


    protected void Load()
    {
        xPath = @"D:\程序设计\C#\ASP.Net\google_maps_ip_searching_v1\Google Maps\" + SetMarkers.SelectedValue + ".xml";
        xml = new XmlBase();
        xml.LoadXml(xPath);
        List<XmlPoint> list = xml.GetXmlPoints();

        for (int i = 0; i < list.Count; i++)
        {
            TextPoint.Value += list[i].Point + ";";
            TextIP.Value += list[i].IP + ",";
        }
    }
}