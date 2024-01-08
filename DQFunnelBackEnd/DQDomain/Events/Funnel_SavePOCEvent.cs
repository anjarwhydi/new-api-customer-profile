using Domain.Core.Events;
using DQDomain.Commands;
using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SavePOCEvent : Event
    {
        public Funnel_SavePOCEvent()
        {
            SalesPOC = new SalesPOC();
        }
        public SalesPOC SalesPOC { get; set; }

        public Funnel_SavePOCEvent(SavePOCCommand funnel)
        {
            SalesPOC = funnel.SalesPOC;
        }
    }
}
