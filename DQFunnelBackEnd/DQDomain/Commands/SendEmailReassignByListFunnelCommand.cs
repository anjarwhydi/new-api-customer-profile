using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailReassignByListFunnelCommand : ProjectTransferListFunnelEmailMapperCommand
    {
        public SendEmailReassignByListFunnelCommand(ProjectTransferListFunnelEmailMapperCommand obj)
        {
            SalesProjectTransfer = obj.SalesProjectTransfer;
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
        }
    }
}
