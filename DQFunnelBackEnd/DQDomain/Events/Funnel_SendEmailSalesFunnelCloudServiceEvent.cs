using Domain.Core.Events;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailSalesFunnelCloudServiceEvent : Event
    {
        public Funnel_SendEmailSalesFunnelCloudServiceEvent()
        {
            SalesFunnelEmail = new SalesFunnelEmail();
            Email = new EmailAddr();
        }
        public SalesFunnelEmail SalesFunnelEmail { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailSalesFunnelCloudServiceEvent(SalesFunnelEmailMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
        }
    }
}
