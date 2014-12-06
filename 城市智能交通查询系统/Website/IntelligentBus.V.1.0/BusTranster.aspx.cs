using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Text;

public partial class BusTranster : System.Web.UI.Page
{
    private IntelligentBus.BLL.BusTranster bll = new IntelligentBus.BLL.BusTranster();

    protected void Page_Load(object sender, EventArgs e)
    {
       DealWithRequest();
    }


    private void DealWithRequest()
    {
        if (Request["source"] != null && Request["dest"] != null)
        {
            ShowTranster(Request["source"], Request["dest"]);

        }
    }

    private void ShowTranster(string source,string dest)
    {
        ShowTransterOne(source, dest);
    }

    private void ShowTransterOne(string source,string dest)
    {
        List<IntelligentBus.Entities.OneTranster> transterOne = bll.GetTransterOne(source, dest);

        if (transterOne != null)
        {
            
            foreach (IntelligentBus.Entities.OneTranster one in transterOne)
            {
                AddToPanel(one, this.panelOne);
            }
        }
    }

    private void AddToPanel(IntelligentBus.Entities.OneTranster one,Panel panelOne)
    {
        string txtOne = string.Empty;
        LinkButton link = new LinkButton();
        string str = one.StartStopIndex + ";" + one.EndStopIndex + ";" + one.FirstInfoID;
        txtOne = string.Format("{0}坐{1}({2}站)到{3} \r\n", one.StartStop, one.FirstInfo, one.Length, one.EndStop);
        link.Text = txtOne;
        link.Attributes.Add("args", str);
        link.Command += LinkBtn_Click;
        panelOne.Controls.Add(link);
        
    }

    private void LinkBtn_Click(object sender, EventArgs e)
    {
        LinkButton link= sender as LinkButton;
        string[] args=link.Attributes["args"].ToString().Split(';');
        int startIndex=Convert.ToInt32(args[0]);
        int endIndex=Convert.ToInt32(args[1]);
        int stationIndex=Convert.ToInt32(args[2]);
        string jsonStr = bll.JsonGetLocation(startIndex, endIndex, stationIndex);
        this.busTranster.Value = jsonStr;
        //Response.Redirect("BusTranster.aspx");
        //Response.Write(jsonStr);
        //Response.End();

        
    }
}