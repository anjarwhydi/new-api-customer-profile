using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailReassignFunnelOpportunityCommand : SalesFunnelOpportunityEmailMapperCommand
    {
        public SendEmailReassignFunnelOpportunityCommand(SalesFunnelOpportunityEmailMapperCommand obj)
        {
            SalesFunnelOpportunityEmail = obj.SalesFunnelOpportunityEmail;
            Email = obj.Email;
        }
    }
}
