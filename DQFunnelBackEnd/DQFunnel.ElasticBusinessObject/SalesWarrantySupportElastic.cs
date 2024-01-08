using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    [ElasticsearchType(IdProperty = nameof(WarrantySupportID))]
    public class SalesWarrantySupportElastic : BaseEntityES
    {
        [Number(Name = "WarrantySupportID")]
        public long WarrantySupportID { get; set; }

        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Text(Name = "PreventivePolicy")]
        public string PreventivePolicy { get; set; }

        [Text(Name = "CorrectivePolicy")]
        public string CorrectivePolicy { get; set; }

        [Date(Name = "StartDateWarranty")]
        public DateTime? StartDateWarranty { get; set; }

        [Text(Name = "ServiceLocation")]
        public string ServiceLocation { get; set; }
    }
}
