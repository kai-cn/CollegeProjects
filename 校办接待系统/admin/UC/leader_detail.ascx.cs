using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UC_leader_detail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void BindData()
    {
        if (Request.QueryString["id"] != null)
        {
            this.txt_id.Visible = false;
            this.btn_ok.Visible = false;

            int leader_id = 0;
            try
            {
                leader_id = Convert.ToInt32(Request.QueryString["id"]);
                DataSet ds = Leader.GetLeader(leader_id);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('暂无领导信息！')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                Response.End();
            }
        }

        if (Request.QueryString["leader_name"] != null)
        {
            string leader_name = Request.QueryString["leader_name"];
            try
            {
                
                DataSet ds = Leader.GetLeader(leader_name);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('暂无领导信息！')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                Response.End();
            }
 
        }
    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        if (this.txt_id.Text.Trim() != "")
        {
            Response.Redirect("~/admin/leader_detail.aspx?leader_name=" + this.txt_id.Text.Trim());
        }
    }
}