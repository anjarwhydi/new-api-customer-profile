using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface IInvoicingScheduleRepository : IRepository<CpInvoicingSchedule>
    {
        CpInvoicingSchedule GetInvoicingScheduleById(long Id);
    }
}
