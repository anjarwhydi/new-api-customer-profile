using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject.ViewModel
{
    public class Req_CustomerSettingGetCustomerDataByID_ViewModel
    {
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public bool Blacklist { get; set; }
        public bool Holdshipment { get; set; }
        public float AvgAR { get; set; }
    }
}
