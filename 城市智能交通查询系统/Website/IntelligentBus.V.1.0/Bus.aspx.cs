using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

public partial class _Default : System.Web.UI.Page
{
    private IntelligentBus.BLL.BusTranster bll = new IntelligentBus.BLL.BusTranster();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (this.txtBegin.Text == "" || this.txtEnd.Text == "")
        {
            Response.Write("cuogdfg");
        }
        else
        { 
            string source=this.txtBegin.Text;
            string dest=this.txtEnd.Text;
            
            Response.Redirect(string.Format("BusTranster.aspx?source={0}&dest={1}", source, dest));
            
        }
    }
}