using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailReqDiscountEvent : Event
    {
        public Funnel_SendEmailReqDiscountEvent()
        {
            DiscountService = new DiscountService();
            SalesFunnel = new SalesFunnel();
            SalesFunnelServiceCatalog = new List<SalesFunnelServiceCatalogEmail>();
            Email = new EmailAddr();
        }

        public DiscountService DiscountService { get; set; }
        public SalesFunnel SalesFunnel { get; set; }
        public List<SalesFunnelServiceCatalogEmail> SalesFunnelServiceCatalog { get; set; }
        public EmailAddr Email { get; set; }

        public string CreatorName { get; set; }

        public Funnel_SendEmailReqDiscountEvent(DiscountServiceMapperCommand obj)
        {
            DiscountService = obj.DiscountService;
            SalesFunnelServiceCatalog = obj.SalesFunnelServiceCatalog;
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
            CreatorName = obj.CreatorName;
        }
    }
}
