using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailReassignByFunnelCommand : ProjectTransferByFunnelEmailMapperCommand
    {
        public SendEmailReassignByFunnelCommand(ProjectTransferByFunnelEmailMapperCommand obj)
        {
            SalesProjectTransfer = obj.SalesProjectTransfer;
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
        }
    }
}
