using Dapper;
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

        public List<Req_CustomerSettingNoNamedAccount_ViewModel> GetCustomerSettingNoNamedAccount(string search, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingNoNamedAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);

            var output = _context.db.Query<Req_CustomerSettingNoNamedAccount_ViewModel>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }

        public List<CpCustomerSettingDashboard> GetCustomerSettingNamedAccount(string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingNamedAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);
            vParams.Add("@SalesID", salesID);

            var output = _context.db.Query<CpCustomerSettingDashboard>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<CpCustomerSettingDashboard> GetCustomerSettingSharebleAccount(string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingSharebleAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);
            vParams.Add("@SalesID", salesID);

            var output = _context.db.Query<CpCustomerSettingDashboard>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<CpCustomerSettingDashboard> GetCpCustomerSettingAllAccount(string search, long? salesID, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingAllAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);
            vParams.Add("@SalesID", salesID);

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
            vParams.Add("@ModifyDate", DateTime.Now);
            vParams.Add("@ModifyUserID", objEntity.ModifyUserID);
            vParams.Add("@Status", objEntity.Status);
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
        public CpSalesAssignment GetSalesAssignmentById(long Id)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<CpSalesAssignment>(c => c.SAssignmentID, Operator.Eq, Id));
            return _context.db.GetList<CpSalesAssignment>(pg).FirstOrDefault();
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
            try
            {
                _sql = "UPDATE OMSPROD.cp.CustomerSetting SET Status = @Status, ModifyUserID = @ModifyUserID, ModifyDate = @ModifyDate WHERE CustomerID = @CustomerID AND SalesID = @SalesID";

                var parameters = new { CustomerID = id, SalesID = objEntity.SalesID, Status = objEntity.Status, ModifyUserID = objEntity.ModifyUserID, ModifyDate = objEntity.ModifyDate };

                var affectedRows = _context.db.Execute(_sql, parameters, transaction: _transaction, commandTimeout: null, commandType: CommandType.Text);

                return affectedRows > 0;
            }
            catch (Exception)
            {
                return false;
            }
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

        public List<Req_CustomerSettingGetCustomerDataByID_ViewModel> GetCustomerDataByID(long customerID)
        {
            _sql = "[cp].[spGetCustomerDataByID]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerID", customerID);
            var output = _context.db.Query<Req_CustomerSettingGetCustomerDataByID_ViewModel>(_sql, param: (object)vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
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
    }
}
