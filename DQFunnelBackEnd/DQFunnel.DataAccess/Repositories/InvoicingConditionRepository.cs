using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DQFunnel.BusinessObject;
using DQFunnel.DataAccess.Interfaces;

namespace DQFunnel.DataAccess.Repositories
{
    public class InvoicingConditionRepository : Repository<CpInvoicingCondition>, IInvoicingConditionRepository
    {
        private IDapperContext _context;
        private IDbTransaction _transaction;
        private string _sql;
        public InvoicingConditionRepository(IDbTransaction transaction, IDapperContext context) : base(transaction, context)
        {
            this._context = context;
            this._transaction = transaction;
        }
    }
}
