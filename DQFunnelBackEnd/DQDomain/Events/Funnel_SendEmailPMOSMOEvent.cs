using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailPMOSMOEvent : Event
    {
        public SalesFunnelEmail SalesFunnelEmail { get; set; }
        public List<FunnelServiceCatalogDashboard> SalesFunnelServiceCatalog { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailPMOSMOEvent(SalesFunnelEmailPMOSMOMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
            SalesFunnelServiceCatalog = obj.SalesFunnelServiceCatalog;
        }
    }
}
