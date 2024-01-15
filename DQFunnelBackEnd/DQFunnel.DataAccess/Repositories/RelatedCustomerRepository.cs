using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DapperExtensions;
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

        public CpRelatedCustomer GetRelatedCustomerById(long Id)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<CpRelatedCustomer>(c => c.RelatedCustomerID, Operator.Eq, Id));
            return _context.db.GetList<CpRelatedCustomer>(pg).FirstOrDefault();
        }
    }
}
