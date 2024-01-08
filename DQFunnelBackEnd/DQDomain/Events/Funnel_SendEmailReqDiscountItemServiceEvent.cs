using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailReqDiscountItemServiceEvent : Event
    {
        public Funnel_SendEmailReqDiscountItemServiceEvent()
        {
            DiscountItemService = new DiscountItemService();
            SalesFunnel = new SalesFunnel();
            SalesFunnelServiceCatalog = new List<SalesFunnelServiceCatalogEmail>();
            Email = new EmailAddr();
        }

        public DiscountItemService DiscountItemService { get; set; }
        public SalesFunnel SalesFunnel { get; set; }
        public List<SalesFunnelServiceCatalogEmail> SalesFunnelServiceCatalog { get; set; }
        public EmailAddr Email { get; set; }

        public string CreatorName { get; set; }

        public Funnel_SendEmailReqDiscountItemServiceEvent(DiscountItemServiceMapperCommand obj)
        {
            DiscountItemService = obj.DiscountItemService;
            SalesFunnelServiceCatalog = obj.SalesFunnelServiceCatalog;
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
            CreatorName = obj.CreatorName;
        }
    }
}
