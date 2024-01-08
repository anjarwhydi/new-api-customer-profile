using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailSalesFunnelCloudServiceCommand : SalesFunnelEmailMapperCommand
    {
        public SendEmailSalesFunnelCloudServiceCommand(SalesFunnelEmailMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
        }
    }
}
