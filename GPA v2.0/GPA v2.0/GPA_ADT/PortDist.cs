using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace GPA.GPA_ADT
{
    abstract class PortDist:Data
    {
       //abstract public DataTable GetPortContainer();

        protected Hashtable portTable;

        protected int ipCount;


        public PortDist()
        {
            portTable = new Hashtable();
        }

        public int IpCount
        {
            get
            {
                return ipCount;
            }
            set
            {
                ipCount = value;
            }
        }


        public Hashtable PortTable
        {
            get
            {
                return portTable;
            }
            set
            {
                portTable = value;
            }
        }

       protected void SetPortTable(DataTable dt)
       {
           ipCount = 0;
           foreach (DataRow row in dt.Rows)
           {
               try
               {
                   if (!portTable.Contains(row[1].ToString()))
                       portTable.Add(row[1], 1);
                   else
                       portTable[row[1].ToString()] = Convert.ToInt32(portTable[row[1].ToString()].ToString()) + 1;
                   ipCount++;
               }
               catch (Exception)
               {
 
               }
           }
       }

       public override void Load()
       {
           DataTable dt = db.reDs(GetCommand()).Tables[0];
           SetPortTable(dt);
           //throw new NotImplementedException();
       }
    }
}
