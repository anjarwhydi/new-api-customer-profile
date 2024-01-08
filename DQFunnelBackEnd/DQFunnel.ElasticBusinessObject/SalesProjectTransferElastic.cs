using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    [ElasticsearchType(IdProperty = nameof(Id))]
    public class SalesProjectTransferElastic:BaseEntityES
    {
        public string Id { get; set; }


        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Number(Name = "CustomerGenID")]
        public long CustomerGenID { get; set; }

        [Text(Name = "CustomerName")]
        public string CustomerName { get; set; }

        [Number(Name = "FromSalesID")]
        public int FromSalesID { get; set; }

        [Text(Name="FromSalesName")]
        public string FromSalesName { get; set; }

        [Number(Name = "ToSalesID")]
        public int ToSalesID { get; set; }

        [Text(Name = "ToSalesName")]
        public string ToSalesName { get; set; }

        [Number(Name = "CrStateFunnelTotalSelling")]
        public decimal CrStateFunnelTotalSelling { get; set; }

        [Number(Name = "CrStateFunnelStatusID")]
        public int CrStateFunnelStatusID { get; set; }

        [Number(Name = "CrStateGPMPctg")]
        public float CrStateGPMPctg { get; set; }

        [Number(Name = "CrStateGPMAmount")]
        public decimal CrStateGPMAmount { get; set; }
    }
}
