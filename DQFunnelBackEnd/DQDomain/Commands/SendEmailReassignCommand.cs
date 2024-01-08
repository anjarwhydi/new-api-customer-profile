using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailReassignCommand : EmailSalesFunnelSupportTeamMapperCommand
    {
        public SendEmailReassignCommand(EmailSalesFunnelSupportTeamMapperCommand obj)
        {
            SalesFunnelSupportTeamEmail = obj.SalesFunnelSupportTeamEmail;
            SalesFunnelSupportTeamDetailEmail = obj.SalesFunnelSupportTeamDetailEmail;
            Email = obj.Email;
        }
    }
}
