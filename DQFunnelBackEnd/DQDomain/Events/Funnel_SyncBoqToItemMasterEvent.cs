using Domain.Core.Events;
using DQDomain.Commands;
using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SyncBoqToItemMasterEvent : Event
    {
        public Funnel_SyncBoqToItemMasterEvent()
        {
            SalesBOQ = new List<SalesBOQ>();
        }
        public List<SalesBOQ> SalesBOQ { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string BUSales { get; set; }

        public Funnel_SyncBoqToItemMasterEvent(SyncBoqToItemMasterCommand funnel)
        {
            SalesBOQ = funnel.SalesBOQ;
            username = funnel.username;
            password = funnel.password;
            BUSales = funnel.BUSales;
        }
    }
}
