using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UC_leader_list : System.Web.UI.UserControl
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
        int type = 0;
        try
        {
            type = Convert.ToInt32(Request.QueryString["type"]);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
        if (type != 0)
        {
            DataSet ds = Leader.GetLeaderList(type);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
            else
                Response.Write("<script>alert('暂无领导数据，请添加！');window.location.href= 'add_leader.aspx?action=add';</script>");

        }
        else
            Response.Write("<script>alert('暂无领导数据，请添加！');window.location.href= 'add_leader.aspx?action=add';</script>");

    }
    protected void LBAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/add_leader.aspx?action=add");
    }

}