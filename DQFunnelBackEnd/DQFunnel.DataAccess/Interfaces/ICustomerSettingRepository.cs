using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface ICustomerSettingRepository : IRepository<CpCustomerSetting>
    {
        List<Req_CustomerSettingNoNamedAccount_ViewModel> GetCustomerSettingNoNamedAccount(string search, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSettingDashboard> GetCustomerSettingNamedAccount(string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSettingDashboard> GetCustomerSettingSharebleAccount(string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSettingDashboard> GetCpCustomerSettingAllAccount(string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSetting> GetCustomerSettingBySalesID(long customerID, long SalesID);
        bool UpdateCustomerSetting(long id, CpCustomerSetting objEntity);
        bool ApproveSalesAssignment(long sAssignmentID, int modifyUserID);
        CpCustomerSetting GetCustomerSettingByCustomerID(long customerID);
        CpSalesAssignment GetSalesAssignmentById(long Id);
        bool DeleteCustomerSettingBySalesID(long customerID, long SalesID);
    }
}
