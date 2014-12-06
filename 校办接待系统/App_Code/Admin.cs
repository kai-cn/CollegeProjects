using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using LLQ;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{
	public Admin()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool HasAdmin(string name)
    {
        string selcmd = "select * from admin_info where admin_name = '" + name + "'";
        DataBase db = new DataBase();
        SqlDataReader dr = db.GetSqlDataReader(selcmd);

        if (dr != null && dr.HasRows)
        {
            db.Close();
            return true;
        }
        else
        {
            db.Close();
            return false;
        }
    }

    public static bool HasAdmin(string name, string pwd)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        string pwdMD5 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(pwd)));
        pwdMD5 = pwdMD5.Replace("-", "");
        string selcmd = "select * from admin_info where admin_name = '" + name + "' and admin_pwd = '" + pwdMD5 + "'";
        DataBase db = new DataBase();
        SqlDataReader dr = db.GetSqlDataReader(selcmd);

        if (dr != null && dr.HasRows)
        {
//            UpdateLoginInfo(name, pwd);
            db.Close();
            return true;
        }
        else
        {
            db.Close();
            return false;
        }
    }
    public static bool AddAdmin(string name, string pwd)
    {
        if (HasAdmin(name))
            return false;

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        string pwdMD5 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(pwd)));
        pwdMD5 = pwdMD5.Replace("-", "");
        string inscmd = "insert into admin_info(admin_name,admin_pwd) values('" + name + "','" + pwdMD5 + "')";
        DataBase db = new DataBase();
        if (db.ExecuteNonQuery(inscmd) == 1)
        {
            db.Close();
            return true;
        }
        else
        {
            db.Close();
            return false;
        }
    }
}