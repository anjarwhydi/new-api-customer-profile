using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface IFunnelElasticRepository : IElasticRepository<FunnelElastic>
    {
        List<FunnelDashboard> GetListBySalesID(int salesID);
        List<FunnelCustomerElastic> GetListCustomerBySalesID(int salesID);
        FunnelElastic GetbyFunnelGenID(long funnelGenID);
        List<FunnelDashboard> FilterSearch(Get_SalesFunnelFilterSearch_ViewModel obj);
        List<FunnelDashboard> Search(string text);
    }
}
