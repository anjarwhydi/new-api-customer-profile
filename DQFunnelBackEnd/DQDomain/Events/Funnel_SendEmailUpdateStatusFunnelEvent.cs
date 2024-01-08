using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailUpdateStatusFunnelEvent : Event
    {
        public Funnel_SendEmailUpdateStatusFunnelEvent()
        {
            SalesFunnelActivity = new SalesFunnelActivity();
            SalesFunnelEmail = new SalesFunnelEmail();
            Email = new EmailAddr();
        }
        public SalesFunnelActivity SalesFunnelActivity { get; set; }
        public SalesFunnelEmail SalesFunnelEmail { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailUpdateStatusFunnelEvent(ActivityUpdateMapperCommand obj)
        {
            SalesFunnelActivity = obj.SalesFunnelActivity;
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
        }
    }
}
