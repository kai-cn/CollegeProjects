using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPA.GPA_ADT;
using GPA.GPA_Xml;

namespace GPA.GPA_MultiThreads
{
    class ThreadClusCoefDist:ThreadDist
    {
        public ThreadClusCoefDist()
        {
            Dists = new ClusCoefDist[1];
            Dists[0] = new ClusCoefDist();

            xmlAnalysis = new XmlClusCoefDist();
        }
    }
}
