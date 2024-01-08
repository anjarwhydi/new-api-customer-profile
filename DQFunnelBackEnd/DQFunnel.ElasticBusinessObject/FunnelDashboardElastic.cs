using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class FunnelDashboardElastic
    {
        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Number(Name = "SalesID")]
        public long SalesID { get; set; }

        [Text(Name = "SalesName")]
        public string SalesName { get; set; }

        [Text(Name = "CustomerName")]
        public string CustomerName { get; set; }

        [Text(Name = "ProjectName")]
        public string ProjectName { get; set; }

        [Number(Name = "TotalSellingPrice")]
        public decimal? TotalSellingPrice { get; set; }

        [Number(Name = "GPMPctg")]
        public float? GPMPctg { get; set; }

        [Number(Name = "GPMAmount")]
        public decimal? GPMAmount { get; set; }

        [Date(Name = "DealCloseDate")]
        public DateTime? DealCloseDate { get; set; }

        [Date(Name = "CreateDate")]
        public DateTime? CreateDate { get; set; }

        [Text(Name = "FunnelStatus")]
        public string FunnelStatus { get; set; }

        [Number(Name = "CustomerGenID")]
        public long CustomerGenID { get; set; }
    }
}
