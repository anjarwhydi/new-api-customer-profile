﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DapperExtensions;
using DQFunnel.BusinessObject;
using DQFunnel.DataAccess.Interfaces;

namespace DQFunnel.DataAccess.Repositories
{
    public class InvoicingScheduleRepository : Repository<CpInvoicingSchedule>, IInvoicingScheduleRepository
    {
        private IDapperContext _context;
        private IDbTransaction _transaction;
        private string _sql;
        public InvoicingScheduleRepository(IDbTransaction transaction, IDapperContext context) : base(transaction, context)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public CpInvoicingSchedule GetInvoicingScheduleById(long Id)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<CpInvoicingSchedule>(c => c.IScheduleID, Operator.Eq, Id));
            return _context.db.GetList<CpInvoicingSchedule>(pg).FirstOrDefault();
        }
    }
}
