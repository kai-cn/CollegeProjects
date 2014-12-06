using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class FakePeerUnit:OriginalUnitBase
    {
        public string ip;
        public int fake_ip_number;
        public int blocklist_bogon_other_number;
        public int connect_fake_ip_number;
        public int connect_ip_in_fake_number;
        
        public FakePeerUnit(string ip,int fake_ip_number,int blocklist_bogon_other_number,int connect_fake_ip_number,int connect_in_fake_number)
        {
            this.ip = ip;
            this.fake_ip_number = fake_ip_number;
            this.blocklist_bogon_other_number = blocklist_bogon_other_number;
            this.connect_fake_ip_number = connect_fake_ip_number;
            this.connect_ip_in_fake_number = connect_in_fake_number;
        }

    }
}
