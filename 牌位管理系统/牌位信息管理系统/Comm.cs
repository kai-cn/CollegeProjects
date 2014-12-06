using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace 蓬莱寺牌位名册
{
    class Comm
    {
        public static string AddPW,EditPW, DelPW, AddQPG, DelQPG, AddUser, DelUser;
        public static string loginName,paiweiName;
        public static string[] softWareName;



        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }
    }
}
