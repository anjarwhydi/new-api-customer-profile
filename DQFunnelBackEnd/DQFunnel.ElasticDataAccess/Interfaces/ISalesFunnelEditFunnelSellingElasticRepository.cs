using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface ISalesFunnelEditFunnelSellingElasticRepository : IElasticRepository<FunnelElastic>
    {
        void UpdateFunnelSelling(SalesFunnelEditSellingElastic salesFunnel);
        IEnumerable<SalesFunnelEditSellingElastic> GetViewFunnelSelling(long funnelGenId);
    }
}
