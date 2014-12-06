using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UC_leader_editor : System.Web.UI.UserControl
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
            if (Request.QueryString["action"] == "add")
            {
                TextBoxDetail.Text = "性别：<br><br>单位：<br><br>职务：<br><br>简介：<br><br>备注：<br><br>";
                TextBoxDetail.Text = TextBoxDetail.Text.Replace("<br>", Environment.NewLine);
            }
            else
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        DataSet ds = Leader.GetLeader(id);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            TextBoxName.Text = ds.Tables[0].Rows[0]["leader_name"].ToString();
                            int type = Convert.ToInt32(ds.Tables[0].Rows[0]["leader_type"]);
                            DDLType.SelectedValue = type.ToString();
                            TextBoxDetail.Text = ds.Tables[0].Rows[0]["leader_info"].ToString();
                            TextBoxDetail.Text = TextBoxDetail.Text.Replace("<br>", Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        
        
        if (TextBoxName.Text.Trim() == "")
        {
            Response.Write("<script>alert('领导姓名不能为空！')</script>");
            return;
        }
        List<string> fileName = CheckUpLoad();
        if (Request.QueryString["action"] != null)
        {
            string action = Request.QueryString["action"].ToString();
            string name = TextBoxName.Text;
            int type = Convert.ToInt32(DDLType.SelectedValue);
            string detail = TextBoxDetail.Text;
            detail = detail.Replace(Environment.NewLine, "<br>");
            if (action == "add")
            {//add
                if (Leader.AddLeader(name, type, detail,fileName[0],fileName[1]))
                {
                    Response.Write("<script>alert('添加成功！');window.location.href= 'leader_list.aspx?type=" + type + "';</script>");
                
                }
                else
                {
                    Response.Write("<script>alert('添加失败！')</script>");
                }
            }
            else
            {//edit
                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (Leader.EditLeader(id, name, type, detail,fileName[0],fileName[1]))
                {
                    Response.Write("<script>alert('修改成功！');window.location.href= 'leader_list.aspx?type=" + type + "';</script>");
                 
                }
                else
                {
                    Response.Write("<script>alert('修改失败！')</script>");
                }


            }

            
                
        }
       
    }
    protected List<string> CheckUpLoad()
    {
        HttpFileCollection files = Request.Files;
        List<string> fileNames = new List<string>();

        for (int i = 0; i < files.Count; i++)
        {
            HttpPostedFile post = files[i];
            try
            {
                if (post.ContentLength > 0)
                {
                    string filePath = post.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("."));
                    fileName = DateTime.Now.ToFileTime().ToString() + fileName;
                    string serverPath = Server.MapPath("~/photo/")+ fileName;
                    fileNames.Add("/photo/"+fileName);
                    post.SaveAs(serverPath);
                    this.lb_info.Text = "上传成功!";
                }
            }
            catch (Exception ex)
            {
                this.lb_info.Text = "上传发生错误! 原因:+" + ex.Message.ToString();
            }

            
        }
        return fileNames;
    }
}