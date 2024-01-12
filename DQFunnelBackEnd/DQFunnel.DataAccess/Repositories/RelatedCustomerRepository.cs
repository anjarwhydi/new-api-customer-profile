using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DQFunnel.BusinessObject;
using DQFunnel.DataAccess.Interfaces;

namespace DQFunnel.DataAccess.Repositories
{
    public class RelatedCustomerRepository : Repository<CpRelatedCustomer>, IRelatedCustomerRepository
    {
        private IDapperContext _context;
        private IDbTransaction _transaction;
        private string _sql;
        public RelatedCustomerRepository(IDbTransaction transaction, IDapperContext context) : base(transaction, context)
        {
            this._context = context;
            this._transaction = transaction;
        }
    }
}
