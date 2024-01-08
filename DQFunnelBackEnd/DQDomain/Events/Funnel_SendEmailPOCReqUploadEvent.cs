using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailPOCReqUploadEvent : Event
    {
        public Funnel_SendEmailPOCReqUploadEvent()
        {
            FileFunnelAttachment = new FileFunnelAttachment();
        }

        public FileFunnelAttachment FileFunnelAttachment { get; set; }

        public Funnel_SendEmailPOCReqUploadEvent(FunnelFileMapperCommand obj)
        {
            FileFunnelAttachment = obj.FileFunnelAttachment;
        }
    }
}
