using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_uni_contact_UC_UniEditor : System.Web.UI.UserControl
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
        if (Request.QueryString["action"] != null)
        {
            string action = Request.QueryString["action"];
            if (action == "edit")
            {//edit
                try
                {
                    int uni_id = 0;
                    uni_id = Convert.ToInt32(Request.QueryString["id"]);
                    DataSet ds = UniContact.GetUniDetail(uni_id);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        TextBoxName.Text = ds.Tables[0].Rows[0]["uni_name"].ToString();
                        TextBoxTel.Text = ds.Tables[0].Rows[0]["uni_tel"].ToString();
                        TextBoxDetail.Text = ds.Tables[0].Rows[0]["uni_note"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('获取学校信息失败！')</script>");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('获取学校信息失败！')</script>");
                }
            }
            else
            {//add
            }
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        int uni_id = Convert.ToInt32(Request.QueryString["id"]);
        if (UniContact.EditUni(uni_id, TextBoxName.Text, TextBoxTel.Text, TextBoxDetail.Text))
        {
            Response.Write("<script>alert('修改成功！');window.location.href= 'contact_uni_detail.aspx?uni_id=" + uni_id + "';</script>");
        }
        else
        {
            Response.Write("<script>alert('修改失败！')</script>");
        }
    }
}