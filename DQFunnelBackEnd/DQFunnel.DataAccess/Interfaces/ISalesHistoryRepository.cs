using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface ISalesHistoryRepository : IRepository<CpSalesHistory>
    {
        CpSalesHistory GetSalesHistoryByCustomerID(long SalesHistoryID);
        List<Req_CustomerSettingShareableApprovalStatus_ViewModel> GetShareableStatus(long customerID);
        List<Req_CustomerSettingGetAccountOwner_ViewModel> GetAccountOwner(long customerID);
        List<Req_CustomerSettingGetSalesAssignHistory_ViewModel> GetSalesAssignHistory(long customerID);
    }
}
