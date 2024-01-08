using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailPOCCommand : SalesPOCMapperCommand
    {
        public SendEmailPOCCommand(SalesPOCMapperCommand obj)
        {
            SalesPOC = obj.SalesPOC;
            Email = obj.Email;
            Attachment = obj.Attachment;
        }
    }
}
