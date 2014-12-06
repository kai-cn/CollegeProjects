using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;

using System.IO;
using System.Data;
using NetUtil.db;

/// <summary>
/// 排名数据类
/// </summary>
public class RankData
{
    public string name;
    public string number;
    public string percent;
    public RankData(string name, string number,string percent)
    {
        this.name = name;
        this.number = number;
        this.percent = percent;
    }
}

/// <summary>
/// json格式化
/// </summary>
public class cjson
{
    public dat top = new dat();
    public dat all = new dat();
    public class dat
    {
        public List<double> dataNoName = new List<double>();
        public List<cdataWithName> dataWithName = new List<cdataWithName>();
        public List<string> categorie = new List<string>();
        public class cdataWithName
        {
            public string name;
            public double y;
            public cdataWithName(string name, double y)
            {
                this.name = name;
                this.y = y;
                
            }
        }
    }
}

public partial class p2p_dataAnalysis : System.Web.UI.Page
{
    public static string maxDate, minDate;//2011-07格式
    public static string year="0", month="0";//存放selected


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetDataDate();
            SetDropDownListDefault();
        }
        AjaxShow();
    }

    private void SetDataDate()
    {
        DataSet ds;

        AMDBUtil sqlDb = AMDBAdapter.GetDBAdapter("218.4.189.17", "sklcc", "skl.yz", "SKLCC", 0);
        sqlDb.Connect();

        string tmp = @"select max(t)  from 
                        (select max(timespan) AS t from country_ranking_foreign_bt
                        union select max(timespan) from country_ranking_internal_bt
                        union select max(timespan) from country_ranking_foreign_em
                        union select max(timespan) from country_ranking_internal_em
                        ) AS a";
        ds = sqlDb.Select(tmp);
        maxDate = ds.Tables[0].Rows[0][0].ToString();
        tmp = @"select min(t) from (
                select min(timespan) AS t from country_ranking_foreign_bt
                union select min(timespan) from country_ranking_internal_bt
                union select min(timespan) from country_ranking_foreign_em
                union select min(timespan) from country_ranking_internal_em
                ) AS a";
        ds = sqlDb.Select(tmp);
        minDate = ds.Tables[0].Rows[0][0].ToString();
    }

    private void SetDropDownListDefault()
    {
        string maxYear = maxDate.Substring(0, 4);
        string minYear = minDate.Substring(0, 4);
        for (int i = Convert.ToInt16(minYear); i <= Convert.ToInt16(maxYear); ++i)
        {
            DropDownList1.Items.Add(i.ToString());
        }
    }

    private void AjaxShow()
    {
        string json="";
        if (Request.Headers["dataType"] != null)
        {
            json = ReturnJsondata(Request.Headers["dataType"], Request.Headers["topAmount"]);
        }
        if (json != "")
        {
            Response.Write(json);
            Response.End();
        }
    }

    /// <summary>
    /// 用Json格式化GetRank()获取的数据(Pie图data)
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public string ReturnJsondata(string type,string topAmount)
    {
        string selectedYear = year;
        string selectedMonth = month;
        string selectStr = "SELECT name,num,percentage FROM ";
        switch(type)
        {
            case "countryRankFoBt": selectStr += "country_ranking_foreign_bt"; break;
            case "countryRankFoEm": selectStr += "country_ranking_foreign_em"; break;
            case "countryRankInBt": selectStr += "country_ranking_internal_bt"; break;
            case "countryRankInEm": selectStr += "country_ranking_internal_em"; break;

            case "portRankFoBt": selectStr += "port_ranking_foreign_bt"; break;
            case "portRankFoEm": selectStr += "port_ranking_foreign_em"; break;
            case "portRankInBt": selectStr += "port_ranking_internal_bt"; break;
            case "portRankInEm": selectStr += "port_ranking_internal_em"; break;

            case "blRankInBt": selectStr += "bl_ranking_internal_bt"; break;
            case "blRankInEm": selectStr += "bl_ranking_internal_em"; break;
            case "blRankFoBt": selectStr += "bl_ranking_foreign_bt"; break;
            case "blRankFoEm": selectStr += "bl_ranking_foreign_em"; break;

            case "serverRankInBt": selectStr += "server_ranking_internal_bt"; break;
            case "serverRankInEm": selectStr += "server_ranking_internal_em"; break;
            case "serverRankFoBt": selectStr += "server_ranking_foreign_bt"; break;
            case "serverRankFoEm": selectStr += "server_ranking_foreign_em"; break;

            //case "": selectStr += ""; break;
            
        }

        //添加时间范围
        selectStr += @" where timespan='";
        selectStr += selectedYear;
        selectStr += "-";
        selectStr += selectedMonth;
        selectStr += @"'";

        //order by
        selectStr += @" order by ranking";

        //获取数据
        List<RankData> rd = GetRank(selectStr, 0);
        string json;
        if (rd.Count==0)
        {
            json = "null";
        }
        //{"top":{"dnn":[1,2,3],"dwn":[['n1',1],['n2',2],['n3',3]],"categorie":['n1','n2','n3']},"all":{"dnn":[1,2,4],"dwn":[['n1',1],['n2',2],['n4',4]],"categorie":['n1','n2','n4']}}
        else
        {
            cjson data = new cjson();
            int i = 0;
            double counter = 0;
            double pct = 0;
            foreach (RankData t in rd)
            {
                data.top.categorie.Add(t.name);
                data.top.dataNoName.Add(Convert.ToDouble(t.number));
                data.top.dataWithName.Add(new cjson.dat.cdataWithName(t.name,Convert.ToDouble(t.number)));

                pct += Convert.ToDouble(t.percent);
                counter += Convert.ToDouble(t.number);
                ++i;
                if (i >= Convert.ToInt32(topAmount))
                    break;
            }
            counter = counter * 100 / pct - counter;
            pct = 100 - pct;

            data.top.categorie.Add("other");
            data.top.dataNoName.Add(Convert.ToDouble(counter));
            data.top.dataWithName.Add(new cjson.dat.cdataWithName("other", Convert.ToDouble(counter)));

            foreach (RankData t in rd)
            {
                data.all.categorie.Add(t.name);
                data.all.dataNoName.Add(Convert.ToDouble(t.number));
                //减小数据量
                //data.all.dataWithName.Add(new cjson.dat.cdataWithName(t.name, Convert.ToDouble(t.number)));
            }
            json=new JavaScriptSerializer().Serialize(data);
        }
        
        return json;
    }


    

    /// <summary>
    /// 返回排名结果(需返回表字段顺序依次为name，num，percentage)
    /// </summary>
    /// <param name="selectStr">select语句</param>
    /// <param name="topNum">前多少条记录(0为全部)</param>
    /// <returns></returns>
    public List<RankData> GetRank(string selectStr,int topNum)
    {
        List<RankData> rd;
        DataSet ds;

        AMDBUtil sqlDb = AMDBAdapter.GetDBAdapter("218.4.189.17", "sklcc", "skl.yz", "SKLCC", 0);
        sqlDb.Connect();

        ds = sqlDb.Select(selectStr);
        DataTable dt = ds.Tables[0];
        rd = new List<RankData>();
        if (topNum == 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                rd.Add(new RankData(dr[0].ToString(), dr[1].ToString(), dr[2].ToString()));
            }
        }
        else
        {
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                rd.Add(new RankData(dr[0].ToString(), dr[1].ToString(), dr[2].ToString()));
                i++;
                if (i >= topNum)
                    break;
            }
        }
        return rd;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string maxMonth = maxDate.Substring(5, 2);
        string minMonth = minDate.Substring(5, 2);
        year = DropDownList1.SelectedValue;
        month = minMonth;
        DropDownList2.Items.Clear();
        //判断是否有一整年，否则只写部分月份
        if (maxDate.Substring(0, 4) != minDate.Substring(0, 4))
        {
            //如选中最大年份，需取现已有月份写入
            if (DropDownList1.SelectedValue == maxDate.Substring(0, 4))
            {
                for (int i = 1; i <= Convert.ToInt16(maxMonth); ++i)
                {
                    DropDownList2.Items.Add(i.ToString().PadLeft(2, '0'));
                }
            }
            else if (DropDownList1.SelectedValue == minDate.Substring(0, 4))
            {
                for (int i = Convert.ToInt16(minMonth); i <= 12; ++i)
                {
                    DropDownList2.Items.Add(i.ToString().PadLeft(2, '0'));
                }
            }
            else if (DropDownList1.SelectedValue != "0")
            {
                for (int i = 1; i <= 12; ++i)
                {
                    DropDownList2.Items.Add(i.ToString().PadLeft(2, '0'));
                }
            }
        }
        else if(DropDownList1.SelectedValue != "0")
        {
            for (int i = Convert.ToInt16(minMonth); i <= Convert.ToInt16(maxMonth); ++i)
            {
                DropDownList2.Items.Add(i.ToString().PadLeft(2, '0'));
            }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        year = DropDownList1.SelectedValue;
        month = DropDownList2.SelectedValue;
    }
}
