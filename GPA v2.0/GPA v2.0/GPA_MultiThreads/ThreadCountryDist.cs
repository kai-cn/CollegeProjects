using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

using GPA.GPA_ADT;
using GPA.GPA_ADT.GPA_CountryDist;
using GPA.GPA_Xml;

namespace GPA.GPA_MultiThreads
{
    class ThreadCountryDist:ThreadDist
    {
        public ThreadCountryDist()
        {
            Dists = new CountryDist[3];
            Dists[0] = new InternalBtCountryDist();
            Dists[1] = new ForeignBtCountryDist();
            Dists[2] = new EmuleCountryDist();

            xmlAnalysis = new XmlCountryDist();
        }
    }
    
}
