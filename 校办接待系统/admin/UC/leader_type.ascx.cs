using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UC_leader_type : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        if (this.txt_id.Text.Trim() != "")
        {
            Response.Redirect("~/admin/leader_detail.aspx?leader_name=" + this.txt_id.Text.Trim());
        }
    }
}