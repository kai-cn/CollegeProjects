using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_uni_contact_UC_UniDetail : System.Web.UI.UserControl
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
        if (Request.QueryString["uni_id"] != null)
        {
            this.txt_id.Visible = false;
            this.btn_ok.Visible = false;
            int uni_id = 0;
            try
            {
                uni_id = Convert.ToInt32(Request.QueryString["uni_id"]);
                DataSet ds = UniContact.GetUniDetail(uni_id);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('暂无此学校信息！')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                Response.End();
            }
        }

        if (Request.QueryString["uni_name"] != null)
        {
            string uni_name = Request.QueryString["uni_name"];
            try
            {
                
                DataSet ds = UniContact.GetUniDetail(uni_name);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('暂无此学校信息！')</script>");
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
            Response.Redirect("contact_uni_detail.aspx?uni_name=" + txt_id.Text);
        }
    }
}