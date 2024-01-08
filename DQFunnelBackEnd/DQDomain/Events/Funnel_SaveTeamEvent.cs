using Domain.Core.Events;
using DQDomain.Commands;
using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SaveTeamEvent : Event
    {
        public Funnel_SaveTeamEvent()
        {
            SalesFunnelSupportTeam = new SalesFunnelSupportTeam();
        }
        public SalesFunnelSupportTeam SalesFunnelSupportTeam { get; set; }

        public Funnel_SaveTeamEvent(SaveTeamCommand funnel)
        {
            SalesFunnelSupportTeam = funnel.SalesFunnelSupportTeam;
        }
    }
}
