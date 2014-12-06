using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Cache
{
    public class CacheManager
    {
        private static Queue<string> Message;

        static CacheManager()
        {
            Message = new Queue<string>();
        }

        public static string DeQueue()
        {
            string outM="";
            lock (Message)
            {
                if (Message.Count != 0)
                    outM = Message.Dequeue();
             }

            return outM;     
        }

        public static void EnQueue(string inM)
        {
            lock (Message)
            {
                Message.Enqueue(inM);
            }
        }

        public static bool IsEmpty()
        {
            lock (Message)
            {
                if (Message.Count == 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
