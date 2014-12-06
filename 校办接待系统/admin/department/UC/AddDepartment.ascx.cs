using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class admin_department_UC_AddDepartment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null)
            {
                DataSet department = Department.GetDepartmentBasicInfo(Convert.ToInt32(Request["id"]));
                if (department != null)
                {
                    this.TBName.Text = department.Tables[0].Rows[0][1].ToString();
                    this.TBAddress.Text = department.Tables[0].Rows[0][2].ToString();
                    this.TBPhone.Text = department.Tables[0].Rows[0][3].ToString();
                    this.DropDownList1.SelectedItem.Value = department.Tables[0].Rows[0][4].ToString();
                }

            }
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string department_name = this.TBName.Text.Trim();
            string department_address = this.TBAddress.Text.Trim();
            string department_fax = this.TBPhone.Text.Trim();
            string department_type = this.DropDownList1.SelectedItem.Value;



            if (Request["action"] != null & Request["action"] == "edit")
            {
                Department.UpdateDepartmentInfo(department_name, department_address, department_fax, department_type,Convert.ToInt32(Request["id"]));
            
            }
            else
            {

                Department.AddDepartmentInfo(department_name, department_address, department_fax, department_type);
            }
            Response.Write("<script>alert('添加成功！');window.location.href= 'department_type.aspx';</script>");
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('添加失败！')</script>");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location.href= 'department_type.aspx';</script>");
    }
}