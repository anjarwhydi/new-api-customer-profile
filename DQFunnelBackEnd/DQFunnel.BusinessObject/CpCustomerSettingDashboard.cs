﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject
{
    public class CpCustomerSettingDashboard
    {
        public long CustomerSettingID { get; set; }
        public long CustomerID { get; set; }
        public string CustomerCatageory { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string LastProjectName { get; set; }
        public string SalesName { get; set; }
        public bool PMOCustomer { get; set; }
        public string RelatedCustomer { get; set; }
        public bool Blacklist { get; set; }
        public bool Holdshipmet { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
