using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailFunnelActivityEvent : Event
    {
        public Funnel_SendEmailFunnelActivityEvent()
        {
            SalesFunnelActivity = new SalesFunnelActivity();
            Email = new EmailAddr();
        }

        public SalesFunnelActivity SalesFunnelActivity { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailFunnelActivityEvent(FunnelActivityMapperCommand obj)
        {
            SalesFunnelActivity = obj.SalesFunnelActivity;
            Email = obj.Email;
        }
    }
}
