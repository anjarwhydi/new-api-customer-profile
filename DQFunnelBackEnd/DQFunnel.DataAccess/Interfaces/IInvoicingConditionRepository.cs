using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface IInvoicingConditionRepository : IRepository<CpInvoicingCondition>
    {
        CpInvoicingCondition GetInvoicingConditionById(long Id);
    }
}
