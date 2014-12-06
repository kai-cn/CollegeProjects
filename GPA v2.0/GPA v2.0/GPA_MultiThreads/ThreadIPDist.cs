using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

using GPA.GPA_ADT;
using GPA.GPA_ADT.GPA_IPDist;
using GPA.GPA_Xml;


namespace GPA.GPA_MultiThreads
{
    class ThreadIPDist:ThreadDist
    {

        public ThreadIPDist()
        {
            Dists = new IPDist[3];
            Dists[0] = new InternalBtIpDist();
            Dists[1] = new ForeignBtIpDist();
            Dists[2] = new EmuleIpDist();
            
            xmlAnalysis = new XmlIpDist();
        }

    }
}
