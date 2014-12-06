using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GPA.Infrastructure.SKLCC;

namespace GPA.BLL
{
    public abstract class DataAnalysis
    {
        protected DBProvider provider;
        protected DBCmd cmd;

        public DBCmd Cmd
        {
            get { return cmd; }
            set { cmd = value; }

        }

        protected abstract void Storage();

        public abstract void Start();

        protected abstract void StartAnalysis(DBCmd cmd);

        protected abstract bool IsAnalysised();

        protected abstract void Update();

        
    }
}
