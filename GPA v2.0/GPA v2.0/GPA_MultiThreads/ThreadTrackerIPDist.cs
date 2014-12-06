using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using GPA.GPA_ADT;
using GPA.GPA_Xml;

namespace GPA.GPA_MultiThreads
{
    class ThreadTrackerIPDist:ThreadDist
    {
        public ThreadTrackerIPDist()
        {
            Dists = new TrackerIPDist[1];
            Dists[0] = new TrackerIPDist();

            xmlAnalysis = new XmlTrackerIPDist();
        }
    }
}
