using Domain.Core.Events;
using DQDomain.Commands;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailCCSAddTicketEvent : Event
    {
        public Funnel_SendEmailCCSAddTicketEvent()
        {
            SalesCustomerCreditServiceEmail = new SalesCustomerCreditServiceEmail();
            Email = new EmailAddr();
        }

        public SalesCustomerCreditServiceEmail SalesCustomerCreditServiceEmail { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailCCSAddTicketEvent(EmailSalesCCSMapperCommand obj)
        {
            SalesCustomerCreditServiceEmail = obj.SalesCustomerCreditServiceEmail;
            Email = obj.Email;
        }
    }
}
