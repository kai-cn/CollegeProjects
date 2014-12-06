using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_finance_UC_FinanceStat : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }
    protected void BindData()
    {

        if (Request.QueryString["type"] == null)
        {
            InitTime();
            InitSearchList();
            this.GVList.Columns[1].Visible = true;
            this.ButtonSubmit.Visible = false;
            return;
        }
        try
        {
            this.panel1.Visible = false;
            if (Request.QueryString["type"] != null)
            {
                int type = Convert.ToInt32(Request.QueryString["type"]);
                InitSearchList(type);
            }
            
        }
        catch (Exception ex)
        {
 
        }

        btn_ok_Click(null, null);


        
        

    }

    protected void BindData(string name)
    {

        if (Request.QueryString["merchant_name"] != null)
        {
            try
            {
                int merchant_id = Convert.ToInt32(Request.QueryString["merchant_id"]);
                //int year = Convert.ToInt32(Request.QueryString["year"]);
                //int month = Convert.ToInt32(Request.QueryString["month"]);
                int type = Convert.ToInt32(Request.QueryString["type"]);
                DataSet ds = Finance.GetFinanceStat(merchant_id, type);
                //DataSet ds = Finance.GetFinanceStat(merchant_id, year, month, type);
                string merchant_name = Finance.GetMerchantName(merchant_id);
                // string smonth =  (month < 10) ? ("0" + month) : (month.ToString());
                // LabelTitle.Text = merchant_name + "  " + year + "-" + smonth;
                LabelAll.Text = ds.Tables[0].Rows[0][0].ToString();
                TBYBX.Text = ds.Tables[0].Rows[0][1].ToString();
                TBWBX.Text = ds.Tables[0].Rows[0][2].ToString();
                ShowGV();
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
            //try
            //{
            //    DataSet ds=Finance.GetFinanceStat(
            //}
            //catch (Exception ex)
            //{
 
            //}
        }
    }


    protected void ShowGV()
    {
        try
        {
            string merchant_name = this.dropDownList1.SelectedItem.Text;
            int type = Convert.ToInt32(Request.QueryString["type"]);
            DataSet ds = null;
            if (merchant_name == "全部")
            {
                if (this.panel1.Visible)
                    ds = Finance.GetFinanceListByTime(Convert.ToInt32(this.ddl_year.SelectedItem.Text), Convert.ToInt32(this.ddl_month.SelectedItem.Text));
                else
                    ds = Finance.GetFinanceList(type);
            }
            else
            {
                int merchant_id = Finance.GetMerchantID(merchant_name);

                if (this.panel1.Visible)
                    ds = Finance.GetFinanceList(merchant_id, Convert.ToInt32(this.ddl_year.SelectedItem.Text), Convert.ToInt32(this.ddl_month.SelectedItem.Text));
                else
                    ds = Finance.GetFinanceList(merchant_id, type);
            }
            GVList.DataSource = ds;
            GVList.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void GVList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVList.PageIndex = e.NewPageIndex;
        ShowGV();
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
          
            Response.Redirect("~/admin/finance/add_finance_detail.aspx?action=add&merchant_name="+this.dropDownList1.SelectedItem.Text+"&type=" + Request.QueryString["type"]);
            //int merchant_id = Convert.ToInt32(Request.QueryString["merchant_id"]);
            //int year = Convert.ToInt32(Request.QueryString["year"]);
            //int month = Convert.ToInt32(Request.QueryString["month"]);
            //int type = Convert.ToInt32(Request.QueryString["type"]);
            //if (Finance.SetYBX(type, merchant_id, year, month, Convert.ToDouble(TBYBX.Text.Trim())))
            //{
            //    Response.Write("<script>alert('修改成功！');window.location.href= 'month_list.aspx?type=" + type + "&merchant_id=" + merchant_id + "';</script>");
            //}
        }
        catch (Exception ex)
        {
        }
    }

    protected void btn_ok_Click(object sender, EventArgs e)
    {
        
        
        
        try
        {
            string merchant_name = this.dropDownList1.SelectedItem.Text;
            int type = Convert.ToInt32(Request.QueryString["type"]);
            DataSet ds = null;
            if (merchant_name == "全部")
            {
                if (this.panel1.Visible)
                    ds = Finance.GetFinanceListByTime(Convert.ToInt32(this.ddl_year.SelectedItem.Text), Convert.ToInt32(this.ddl_month.SelectedItem.Text));
                else
                ds = Finance.GetFinanceList(type);
            }
            else
            {
                int merchant_id = Finance.GetMerchantID(merchant_name);

                if (this.panel1.Visible)
                    ds = Finance.GetFinanceList(merchant_id, Convert.ToInt32(this.ddl_year.SelectedItem.Text), Convert.ToInt32(this.ddl_month.SelectedItem.Text));
                else
                    ds = Finance.GetFinanceList(merchant_id, type);
            }

            int all = 0, ybx = 0, wbx = 0;


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                all += Convert.ToInt32(dr[7]);

                if (Convert.ToInt32(dr[9]) == 0)
                    wbx += Convert.ToInt32(dr[7]);

            }

            ybx = all - wbx;


            LabelAll.Text = all.ToString();
            TBYBX.Text = ybx.ToString();
            TBWBX.Text = wbx.ToString();
            ShowGV();
        }
        catch (Exception ex)
        {
        }
    }

    protected void InitSearchList()
    {
        DataSet ds = Finance.GetMerchantList();

        BindDropDownList(ds, this.dropDownList1);
    }

    protected void InitSearchList(int type)
    {
        DataSet ds = Finance.GetMerchantList(type);
        BindDropDownList(ds, this.dropDownList1);
    }

    protected void BindDropDownList(DataSet ds, DropDownList ddl)
    {
        try
        {
            ddl.Items.Add(new ListItem("全部", "all"));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
                ddl.Items.Add(new ListItem(dr[0].ToString()));
            }
            
           
            


        }
        catch (Exception)
        {
 
        }
        
    }

    protected void InitTime()
    {
        try
        {
            string beginTime = Finance.GetFinanceMinTime().Tables[0].Rows[0][0].ToString();
            string endTime = Finance.GetFinanceMaxTime().Tables[0].Rows[0][0].ToString();


            string[] begin = beginTime.Split('/');
            string[] end = endTime.Split('/');

            int beginYear = Convert.ToInt32(begin[0]);
            int endYear = Convert.ToInt32(end[0]);

            for (int i = beginYear; i <= endYear; i++)
            {
                this.ddl_year.Items.Add(new ListItem(i.ToString()));
            }

            for (int i = 1; i <= 12; i++)
            {
                this.ddl_month.Items.Add(new ListItem(i.ToString()));
            }
        }
        catch (Exception ex)
        {
 
        }
    }
    protected void GVList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            string finance_id = e.CommandArgument.ToString();

            if (Finance.DeleteFinace(finance_id))
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">" + "alert('删除成功')" + "</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
            }

            BindData();
        }
        else
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/admin/finance/add_finance_detail.aspx?action=edit&id="+e.CommandArgument.ToString()+"&merchant_name=" + this.dropDownList1.SelectedItem.Text + "&type=" + Request.QueryString["type"]);
            }
                
        }

    }
    protected void GVList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
