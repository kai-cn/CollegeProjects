using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using LLQ;

/// <summary>
/// Summary description for Leader
/// </summary>
public class Leader
{
	public Leader()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataSet GetLeaderList(int type)
    {
        string selcmd = "select * from leader_personal_info where leader_type=" + type.ToString();
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }
    public static bool AddLeader(string name, int type, string detail,string photo,string card)
    {
        string inscmd = "insert into leader_personal_info(leader_name,leader_type,leader_info,leader_photo,leader_card) values('" + name.Trim() + "'," + type + ",'" + detail + "','"+photo+"','"+card+"')";

        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(inscmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }
    public static bool EditLeader(int id, string name, int type, string detail,string photo,string card)
    {
        string inscmd = "update leader_personal_info set leader_name='" + name.Trim() + "',leader_type=" + type + ",leader_info='" + detail + "', leader_photo='"+photo+"', leader_card='"+card+"' where leader_id=" + id.ToString();
        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(inscmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }
    public static DataSet GetLeader(int id)
    {
        string selcmd = "select * from leader_personal_info,leader_type_info where leader_type=leader_type_index and leader_id =" + id.ToString();
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetLeader(string leader_name)
    {
        string selCmd = "select * from leader_personal_info,leader_type_info  where leader_type=leader_type_index and leader_name like '%" + leader_name + "%'";
        DataBase db = new DataBase();
        return db.GetDataSet(selCmd);
    }
}