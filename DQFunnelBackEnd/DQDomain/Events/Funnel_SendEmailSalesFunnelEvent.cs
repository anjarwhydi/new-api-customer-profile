using Domain.Core.Events;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailSalesFunnelEvent : Event
    {
        public Funnel_SendEmailSalesFunnelEvent()
        {
            SalesFunnelEmail = new SalesFunnelEmail();
        }
        public SalesFunnelEmail SalesFunnelEmail { get; set; }

        public Funnel_SendEmailSalesFunnelEvent(SalesFunnelEmailMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
        }
    }
}
