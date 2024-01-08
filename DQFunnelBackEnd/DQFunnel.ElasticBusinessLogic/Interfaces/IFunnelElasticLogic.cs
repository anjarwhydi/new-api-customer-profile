
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic.Interfaces
{
    public interface IFunnelElasticLogic
    {
        string Save(FunnelElastic entity);
        FunnelElastic GetById(string id);
        List<FunnelElastic> GetListAll();
        List<FunnelDashboard> GetListBySalesID(int salesID);
        List<FunnelCustomerElastic> GetCustomerBySalesID(int salesID);
        FunnelElastic GetByFunnelGenId(long funnelGenId);
        List<FunnelDashboard> FilterSearch(Get_SalesFunnelFilterSearch_ViewModel obj);
        List<FunnelDashboard> Search(string text);
    }
}
