using DQFunnel.BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.BusinessObject
{
    public class CpInvoicingSchedule : BaseEntity
    {
        public long IScheduleID { get; set; }
        public long CustomerID { get; set; }
        public string ScheduleDays { get; set; }
        public int MinDate { get; set; }
        public int MaxDate { get; set; }
        public string Remark { get; set; }
    }
}
