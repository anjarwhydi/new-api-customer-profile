using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailEditProductCommand : SalesFunnelItemsEmailMapperCommand
    {
        public SendEmailEditProductCommand(SalesFunnelItemsEmailMapperCommand obj)
        {
            SalesFunnelItems = obj.SalesFunnelItems;
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
        }
    }
}
