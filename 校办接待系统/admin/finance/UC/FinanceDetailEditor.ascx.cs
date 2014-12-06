using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_finance_UC_FinanceDetailEditor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.TBGiftName.Text = Request.QueryString["merchant_name"];
            redirect();
        }
    }

    protected void redirect()
    {
        
        if (Request.QueryString["action"] == "edit")
        {
            DataSet ds = Finance.GetFinanceBasicInfoById(Request.QueryString["id"]);
            TBTime.Text= ds.Tables[0].Rows[0]["finance_occur_time"].ToString();
            TBGiftName.Text = ds.Tables[0].Rows[0]["finance_good_name"].ToString();
            TBGiftPrice.Text = ds.Tables[0].Rows[0]["finance_good_price"].ToString();
            TBDetail.Text = ds.Tables[0].Rows[0]["finance_people"].ToString();


            if(ds.Tables[0].Rows[0]["finance_ybx"].ToString()=="1")
            {
                check1.Checked = true;
            }

           
        }

        
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        
        DateTime dt = DateTime.Parse(TBTime.Text.Trim());
        string good_name = this.TBGiftName.Text.Trim();
        string detail = this.TBDetail.Text.Trim();
        double good_price = Convert.ToDouble(TBGiftPrice.Text.Trim());
        string merchant_name = this.TBGiftName.Text;
        int type=Convert.ToInt32(Request.QueryString["type"]);
        int finance_ybx = 0;

        if (this.check1.Checked)
            finance_ybx = 1;

        if (Request.QueryString["action"] == "add")
        {
            if (merchant_name.Trim() != "")
            {
                Finance.AddMerchant(merchant_name, type);
                int merchant_id = Finance.GetMerchantID(merchant_name);
                if (Finance.AddFinance(Convert.ToInt32(Request.QueryString["type"]), merchant_id, dt, good_name, good_price, detail, finance_ybx))
                {
                    Response.Write("<script>alert('添加成功！');window.location.href= 'finance_stat.aspx?type=" + Request.QueryString["type"] + "';</script>");
                }
                else
                {
                    Response.Write("<script>alert('添加失败！')</script>");
                }
            }
        }
        else
        {
             if (merchant_name.Trim() != "")
            {
                 int merchant_id = Finance.GetMerchantID(merchant_name);
                 if(Finance.UpdateFinance(Convert.ToInt32(Request.QueryString["type"]),merchant_id,dt,good_name,finance_ybx,good_price,detail,Request.QueryString["id"]))
                 {
                    Response.Write("<script>alert('修改成功！');window.location.href= 'finance_stat.aspx?type=" + Request.QueryString["type"] + "';</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败！')</script>");
                }
            }
            
        }

    }
   
}