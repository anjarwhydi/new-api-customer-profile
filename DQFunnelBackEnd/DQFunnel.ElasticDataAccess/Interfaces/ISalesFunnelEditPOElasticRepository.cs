using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface ISalesFunnelEditPOElasticRepository : IElasticRepository<FunnelElastic>
    {
        IEnumerable<SalesFunnelEditPOElastic> GetViewFunnelPOByFunnelGenID(long funnelGenID);
        void UpdateFunnelPO(SalesFunnelEditPOElastic salesFunnel);
    }
}
