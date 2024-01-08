using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic.Interfaces
{
    public interface IFunnelViewEditElasticLogic
    {
        ResultAction UpdateStatus(SalesFunnelEditStatusElastic objEntity);
        ResultAction UpdateCustomer(SalesFunnelEditCustomerElastic objEntity);
        ResultAction UpdateProductService(SalesFunnelEditProductServiceElastic objEntity);
        ResultAction UpdateFunnelAdditional(SalesFunnelEditFunnelAdditionalElastic objEntity);
        ResultAction UpdateFunnelSelling(SalesFunnelEditSellingElastic objEntity);
        ResultAction UpdateFunnelPO(SalesFunnelEditPOElastic objEntity);


        IEnumerable<SalesFunnelEditFunnelAdditionalElastic> GetViewFunnelAdditionalByFunnelGenID(long funnelGenId);
        IEnumerable<SalesFunnelEditPOElastic> GetViewFunnelPOByFunnelGenID(long funnelGenId);
        IEnumerable<SalesFunnelEditStatusElastic> GetViewFunnelStatusByFunnelGenID(long funnelGenId);
        IEnumerable<SalesFunnelEditCustomerElastic> GetViewFunnelCustomerByFunnelGenID(long funnelGenId);
        IEnumerable<SalesFunnelEditSellingElastic> GetViewFunnelSellingByFunnelGenID(long funnelGenId);
    }
}
