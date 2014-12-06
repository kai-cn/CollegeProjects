using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class admin_department_UC_DeparmentType : System.Web.UI.UserControl
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

        btn_ok_Click(null, null);
    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        try
        {
            int department_type = Convert.ToInt32(this.dropDownList1.SelectedItem.Value);
            DataSet ds = null;
            if (department_type == 0)
            {
                ds = Department.GetDepartmentBasicInfo(this.txt_id.Text);
            }
            else
            {

                ds = Department.GetDepartmentBasicInfo(department_type,this.txt_id.Text);
            }

            if (ds.Tables.Count>0&&ds.Tables[0].Rows.Count==0)
            {
                ds = Department.GetEmptyDepartmentBasicRow();
            }


            GVList.DataSource = ds;
            GVList.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/department/add_department.aspx?action=add");
    }

    protected void GVList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVList.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GVList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Delete")
        {
            string department_id = e.CommandArgument.ToString();

            if (Department.DeleteDepartment(department_id))
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
                Response.Redirect("~/admin/department/add_department.aspx?action=edit&id="+e.CommandArgument.ToString());
            }
        }
    }
}