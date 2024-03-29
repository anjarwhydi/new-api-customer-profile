﻿using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface ICustomerSettingRepository : IRepository<CpCustomerSetting>
    {
        List<CpCustomerSettingDashboard> GetCustomerSettingNoNamedAccount(string search, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSettingDashboard> GetCustomerSettingNamedAccount(string search, string salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSettingDashboard> GetCustomerSettingShareableAccount(string search, string salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        List<CpCustomerSettingDashboard> GetCustomerSettingAllAccount(string search, string salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null);
        CpCustomerSetting GetCustomerSettingBySalesID(long customerID, long SalesID);
        bool UpdateAllCustomerSetting(long id, CpCustomerSetting objEntity);
        List<CpCustomerSetting> GetCustomerSettingByCustomerID(long customerID);
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
        List<string> GetCustomerCategory();
        bool UpdateSpecificCustomerSetting(long id, CpCustomerSetting objEntity);
        List<Req_CustomerSettingGetCustomerDataByName_ViewModel> GetCustomerByName(string customerName);
        long GetApprovalID();
        List<Req_CustomerSettingGetRelatedCustomerAndLastProject_ViewModel> GetRelatedAndLast();
    }
}
