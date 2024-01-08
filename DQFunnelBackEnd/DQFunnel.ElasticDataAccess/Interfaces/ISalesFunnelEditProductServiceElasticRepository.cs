using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface ISalesFunnelEditProductServiceElasticRepository : IElasticRepository<FunnelElastic>
    {
        void UpdateProductService(SalesFunnelEditProductServiceElastic salesFunnel);
    }
}
