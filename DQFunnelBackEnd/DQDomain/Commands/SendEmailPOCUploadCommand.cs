using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailPOCUploadCommand : SalesPOCUploadMapperCommand
    {
        public SendEmailPOCUploadCommand(SalesPOCUploadMapperCommand obj)
        {
            SalesPOC = obj.SalesPOC;
            SalesFunnel = obj.SalesFunnel;
            FileFunnelAttachment = obj.FileFunnelAttachment;
            CreatorName = obj.CreatorName;
            Email = obj.Email;
        }
    }
}
