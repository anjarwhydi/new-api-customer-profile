using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelEditPOElastic : BaseEntityES
    {
        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Text(Name = "POCustomerNo")]
        public string POCustomerNo { get; set; }

        [Date(Name = "POCustomerDate")]
        public DateTime? POCustomerDate { get; set; }

        [Text(Name = "ContractNo")]
        public string ContractNo { get; set; }

        [Date(Name = "ContractStartDate")]
        public DateTime? ContractStartDate { get; set; }

        [Date(Name = "ContractEndDate")]
        public DateTime? ContractEndDate { get; set; }

        [Text(Name = "SA")]
        public string SA { get; set; }

        [Text(Name = "SO")]
        public string SO { get; set; }
    }
}
