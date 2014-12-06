using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_uni_contact_UC_Index : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        if (txt_id.Text.Trim() != null)
        {
            Response.Redirect("contact_uni_detail.aspx?uni_name=" + txt_id.Text);
        }
    }
}