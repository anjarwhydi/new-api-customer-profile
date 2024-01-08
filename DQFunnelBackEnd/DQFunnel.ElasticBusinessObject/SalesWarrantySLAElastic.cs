using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    [ElasticsearchType(IdProperty = nameof(WarrantySLAGenID))]
    public class SalesWarrantySLAElastic : BaseEntityES
    {
        [Number(Name = "WarrantySLAGenID")]
        public long WarrantySLAGenID { get; set; }

        [Number(Name = "WarrantySupportID")]
        public long WarrantySupportID { get; set; }

        [Number(Name = "ProblemClassID")]
        public long ProblemClassID { get; set; }

        [Number(Name = "BrandID")]
        public long BrandID { get; set; }

        [Number(Name = "SubBrandID")]
        public long SubBrandID { get; set; }

        [Date(Name = "StartWarrantyCust")]
        public DateTime? StartWarrantyCust { get; set; }

        [Text(Name = "CustomerWarranty")]
        public string CustomerWarranty { get; set; }

        [Date(Name = "StartWarrantyVendor")]
        public DateTime? StartWarrantyVendor { get; set; }

        [Text(Name = "VendorWarranty")]
        public string VendorWarranty { get; set; }
    }
}
