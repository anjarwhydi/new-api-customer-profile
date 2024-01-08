using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface ISalesFunnelEditFunnelAdditionalElasticRepository : IElasticRepository<FunnelElastic>
    {
        IEnumerable<SalesFunnelEditFunnelAdditionalElastic> GetViewFunnelAdditional(long funnelGenId);
        void UpdateFunnelAdditional(SalesFunnelEditFunnelAdditionalElastic salesFunnel);
    }
}
