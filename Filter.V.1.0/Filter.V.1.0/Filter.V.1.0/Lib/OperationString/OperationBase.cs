using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filter.Lib.OperationString
{
    public class OperationBase
    {
        /*BT*/
        protected string distinct_TorPath_from_SBR;
        protected string write_SBR_into_BRD;
        protected string update_RLP_from_BRD;
        protected string delete_from_BRD;
        protected string remark_SBR_flag;
        protected string select_count_BRD;
        protected string select_BRD;

        /*eMule*/
        protected string distinct_ed2k_link_SER;
        protected string write_SER_into_ERD;
        protected string update_RLP_from_ERD;
        protected string delete_from_ERD;
        protected string remark_SER_flag;
        protected string select_count_ERD;
        protected string select_ERD;

        /*Other*/
        protected string path_count_days_from_POD;
        protected string all_from_RLP;
        protected string delete_from_POD;
        protected string delete_from_RLP_flag;
        protected string delete_from_RLP;
        //protected string update_RLP;
        protected string Set_time;
        protected string getOldTime;
        protected string getOldTimeFromOriginalData;
        
#if (p2p_original_data_bak)
        protected DateTime startTime;
        protected DateTime endTime;
#endif

    }
}
