using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailPOCEvent : Event
    {
        public Funnel_SendEmailPOCEvent()
        {
            SalesPOC = new SalesPOC();
            Email = new EmailAddr();
            Attachment = new FileFunnelAttachmentEmail();
        }

        public SalesPOC SalesPOC { get; set; }
        public EmailAddr Email { get; set; }
        public FileFunnelAttachmentEmail Attachment { get; set; }

        public Funnel_SendEmailPOCEvent(SalesPOCMapperCommand obj)
        {
            SalesPOC = obj.SalesPOC;
            Email = obj.Email;
            Attachment = obj.Attachment;
        }
    }
}
