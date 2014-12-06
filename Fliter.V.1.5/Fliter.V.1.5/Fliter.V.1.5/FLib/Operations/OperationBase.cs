using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using NetUtil.db;

namespace Fliter.FLib.Operations
{
    abstract class OperationBase
    {
        protected AMDBUtil dbUtil;

        public OperationBase(AMDBUtil dbUtil)
        {
            this.dbUtil=dbUtil;
        }

        public abstract DataSet SelectSpiderResource(string type);

        public abstract DataSet SelectResourceDailyCount(string type);

        public abstract void InsertToResourceDaily(string type);

        public abstract void InsertToResourceLivePeriod(string type);

        public abstract void DeleteResourceDaily(string type);

        public abstract void UpdateSpiderResource(string type);

        public abstract void DeleteResourceLivePeriod();

        public abstract void UpdateDateTime();

        public abstract void SelectDateTime();


        
    }
}
