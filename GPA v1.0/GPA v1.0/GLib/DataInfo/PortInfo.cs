using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GPA
{
    class PortInfo
    {
       private Hashtable internalBtPort;
       private Hashtable foreignBtPort;
       private Hashtable emulePort;


       public Hashtable EmulePort
       {
           get
           {
               return emulePort;
           }
           set
           {
               emulePort = value;
           }
       }
       public Hashtable InternalBtPort
       {
           get
           {
               return internalBtPort;
           }
           set
           {
               internalBtPort = value;
           }
        }

       public Hashtable ForeignBtPort
       {
           get
           {
               return foreignBtPort;
           }
           set
           {
               foreignBtPort = value;
           }
       }


       public int Length
       {
           get
           {
               return internalBtPort.Count+foreignBtPort.Count;
           }
       }
       public PortInfo()
       {
           internalBtPort = new Hashtable();
           foreignBtPort = new Hashtable();
       }
    }
}
