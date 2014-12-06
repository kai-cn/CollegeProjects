using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace    GPA.BLL.ADT
{
    class OriginalFakePeer
    {
         private string ip;
        private string fakeIp;

        public OriginalFakePeer(string ip, string fakeIp)
        {
            this.ip = ip;
            this.fakeIp = fakeIp;

        }
    }
}
