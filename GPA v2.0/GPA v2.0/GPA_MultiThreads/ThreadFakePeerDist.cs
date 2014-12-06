using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPA.GPA_ADT;
using GPA.GPA_Xml;

namespace GPA.GPA_MultiThreads
{
    class ThreadFakePeerDist:ThreadDist
    {
        public ThreadFakePeerDist()
        {
            Dists = new FakePeerDist[1];
            Dists[0] = new FakePeerDist();

            xmlAnalysis = new XmlFakePeersDist();
        }
    }
}
