using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_finance_UC_MonthList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }
    protected void BindData()
    {
        int type = Convert.ToInt32(Request.QueryString["type"]);
        int merchant_id = Convert.ToInt32(Request.QueryString["merchant_id"]);
        DataSet ds = Finance.GetMonthList(merchant_id, type);
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }
}