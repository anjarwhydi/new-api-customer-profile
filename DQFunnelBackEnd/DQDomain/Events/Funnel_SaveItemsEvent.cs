using Domain.Core.Events;
using DQDomain.Commands;
using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SaveItemsEvent : Event
    {
        public Funnel_SaveItemsEvent()
        {
            SalesFunnelItems = new SalesFunnelItems();
        }
        public SalesFunnelItems SalesFunnelItems { get; set; }

        public Funnel_SaveItemsEvent(SaveItemsCommand funnel)
        {
            SalesFunnelItems = funnel.SalesFunnelItems;
        }
    }
}
