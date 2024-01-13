using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject.ViewModel;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface ISalesAssignmentRepository
    {
        List<Req_CustomerSettingGetSalesData_ViewModel> GetListSales();
    }
}
