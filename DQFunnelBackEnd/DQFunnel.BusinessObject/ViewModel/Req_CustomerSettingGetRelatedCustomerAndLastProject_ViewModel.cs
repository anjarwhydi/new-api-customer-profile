using System;

namespace DQFunnel.BusinessObject.ViewModel
{
    public class Req_CustomerSettingGetRelatedCustomerAndLastProject_ViewModel
    {
        public long CustomerID { get; set; }
        public string LastProjectName { get; set; }
        public string RelatedCustomer { get; set; }
    }
}
