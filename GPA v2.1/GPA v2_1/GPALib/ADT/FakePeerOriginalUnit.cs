using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class FakePeerOriginalUnit:OriginalUnitBase
    {
        public string ip;
        public string fake_ip;

        public FakePeerOriginalUnit(string ip, string fake_ip)
        {
            this.ip = ip;
            this.fake_ip = fake_ip;

        }
    }
}
