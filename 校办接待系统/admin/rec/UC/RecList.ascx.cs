using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_rec_UC_rec_list : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }
    protected void BindData()
    {
        if (Request.QueryString["type"] != null)
        {
            try
            {
                int type = Convert.ToInt32(Request.QueryString["type"]);
                DataSet ds = Rec.GetRecList(type);
                GVRec.DataSource = ds;
                GVRec.DataBind();

                DropDownList ddl=null;

                for (int i = 0; i <= GVRec.Rows.Count - 1; i++)
                {
                    ddl=(DropDownList)GVRec.Rows[i].FindControl("ddlMajor");
                    string[] items=(GVRec.Rows[i].FindControl("Label1") as Label).Text.Split(',');

                    foreach (string item in items)
                        ddl.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            this.LBAdd.Visible = false;
        }
    }



    protected void BindData(string name)
    {

        if (Request.QueryString["type"] != null)
        {
            try
            {
                int type = Convert.ToInt32(Request.QueryString["type"]);
                DataSet ds = Rec.GetRecList(type,name);
                GVRec.DataSource = ds;
                GVRec.DataBind();
            }
            catch(Exception ex)
            {
            }
        }
        else
        {
            DataSet ds = Rec.GetRecList(name);
            GVRec.DataSource = ds;
            GVRec.DataBind();
        }
        
        
    }


    protected void GVRec_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVRec.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void LBAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/rec/add_rec.aspx?action=add&type=" + Request.QueryString["type"]);
    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        
        if (this.txt_id.Text.Trim() != null)
            BindData(this.txt_id.Text);
        
    }
    protected void GVRec_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string visit_id = e.CommandArgument.ToString();

            if (Rec.DeleteRec(visit_id))
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">"+"alert('删除成功')"+"</script>");
            }
            else
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">" + "alert('删除失败')" + "</script>");
            }

            DataBind();
        }
        else
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/admin/rec/add_rec.aspx?action=edit&id="+e.CommandArgument.ToString()+"&type=" + Request.QueryString["type"]);
            }
        }
    }
    protected void GVRec_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}