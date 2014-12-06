using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.IO;

public partial class admin_department_UC_OfficeList : System.Web.UI.UserControl
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
        try
        {
            if (Request.QueryString["id"] != null)
            {
                int department_id = Convert.ToInt32(Request.QueryString["id"]);
                DataSet ds = null;
                ds = Department.GetDepartmentOfficeByDepartmentId(department_id);


                GVOffice.DataSource = ds;
                GVOffice.DataBind();

                DropDownList ddl = null;

                for (int i = 0; i <= GVOffice.Rows.Count - 1; i++)
                {
                    ddl = (DropDownList)GVOffice.Rows[i].FindControl("office_major");
                    string[] items = (GVOffice.Rows[i].FindControl("Label1") as Label).Text.Split(',');

                    foreach (string item in items)
                        ddl.Items.Add(item.Trim());

                    ddl = (DropDownList)GVOffice.Rows[i].FindControl("office_idcard");
                    items = (GVOffice.Rows[i].FindControl("Label2") as Label).Text.Split(',');


                    foreach (string item in items)
                        ddl.Items.Add(item.Trim());
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void LBAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/department/add_office.aspx?action=add&id=" + Request.QueryString["id"]);
    }

    protected void GVOffice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVOffice.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void GVOffice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GVOffice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string office_id = e.CommandArgument.ToString();

            if (Department.DeleteOffice(office_id))
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">" + "alert('删除成功')" + "</script>");
            }
            else
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">" + "alert('删除失败')" + "</script>");
            }

            BindData();
        }
        else
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/admin/department/add_office.aspx?action=edit&office_id=" + e.CommandArgument.ToString() + "&id=" + Request.QueryString["id"]);
            }
            else
            {
                if (e.CommandName == "Download")
                {
                    if (e.CommandArgument.ToString().Trim() != "")
                    {
                        try
                        {
                            string filePath = Server.MapPath("~/photo/") + e.CommandArgument.ToString();

                            FileInfo fileInfo = new FileInfo(filePath);

                            Response.Clear();
                            Response.ClearContent();
                            Response.ClearHeaders();

                            Response.AddHeader("Content-Disposition", "attachment;filename=" + e.CommandArgument.ToString());
                            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                            Response.AddHeader("Content-Transfer-Encoding", "binary");
                            Response.ContentType = "application/octet-stream";
                            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                            Response.WriteFile(fileInfo.FullName);
                            Response.Flush();
                            Response.End();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        Response.Write("<script language=\"javascript\" type=\"text/javascript\">" + "alert('未上传文件，下载失败')" + "</script>");
                    }
                        
                }
            }
        }
    }
    protected void btn_ok_Click(object sender, EventArgs e)
    {
        try
        {
            string search_type = this.dropDownList1.SelectedItem.Value;
            DataSet ds = null;
            
            ds = Department.GetDepartmentOfficeInfo(search_type, this.txt_id.Text);

            GVOffice.DataSource = ds;
            GVOffice.DataBind();

            DropDownList ddl = null;

                for (int i = 0; i <= GVOffice.Rows.Count - 1; i++)
                {
                    ddl = (DropDownList)GVOffice.Rows[i].FindControl("office_major");
                    string[] items = (GVOffice.Rows[i].FindControl("Label1") as Label).Text.Split(',');

                    foreach (string item in items)
                        ddl.Items.Add(item.Trim());

                    ddl = (DropDownList)GVOffice.Rows[i].FindControl("office_idcard");
                    items = (GVOffice.Rows[i].FindControl("Label2") as Label).Text.Split(',');


                    foreach (string item in items)
                        ddl.Items.Add(item.Trim());
                }
            }
        catch(Exception ex)
        {

        }
        

    }
}