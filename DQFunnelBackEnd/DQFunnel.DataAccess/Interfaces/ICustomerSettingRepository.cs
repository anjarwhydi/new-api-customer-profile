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
    }
}
