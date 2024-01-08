using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic.Interfaces
{
    public interface IFunnelItemsElasticLogic
    {
        List<SalesFunnelItems> GetByFunnelGenID(long funnelGenID);
    }
}
