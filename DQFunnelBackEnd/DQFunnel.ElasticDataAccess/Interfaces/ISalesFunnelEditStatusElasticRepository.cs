using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface ISalesFunnelEditStatusElasticRepository : IElasticRepository<FunnelElastic>
    {
        void UpdateStatus(SalesFunnelEditStatusElastic salesFunnel);
        IEnumerable<SalesFunnelEditStatusElastic> GetViewFunnelStatusByFunnelGenID(long FunnelGenID);
    }
}
