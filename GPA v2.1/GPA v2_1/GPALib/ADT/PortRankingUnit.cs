using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace GPA.GPALib.ADT
{
    class PortRankingUnit:OriginalUnitBase
    {
        public string port;
        public int portNumber;
        public double portPercentage;

        public PortRankingUnit(string p, int pN, double pP)
        {
            port = p;
            portNumber = pN;
            portPercentage = pP;
        }
    }
}
