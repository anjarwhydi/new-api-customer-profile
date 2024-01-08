using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.Base;
using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
	public class Funnel_SaveFunnelEvent : Event
	{
        public Funnel_SaveFunnelEvent()
        {
            FunnelElastic = new FunnelElastics();
        }
        public FunnelElastics FunnelElastic { get; set; }

        public Funnel_SaveFunnelEvent(FunnelElasticCommand funnel)
		{
            FunnelElastic = funnel.FunnelElastic;
        }
	}
}
