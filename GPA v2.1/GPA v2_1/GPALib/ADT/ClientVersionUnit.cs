using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class ClientVersionUnit
    {
        public string clientVersion;
        public int peer_number;
        public double peer_percentage;

        public ClientVersionUnit(string clientVersion, int peer_number)
        {
            this.clientVersion = clientVersion;
            this.peer_number = peer_number;
            peer_percentage = 0;
        }
    }
}
