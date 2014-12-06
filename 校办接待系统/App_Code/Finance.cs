using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using LLQ;

/// <summary>
/// Summary description for Finance
/// </summary>
public class Finance
{
	public Finance()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataSet GetMerchantList(int type)
    {
        string selcmd = "select distinct merchant_name,merchant_id from merchant_info,finance_basic_info where merchant_id = finance_merchant_id and finance_type = " + type;
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }
    public static DataSet GetMerchantList()
    {
        string selcmd = "select distinct merchant_name,merchant_id from merchant_info,finance_basic_info where merchant_id = finance_merchant_id";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }
    public static DataSet GetMonthList(int merchant_id, int type)
    {
        string selcmd = "select finance_merchant_id, finance_year, finance_month, finance_type from finance_stat_info where finance_merchant_id = " + merchant_id + " and finance_type = " + type;
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }
    public static DataSet GetFinanceList(int merchant_id, int year, int month)
    {
        string selcmd = "select * from  finance_basic_info where finance_merchant_id = " + merchant_id + " and YEAR(finance_occur_time) = " + year + " and MONTH(finance_occur_time) = " + month  + " order by finance_occur_time desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetFinanceListByTime(int year, int month)
    {
        string selcmd = "select * from  finance_basic_info  where YEAR(finance_occur_time) = " + year + " and MONTH(finance_occur_time) = " + month + " order by finance_occur_time desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    

    public static DataSet GetFinanceList(int type)
    {
        string selCmd = "select * from finance_basic_info where finance_type="+type;
        DataBase db = new DataBase();
        return db.GetDataSet(selCmd);
    }

    public static bool ExsitMerchant(string merchant_name)
    {
        string sqlCmd = "select * from merchant_info where merchant_name='" + merchant_name + "'";
        DataBase db = new DataBase();

        if (db.GetDataSet(sqlCmd).Tables.Count != 0 && db.GetDataSet(sqlCmd).Tables[0].Rows.Count != 0)
        {
            return true;
        }
        return false;
    }

    

    public static DataSet GetFinanceList(int merchant_id, int type)
    {
       // string selcmd = "select * from visit_info right join finance_basic_info on visit_id=finance_activity_id where finance_merchant_id = " + merchant_id + " and finance_type = " + type + " order by finance_occur_time desc";
        string selcmd = "select * from finance_basic_info where finance_merchant_id=" + merchant_id + " and finance_type=" + type + " order by finance_occur_time desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetFinanceBasicInfoById(string finance_id)
    {
        string selCmd = "select * from finance_basic_info where finance_id=" + finance_id;
        DataBase db = new DataBase();
        return db.GetDataSet(selCmd);

    }

    public static DataSet GetFinanceStat(int merchant_id, int year, int month, int type)
    {
        string selcmd = "select finance_all, finance_ybx, finance_wbx from finance_stat_info where finance_merchant_id = " + merchant_id + " and finance_year = " + year + " and finance_month = " + month + " and finance_type=" + type;
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetFinanceStat(int merchant_id, int type, DateTime time)
    {
        string selcmd = "select * from visit_info right join finance_basic_info on visit_id=finance_activity_id where finance_merchant_id = " + merchant_id + " and finance_type = " + type +" and finance_occur_time <='"+time+ "' order by finance_occur_time desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetFinanceStat(string name)
    {
        string selCmd = "select finance_all, finance_ybx,finance_wbx from finance_stat_info where finance_people like '%" + name + "%'";
        DataBase db = new DataBase();
        return db.GetDataSet(selCmd);
    }

    public static DataSet GetFinanceStat(int merchant_id, int type)
    {
        string selcmd = "select finance_all, finance_ybx, finance_wbx from finance_stat_info where finance_merchant_id = " + merchant_id +  " and  finance_type=" + type;
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static int GetMerchantID(string merchant_name)
    {
        string selcmd = "select merchant_id from merchant_info where merchant_name = '" + merchant_name + "'";
        DataBase db = new DataBase();
        DataSet ds = db.GetDataSet(selcmd);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            int res = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            db.Close();
            return res;
        }
        else
            return -1;
    }
    public static string GetMerchantName(int merchant_id)
    {
        string selcmd = "select merchant_name from merchant_info where merchant_id = " + merchant_id;
        DataBase db = new DataBase();
        DataSet ds = db.GetDataSet(selcmd);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string res = ds.Tables[0].Rows[0][0].ToString();
            db.Close();
            return res;
        }
        else
            return "";
    }
    public static DataSet GetActivityList(int type)
    {
        string selcmd = "select visitor_unit,visit_date,visit_id from visit_info where visit_type = " + type + " order by visit_date desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }
    public static DataSet GetActivityList()
    {
        string selcmd = "select visitor_unit,visit_date,visit_id from visit_info order by visit_date desc";
        DataBase db = new DataBase();
        return db.GetDataSet(selcmd);
    }

    public static DataSet GetFinanceMinTime()
    {
        string selCmd = "select MIN(finance_occur_time) from finance_basic_info";
        DataBase db = new DataBase();
        return db.GetDataSet(selCmd);         
    }

    public static DataSet GetFinanceMaxTime()
    {
        string selCmd = "select MAX(finance_occur_time) from finance_basic_info";
        DataBase db = new DataBase();
        return db.GetDataSet(selCmd);
    }




    public static bool AddFinance(int finance_type, int merchant_id, DateTime dt, string good_name,  double good_price,string detail,int ybx)
    {
        string inscmd = "insert into finance_basic_info(finance_type,finance_merchant_id,finance_occur_time,finance_good_name,finance_good_price,finance_people,finance_ybx) values("
                               + finance_type + "," + merchant_id + ",'" + dt.ToShortDateString() + "','" + good_name + "'," + good_price +",'"+detail+"',"+ybx+")";
        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(inscmd);
        db.Close();
        if (res == 1)
        {
            if (SyncFinanceStat(finance_type, merchant_id, dt.Year, dt.Month, good_price))
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public static bool UpdateFinance(int finance_type,int merchant_id,DateTime dt,string good_name,int ybx, double good_price,string finance_people,string finance_id)
    {
        int good_num = 1;
        string updateCmd1 = "update merchant_info set merchant_name='" + good_name+"' where merchant_id="+merchant_id;
        DataBase db = new DataBase();
        db.ExecuteNonQuery(updateCmd1);


        string updatecmd = "update finance_basic_info set finance_occur_time= '"+dt.ToShortDateString()+"',finance_good_name='"+good_name+"'"+
            ", finance_good_price="+good_price.ToString()+", finance_ybx="+ybx+", finance_people='"+finance_people+"' where finance_id="+finance_id;

        int res = db.ExecuteNonQuery(updatecmd);
        db.Close();
        if (res == 1)
        {
            if (SyncFinanceStat(finance_type, merchant_id, dt.Year, dt.Month, good_price * good_num))
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public static bool AddFinance(int finance_type, int activity_id, int merchant_id, DateTime dt, string good_name, int good_num, double good_price)
    {
        string inscmd = "insert into finance_basic_info(finance_type, finance_activity_id,finance_merchant_id,finance_occur_time,finance_good_name,finance_good_num,finance_good_price) values("
                        + finance_type + "," + activity_id + "," + merchant_id + ",'" + dt.ToShortDateString() + "','" + good_name + "'," + good_num + "," + good_price + ")";
        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(inscmd);
        db.Close();
        if (res == 1)
        {
            if (SyncFinanceStat(finance_type, merchant_id, dt.Year, dt.Month, good_price * good_num))
                return true;
            else
                return false;
        }
        else
            return false;
    }
    public static bool AddFinance(int finance_type, int activity_id, string merchant_name, DateTime dt, string good_name, int good_num, double good_price)
    {
        if (AddMerchant(merchant_name))
        {
            int id = GetMerchantID(merchant_name);
            return AddFinance(finance_type, activity_id, id, dt, good_name, good_num, good_price);
        }
        else
            return false;
    }
    public static bool SyncFinanceStat(int type, int merchant_id, int year, int month, double price)
    {
        if (HasFinanceStat(type, merchant_id, year, month))
        {
            if (UpdateFinanceStat(type, merchant_id, year, month, price))
                return true;
            else
                return false;
        }
        else
        {
            if (AddFinanceStat(type, merchant_id, year, month, price))
                return true;
            else
                return false;
        }
    }
    protected static bool AddFinanceStat(int type, int merchant_id, int year, int month, double price)
    {
        string inscmd = "insert into finance_stat_info(finance_type, finance_merchant_id,finance_year,finance_month,finance_all,finance_wbx,finance_ybx) values("
                        + type + "," + merchant_id + "," + year + "," + month + "," + price + "," + price + ",0)";
        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(inscmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }
    protected static bool UpdateFinanceStat(int type, int merchant_id, int year, int month, double price)
    {
        string updcmd = "update finance_stat_info set finance_all=finance_all+" + price + ", finance_wbx = finance_wbx+" + price + " where finance_merchant_id=" + merchant_id + " and finance_year=" + year + " and finance_month=" + month + " and finance_type=" + type;
        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(updcmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }
    public static bool SetYBX(int type, int merchant_id, int year, int month, double ybx)
    {
        string updcmd = "update finance_stat_info set finance_ybx = " + ybx + ", finance_wbx = finance_all - " + ybx + " where finance_merchant_id=" + merchant_id + " and finance_year=" + year + " and finance_month=" + month + " and finance_type=" + type;
        DataBase db = new DataBase();
        int res = db.ExecuteNonQuery(updcmd);
        db.Close();
        if (res == 1)
            return true;
        else
            return false;
    }
    protected static bool HasFinanceStat(int type, int merchant_id, int year, int month)
    {
        string selcmd = "select * from finance_stat_info where finance_merchant_id=" + merchant_id + " and finance_year=" + year + " and finance_month=" + month + " and finance_type=" + type;
        DataBase db = new DataBase();
        SqlDataReader dr = db.GetSqlDataReader(selcmd);
        if (dr != null && dr.HasRows)
        {
            dr.Close();
            return true;
        }
        else
        {
            dr.Close();
            return false;
        }
    }
    public static bool AddMerchant(string merchant_name)
    {
        if (!HasMerchant(merchant_name))
        {
            string inscmd = "insert into merchant_info(merchant_name) values('" + merchant_name.Trim() + "')";
            DataBase db = new DataBase();
            int res = db.ExecuteNonQuery(inscmd);
            db.Close();
            if (res == 1)
                return true;
            else
                return false;
        }
        else
            return false;
    }


    public static bool AddMerchant(string merchant_name,int merchant_type)
    {
        if (!HasMerchant(merchant_name))
        {
            string inscmd = "insert into merchant_info(merchant_name,merchant_type) values('" + merchant_name.Trim() + "',"+merchant_type+")";
            DataBase db = new DataBase();
            int res = db.ExecuteNonQuery(inscmd);
            db.Close();
            if (res == 1)
                return true;
            else
                return false;
        }
        else
            return false;
    }


    protected static bool HasMerchant(string merchant_name)
    {
        string selcmd = "select * from merchant_info where merchant_name='" + merchant_name + "'";
        DataBase db = new DataBase();
        SqlDataReader dr = db.GetSqlDataReader(selcmd);
        if (dr != null && dr.HasRows)
        {
            dr.Close();
            return true;
        }
        else
        {
            dr.Close();
            return false;
        }
    }


    public static bool DeleteFinace(string finance_id)
    {
        DataSet ds=GetFinanceBasicInfoById(finance_id);

         if (ds.Tables.Count>0&& ds.Tables[0].Rows.Count>0)
        {
            if (SyncFinanceStat((int)ds.Tables[0].Rows[0]["finance_type"], (int)ds.Tables[0].Rows[0]["finance_merchant_id"], ((DateTime)ds.Tables[0].Rows[0]["finance_occur_time"]).Year, ((DateTime)ds.Tables[0].Rows[0]["finance_occur_time"]).Month, -(double)ds.Tables[0].Rows[0]["finance_good_price"]))
            {
                string deleteCmd = "delete from finance_basic_info where finance_id= " + finance_id;
                DataBase db = new DataBase();
                int res = db.ExecuteNonQuery(deleteCmd);
                db.Close();
                if (res == 1)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        else
            return false;

        
    }
}