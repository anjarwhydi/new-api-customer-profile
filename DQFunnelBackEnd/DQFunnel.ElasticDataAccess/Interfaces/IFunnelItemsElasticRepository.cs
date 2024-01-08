using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface IFunnelItemsElasticRepository : IElasticRepository<SalesFunnelItemsElastic>
    {
        List<SalesFunnelItems> GetByFunnelGenID(long funnelGenID);
    }
}
