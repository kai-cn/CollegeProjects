using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using LLQ;

/// <summary>
/// Summary description for Rec
/// </summary>
public class Rec
{
	public Rec()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataSet GetRecList(int type)
    {
        string selcmd = "select *,CONVERT(varchar(100),visit_info.visit_date,23) as visit_new_date from visit_info where visit_type=" + type + " order by visit_date desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetRecList(string name)
    {
        string selcmd = "select *,CONVERT(varchar(100),visit_info.visit_date,23) as visit_new_date from visit_info where  visitor_unit like '%" + name + "%'";
        selcmd += " union select *,CONVERT(varchar(100),visit_info.visit_date,23) as visit_new_date from visit_info where  visitor_name like '%" + name + "%' order by visit_date desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetRecList(int type, string name)
    {
        string selcmd = "select *,CONVERT(varchar(100),visit_info.visit_date,23) as visit_new_date from visit_info where visit_type=" + type +" and  visitor_unit ='" + name + "' ";
        selcmd += " union select *,CONVERT(varchar(100),visit_info.visit_date,23) as visit_new_date from visit_info where  visit_type=" + type + " and   visitor_name='" + name + "' order by visit_date desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static int GetRecType(int id)
    {
        string selcmd = "select visit_type from visit_info where visit_id=" + id;
        DataBase db = new DataBase();
        SqlDataReader dr = db.GetSqlDataReader(selcmd);
        if (dr != null && dr.HasRows)
        {
            dr.Read();
            int res = Convert.ToInt32(dr.GetValue(0));
            dr.Close();
            return res;
        }
        return 0;// db.GetDataSet(selcmd);
    }
    public static DataSet GetRec(int id)
    {
        string selcmd = "select * from visit_info where visit_id=" + id;
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    

    public static bool AddRec(int type, DateTime dt, string unit, string num, string name, string pos, string content, string arr_dep_time, string car_arrangement, string accompany, string hotel, string room, string dinner, string first_opinion, bool material, bool pub, bool photo, bool guard, bool video, bool cir, bool welcome_logo, bool meeting_room, string final_opinion, string note)
    {
        string inscmd = "insert into visit_info(visit_type,visit_date,visitor_unit,visitor_num,visitor_name,visitor_pos,visit_content,visitor_arr_dep_time,visitor_car_arrangement,visitor_accompany,visitor_hotel,visitor_room,visitor_dinner,visitor_first_opinion,visitor_arr_material,visitor_arr_pub,visitor_arr_photo,visitor_arr_guard,visitor_arr_video,visitor_arr_cir,visitor_arr_welcome_logo,visitor_arr_meeting_room,visitor_final_opinion,visitor_note) values("
                        + type + ",'" + dt.ToShortDateString() + "','" + unit + "','" + num + "','" + name + "','" + pos + "','" + content + "','" + arr_dep_time + "','" + car_arrangement + "','" + accompany + "','" + hotel + "','" + room + "','" + dinner + "','" + first_opinion + "',";
        if (material)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (pub)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (photo)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (guard)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (video)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (cir)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (welcome_logo)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (meeting_room)
            inscmd += "1,'";
        else
            inscmd += "0,'";
        inscmd = inscmd + final_opinion + "','" + note + "')";

        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(inscmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }

    public static bool AddRec(int type, DateTime dt, string unit, string num, string name, string pos, string content, string arr_dep_time, string car_arrangement, string accompany, string hotel, string room, string dinner, string first_opinion, bool material, bool pub, bool photo, bool guard, bool video, bool cir, bool welcome_logo, bool meeting_room, string final_opinion, string note,string major,string filePath)
    {
        string inscmd = "insert into visit_info(visit_type,visit_date,visitor_unit,visitor_num,visitor_name,visitor_pos,visit_content,visitor_arr_dep_time,visitor_car_arrangement,visitor_accompany,visitor_hotel,visitor_room,visitor_dinner,visitor_first_opinion,visitor_arr_material,visitor_arr_pub,visitor_arr_photo,visitor_arr_guard,visitor_arr_video,visitor_arr_cir,visitor_arr_welcome_logo,visitor_arr_meeting_room,visitor_final_opinion,visitor_note,visit_major,visit_file) values("
                        + type + ",'" + dt.ToShortDateString() + "','" + unit + "','" + num + "','" + name + "','" + pos + "','" + content + "','" + arr_dep_time + "','" + car_arrangement + "','" + accompany + "','" + hotel + "','" + room + "','" + dinner + "','" + first_opinion + "',";
        if (material)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (pub)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (photo)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (guard)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (video)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (cir)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (welcome_logo)
            inscmd += "1,";
        else
            inscmd += "0,";
        if (meeting_room)
            inscmd += "1,'";
        else
            inscmd += "0,'";
        inscmd = inscmd + final_opinion + "','" + note +"','" +major+"','"+filePath+ "')";

        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(inscmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }
    
    
    
    public static bool EditRec(int id, DateTime dt, string unit, string num, string name, string pos, string content, string arr_dep_time, string car_arrangement, string accompany, string hotel, string room, string dinner, string first_opinion, bool material, bool pub, bool photo, bool guard, bool video, bool cir, bool welcome_logo, bool meeting_room, string final_opinion, string note)
    {
        string updcmd = "update visit_info set visit_date='" + dt.ToShortDateString() + "',visitor_unit='" + unit + "',visitor_num='" + num + "',visitor_name='" + name + "',visitor_pos='" + pos + "',visit_content='" + content + "',visitor_arr_dep_time='" + arr_dep_time + "',visitor_car_arrangement='" + car_arrangement + "',visitor_accompany='" + accompany + "',visitor_hotel='" + hotel + "',visitor_room='" + room + "',visitor_dinner='" + dinner + "',visitor_first_opinion='" + first_opinion + "',";
        if (material)
            updcmd += "visitor_arr_material=1,";
        else
            updcmd += "visitor_arr_material=0,";
        if (pub)
            updcmd += "visitor_arr_pub=1,";
        else
            updcmd += "visitor_arr_pub=0,";
        if (photo)
            updcmd += "visitor_arr_photo=1,";
        else
            updcmd += "visitor_arr_photo=0,";
        if (guard)
            updcmd += "visitor_arr_guard=1,";
        else
            updcmd += "visitor_arr_guard=0,";
        if (video)
            updcmd += "visitor_arr_video=1,";
        else
            updcmd += "visitor_arr_video=0,";
        if (cir)
            updcmd += "visitor_arr_cir=1,";
        else
            updcmd += "visitor_arr_cir=0,";
        if (welcome_logo)
            updcmd += "visitor_arr_welcome_logo=1,";
        else
            updcmd += "visitor_arr_welcome_logo=0,";
        if (meeting_room)
            updcmd += "visitor_arr_meeting_room=1,";
        else
            updcmd += "visitor_arr_meeting_room=0,";
        updcmd = updcmd + "visitor_final_opinion='" + final_opinion + "',visitor_note='" + note + "' where visit_id=" + id;

        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(updcmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }

    public static bool EditRec(int id, DateTime dt, string unit, string num, string name, string pos, string content, string arr_dep_time, string car_arrangement, string accompany, string hotel, string room, string dinner, string first_opinion, bool material, bool pub, bool photo, bool guard, bool video, bool cir, bool welcome_logo, bool meeting_room, string final_opinion, string note,string major,string filePath)
    {
        string updcmd = "update visit_info set visit_date='" + dt.ToShortDateString() + "',visitor_unit='" + unit + "',visitor_num='" + num + "',visitor_name='" + name + "',visitor_pos='" + pos + "',visit_content='" + content + "',visitor_arr_dep_time='" + arr_dep_time + "',visitor_car_arrangement='" + car_arrangement + "',visitor_accompany='" + accompany + "',visitor_hotel='" + hotel + "',visitor_room='" + room + "',visitor_dinner='" + dinner + "',visitor_first_opinion='" + first_opinion + "',";
        if (material)
            updcmd += "visitor_arr_material=1,";
        else
            updcmd += "visitor_arr_material=0,";
        if (pub)
            updcmd += "visitor_arr_pub=1,";
        else
            updcmd += "visitor_arr_pub=0,";
        if (photo)
            updcmd += "visitor_arr_photo=1,";
        else
            updcmd += "visitor_arr_photo=0,";
        if (guard)
            updcmd += "visitor_arr_guard=1,";
        else
            updcmd += "visitor_arr_guard=0,";
        if (video)
            updcmd += "visitor_arr_video=1,";
        else
            updcmd += "visitor_arr_video=0,";
        if (cir)
            updcmd += "visitor_arr_cir=1,";
        else
            updcmd += "visitor_arr_cir=0,";
        if (welcome_logo)
            updcmd += "visitor_arr_welcome_logo=1,";
        else
            updcmd += "visitor_arr_welcome_logo=0,";
        if (meeting_room)
            updcmd += "visitor_arr_meeting_room=1,";
        else
            updcmd += "visitor_arr_meeting_room=0,";
        updcmd = updcmd + "visitor_final_opinion='" + final_opinion + "',visitor_note='" + note + "',visit_major='" + major + "',visit_file='" + filePath + "' where visit_id=" + id;

        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(updcmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }

    public static bool DeleteRec(string visit_id)
    {
        string deleteCmd = "delete from dbo.visit_info where visit_id="+visit_id;

        DataBase db = new DataBase();

        int result = db.ExecuteNonQuery(deleteCmd);

        if (result > 0)
            return true;
        else
            return false;
    }

    
}