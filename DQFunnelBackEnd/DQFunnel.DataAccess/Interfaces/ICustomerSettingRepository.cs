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
        List<CpCustomerSettingDashboard> GetCustomerSettingNamedAccount(string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSettingDashboard> GetCustomerSettingSharebleAccount(string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSettingDashboard> GetCpCustomerSettingAllAccount(string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        CpCustomerSetting GetCustomerSettingBySalesID(long customerID, long SalesID);
        bool UpdateAllCustomerSetting(long id, CpCustomerSetting objEntity);
        bool UpdateSpecificCustomerSetting(long id, CpCustomerSetting objEntity);
        List<CpCustomerSetting> GetCustomerSettingByCustomerID(long customerID);
        bool ApproveCustomerSetting(long customerID, long SalesID);
        bool DeleteCustomerSettingBySalesID(long customerID, long SalesID);
        List<Req_CustomerSettingGetPIC_ViewModel> GetCustomerPICByCustomerID(long customerID);
        List<Req_CustomerSettingGetBrandSummary_ViewModel> GetBrandSummary(long customerID);
        List<Req_CustomerSettingGetServiceSummary_ViewModel> GetServiceSummary(long customerID);
        Req_CustomerSettingGetCustomerDataByID_ViewModel GetCustomerDataByID(long customerID);
        List<Req_CustomerSettingGetProjectHistory_ViewModel> GetProjectHistory(long customerID);
        List<Req_CustomerSettingGetSalesData_ViewModel> GetListSales();
        List<Req_CustomerSettingGetConfigItem_ViewModel> GetConfigItem(long customerID);
        List<Req_CustomerSettingGetCollectionHistory_ViewModel> GetCollectionHistory(long customerID);
        List<Req_CustomerSettingGetSalesData_ViewModel> GetSalesByName(string salesName);
        List<Req_CustomerSettingGetCustomerCategory_ViewModel> GetCustomerCategory();
    }
}
