using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface ISalesAssignmentRepository : IRepository<CpSalesAssignment>
    {
        List<Req_CustomerSettingGetSalesData_ViewModel> GetListSales();
        CpSalesAssignment GetSalesAssignmentById(long Id);

    }
}
