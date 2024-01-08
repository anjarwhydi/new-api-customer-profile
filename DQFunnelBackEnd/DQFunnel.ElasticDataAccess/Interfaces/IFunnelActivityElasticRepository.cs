using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface IFunnelActivityElasticRepository : IElasticRepository<SalesFunnelActivityElastic>
    {
        List<FunnelActivityDashboard> Search(string text);
    }
}
