using DQFunnel.ElasticBusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesBOQElastic : BaseEntityES
    {
        public long BoqGenID { get; set; }
        public long FunnelGenID { get; set; }
        public string Description { get; set; }
        public string ProductNumber { get; set; }
        public int Qty { get; set; }
        public long BrandID { get; set; }
        public long SubBrandID { get; set; }
        public int Warranty { get; set; }
        public string WarrantyDurationType { get; set; }
        public int? WarrantyInDays { get; set; }
    }
}
