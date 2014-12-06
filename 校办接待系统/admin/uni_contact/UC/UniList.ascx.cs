using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_uni_contact_UC_UniList : System.Web.UI.UserControl
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
            DataSet ds;

            if (Request.QueryString["type"] == null)
                ds = UniContact.GetUniList(Convert.ToInt32(Request.QueryString["province_id"]));
            else
                ds = UniContact.GetBasicUniList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('获取学校数据失败！')</script>");

            }
        }
        catch (Exception ex)
        {
        }
    }
}