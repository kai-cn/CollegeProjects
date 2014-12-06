using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class CountryRankingUnit:OriginalUnitBase
    {
        public string countryCode;
        public int countryNumber;
        public double countryPercentage;


        public CountryRankingUnit(string countryC, int countryN, double countryP)
        {
            countryCode = countryC;
            countryNumber = countryN;
            countryPercentage = countryP;
        }
    }
}
