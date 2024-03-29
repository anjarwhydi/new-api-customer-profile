﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject
{
    public class CpCustomerSettingDashboard
    {
        public long CustomerID { get; set; }
        public string CustomerCategory { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string LastProjectName { get; set; }
        public string SalesName { get; set; }
        public bool PMOCustomer { get; set; }
        public string RelatedCustomer { get; set; }
        public bool Blacklist { get; set; }
        public bool Holdshipment { get; set; }
        public bool Named { get; set; }
        public bool Shareable { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string RequestedBy { get; set; }
        public long SalesShareableID { get; set; }
        public long ApprovalBy { get; set; }
        public string Status { get; set; }
    }
}
