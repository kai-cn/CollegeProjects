using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace    GPA.BLL.ADT
{
    class Country
    {
        private string countryCode;
        private int countryNumber;
        private double countryPercentage;

        public string CountryCode
        {
            get { return countryCode; }
            set { countryCode = value; }
        }

        public int CountryNumber
        {
            get {return countryNumber; }
            set { countryNumber = value; }
            
        }

        public double CountryPercentage
        {
            get { return countryPercentage; }
            set { countryPercentage = value; }
        }

        public Country(string countryC, int countryN, double countryP)
        {
            countryCode = countryC;
            countryNumber = countryN;
            countryPercentage = countryP;
        }
    }
}
