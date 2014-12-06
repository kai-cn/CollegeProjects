using System;
using System.Collections.Generic;

using System.Web;

/// <summary>
///BusTranster 的摘要说明
/// </summary>
///
using System.Collections;

namespace IntelligentBus.BLL
{

    public class BusTranster
    {
        private BusStation bs = new BusStation();
        private BusLine bl = new BusLine();
        private BusInfo bi = new BusInfo();

        public BusTranster()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        

        public List<Entities.OneTranster> GetTransterOne(string source,string dest)
        {
            List<Entities.OneTranster> ListOne = bs.GetTransterOne(source, dest);
            foreach (Entities.OneTranster one in ListOne)
            {
                one.FirstInfo = GetLineCode(one.FirstInfoID);
            }
            return ListOne;
        }

        public List<Entities.TwoTranster> GetTransterTwo(string source, string dest)
        {
            List<Entities.TwoTranster> listTwo = bs.GetTransterTwo(source, dest);
            foreach (Entities.TwoTranster two in listTwo)
            {
                two.FirstInfo = GetLineCode(two.FirstInfoID);
                two.SecondInfo = GetLineCode(two.SecondInfoID);
            }
            return listTwo;
        }

        private string GetLineCode(int infoID)
        {
            Entities.BusInfo ebi = bi.SelectByID(infoID);
            Entities.BusLine ebl = bl.SelectByID(ebi.BusLineID);

            return ebl.LineCode;
        }

        public string JsonGetLocation(int startIndex,int endIndex,int stationInfoID)
        {

            return bs.JsonGetStationDetail(startIndex, endIndex, stationInfoID);
        }

        
    }
}