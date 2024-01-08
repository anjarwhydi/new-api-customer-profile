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
    public class WarrantySupportElasticLogic : IWarrantySupportElasticLogic
    {
        private IUnitOfWork uow;
        private string uri;

        public WarrantySupportElasticLogic(string ES_URI)
        {
            uri = ES_URI;
        }
        public SalesWarrantySupport Get(long funnelGenID)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_WARRANTY_SUPPORT, uri);
            return uow.WarrantySupportElasticRepository.Get(funnelGenID);
        }
    }
}
