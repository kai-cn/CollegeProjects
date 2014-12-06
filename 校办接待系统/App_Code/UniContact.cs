using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using LLQ;

/// <summary>
/// Summary description for UniContact
/// </summary>
public class UniContact
{
	public UniContact()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataSet GetProvinceList()
    {
        string selcmd = "select * from province_info order by province_id";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }
    public static DataSet GetUniList(int prov_id)
    {
        string selcmd = "select * from unicontact_info where uni_prov_id=" + prov_id + " order by uni_id";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }
    public static DataSet GetBasicUniList()
    {
        string selcmd = "select * from unicontact_info where uni_is_basic=1 order by uni_id";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }
    public static DataSet GetUniDetail(int uni_id)
    {
        string selcmd = "select * from unicontact_info where uni_id=" + uni_id;
//        HttpContext.Current.Response.Write("<script>alert('" + selcmd + "')</script>");
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetUniDetail(string uni_name)
    {
        string selCmd = "select * from unicontact_info where uni_name like '%" + uni_name + "%'";
        DataBase db = new DataBase();
        return db.GetDataSet(selCmd);
    }

    public static bool EditUni(int id, string name, string tel, string note)
    {
        string updcmd = "update unicontact_info set uni_name='" + name + "',uni_tel='" + tel + "',uni_note='" + note + "' where uni_id=" + id;
        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(updcmd);
        db.Close();
        if (res == 1)
        {
            return true;
        }
        else
            return false;
    }

}