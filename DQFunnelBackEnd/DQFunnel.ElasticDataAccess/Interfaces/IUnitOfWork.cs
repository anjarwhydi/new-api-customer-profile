using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ISalesFunnelEditCustomerElasticRepository SalesFunnelEditCustomerElasticRepository { get; }
        ISalesFunnelEditFunnelAdditionalElasticRepository SalesFunnelEditFunnelAdditionalElasticRepository { get; }
        ISalesFunnelEditFunnelSellingElasticRepository SalesFunnelEditFunnelSellingElasticRepository { get; }
        ISalesFunnelEditPOElasticRepository SalesFunnelEditPOElasticRepository { get; }
        ISalesFunnelEditProductServiceElasticRepository SalesFunnelEditProductServiceElasticRepository { get; }
        ISalesFunnelEditStatusElasticRepository SalesFunnelEditStatusElasticRepository { get; }
        IBankGuaranteeElasticRepository BankGuaranteeElasticRepository { get; }
        IFunnelElasticRepository FunnelElasticRepository { get; }
        //IFileFunnelElasticRepository FileFunnelElasticRepository { get; }
        IFunnelActivityElasticRepository FunnelActivityElasticRepository { get; }
        IFunnelItemsElasticRepository FunnelItemsElasticRepository { get; }
        IWarrantySupportElasticRepository WarrantySupportElasticRepository { get; }
        IWarrantySLAElasticRepository WarrantySLAElasticRepository { get; }
    }
}
