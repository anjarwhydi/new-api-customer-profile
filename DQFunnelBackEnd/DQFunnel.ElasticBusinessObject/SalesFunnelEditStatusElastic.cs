using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelEditStatusElastic : BaseEntityES
    {
        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Text(Name = "FunnelID")]
        public string FunnelID { get; set; }

        [Number(Name = "FunnelStatusID")]
        public int FunnelStatusID { get; set; }

        [Text(Name = "FunnelStatus")]
        public string FunnelStatus { get; set; }

        [Date(Name = "DealCloseDate")]
        public DateTime DealCloseDate { get; set; }

        [Number(Name = "SalesID")]
        public int SalesID { get; set; }

        [Text(Name = "SalesName")]
        public string SalesName { get; set; }
    }
}
