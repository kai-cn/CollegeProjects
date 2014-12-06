using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LineSearchDetail : System.Web.UI.Page
{
    private IntelligentBus.FrameWork.IStation station = new IntelligentBus.BLL.Station();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DealWithRequest();
        }
    }

    public void DealWithRequest()
    {
        if (Request["arg"]!=null&& Request["arg"].Trim() != "")
        {
            SetBusStation();


        }
        
    }

    public void SetBusStation()
    {
        int id = Convert.ToInt32(Request["arg"].Trim());
        List<IntelligentBus.Entities.BusStation> listBS = station.GetStation(id);

        string txt = string.Empty;
        foreach (IntelligentBus.Entities.BusStation ebs in listBS)
        {
            txt += ebs.Station + "->";
        }
        txt = txt.Substring(0, txt.Length - 2);

        this.txtBusStation.Text = txt;

        UpLoad(listBS);

    }

    public void UpLoad(List<IntelligentBus.Entities.BusStation> listBS)
    {
        string stationBE=listBS[0].Station+";";
        stationBE+=listBS[listBS.Count-2].Station;
        this.busStation.Value =stationBE;
        
    }
}