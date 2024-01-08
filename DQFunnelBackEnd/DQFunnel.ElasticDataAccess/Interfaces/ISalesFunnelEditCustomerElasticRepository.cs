using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface ISalesFunnelEditCustomerElasticRepository : IElasticRepository<FunnelElastic>
    {
        IEnumerable<SalesFunnelEditCustomerElastic> GetViewFunnelCustomerByFunnelGenID(long funnelGenID);
        void UpdateCustomer(SalesFunnelEditCustomerElastic salesFunnel);
    }
}
