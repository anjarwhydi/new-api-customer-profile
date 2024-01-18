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
    public class SalesHistoryRepository : Repository<CpSalesHistory>, ISalesHistoryRepository
    {
        private IDapperContext _context;
        private IDbTransaction _transaction;
        private string _sql;
        public SalesHistoryRepository(IDbTransaction transaction, IDapperContext context) : base(transaction, context)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CpSalesHistory GetSalesHistoryByCustomerID(long SalesHistoryID)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<CpSalesHistory>(c => c.SalesHistoryID, Operator.Eq, SalesHistoryID));
            return _context.db.GetList<CpSalesHistory>(pg).FirstOrDefault();
        }
        public Req_CustomerSettingShareableApprovalStatus_ViewModel GetShareableStatus(long customerID)
        {
            _sql = "[cp].[spGetSalesHistoryApprovalInfo]";
            var vParams = new DynamicParameters();
            vParams.Add("@CustomerID", customerID);
            var output = _context.db.Query<Req_CustomerSettingShareableApprovalStatus_ViewModel>(
                _sql,
                param: vParams,
                transaction: _transaction,
                buffered: false,
                commandTimeout: null,
                commandType: CommandType.StoredProcedure
            ).SingleOrDefault();

            return output;
        }
    }
}
