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

        public CpCustomerSettingEnvelope GetCustomerSettingNamedAccount(int page, int pageSize, string column, string sorting, string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
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

                var softwareDashboards = uow.CustomerSettingRepository.GetCustomerSettingNamedAccount(search, salesName, pmoCustomer, blacklist, holdshipment);

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
    }
}
