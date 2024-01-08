using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailAssignCommand : EmailSalesFunnelSupportTeamMapperCommand
    {
        public SendEmailAssignCommand(EmailSalesFunnelSupportTeamMapperCommand obj)
        {
            SalesFunnelSupportTeamEmail = obj.SalesFunnelSupportTeamEmail;
            Email = obj.Email;
        }
    }
}
