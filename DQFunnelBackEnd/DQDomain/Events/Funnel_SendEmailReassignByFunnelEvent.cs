using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailReassignByFunnelEvent : Event
    {
        public Funnel_SendEmailReassignByFunnelEvent()
        {
            SalesProjectTransfer = new SalesProjectTransfer();
            SalesFunnel = new SalesFunnel();
            Email = new EmailAddr();
        }

        public SalesProjectTransfer SalesProjectTransfer { get; set; }
        public SalesFunnel SalesFunnel { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailReassignByFunnelEvent(ProjectTransferByFunnelEmailMapperCommand obj)
        {
            SalesProjectTransfer = obj.SalesProjectTransfer;
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
        }
    }
}
