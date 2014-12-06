using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {

        
        //客户端禁用 Cookies ，无法判断验证码
        if (Request.Cookies["CheckCode"] == null)
        {
            Response.Write("<Script>alert('您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统!')</Script>");
            return;
        }

        //验证码输入不正确
        else if (String.Compare(HttpContext.Current.Request.Cookies["CheckCode"].Value, TextBoxValidateCode.Text, true) != 0)
        {
            HttpContext.Current.Response.Write("<Script>alert('验证码错误，请输入正确的验证码!')</Script>");
            return;
        }

        if (Admin.HasAdmin(TextBoxUserName.Text, TextBoxPwd.Text))
        {
            FormsAuthentication.SetAuthCookie(TextBoxUserName.Text, false);
            FormsAuthentication.RedirectFromLoginPage(TextBoxUserName.Text, false);
        }
        else
        {
            Response.Write("<script>alert('用户名或密码错误，请重新输入！')</script>");
            TextBoxUserName.Text = "";
            TextBoxPwd.Text = "";
            TextBoxValidateCode.Text = "";
        }
    }
}