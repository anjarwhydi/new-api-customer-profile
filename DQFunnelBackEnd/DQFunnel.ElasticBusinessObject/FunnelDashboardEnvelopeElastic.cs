using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class FunnelDashboardEnvelopeElastic
    {
        public int TotalRows { get; set; }
        public List<FunnelDashboardElastic> Funnels { get; set; }
    }
}
