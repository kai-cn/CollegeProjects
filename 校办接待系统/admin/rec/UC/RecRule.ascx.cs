using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

public partial class admin_rec_UC_RecRule : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void LBAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["src"] != null)
        {
            string fileName = Request.QueryString["src"];
            fileName = fileName.Split('/')[2];
            fileName = fileName.Split('.')[0]+".doc";
            DownLoad(fileName);
        }
    }

    protected void DownLoad(string fileName)
    {
        try
        {
            string filePath = Server.MapPath("~/download/") + fileName;

            FileInfo fileInfo = new FileInfo(filePath);

            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();

            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        { 

        }
    }
}