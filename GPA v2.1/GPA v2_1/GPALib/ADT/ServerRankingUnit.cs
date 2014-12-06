using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class ServerRankingUnit
    {
        public string serverIp;
        public int ownPeerIpNumber;
        public double percentage;

        public ServerRankingUnit(string server, int ownPeerIp)
        {
            serverIp = server;
            ownPeerIpNumber = ownPeerIp;
        }
    }
}
