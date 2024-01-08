using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelEditFunnelAdditionalElastic : BaseEntityES
    {
        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Text(Name = "CompellingEvent")]
        public string CompellingEvent { get; set; }

        [Number(Name = "CustomerBudget")]
        public decimal? CustomerBudget { get; set; }

        [Text(Name = "SupportiveCoach")]
        public string SupportiveCoach { get; set; }

        [Text(Name = "CustomerNeeds")]
        public string CustomerNeeds { get; set; }

        [Text(Name = "Competitor")]
        public string Competitor { get; set; }
    }
}
