﻿using System;
using System.Collections.Generic;

namespace DQFunnel.BusinessObject.ViewModel
{
    public class Req_CustomerSettingCustomerDataEnvelope_ViewModel
    {
        public string AccountStatus { get; set; }
        public long CustomerID { get; set; }
        public string CustomerCategory { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string PMOCustomer { get; set; }
        public bool Blacklist { get; set; }
        public bool Holdshipment { get; set; }
        public float AvgAR { get; set; }
        public string SalesName { get; set; }
        public List<Req_CustomerSettingShareableApprovalStatus_ViewModel> ShareableApprovalStatus { get; set; }
    }
}
