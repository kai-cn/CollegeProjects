using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace    GPA.BLL.ADT
{
    class FakePeer
    {
        private string ip;
        private int fakeIpNumber;
        private int blocklistBogonOtherNumber;
        private int connectFakeIPNumber;
        private int connectIPInFakeNumber;
        
        public FakePeer(string ip,int fakeIpNumber,int blocklistBogonOtherNumber,int connectFakeIPNumber,int connectIPInFakeNumber)
        {
            this.ip = ip;
            this.fakeIpNumber = fakeIpNumber;
            this.blocklistBogonOtherNumber = blocklistBogonOtherNumber;
            this.connectFakeIPNumber = connectFakeIPNumber;
            this.connectIPInFakeNumber = connectIPInFakeNumber;
        }
    }
}
