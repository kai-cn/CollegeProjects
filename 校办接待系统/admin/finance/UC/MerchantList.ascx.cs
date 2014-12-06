using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_finance_UC_merchant_list : System.Web.UI.UserControl
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
        if (Request.QueryString["type"] != null)
        {
            try
            {
                int type = Convert.ToInt32(Request.QueryString["type"]);
                DataSet ds = Finance.GetMerchantList(type);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                }
                else
                {
                    LabelNotice.Visible = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

    }

    protected void BindData(string name)
    {
        if (Request.QueryString["type"] != null)
        {
            try
            {
                DataSet ds=null;
                if (Request.QueryString["type"] != null)
                {
                    int type = Convert.ToInt32(Request.QueryString["type"]);
                    ds = Finance.GetMerchantList(type);
                    
                }
                else
                {
                   
                }
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                }
                else
                {
                    LabelNotice.Visible = true;
                  
                }
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            
        }
    }

    protected void LBAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/admin/finance/add_finance_detail.aspx?action=add&type=" + Request.QueryString["type"]);
    }

    
}