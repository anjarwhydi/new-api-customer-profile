using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.DataAccess.Interfaces;

namespace DQFunnel.DataAccess.Repositories
{
    public class SalesAssignmentRepository : Repository<CpSalesAssignment>, ISalesAssignmentRepository
    {
        private IDapperContext _context;
        private IDbTransaction _transaction;
        private string _sql;
        public SalesAssignmentRepository(IDbTransaction transaction, IDapperContext context) : base(transaction, context)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public List<Req_CustomerSettingGetSalesData_ViewModel> GetListSales()
        {
            _sql = "[cp].[spGetSalesData]";
            var output = _context.db.Query<Req_CustomerSettingGetSalesData_ViewModel>(_sql, param: null, transaction: _transaction, buffered: false, commandTimeout: null, commandType: CommandType.StoredProcedure).ToList();
            return output;
        }
    }
}
