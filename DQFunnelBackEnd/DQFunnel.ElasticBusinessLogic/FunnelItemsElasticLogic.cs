using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessLogic.Interfaces;
using DQFunnel.ElasticBusinessObject.Common;
using DQFunnel.ElasticDataAccess;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic
{
    public class FunnelItemsElasticLogic : IFunnelItemsElasticLogic
    {
        private IUnitOfWork uow;
        private string uri;

        public FunnelItemsElasticLogic(string ES_URI)
        {
            uri = ES_URI;
        }

        public List<SalesFunnelItems> GetByFunnelGenID(long funnelGenID)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL_ITEMS, uri);
            return uow.FunnelItemsElasticRepository.GetByFunnelGenID(funnelGenID);
        }
    }
}
