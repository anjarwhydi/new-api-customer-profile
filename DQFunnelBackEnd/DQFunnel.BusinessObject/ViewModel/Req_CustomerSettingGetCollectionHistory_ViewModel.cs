using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject.ViewModel
{
    public class Req_CustomerSettingGetCollectionHistory_ViewModel
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public long SOID { get; set; }
        public float CollectionAmount { get; set; }
        public string CollectionDate { get; set; }
    }
}
