using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

using GPA.GPA_ADT;
using GPA.GPA_ADT.GPA_PortDist;
using GPA.GPA_Xml;
namespace GPA.GPA_MultiThreads
{
    class ThreadPortDist:ThreadDist
    {
       


        public ThreadPortDist()
        {
            Dists = new PortDist[3];
            Dists[0] = new InternalPortDist();
            Dists[1] = new ForeignPortDist();
            Dists[2] = new EmulePortDist();

            xmlAnalysis = new XmlPortDist();
        }

    }
}
