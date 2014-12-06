using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GPA
{
    class IPInfo
    {
       private ArrayList internalBtIp;
       private ArrayList foreignBtIp;
       private ArrayList emuleIp;


       public ArrayList EmuleIp
       {
           get
           {
               return emuleIp;
           }
           set
           {
               emuleIp = value;
           }
       }

       public ArrayList InternalBtIP
       {
           get
           {
               return internalBtIp;
           }
           set
           {
               internalBtIp = value;
           }
       }


       public ArrayList ForeignBtIP
       {
           get
           {
               return foreignBtIp;
           }
           set
           {
               foreignBtIp = value;
           }
       }

       public ArrayList AllBtIP
       {
           get
           {
               ArrayList temp=new ArrayList();
               temp=internalBtIp;
               temp.AddRange(foreignBtIp);
               return temp;
           }
       }

       public IPInfo()
       {
           internalBtIp = new ArrayList();
           foreignBtIp = new ArrayList();
           emuleIp = new ArrayList();
       }
    }
}
