using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailPOCReqUploadCommand : FunnelFileMapperCommand
    {
        public SendEmailPOCReqUploadCommand(FunnelFileMapperCommand obj)
        {
            FileFunnelAttachment = obj.FileFunnelAttachment;
        }
    }
}
