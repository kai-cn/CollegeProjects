using System;
using System.Collections.Generic;
using System.Web;

using System.Data;
using LLQ;

/// <summary>
///Department 的摘要说明
/// </summary>
public class Department
{
	public Department()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static DataSet GetDepartmentBasicInfo(int type,string name)
    {
        string selectSql = "select * from department_basic_info where department_type=" + type+" and department_name like '"+name+"%'";
        DataBase ds = new DataBase();
        return ds.GetDataSet(selectSql);
    }

    public static DataSet GetDepartmentBasicInfo(int department_id)
    {
        string selectSql = "select * from department_basic_info where department_id="+department_id;
        DataBase ds = new DataBase();
        return ds.GetDataSet(selectSql);
    }

    public static DataSet GetDepartmentBasicInfo(string name)
    {
        string selectSql = "select * from department_basic_info where department_name like '"+name+"%'";
        DataBase ds = new DataBase();
        return ds.GetDataSet(selectSql);
    }

    public static DataSet GetOfficeInfo(int office_id)
    {
        string selectSql = "select * from department_office_info where office_id=" + office_id;
        DataBase ds = new DataBase();
        return ds.GetDataSet(selectSql);
    }

    public static DataSet GetEmptyDepartmentBasicRow()
    {
        string selectSql = "select * from department_basic_info";
        DataBase db = new DataBase();
        DataSet ds = db.GetDataSet(selectSql);
        if(ds.Tables.Count>0)
        {
            DataRow dr = ds.Tables[0].NewRow();
            ds.Clear();
            ds.Tables[0].Rows.Add(dr);
        }
        
        return ds;
    }

    public static DataSet GetDepartmentOfficeByDepartmentId(int departmentId)
    {
        string selectSql = "select * from department_office_info where department_id="+departmentId;
        DataBase ds = new DataBase();
        return ds.GetDataSet(selectSql);
    }

    public static bool AddDepartmentInfo(string department_name, string department_address, string department_fax, string department_type)
    {
        bool result = false;
        string insertSql="insert into department_basic_info(department_name,department_address,department_fax,department_type) values('{0}','{1}','{2}',{3})";

        insertSql = string.Format(insertSql, department_name, department_address, department_fax, department_type);

        DataBase ds = new DataBase();
        if (ds.ExecuteNonQuery(insertSql) > 0)
        {
            result = true;
        }

        return result;
    }

    public static bool AddOfficeInfo(string office_name, string office_address, string office_phone,string department_id,string office_person_name,string office_major,string office_idcard,string office_note,string office_file)
    {
        bool result = false;
        string insertSql = "insert into department_office_info(office_name,office_address,office_phone,department_id,office_person_name,office_major,office_idcard,office_note,office_file) values('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}')";

        insertSql = string.Format(insertSql, office_name, office_address, office_phone, department_id,office_person_name,office_major,office_idcard,office_note,office_file);

        DataBase ds = new DataBase();
        if (ds.ExecuteNonQuery(insertSql)>0)
        {
            result = true;
        }

        return result;
    }

    public static bool UpdateOfficeInfo(string office_name, string office_address, string office_phone, string department_id, string office_person_name, string office_major, string office_idcard, string office_note, string office_file,int office_id)
    {
        bool result = false;

        string updateSql = "update department_office_info set office_name='" + office_name + "',office_address='" + office_address + "',office_phone='" + office_phone + "',department_id=" + department_id + ",office_person_name='" + office_person_name + "',office_major='" + office_major +
            "',office_idcard='" + office_idcard + "',office_note='" + office_note + "',office_file='" + office_file + "' where office_id="+office_id;

        
        DataBase ds = new DataBase();
        if (ds.ExecuteNonQuery(updateSql) > 0)
        {
            result = true;
        }

        return result;
    }

    public static bool DeleteDepartment(string department_id)
    {
        bool result = false;
        string deleteSql1="delete from department_office_info where department_id="+department_id;
        string deleteSql = "delete from department_basic_info where department_id=" + department_id;

        DataBase ds = new DataBase();


        ds.ExecuteNonQuery(deleteSql1);
        
        result= ds.ExecuteNonQuery(deleteSql) >0? true:false;

        return result;
    }


    public static bool UpdateDepartmentInfo(string department_name, string department_address, string department_fax, string department_type,int department_id)
    {
        bool result = false;

        string updateSql="update department_basic_info set department_name='"+department_name+"', department_address='"+department_address+"',department_fax='"+department_fax+"', department_type="+department_type+" where department_id="+department_id;
    
        DataBase ds = new DataBase();
        if (ds.ExecuteNonQuery(updateSql) > 0)
        {
            result = true;
        }

        return result;
    }

    public static bool DeleteOffice(string Office_id)
    {
        bool result = false;
        string deleteSql = "delete from department_office_info where office_id=" + Office_id;
        
        DataBase ds = new DataBase();


        result = ds.ExecuteNonQuery(deleteSql) > 0 ? true : false;

        return result;
    }

    public static DataSet GetDepartmentOfficeInfo(string search_type, string text)
    {
        string selectSql = "select * from department_office_info where "+search_type+" like '%"+text+"%'";
        DataBase ds = new DataBase();
        return ds.GetDataSet(selectSql);
    }

}