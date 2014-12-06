using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

using GPA.BLL;
using GPA.Infrastructure.SKLCC.Oracle.ForeignBT;
using GPA.Infrastructure.SKLCC.Oracle.DomesticBT;
using GPA.Infrastructure.SKLCC.Oracle.DomesticEmule;
using GPA.Infrastructure.SKLCC.Oracle.ForeignEmule;

namespace GPA.Core
{
    public class Analysis
    {
        private Configuration config;
        private List<DataAnalysis> listAnalysis;

        public Analysis()
        {
            string currPath=AppDomain.CurrentDomain.BaseDirectory;
            string configPath = currPath.Substring(0, currPath.IndexOf("GPA.V.2.2") + 10) + @"\GPA.Presentation\bin\Debug\GPA.Presentation.exe";
            config = ConfigurationManager.OpenExeConfiguration(configPath);
            listAnalysis = new List<DataAnalysis>();
        }

        public void Start()
        {
            Initial();
            StartAnalysis();
            
        }

        private void Initial()
        {
            string[] allKeys=config.AppSettings.Settings.AllKeys;

            for (int i = 5; i < allKeys.Count(); i++)
            {
                try
                {
                    listAnalysis.Add(Assembly.Load("GPA.BLL").CreateInstance("GPA.BLL." + config.AppSettings.Settings[allKeys[i]].Value) as DataAnalysis);
                }
                catch (Exception ex)
                {
                    Utility.Log.LogManager.WriteLog(Utility.Log.LogManager.LogFile.Warning, "Analysis.cs"+ex.Message);
                }
            }
        }

        private void StartAnalysis()
        {
            listAnalysis[2].Start();

            for (int i = 0; i < listAnalysis.Count; i++)
            {
                try
                {
                    listAnalysis[i].Start();
                }
                catch (Exception ex)
                {
                    Utility.Log.LogManager.WriteLog(Utility.Log.LogManager.LogFile.Error,"Analysis.cs"+ex.Message);
                }
            }
        }
    }
}
