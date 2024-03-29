﻿using Dapper;
using DapperExtensions;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DQFunnel.DataAccess.Repositories
{
    public class CustomerSettingRepository : Repository<CpCustomerSetting>, ICustomerSettingRepository
    {
        private IDapperContext _context;
        private IDbTransaction _transaction;
        private string _sql;
        public CustomerSettingRepository(IDbTransaction transaction, IDapperContext context) : base(transaction, context)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public List<CpCustomerSettingDashboard> GetCustomerSettingNoNamedAccount(string search, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingNoNamedAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);

            var output = _context.db.Query<CpCustomerSettingDashboard>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }

        public List<CpCustomerSettingDashboard> GetCustomerSettingNamedAccount(string search, string salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingNamedAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);
            vParams.Add("@SalesIDs", salesID);

            var output = _context.db.Query<CpCustomerSettingDashboard>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<CpCustomerSettingDashboard> GetCustomerSettingShareableAccount(string search, string salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingShareableAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);
            vParams.Add("@SalesIDs", salesID);

            var output = _context.db.Query<CpCustomerSettingDashboard>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<CpCustomerSettingDashboard> GetCustomerSettingAllAccount(string search, string salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingAllAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);
            vParams.Add("@SalesIDs", salesID);

            var output = _context.db.Query<CpCustomerSettingDashboard>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public bool UpdateAllCustomerSetting(long id, CpCustomerSetting objEntity)
        {
            _sql = "[cp].[spUpdateCustomerSetting]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerID", id);
            vParams.Add("@Named", objEntity.Named);
            vParams.Add("@Shareable", objEntity.Shareable);
            vParams.Add("@PMOCustomer", objEntity.PMOCustomer);
            vParams.Add("@ModifyDate", objEntity.ModifyDate);
            vParams.Add("@ModifyUserID", objEntity.ModifyUserID);
            vParams.Add("@Category", objEntity.CustomerCategory);
            var output = _context.db.Execute(_sql, param: vParams, transaction: _transaction, commandTimeout: null, commandType: CommandType.StoredProcedure);
            return output == 1 ? true : false;
        }
        public List<CpCustomerSetting> GetCustomerSettingByCustomerID(long customerID)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<CpCustomerSetting>(c => c.CustomerID, Operator.Eq, customerID));
            return _context.db.GetList<CpCustomerSetting>(pg).ToList();
        }


        public CpCustomerSetting GetCustomerSettingBySalesID(long customerID, long salesID)
        {
            _sql = "SELECT * FROM OMSPROD.cp.CustomerSetting WHERE CustomerID = @CustomerID AND SalesID = @SalesID";

            var parameters = new { CustomerID = customerID, SalesID = salesID };

            var output = _context.db.Query<CpCustomerSetting>(_sql, parameters, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.Text).FirstOrDefault();

            return output;
        }
        public bool DeleteCustomerSettingBySalesID(long customerID, long SalesID)
        {
            try
            {
                _sql = "DELETE FROM OMSPROD.cp.CustomerSetting WHERE CustomerID = @CustomerID AND SalesID = @SalesID";

                var parameters = new { CustomerID = customerID, SalesID = SalesID };

                var affectedRows = _context.db.Execute(_sql, parameters, transaction: _transaction, commandTimeout: null, commandType: CommandType.Text);

                return affectedRows > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateSpecificCustomerSetting(long id, CpCustomerSetting objEntity)
        {
            _sql = "[cp].[spUpdateCustomerSettingPMOCustomerCategory]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerID", id);
            vParams.Add("@PMOCustomer", objEntity.PMOCustomer);
            vParams.Add("@ModifyDate", objEntity.ModifyDate);
            vParams.Add("@ModifyUserID", objEntity.ModifyUserID);
            vParams.Add("@Category", objEntity.CustomerCategory);
            var output = _context.db.Execute(_sql, param: vParams, transaction: _transaction, commandTimeout: null, commandType: CommandType.StoredProcedure);
            return output == 1 ? true : false;
        }


        public List<Req_CustomerSettingGetPIC_ViewModel> GetCustomerPICByCustomerID(long customerID)
        {
            _sql = "[cp].[spGetCustomerPICByCustomerID]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerID", customerID);
            var output = _context.db.Query<Req_CustomerSettingGetPIC_ViewModel>(_sql, param: (object)vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }

        public List<Req_CustomerSettingGetBrandSummary_ViewModel> GetBrandSummary(long customerID)
        {
            _sql = "[cp].[spGetBrandSummary]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerIDC", customerID);
            var output = _context.db.Query<Req_CustomerSettingGetBrandSummary_ViewModel>(_sql, param: (object)vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }

        public List<Req_CustomerSettingGetServiceSummary_ViewModel> GetServiceSummary(long customerID)
        {
            _sql = "[cp].[spGetServiceSummary]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerIDC", customerID);
            var output = _context.db.Query<Req_CustomerSettingGetServiceSummary_ViewModel>(_sql, param: (object)vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }

        public Req_CustomerSettingGetCustomerDataByID_ViewModel GetCustomerDataByID(long customerID)
        {
            _sql = "[cp].[spGetCustomerDataByID]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerID", customerID);
            var output = _context.db.Query<Req_CustomerSettingGetCustomerDataByID_ViewModel>(
                _sql,
                param: vParams,
                transaction: _transaction,
                buffered: false,
                commandTimeout: null,
                commandType: CommandType.StoredProcedure
            ).SingleOrDefault();

            return output;
        }
        public long GetApprovalID()
        {
            _sql = "[cp].[spGetApproverShareableAccount]";
            var output = _context.db.Query<long>(_sql, param: null, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return output;
        }
        public List<Req_CustomerSettingGetProjectHistory_ViewModel> GetProjectHistory(long customerID)
        {
            _sql = "[cp].[spGetProjectHistory]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerIDC", customerID);
            var output = _context.db.Query<Req_CustomerSettingGetProjectHistory_ViewModel>(_sql, param: (object)vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<Req_CustomerSettingGetSalesData_ViewModel> GetListSales()
        {
            _sql = "[cp].[spGetSalesData]";
            var output = _context.db.Query<Req_CustomerSettingGetSalesData_ViewModel>(_sql, param: null, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }

        public List<Req_CustomerSettingGetConfigItem_ViewModel> GetConfigItem(long customerID)
        {
            _sql = "[cp].[spGetConfigItem]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerID", customerID);
            var output = _context.db.Query<Req_CustomerSettingGetConfigItem_ViewModel>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<Req_CustomerSettingGetCollectionHistory_ViewModel> GetCollectionHistory(long customerID)
        {
            _sql = "[cp].[spGetCustomerCollectionsHistory]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerID", customerID);
            var output = _context.db.Query<Req_CustomerSettingGetCollectionHistory_ViewModel>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<Req_CustomerSettingGetSalesData_ViewModel> GetSalesByName(string salesName)
        {
            _sql = "[cp].[spSearchSalesName]";
            var vParams = new DynamicParameters();
            vParams.Add("@Search", salesName);
            var output = _context.db.Query<Req_CustomerSettingGetSalesData_ViewModel>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<string> GetCustomerCategory()
        {
            _sql = "[cp].[spGetCustomerCategory]";
            var output = _context.db.Query<string>(_sql, param: null, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<Req_CustomerSettingGetCustomerDataByName_ViewModel> GetCustomerByName(string customerName)
        {
            _sql = "[cp].[spSearchCustomerName]";
            var vParams = new DynamicParameters();
            vParams.Add("@Search", customerName);
            var output = _context.db.Query<Req_CustomerSettingGetCustomerDataByName_ViewModel>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<Req_CustomerSettingGetRelatedCustomerAndLastProject_ViewModel> GetRelatedAndLast()
        {
            _sql = "[cp].[spGetRelatedAndLastProject]";
            var output = _context.db.Query<Req_CustomerSettingGetRelatedCustomerAndLastProject_ViewModel>(_sql, param: null, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
    }
}
