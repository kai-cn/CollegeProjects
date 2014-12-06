using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class admin_department_UC_AddOfficeEditor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request["office_id"]!=null)
            {
                DataSet ds=Department.GetOfficeInfo(Convert.ToInt32(Request["office_id"]));

                this.TBPerson.Text = ds.Tables[0].Rows[0][12].ToString();

                this.TBAddress.Text = ds.Tables[0].Rows[0][3].ToString();
                this.TBPhone.Text = ds.Tables[0].Rows[0][2].ToString();

                this.TBName.Text = ds.Tables[0].Rows[0][1].ToString();
                this.TBMajor.Text=ds.Tables[0].Rows[0][10].ToString();
                this.TBidCard.Text = ds.Tables[0].Rows[0][11].ToString();
                this.TBNote.Text = ds.Tables[0].Rows[0][13].ToString();
                this.label_hidden_name.Text = ds.Tables[0].Rows[0][14].ToString() ;
            }
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            string office_person = this.TBPerson.Text.Trim();
            string office_address = this.TBAddress.Text.Trim();
            string office_phone = this.TBPhone.Text.Trim();
            string office_name = this.TBName.Text.Trim();
            string office_major = this.TBMajor.Text.Trim().Replace('，',',');
            string office_idCard = this.TBidCard.Text.Trim().Replace('，', ',');
            string office_note = this.TBNote.Text.Trim();
            string office_file = null;
            if (FileUpload1.HasFile)
            {

                string save_path = Server.MapPath("~/photo/");
                if (!System.IO.Directory.Exists(save_path))
                {
                    System.IO.Directory.CreateDirectory(save_path);
                }

                save_path +=   DateTime.Now.ToFileTimeUtc()+this.FileUpload1.FileName;

                this.FileUpload1.SaveAs(save_path);
                office_file =  DateTime.Now.ToFileTimeUtc()+this.FileUpload1.FileName ;
            }
            else
            {
                office_file = this.label_hidden_name.Text;
 
            }
          


            string department_id = Request.QueryString["id"];

            if (Request.QueryString["action"] != null & Request.QueryString["action"] == "edit")
            {
                Department.UpdateOfficeInfo(office_name, office_address, office_phone, department_id, office_person, office_major, office_idCard, office_note, office_file,Convert.ToInt32(Request.QueryString["office_id"]));

            }
            else
            {
                Department.AddOfficeInfo(office_name, office_address, office_phone, department_id, office_person, office_major, office_idCard, office_note, office_file);

            }

            

            
            Response.Write("<script>alert('添加成功！');window.location.href= 'department_office_info.aspx?id=" + Request.QueryString["id"] + "';</script>");
        }
        else
        {
            Response.Write("<script>alert('添加失败！')</script>");
        }


    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.location.href= 'department_office_info.aspx?id=" + Request.QueryString["id"] + "';</script>");
    }
}