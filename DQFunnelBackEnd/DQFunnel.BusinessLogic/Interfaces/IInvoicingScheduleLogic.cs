﻿using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface IInvoicingScheduleLogic
    {
        ResultAction GetInvoicingSchedule();
        ResultAction InsertInvoicingSchedule(CpInvoicingSchedule objEntity);
        ResultAction UpdateInvoicingSchedule(long Id, CpInvoicingSchedule objEntity);
        ResultAction DeleteInvoicingSchedule(long Id);
        ResultAction GetInvoicingScheduleByCustomerID(long customerID);
    }
}
