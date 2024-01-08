using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailFunnelOpportunityEvent : Event
    {
        public Funnel_SendEmailFunnelOpportunityEvent()
        {
            SalesFunnelOpportunityEmail = new SalesFunnelOpportunityEmail();
            Email = new EmailAddr();
        }

        public SalesFunnelOpportunityEmail SalesFunnelOpportunityEmail { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailFunnelOpportunityEvent(SalesFunnelOpportunityEmailMapperCommand obj)
        {
            SalesFunnelOpportunityEmail = obj.SalesFunnelOpportunityEmail;
            Email = obj.Email;
        }
    }
}
