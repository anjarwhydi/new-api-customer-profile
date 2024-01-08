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
    public class WarrantySLAElasticLogic : IWarrantySLAElasticLogic
    {
        private IUnitOfWork uow;
        private string uri;

        public WarrantySLAElasticLogic(string ES_URI)
        {
            uri = ES_URI;
        }

        public SalesWarrantySLA Get(long supportID)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_WARRANTY_SLA, uri);
            return uow.WarrantySLAElasticRepository.Get(supportID);
        }
    }
}
