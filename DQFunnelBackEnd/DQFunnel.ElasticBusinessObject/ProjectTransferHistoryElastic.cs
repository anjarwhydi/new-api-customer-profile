
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class ProjectTransferHistoryElastic
    {
        public Guid ID { get; set; }
        public string CustomerName { get; set; }
        public string FunnelID { get; set; }
        public string FromSales { get; set; }
        public string ToSales { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatorUserID { get; set; }
    }
}
