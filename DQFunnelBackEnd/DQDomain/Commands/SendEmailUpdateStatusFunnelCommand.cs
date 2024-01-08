using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailUpdateStatusFunnelCommand : ActivityUpdateMapperCommand
    {
        public SendEmailUpdateStatusFunnelCommand(ActivityUpdateMapperCommand obj)
        {
            SalesFunnelActivity = obj.SalesFunnelActivity;
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
        }
    }
}
