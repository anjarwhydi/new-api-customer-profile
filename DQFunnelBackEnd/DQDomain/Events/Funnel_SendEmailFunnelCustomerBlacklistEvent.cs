using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.Additional;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailFunnelCustomerBlacklistEvent : Event
    {
        public Funnel_SendEmailFunnelCustomerBlacklistEvent()
        {
            SalesFunnel = new SalesFunnelEmail();
            Customer = new Customer();
            Email = new EmailAddr();
        }

        public SalesFunnelEmail SalesFunnel { get; set; }
        public Customer Customer { get; set; }
        public EmailAddr Email { get; set; }

        public string CreatorName { get; set; }

        public Funnel_SendEmailFunnelCustomerBlacklistEvent(CustomerBlacklistMapperCommand obj)
        {
            SalesFunnel = obj.SalesFunnel;
            Customer = obj.Customer;
            Email = obj.Email;
            CreatorName = obj.CreatorName;
        }
    }
}
