using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPA.GPA_ADT;
using GPA.GPA_Xml;

namespace GPA.GPA_MultiThreads
{
    class ThreadSDofSDist:ThreadDist
    {
        public ThreadSDofSDist()
        {
            Dists = new SDofSDist[1];
            Dists[0] = new SDofSDist();

            xmlAnalysis = new XmlSDofSDist();
        }
    }
}
