using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface ICustomerSettingLogic
    {
        ResultAction GetAllCustomerSetting();
        ResultAction GetCustomerSettingBySalesID(long customerID, long SalesID);
        Req_CustomerSettingNoNamedAccountEnvelope_ViewModel GetCustomerSettingNoNamedAccount(int page, int pageSize, string column, string sorting, string search, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        CpCustomerSettingEnvelope GetCustomerSettingNamedAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        CpCustomerSettingEnvelope GetCustomerSettingSharebleAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        CpCustomerSettingEnvelope GetCustomerSettingAllAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        ResultAction Insert(Req_CustomerSettingInsertCustomerSetting_ViewModel objEntity);
        ResultAction Update(long id, CpCustomerSetting objEntity);
        ResultAction Delete(long customerID, long SalesID, int ModifyUserID);
        ResultAction GetCustomerPICByCustomerID(long customerID);
        ResultAction GetBrandSummary(long customerID);
        ResultAction GetServiceSummary(long customerID);
        ResultAction GetProjectHistory(long customerID);
        ResultAction GetCustomerDataByID(long customerID);
    }
}
