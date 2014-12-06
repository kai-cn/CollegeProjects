using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class SixDegreeUnit:OriginalUnitBase
    {
        public string resource_uri;
        public int swarm_size;
        public double six_degree;
        public double clus_coef;

        public SixDegreeUnit(string resource_uri,int swarm_size,double six_degree,double clus_coef)
        {
            this.resource_uri = resource_uri;
            this.swarm_size = swarm_size;
            this.six_degree = six_degree;
            this.clus_coef = clus_coef;
        }
    }
}
