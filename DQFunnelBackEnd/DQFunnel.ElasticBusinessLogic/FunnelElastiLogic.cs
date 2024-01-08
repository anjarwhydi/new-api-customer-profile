using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.ElasticBusinessLogic.Interfaces;
using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticBusinessObject.Common;
using DQFunnel.ElasticDataAccess;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace DQFunnel.ElasticBusinessLogic
{
    public class FunnelElastiLogic : IFunnelElasticLogic
    {
        private IUnitOfWork uow;
        private string uri;

        public FunnelElastiLogic(string ES_URI)
        {
            uri = ES_URI;
        }

        public List<FunnelDashboard> FilterSearch(Get_SalesFunnelFilterSearch_ViewModel obj)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.FunnelElasticRepository.FilterSearch(obj);
        }

        public FunnelElastic GetByFunnelGenId(long funnelGenId)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.FunnelElasticRepository.GetbyFunnelGenID(funnelGenId);
        }

        public FunnelElastic GetById(string id)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.FunnelElasticRepository.QueryById(id);
        }

        public List<FunnelCustomerElastic> GetCustomerBySalesID(int salesID)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.FunnelElasticRepository.GetListCustomerBySalesID(salesID);
        }

        public List<FunnelElastic> GetListAll()
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.FunnelElasticRepository.QueryAll();
        }

        public List<FunnelDashboard> GetListBySalesID(int salesID)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.FunnelElasticRepository.GetListBySalesID(salesID);
        }

        public string Save(FunnelElastic entity)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            if (uow.FunnelElasticRepository.Index(entity))
                return "Index Success";
            return "Index Failed";
        }

        public List<FunnelDashboard> Search(string text)
        {
            uow = new UnitOfWork(IndexNameConst.SALES_FUNNEL, uri);
            return uow.FunnelElasticRepository.Search(text);
        }
    }
}
