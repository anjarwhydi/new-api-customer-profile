using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailEditProductEvent : Event
    {
        public Funnel_SendEmailEditProductEvent()
        {
            SalesFunnelItems = new SalesFunnelItems();
            SalesFunnelEmail = new SalesFunnelEmail();
            Email = new EmailAddr();
        }
        public SalesFunnelItems SalesFunnelItems { get; set; }
        public SalesFunnelEmail SalesFunnelEmail { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailEditProductEvent(SalesFunnelItemsEmailMapperCommand obj)
        {
            SalesFunnelItems = obj.SalesFunnelItems;
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
        }
    }
}
