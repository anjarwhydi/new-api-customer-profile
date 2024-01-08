using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailReassignEvent : Event
    {
        public Funnel_SendEmailReassignEvent()
        {
            SalesFunnelSupportTeamEmail = new SalesFunnelSupportTeamEmail();
            SalesFunnelSupportTeamDetailEmail = new SalesFunnelSupportTeamDetailEmail();
            Email = new EmailAddr();
        }

        public SalesFunnelSupportTeamEmail SalesFunnelSupportTeamEmail { get; set; }
        public SalesFunnelSupportTeamDetailEmail SalesFunnelSupportTeamDetailEmail { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailReassignEvent(EmailSalesFunnelSupportTeamMapperCommand obj)
        {
            SalesFunnelSupportTeamEmail = obj.SalesFunnelSupportTeamEmail;
            SalesFunnelSupportTeamDetailEmail = obj.SalesFunnelSupportTeamDetailEmail;
            Email = obj.Email;
        }
    }
}
