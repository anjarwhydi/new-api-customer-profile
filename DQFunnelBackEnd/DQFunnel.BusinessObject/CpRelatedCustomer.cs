using DQFunnel.BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject
{
    internal class CpRelatedCustomer : BaseEntity
    {
        public long RCustomerID { get; set; }
        public long CustomerID { get; set; }
        public long RelatedCustomerID { get; set; }
    }
}
