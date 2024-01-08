
using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic.Interfaces
{
    public interface IBankGuaranteeElasticLogic
    {
        List<SalesBankGuaranteeElastic> GetAll();
        SalesBankGuaranteeElastic GetbyFunnelGenID(long funnelGenID);
        SalesBankGuaranteeElastic GetbyBGID(long bgID);
    }
}
