using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    [ElasticsearchType(IdProperty = nameof(WarrantySLADetailID))]
    public class SalesWarrantySLADetailElastic : BaseEntityES
    {
        [Number(Name = "WarrantySLADetailID")]
        public long WarrantySLADetailID { get; set; }

        [Number(Name = "WarrantySLAGenID")]
        public long WarrantySLAGenID { get; set; }

        [Text(Name = "SLAType")]
        public string SLAType { get; set; }

        [Text(Name = "ProductNumber")]
        public string ProductNumber { get; set; }

        [Text(Name = "ServiceLocation")]
        public string ServiceLocation { get; set; }

        [Text(Name = "CoverageHour")]
        public string CoverageHour { get; set; }

        [Text(Name = "ResponseTime")]
        public string ResponseTime { get; set; }

        [Text(Name = "ResolutionTime")]
        public string ResolutionTime { get; set; }
    }
}
