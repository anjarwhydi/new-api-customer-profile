using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject.ViewModel
{
    public class Req_CustomerSettingNoNamedAccount_ViewModel
    {
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public bool Blacklist { get; set; }
        public bool Holdshipment { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
