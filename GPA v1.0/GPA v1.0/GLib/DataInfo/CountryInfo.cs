using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GPA
{
    class CountryInfo
    {
       private Hashtable internalBtCountry;
       private Hashtable foreignBtCountry;


       public Hashtable InternalBtCountry
       {
           get
           {
               return internalBtCountry;
           }
           set
           {
               internalBtCountry = value;
           }
       }


       public Hashtable ForeignBtCountry
       {
           get
           {
               return foreignBtCountry;
           }
           set
           {
               foreignBtCountry = value;
           }

       }


       public CountryInfo()
       {
           internalBtCountry = new Hashtable();
           foreignBtCountry = new Hashtable();
       }
    }
}
