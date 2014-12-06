using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.GPALib.ADT
{
    class BlockListUnit
    {
        public string blocklistName;
        public int ipNumber;
        public double blocklist_percentage=0;

        public BlockListUnit(string blName, int ipN)
        {
            blocklistName = blName;
            ipNumber = ipN;
        }

    }
}
