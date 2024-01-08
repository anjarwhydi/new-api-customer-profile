using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailSalesFunnelCommand : SalesFunnelEmailMapperCommand
    {
        public SendEmailSalesFunnelCommand(SalesFunnelEmailMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
        }
    }
}
