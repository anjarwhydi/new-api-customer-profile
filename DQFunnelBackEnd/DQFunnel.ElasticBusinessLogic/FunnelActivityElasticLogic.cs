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
    public class FunnelActivityElasticLogic : IFunnelActivityElasticLogic
    {
        private IUnitOfWork uow;
        private string uri;

        public FunnelActivityElasticLogic(string ES_URI)
        {
            uri = ES_URI;
        }
        public List<FunnelActivityDashboard> Search(string text)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL_ACTIVITY, uri);
            return uow.FunnelActivityElasticRepository.Search(text);
        }
    }
}
