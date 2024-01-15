using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface ISalesAssignmentLogic
    {
        ResultAction GetSalesData();
        ResultAction Insert(CpSalesAssignment objEntity);
        ResultAction Update(long id, CpSalesAssignment objEntity);
        ResultAction Delete(long id);
    }
}
