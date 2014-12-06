using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace    GPA.BLL.ADT
{
    class BlockList
    {
        private string blocklistName;
        private int ipNumber;
        private double blocklistPercentage;



        public BlockList(string blName, int ipN)
        {
            blocklistName = blName;
            ipNumber = ipN;
            blocklistPercentage = 0;
        }
    }
}
