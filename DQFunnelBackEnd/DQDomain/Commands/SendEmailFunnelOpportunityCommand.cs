using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailFunnelOpportunityCommand : SalesFunnelOpportunityEmailMapperCommand
    {
        public SendEmailFunnelOpportunityCommand(SalesFunnelOpportunityEmailMapperCommand obj)
        {
            SalesFunnelOpportunityEmail = obj.SalesFunnelOpportunityEmail;
            Email = obj.Email;
        }
    }
}
