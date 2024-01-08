using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface IBankGuaranteeElasticRepository : IElasticRepository<SalesBankGuaranteeElastic>
    {
        SalesBankGuaranteeElastic GetByFunnelGenID(long funnelGenID);
        SalesBankGuaranteeElastic GetByBGID(long bgID);
        bool Delete(long bgID);
    }
}
