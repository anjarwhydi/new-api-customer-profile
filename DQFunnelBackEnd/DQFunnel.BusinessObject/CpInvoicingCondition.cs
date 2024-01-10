using DQFunnel.BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject
{
    public class CpInvoicingCondition : BaseEntity
    {
        public long IConditionID { get; set; }
        public long CustomerID { get; set; }
        public string ProjectType { get; set; }
        public string DocumentName { get; set; }
    }
}
