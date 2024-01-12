using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject
{
    public class CpSalesAssignment
    {
        public long SAssignmentID { get; set; }
        public long CustomerID { get; set; }
        public long SalesID { get; set; }
        public string Status { get; set; }
        public int ModifyUserID { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
