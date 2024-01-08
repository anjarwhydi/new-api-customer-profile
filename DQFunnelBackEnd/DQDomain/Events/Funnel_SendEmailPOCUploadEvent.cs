using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailPOCUploadEvent : Event
    {
        public Funnel_SendEmailPOCUploadEvent()
        {
            SalesPOC = new SalesPOC();
            SalesFunnel = new SalesFunnel();
            FileFunnelAttachment = new FileFunnelAttachment();
            Email = new EmailAddr();
        }

        public SalesPOC SalesPOC { get; set; }
        public SalesFunnel SalesFunnel { get; set; }
        public FileFunnelAttachment FileFunnelAttachment { get; set; }
        public EmailAddr Email { get; set; }

        public string CreatorName { get; set; }

        public Funnel_SendEmailPOCUploadEvent(SalesPOCUploadMapperCommand obj)
        {
            SalesPOC = obj.SalesPOC;
            SalesFunnel = obj.SalesFunnel;
            FileFunnelAttachment = obj.FileFunnelAttachment;
            CreatorName = obj.CreatorName;
            Email = obj.Email;
        }
    }
}
