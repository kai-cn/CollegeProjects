using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LineSearch : System.Web.UI.Page
{
    IntelligentBus.FrameWork.ILineSearch lineSearch = new IntelligentBus.BLL.LineSearch();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
 
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtLine.Text!= null&& txtLine.Text.Trim()!="")
        {
            List<IntelligentBus.Entities.BusLine> listBusLine = lineSearch.GetBusLine(txtLine.Text.Trim());

            foreach (IntelligentBus.Entities.BusLine ebl in listBusLine)
            {
                AddToPanel(ebl, busLinePanel); 
            }
        }
    }

    private void AddToPanel(IntelligentBus.Entities.BusLine ebl, Panel panelOne)
    {
        string txt = string.Empty;
        HyperLink link = new HyperLink();
        List<IntelligentBus.Entities.BusInfo> listBusInfo=lineSearch.GetBusInfo(ebl);

        txt+=ebl.LineCode;



        foreach (IntelligentBus.Entities.BusInfo ebi in listBusInfo)
        {
            txt += ebi.StartTime + "-" + ebi.EndTime + " ";
        }



        link.Text = txt;
        //link.Command += LinkBtn_Click;
        link.NavigateUrl = string.Format("LineSearchDetail.aspx?arg={0}", ebl.ID.ToString());
        panelOne.Controls.Add(link);

    }

}