using Domain.Core.Events;
using DQDomain.Commands;
using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SaveActivityEvent : Event
    {
        public Funnel_SaveActivityEvent()
        {
            SalesFunnelActivity = new SalesFunnelActivity();
        }
        public SalesFunnelActivity SalesFunnelActivity { get; set; }

        public Funnel_SaveActivityEvent(SaveActivityCommand funnel)
        {
            SalesFunnelActivity = funnel.SalesFunnelActivity;
        }
    }
}
