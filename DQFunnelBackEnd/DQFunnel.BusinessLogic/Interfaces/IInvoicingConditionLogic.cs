using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;
using ExcelDataReader.Log;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface IInvoicingConditionLogic
    {
        ResultAction GetInvoicingCondition();
        ResultAction InsertInvoicingCondition(CpInvoicingCondition objEntity);
        ResultAction UpdateInvoicingCondition(long Id, CpInvoicingCondition objEntity);
        ResultAction DeleteInvoicingCondition(long Id);
    }
}
