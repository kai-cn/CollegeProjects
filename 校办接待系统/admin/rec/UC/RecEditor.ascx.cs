using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_rec_UC_RecEditor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["action"] != null && Request.QueryString["action"] == "edit")
            {
                try
                {
                    int visit_id = Convert.ToInt32(Request.QueryString["id"]);
                    DataSet ds = Rec.GetRec(visit_id);
                    Calendar1.Text = ds.Tables[0].Rows[0]["visit_date"].ToString();
                    TBUnit.Text = ds.Tables[0].Rows[0]["visitor_unit"].ToString();
                    TBNum.Text = ds.Tables[0].Rows[0]["visitor_num"].ToString();
                    TBName.Text = ds.Tables[0].Rows[0]["visitor_name"].ToString();
                    TBPos.Text = ds.Tables[0].Rows[0]["visitor_pos"].ToString();
                    TBContent.Text = ds.Tables[0].Rows[0]["visit_content"].ToString();
                    TBArrDepTime.Text = ds.Tables[0].Rows[0]["visitor_arr_dep_time"].ToString();
                    TBCar.Text = ds.Tables[0].Rows[0]["visitor_car_arrangement"].ToString();
                    TBAccompany.Text = ds.Tables[0].Rows[0]["visitor_accompany"].ToString();
                    TBHotel.Text = ds.Tables[0].Rows[0]["visitor_hotel"].ToString();
                    TBRoom.Text = ds.Tables[0].Rows[0]["visitor_room"].ToString();
                    TBDinner.Text = ds.Tables[0].Rows[0]["visitor_dinner"].ToString();
                    TBFirstOpinion.Text = ds.Tables[0].Rows[0]["visitor_first_opinion"].ToString();
                    CBMaterial.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["visitor_arr_material"]);
                    CBPub.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["visitor_arr_pub"]);
                    CBPhoto.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["visitor_arr_photo"]);
                    CBGuard.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["visitor_arr_guard"]);
                    CBVideo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["visitor_arr_video"]);
                    CBCir.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["visitor_arr_cir"]);
                    CBLogo.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["visitor_arr_welcome_logo"]);
                    CBMeetingRoom.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["visitor_arr_meeting_room"]);
                    TBFinalOpinion.Text = ds.Tables[0].Rows[0]["visitor_final_opinion"].ToString();
                    TBNote.Text = ds.Tables[0].Rows[0]["visitor_note"].ToString();
                    
                    
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null)
        {
            try
            {
                int type = Convert.ToInt32(Request.QueryString["type"]);
                DateTime dt = DateTime.Parse(Calendar1.Text);
                string unit = TBUnit.Text.Trim();
                string num = TBNum.Text.Trim();
                string name = TBName.Text.Trim();
                string pos = TBPos.Text.Trim();
                string content = TBContent.Text.Trim();
                string arr_dep_time = TBArrDepTime.Text.Trim();
                string car_arrangement = TBCar.Text.Trim();
                string accompany = TBAccompany.Text.Trim();
                string hotel = TBHotel.Text.Trim();
                string room = TBRoom.Text.Trim();
                string dinner = TBDinner.Text.Trim();
                string first_opinion = TBFirstOpinion.Text.Trim();
                bool material = CBMaterial.Checked;
                bool pub = CBPub.Checked;
                bool photo = CBPhoto.Checked;
                bool guard = CBGuard.Checked;
                bool video = CBVideo.Checked;
                bool cir = CBCir.Checked;
                bool welcome_logo = CBLogo.Checked;
                bool meeting_room = CBMeetingRoom.Checked;
                string final_opinion = TBFinalOpinion.Text.Trim();
                string note = TBNote.Text.Trim();
                string action = Request.QueryString["action"];
                if (action == "add")
                {//add
                    if (Rec.AddRec(type, dt, unit, num, name, pos, content, arr_dep_time, car_arrangement, accompany, hotel, room, dinner, first_opinion, material, pub, photo, guard, video, cir, welcome_logo, meeting_room, final_opinion, note,"",""))
                    {
                        Response.Write("<script>alert('添加成功！');window.location.href= 'rec_list.aspx?type=" + type + "';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败！')</script>");
                    }
                }
                else
                {//edit
                    if (Rec.EditRec(Convert.ToInt32(Request.QueryString["id"]), dt, unit, num, name, pos, content, arr_dep_time, car_arrangement, accompany, hotel, room, dinner, first_opinion, material, pub, photo, guard, video, cir, welcome_logo, meeting_room, final_opinion, note,"",""))
                    {
                        Response.Write("<script>alert('修改成功！');window.location.href= 'rec_list.aspx?type=" + Rec.GetRecType(Convert.ToInt32(Request.QueryString["id"])) + "';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败！')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}