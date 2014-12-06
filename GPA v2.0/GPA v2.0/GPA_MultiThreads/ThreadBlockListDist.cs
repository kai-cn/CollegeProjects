using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.IO;

using GPA.GPA_ADT;
using GPA.GPA_ADT.GPA_BlockListDist;
using GPA.GPA_Xml;

namespace GPA.GPA_MultiThreads
{
    class ThreadBlockListDist:ThreadDist
    {


        public ThreadBlockListDist()
        {
            Dists = new BlockListDist[3];
            Dists[0] = new InternalBtBlockListDist();
            Dists[1] = new ForeignBtBlockListDist();
            Dists[2] = new EmuleBlockListDist();

            xmlAnalysis = new XmlBlockListDist();
        }

    }
}
