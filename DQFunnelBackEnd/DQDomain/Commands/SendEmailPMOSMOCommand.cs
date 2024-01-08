using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailPMOSMOCommand : SalesFunnelEmailPMOSMOMapperCommand
    {
        public SendEmailPMOSMOCommand(SalesFunnelEmailPMOSMOMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
            SalesFunnelServiceCatalog = obj.SalesFunnelServiceCatalog;
        }
    }
}
