using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendFunnelFileEvent : Event
    {
        public Funnel_SendFunnelFileEvent()
        {
            FileFunnelAttachment = new FileFunnelAttachment();
        }
        public FileFunnelAttachment FileFunnelAttachment { get; set; }

        public Funnel_SendFunnelFileEvent(FunnelFileMapperCommand funnel)
        {
            FileFunnelAttachment = funnel.FileFunnelAttachment;
        }
    }
}
