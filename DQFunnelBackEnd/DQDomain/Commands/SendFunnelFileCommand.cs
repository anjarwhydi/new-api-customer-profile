using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendFunnelFileCommand : FunnelFileMapperCommand
    {
        public SendFunnelFileCommand(FunnelFileMapperCommand funnel)
        {
            FileFunnelAttachment = funnel.FileFunnelAttachment;
        }
    }
}
