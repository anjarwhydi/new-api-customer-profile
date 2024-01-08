using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailSummaryInsertFormCommand : SummaryPlanInsertFormEmail
    {
        public SendEmailSummaryInsertFormCommand(SummaryPlanInsertFormEmail obj)
        {
            SalesActionPlanNotes = obj.SalesActionPlanNotes;
            Employee = obj.Employee;
        }
    }
}
