using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.Additional;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailSummaryInsertFormEvent : Event
    {
        public Funnel_SendEmailSummaryInsertFormEvent()
        {
            SalesActionPlanNotes = new SalesActionPlanNotes();
            Employee = new Employee();
        }

        public SalesActionPlanNotes SalesActionPlanNotes { get; set; }
        public Employee Employee { get; set; }

        public Funnel_SendEmailSummaryInsertFormEvent(SummaryPlanInsertFormEmail obj)
        {
            SalesActionPlanNotes = obj.SalesActionPlanNotes;
            Employee = obj.Employee;
        }
    }
}
