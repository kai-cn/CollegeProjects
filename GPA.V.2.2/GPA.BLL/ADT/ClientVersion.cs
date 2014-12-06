using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace    GPA.BLL.ADT
{
    class ClientVersion
    {
        private string clientVersion;
        private int peerNumber;
        private double peerPercentage;

        public ClientVersion(string clientVersion, int peerNumber)
        {
            this.clientVersion = clientVersion;
            this.peerNumber = peerNumber;
            peerPercentage = 0;
        }
    }
}
