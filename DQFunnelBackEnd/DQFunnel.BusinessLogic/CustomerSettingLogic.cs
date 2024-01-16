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

        public Req_CustomerSettingNoNamedAccountEnvelope_ViewModel GetCustomerSettingNoNamedAccount(int page, int pageSize, string column, string sorting, string search, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            Req_CustomerSettingNoNamedAccountEnvelope_ViewModel result = new Req_CustomerSettingNoNamedAccountEnvelope_ViewModel();

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

                var resultSoftware = new List<Req_CustomerSettingNoNamedAccount_ViewModel>();

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

        public CpCustomerSettingEnvelope GetCustomerSettingNamedAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
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

                var softwareDashboards = uow.CustomerSettingRepository.GetCustomerSettingNamedAccount(search, salesID, pmoCustomer, blacklist, holdshipment);

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

        public CpCustomerSettingEnvelope GetCustomerSettingSharebleAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
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

                var softwareDashboards = uow.CustomerSettingRepository.GetCustomerSettingSharebleAccount(search, salesID, pmoCustomer, blacklist, holdshipment);

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
        public CpCustomerSettingEnvelope GetCustomerSettingAllAccount(int page, int pageSize, string column, string sorting, string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
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

                var softwareDashboards = uow.CustomerSettingRepository.GetCpCustomerSettingAllAccount(search, salesID, pmoCustomer, blacklist, holdshipment);

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

        public ResultAction Insert(CpCustomerSetting objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCustomerSettingByCustomerID(objEntity.CustomerID);
                    CpCustomerSetting newCustomerSetting = new CpCustomerSetting();
                    var findCustomerSetting = existing.FirstOrDefault(x => x.Status == "approve");
                    if (existing.Count == 0 && findCustomerSetting == null)
                    {
                        newCustomerSetting.CustomerID = objEntity.CustomerID;
                        newCustomerSetting.SalesID = objEntity.SalesID;
                        newCustomerSetting.Named = true;
                        newCustomerSetting.Shareable = false;
                        newCustomerSetting.Status = "approve";
                        newCustomerSetting.CreateUserID = objEntity.CreateUserID;
                        newCustomerSetting.CreateDate = DateTime.Now;
                        newCustomerSetting.RequestedBy = objEntity.RequestedBy;
                        newCustomerSetting.RequestedDate = DateTime.Now;
                        newCustomerSetting.PMOCustomer = false;
                        newCustomerSetting.ModifyDate = null;
                        newCustomerSetting.ModifyUserID = null;
                    }
                    if (findCustomerSetting != null)
                    {
                        findCustomerSetting.Shareable = true;
                        findCustomerSetting.Named = false;
                        findCustomerSetting.ModifyUserID = objEntity.ModifyUserID;
                        findCustomerSetting.ModifyDate = DateTime.Now;
                        uow.CustomerSettingRepository.UpdateAllCustomerSetting(objEntity.CustomerID, findCustomerSetting);

                        newCustomerSetting.CustomerID = findCustomerSetting.CustomerID;
                        newCustomerSetting.SalesID = objEntity.SalesID;
                        newCustomerSetting.CreateDate = findCustomerSetting.CreateDate;
                        newCustomerSetting.CreateUserID = findCustomerSetting.CreateUserID;
                        newCustomerSetting.PMOCustomer = findCustomerSetting.PMOCustomer;
                        newCustomerSetting.Status = "waiting";
                        newCustomerSetting.Named = findCustomerSetting.Named;
                        newCustomerSetting.Shareable = findCustomerSetting.Shareable;
                        newCustomerSetting.RequestedBy = objEntity.RequestedBy;
                        newCustomerSetting.RequestedDate = DateTime.Now;
                        newCustomerSetting.ModifyUserID = findCustomerSetting.ModifyUserID;
                        newCustomerSetting.ModifyDate = findCustomerSetting.ModifyDate;
                        uow.CustomerSettingRepository.Add(newCustomerSetting);
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
                    existing.Status = "release";
                    existing.ModifyDate = DateTime.Now;
                    existing.ModifyUserID = modifyUserID;
                    var listCustomerSetting = uow.CustomerSettingRepository.GetCustomerSettingByCustomerID(customerID).FirstOrDefault(x => x.Status == "approve");
                    if (listCustomerSetting != null)
                    {
                        listCustomerSetting.Named = true;
                        listCustomerSetting.Shareable = false;
                        listCustomerSetting.ModifyDate = existing.ModifyDate;
                        listCustomerSetting.ModifyUserID = modifyUserID;
                        existing.Named = true;
                        existing.Shareable = false;
                        uow.CustomerSettingRepository.UpdateAllCustomerSetting(customerID, listCustomerSetting);
                    }
                    uow.CustomerSettingRepository.UpdateSpecificCustomerSetting(customerID, existing);
                    result = MessageResult(true, "Update Success!");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction Update(long id, CpCustomerSetting objEntity)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCustomerSettingByCustomerID(id);
                    if (existing == null)
                    {
                        return result = MessageResult(false, "Data not found!");
                    }
                    uow.CustomerSettingRepository.UpdateAllCustomerSetting(id, objEntity);
                    result = MessageResult(true, "Update Success!");
                }
            }
            catch (Exception ex)
            {
                result = MessageResult(false, ex.Message);
            }
            return result;
        }
        public ResultAction Delete(long customerID, long SalesID, int ModifyUserID)
        {
            ResultAction result = new ResultAction();
            try
            {
                using (_context)
                {
                    IUnitOfWork uow = new UnitOfWork(_context);
                    var existing = uow.CustomerSettingRepository.GetCustomerSettingByCustomerID(customerID);
                    if (existing == null)
                    {
                        return result = MessageResult(false, "Data not found!");
                    }
                    uow.CustomerSettingRepository.DeleteCustomerSettingBySalesID(customerID, SalesID);
                    result = MessageResult(true, "Delete Success!");
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
                    result = MessageResult(true, "Success", existing);
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
                    result = MessageResult(true, "Success", existing);
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
