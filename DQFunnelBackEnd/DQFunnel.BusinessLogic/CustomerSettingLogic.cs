using DQFunnel.BusinessLogic.Interfaces;
using DQFunnel.BusinessLogic.Services;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.DataAccess;
using DQFunnel.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.BusinessLogic
{
    public class CustomerSettingLogic : ICustomerSettingLogic
    {
        private DapperContext _context;
        private IGenericAPI genericAPI;
        public CustomerSettingLogic(string connectionstring, string apiGateway)
        {
            this._context = new DapperContext(connectionstring);
            genericAPI = new GenericAPI(apiGateway);
        }

        private ResultAction MessageResult(bool bSuccess, string message)
        {
            return MessageResult(bSuccess, message, null);
        }

        private ResultAction MessageResult(bool bSuccess, string message, object objResult)
        {
            ResultAction result = new ResultAction()
            {
                bSuccess = bSuccess,
                ErrorNumber = (bSuccess ? "0" : "666"),
                Message = message,
                ResultObj = objResult
            };

            return result;

        }

        public ResultAction GetAllCustomerSetting()
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetAll();
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction GetCustomerSettingBySalesID(long customerID, long SalesID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCustomerSettingBySalesID(customerID, SalesID);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public CpCustomerSettingEnvelope GetCustomerSettingNoNamedAccount(int page, int pageSize, string column, string sorting, string search, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            CpCustomerSettingEnvelope result = new CpCustomerSettingEnvelope();

            if (sorting != null)
            {
                if (sorting.ToLower() == "descending")
                    sorting = "desc";
                if (sorting.ToLower() == "ascending")
                    sorting = "asc";
            }

            using (_context)
            {
                IUnitOfWork uow = new UnitOfWork(_context);

                var softwareDashboards = uow.CustomerSettingRepository.GetCustomerSettingNoNamedAccount(search, pmoCustomer, blacklist, holdshipment);

                var resultSoftware = new List<CpCustomerSettingDashboard>();

                if (page > 0)
                {
                    var queryable = softwareDashboards.AsQueryable();
                    resultSoftware = queryable
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                }
                else
                {
                    resultSoftware = softwareDashboards;
                }

                result.TotalRows = softwareDashboards.Count();
                result.Column = column;

                if (sorting != null)
                {
                    if (sorting == "desc")
                    {
                        sorting = "descending";
                        result.Rows = resultSoftware.OrderByDescending(x => x.GetType().GetProperty(column).GetValue(x, null)).ToList();
                    }
                    if (sorting == "asc")
                    {
                        sorting = "ascending";
                        result.Rows = resultSoftware.OrderBy(x => x.GetType().GetProperty(column).GetValue(x, null)).ToList();
                    }

                    result.Sorting = sorting;
                }
                else
                {
                    result.Rows = resultSoftware.OrderByDescending(c => c.CreatedDate).ToList();
                }
            }

            return result;
        }

        public CpCustomerSettingEnvelope GetCustomerSettingNamedAccount(int page, int pageSize, string column, string sorting, string search, string salesID, long approvalBy, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            CpCustomerSettingEnvelope result = new CpCustomerSettingEnvelope();

            if (sorting != null)
            {
                if (sorting.ToLower() == "descending")
                    sorting = "desc";
                if (sorting.ToLower() == "ascending")
                    sorting = "asc";
            }

            using (_context)
            {
                IUnitOfWork uow = new UnitOfWork(_context);

                var softwareDashboards = uow.CustomerSettingRepository.GetCustomerSettingNamedAccount(search, salesID, approvalBy, pmoCustomer, blacklist, holdshipment);

                var resultSoftware = new List<CpCustomerSettingDashboard>();

                if (page > 0)
                {
                    var queryable = softwareDashboards.AsQueryable();
                    resultSoftware = queryable
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                }
                else
                {
                    resultSoftware = softwareDashboards;
                }

                result.TotalRows = softwareDashboards.Count();
                result.Column = column;

                if (sorting != null)
                {
                    if (sorting == "desc")
                    {
                        sorting = "descending";
                        result.Rows = resultSoftware.OrderByDescending(x => x.GetType().GetProperty(column).GetValue(x, null)).ToList();
                    }
                    if (sorting == "asc")
                    {
                        sorting = "ascending";
                        result.Rows = resultSoftware.OrderBy(x => x.GetType().GetProperty(column).GetValue(x, null)).ToList();
                    }

                    result.Sorting = sorting;
                }
                else
                {
                    result.Rows = resultSoftware.OrderByDescending(c => c.CreatedDate).ToList();
                }
            }

            return result;
        }

        public CpCustomerSettingEnvelope GetCustomerSettingShareableAccount(int page, int pageSize, string column, string sorting, string search, string salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            CpCustomerSettingEnvelope result = new CpCustomerSettingEnvelope();

            if (sorting != null)
            {
                if (sorting.ToLower() == "descending")
                    sorting = "desc";
                if (sorting.ToLower() == "ascending")
                    sorting = "asc";
            }

            using (_context)
            {
                IUnitOfWork uow = new UnitOfWork(_context);

                var softwareDashboards = uow.CustomerSettingRepository.GetCustomerSettingShareableAccount(search, salesID, pmoCustomer, blacklist, holdshipment);

                var resultSoftware = new List<CpCustomerSettingDashboard>();

                if (page > 0)
                {
                    var queryable = softwareDashboards.AsQueryable();
                    resultSoftware = queryable
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                }
                else
                {
                    resultSoftware = softwareDashboards;
                }

                result.TotalRows = softwareDashboards.Count();
                result.Column = column;

                if (sorting != null)
                {
                    if (sorting == "desc")
                    {
                        sorting = "descending";
                        result.Rows = resultSoftware.OrderByDescending(x => x.GetType().GetProperty(column).GetValue(x, null)).ToList();
                    }
                    if (sorting == "asc")
                    {
                        sorting = "ascending";
                        result.Rows = resultSoftware.OrderBy(x => x.GetType().GetProperty(column).GetValue(x, null)).ToList();
                    }

                    result.Sorting = sorting;
                }
                else
                {
                    result.Rows = resultSoftware.OrderByDescending(c => c.CreatedDate).ToList();
                }
            }

            return result;
        }
        public CpCustomerSettingEnvelope GetCustomerSettingAllAccount(int page, int pageSize, string column, string sorting, string search, string salesID, long approvalBy, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null, bool? showNoName = null, bool? showNamed = null, bool? showShareable = null)
        {
            CpCustomerSettingEnvelope result = new CpCustomerSettingEnvelope();

            if (sorting != null)
            {
                if (sorting.ToLower() == "descending")
                    sorting = "desc";
                if (sorting.ToLower() == "ascending")
                    sorting = "asc";
            }

            using (_context)
            {
                IUnitOfWork uow = new UnitOfWork(_context);

                var noName = (showNoName ?? true) ? uow.CustomerSettingRepository.GetCustomerSettingNoNamedAccount(search, pmoCustomer, blacklist, holdshipment) : new List<CpCustomerSettingDashboard>();
                var Named = (showNamed ?? true) ? uow.CustomerSettingRepository.GetCustomerSettingNamedAccount(search, salesID, approvalBy, pmoCustomer, blacklist, holdshipment) : new List<CpCustomerSettingDashboard>();
                var shareable = (showShareable ?? true) ? uow.CustomerSettingRepository.GetCustomerSettingShareableAccount(search, salesID, pmoCustomer, blacklist, holdshipment) : new List<CpCustomerSettingDashboard>();

                var mergedList = noName.Concat(Named).Concat(shareable).ToList();

                var resultSoftware = new List<CpCustomerSettingDashboard>();

                if (page > 0)
                {
                    var queryable = mergedList.AsQueryable();
                    resultSoftware = queryable
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                }
                else
                {
                    resultSoftware = mergedList;
                }

                result.TotalRows = mergedList.Count();
                result.Column = column;

                if (sorting != null)
                {
                    if (sorting == "desc")
                    {
                        sorting = "descending";
                        result.Rows = resultSoftware.OrderByDescending(x => x.GetType().GetProperty(column).GetValue(x, null)).ToList();
                    }
                    if (sorting == "asc")
                    {
                        sorting = "ascending";
                        result.Rows = resultSoftware.OrderBy(x => x.GetType().GetProperty(column).GetValue(x, null)).ToList();
                    }

                    result.Sorting = sorting;
                }
                else
                {
                    result.Rows = resultSoftware.OrderByDescending(c => c.CreatedDate).ToList();
                }
            }

            return result;
        }

        public ResultAction Insert(CpCustomerSetting objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);

                    var existing = uow.CustomerSettingRepository.GetCustomerSettingByCustomerID(objEntity.CustomerID);

                    CpSalesHistory newSalesHistory = new CpSalesHistory()
                    {
                        SalesID = objEntity.SalesID,
                        CustomerID = objEntity.CustomerID,
                        CreateDate = DateTime.Now,
                        RequestedDate = DateTime.Now,
                        RequestedBy = objEntity.RequestedBy,
                        CreateUserID = objEntity.CreateUserID
                    };

                    if (existing.Count == 0)
                    {
                        CpCustomerSetting newCustomerSetting = new CpCustomerSetting()
                        {
                            CustomerID = objEntity.CustomerID,
                            SalesID = objEntity.SalesID,
                            Named = true,
                            Shareable = false,
                            CreateUserID = objEntity.CreateUserID,
                            CreateDate = DateTime.Now,
                            RequestedBy = objEntity.RequestedBy,
                            RequestedDate = DateTime.Now,
                            PMOCustomer = null
                        };
                        uow.CustomerSettingRepository.Add(newCustomerSetting);
                        newSalesHistory.Status = "Assign";
                        uow.SalesHistoryRepository.Add(newSalesHistory);
                        result = MessageResult(true, "Insert Success!");
                    }
                    else if (existing.Count == 1)
                    {
                        newSalesHistory.Status = "Pending";
                        uow.SalesHistoryRepository.Add(newSalesHistory);
                        result = MessageResult(true, "Wait for Approval!");
                    }
                    else
                    {
                        var customerSetting = existing.FirstOrDefault(x => x.CustomerID == objEntity.CustomerID);
                        CpCustomerSetting newCustomerSetting = new CpCustomerSetting()
                        {
                            CustomerID = objEntity.CustomerID,
                            SalesID = objEntity.SalesID,
                            Named = false,
                            Shareable = true,
                            CreateUserID = customerSetting.CreateUserID,
                            CreateDate = customerSetting.CreateDate,
                            RequestedBy = objEntity.RequestedBy,
                            RequestedDate = DateTime.Now,
                            PMOCustomer = customerSetting.PMOCustomer,
                            ModifyUserID = objEntity.CreateUserID,
                            ModifyDate = DateTime.Now,
                            CustomerCategory = customerSetting.CustomerCategory
                        };
                        uow.CustomerSettingRepository.Add(newCustomerSetting);
                        uow.CustomerSettingRepository.UpdateAllCustomerSetting(objEntity.CustomerID, newCustomerSetting);
                        newSalesHistory.Status = "Assign";
                        uow.SalesHistoryRepository.Add(newSalesHistory);
                        result = MessageResult(true, "Insert Success!");
                    }
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }

            return result;
        }
        public ResultAction ReleaseAccount(long customerID, long salesID, int? modifyUserID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);

                    var existing = uow.CustomerSettingRepository.GetCustomerSettingBySalesID(customerID, salesID);
                    if (existing == null)
                    {
                        return result = MessageResult(false, "Data not found!");
                    }

                    var salesHistory = uow.SalesHistoryRepository.GetAll().FirstOrDefault(x => x.CustomerID == customerID && x.SalesID == salesID && x.Status == "Assign");
                    salesHistory.Status = "Release";
                    salesHistory.ModifyUserID = modifyUserID;
                    salesHistory.ModifyDate = DateTime.Now;
                    uow.SalesHistoryRepository.Update(salesHistory);

                    uow.CustomerSettingRepository.DeleteCustomerSettingBySalesID(customerID, salesID);

                    var listCustomerSetting = uow.CustomerSettingRepository.GetCustomerSettingByCustomerID(customerID);
                    if (listCustomerSetting.Count > 0)
                    {
                        var cs = listCustomerSetting.First();
                        cs.Named = true;
                        cs.Shareable = false;
                        cs.ModifyDate = existing.ModifyDate;
                        cs.ModifyUserID = modifyUserID;
                        uow.CustomerSettingRepository.UpdateAllCustomerSetting(customerID, cs);
                    }

                    result = MessageResult(true, "Update Success!");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction ApproveCustomerSetting(long customerID, long salesID, bool isApprove, int? modifyUserID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.SalesHistoryRepository.GetAll().FirstOrDefault(x => x.CustomerID == customerID && x.SalesID == salesID);
                    if (existing == null)
                    {
                        return MessageResult(false, "Data not found!");
                    }
                    if (!isApprove)
                    {
                        existing.Status = "Rejected";
                    }
                    else
                    {
                        existing.Status = "Assign";
                        var customerSetting = uow.CustomerSettingRepository.GetAll().FirstOrDefault(x => x.CustomerID == customerID);
                        CpCustomerSetting newCustomerSetting = new CpCustomerSetting()
                        {
                            CustomerID = existing.CustomerID,
                            SalesID = existing.SalesID,
                            Named = false,
                            Shareable = true,
                            CreateUserID = customerSetting.CreateUserID,
                            CreateDate = customerSetting.CreateDate,
                            RequestedBy = existing.RequestedBy,
                            RequestedDate = existing.RequestedDate,
                            PMOCustomer = customerSetting.PMOCustomer,
                            ModifyUserID = modifyUserID,
                            ModifyDate = DateTime.Now,
                            CustomerCategory = customerSetting.CustomerCategory
                        };
                        uow.CustomerSettingRepository.Add(newCustomerSetting);
                        uow.CustomerSettingRepository.UpdateAllCustomerSetting(customerID, newCustomerSetting);
                    }
                    existing.ModifyUserID = modifyUserID;
                    existing.ModifyDate = DateTime.Now;
                    uow.SalesHistoryRepository.Update(existing);
                    result = MessageResult(true, "Success!");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction GetCustomerPICByCustomerID(long customerID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCustomerPICByCustomerID(customerID);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction GetBrandSummary(long customerID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetBrandSummary(customerID);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction GetServiceSummary(long customerID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetServiceSummary(customerID);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction GetProjectHistory(long customerID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetProjectHistory(customerID);
                    List<Req_CustomerSettingGetProjectHistoryEnvelope_ViewModel> project = existing.Select(item => new Req_CustomerSettingGetProjectHistoryEnvelope_ViewModel
                    {
                        FunnelID = item.FunnelID,
                        SO = item.SO,
                        ProjectName = item.ProjectName,
                        CustomerName = item.CustomerName,
                        SalesName = item.SalesName,
                        SalesDept = item.SalesDept,
                        SOCloseDate = item.SOCloseDate,
                        SOAmount = item.SOAmount,
                        SuccessStory = item.SuccessStory,
                        ModifiedStoryBy = uow.CustomerSuccessStoryRepository.GetCustomerStoriesByCustomerID(item.FunnelID).ToList()
                    }).ToList();
                    result = MessageResult(true, "Success", project);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }

        public ResultAction GetCustomerDataByID(long customerID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCustomerDataByID(customerID);
                    if (existing == null)
                    {
                        return result = MessageResult(false, "Data not found!");
                    }
                    Req_CustomerSettingCustomerDataEnvelope_ViewModel envelope = new Req_CustomerSettingCustomerDataEnvelope_ViewModel();
                    envelope.AccountStatus = existing.AccountStatus;
                    envelope.CustomerID = existing.CustomerID;
                    envelope.CustomerName = existing.CustomerName;
                    envelope.AvgAR = existing.AvgAR;
                    envelope.PMOCustomer = existing.PMOCustomer;
                    envelope.Holdshipment = existing.Holdshipment;
                    envelope.Blacklist = existing.Blacklist;
                    envelope.SalesName = existing.SalesName;
                    envelope.CustomerAddress = existing.CustomerAddress;
                    envelope.CustomerCategory = existing.CustomerCategory;
                    var shareable = uow.SalesHistoryRepository.GetShareableStatus(customerID);
                    envelope.ShareableApprovalStatus = shareable;
                    result = MessageResult(true, "Success", envelope);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction GetSalesData()
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetListSales();
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction GetCustomerCategory()
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCustomerCategory();
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction GetConfigItem(long customerID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetConfigItem(customerID);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction GetCollectionHistory(long customerID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCollectionHistory(customerID);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction GetSalesByName(string salesName)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetSalesByName(salesName);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction GetCustomerName(string customerName)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCustomerByName(customerName);
                    result = MessageResult(true, "Success", existing);
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction Update(long customerID, CpCustomerSetting objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    objEntity.ModifyDate = DateTime.Now;
                    var existing = uow.CustomerSettingRepository.UpdateSpecificCustomerSetting(customerID, objEntity);
                    result = MessageResult(true, "Update Success!");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
    }
}
