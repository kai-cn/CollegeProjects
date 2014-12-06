using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.Config
{
    public class DBConfig
    {
        public string OracleConnectionString { get; set; }

        public string SqlServerConnectionString { get; set; }

        public string OracleWebConnectionString { get; set; }

        public string MaxMindGeoLite { get; set; }

        public string BlockList { get; set; }
    }
}
