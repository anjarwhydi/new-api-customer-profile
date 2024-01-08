using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailAssignEvent : Event
    {
        public Funnel_SendEmailAssignEvent()
        {
            SalesFunnelSupportTeamEmail = new SalesFunnelSupportTeamEmail();
            Email = new EmailAddr();
        }

        public SalesFunnelSupportTeamEmail SalesFunnelSupportTeamEmail { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailAssignEvent(EmailSalesFunnelSupportTeamMapperCommand obj)
        {
            SalesFunnelSupportTeamEmail = obj.SalesFunnelSupportTeamEmail;
            Email = obj.Email;
        }
    }
}
