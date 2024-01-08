using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailFunnelActivityCommand : FunnelActivityMapperCommand
    {
        public SendEmailFunnelActivityCommand(FunnelActivityMapperCommand obj)
        {
            SalesFunnelActivity = obj.SalesFunnelActivity;
            Email = obj.Email;
        }
    }
}
