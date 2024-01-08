using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailSACostChangedCommand : EmailSACostChangedMapperCommand
    {
        public SendEmailSACostChangedCommand(EmailSACostChangedMapperCommand obj)
        {
            SalesFunnelSAEmail = obj.SalesFunnelSAEmail;
            Email = obj.Email;
        }
    }
}
