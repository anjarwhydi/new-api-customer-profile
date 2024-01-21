using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface ISalesHistoryLogic
    {
        ResultAction GetSalesHistoryByCustomerID(long SalesHistoryID);
        ResultAction GetAllSalesHistory();
        ResultAction InsertSalesHistory(CpSalesHistory salesHistory);
        ResultAction UpdateSalesHistory(long SalesHistoryID, CpSalesHistory salesHistory);
        ResultAction DeleteSalesHistory(long SalesHistoryID);
        ResultAction GetAccountOwner(long customerID);
        ResultAction GetSalesAssignHistory(long customerID);
    }
}
