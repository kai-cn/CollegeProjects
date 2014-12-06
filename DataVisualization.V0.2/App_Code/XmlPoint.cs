using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///XmlPoint 的摘要说明
/// </summary>
public class XmlPoint
{

    private string ip;
    private string point;

    public string IP
    {
        get
        {
            return ip;
        }
    
    }

    public string Point
    {
        get
        {
            return point;
        }
    }

	public XmlPoint(string ip,string point)
	{
        this.ip = ip;
        this.point = point;
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}



}