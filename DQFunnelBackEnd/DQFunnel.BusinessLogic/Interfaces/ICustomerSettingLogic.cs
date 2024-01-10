using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface ICustomerSettingLogic
    {
        Req_CustomerSettingNoNamedAccountEnvelope_ViewModel GetCustomerSettingNoNamedAccount(int page, int pageSize, string column, string sorting, string search, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        CpCustomerSettingEnvelope GetCustomerSettingNamedAccount(int page, int pageSize, string column, string sorting, string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
    }
}
