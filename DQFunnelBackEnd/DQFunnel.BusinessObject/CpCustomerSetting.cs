using DQFunnel.BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject
{
    public class CpCustomerSetting : BaseEntity
    {
        public long CustomerSettingID { get; set; }
        public long CustomerID { get; set; }
        public long SalesID { get; set; }
        public bool Shareable { get; set; }
        public bool Named { get; set; }
        public bool PMOCustomer { get; set; }
    }
}
