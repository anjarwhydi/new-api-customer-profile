using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface ISalesAssignmentLogic
    {
        ResultAction GetSalesData();
        ResultAction GetSalesAssignment();
        ResultAction InsertSalesAssignment(CpSalesAssignment objEntity);
        ResultAction UpdateSalesAssignment(long Id, CpSalesAssignment objEntity);
        ResultAction DeleteSalesAssignment(long Id);
    }
}
