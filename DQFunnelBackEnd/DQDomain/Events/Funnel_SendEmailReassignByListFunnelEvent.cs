using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailReassignByListFunnelEvent : Event
    {
        public Funnel_SendEmailReassignByListFunnelEvent()
        {
            SalesProjectTransfer = new SalesProjectTransfer();
            SalesFunnel = new List<SalesFunnel>();
            Email = new EmailAddr();
        }

        public SalesProjectTransfer SalesProjectTransfer { get; set; }
        public List<SalesFunnel> SalesFunnel { get; set; }
        public EmailAddr Email { get; set; }

        public Funnel_SendEmailReassignByListFunnelEvent(ProjectTransferListFunnelEmailMapperCommand obj)
        {
            SalesProjectTransfer = obj.SalesProjectTransfer;
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
        }
    }
}
