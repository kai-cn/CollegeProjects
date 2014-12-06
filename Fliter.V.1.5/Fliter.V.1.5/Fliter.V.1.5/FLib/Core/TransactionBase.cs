using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fliter.FLib.Core
{
    abstract class TransactionBase
    {
        protected abstract void UpdateResourceLivePeriod();

        protected abstract void RemarkSpiderResource();

        protected abstract void UpdateDailyResource();


        public void Start()
        {
            UpdateResourceLivePeriod();
            RemarkSpiderResource();
            UpdateDailyResource();
        }


    }
}
