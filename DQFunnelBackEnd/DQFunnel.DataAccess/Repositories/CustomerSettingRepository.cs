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

        public List<CpCustomerSettingDashboard> GetCustomerSettingNamedAccount(string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingNamedAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);
            vParams.Add("@SalesName", salesName);

            var output = _context.db.Query<CpCustomerSettingDashboard>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
        public List<CpCustomerSettingDashboard> GetCustomerSettingSharebleAccount(string search, string salesName, bool? pmoCustomer = null, bool? blacklist = null, bool? holdshipment = null)
        {
            _sql = "[cp].[spGetCustomerSettingSharebleAccounts]";
            var vParams = new DynamicParameters();
            vParams.Add("@SearchKeyword", search);
            vParams.Add("@PMOCustomer", pmoCustomer);
            vParams.Add("@Blacklist", blacklist);
            vParams.Add("@Holdshipment", holdshipment);
            vParams.Add("@SalesName", salesName);

            var output = _context.db.Query<CpCustomerSettingDashboard>(_sql, param: vParams, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }

        public CpCustomerSetting GetCustomerSettingByCustomerSettingID(long customerSettingID)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<CpCustomerSetting>(c => c.CustomerSettingID, Operator.Eq, customerSettingID));
            return _context.db.GetList<CpCustomerSetting>(pg).FirstOrDefault();
        }
        public CpCustomerSetting GetCustomerSettingByCustomerID(long customerID)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<CpCustomerSetting>(c => c.CustomerID, Operator.Eq, customerID));
            return _context.db.GetList<CpCustomerSetting>(pg).FirstOrDefault();
        }

    }
}
