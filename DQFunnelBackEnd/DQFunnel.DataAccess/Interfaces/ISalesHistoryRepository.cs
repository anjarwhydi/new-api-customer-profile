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
        Req_CustomerSettingShareableApprovalStatus_ViewModel GetShareableStatus(long customerID);
    }
}
