using DQFunnel.BusinessObject.Additional;
using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailFunnelCustomerBlacklistCommand : CustomerBlacklistMapperCommand
    {
        public SendEmailFunnelCustomerBlacklistCommand(CustomerBlacklistMapperCommand obj)
        {
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
            CreatorName = obj.CreatorName;
            Customer = obj.Customer;
        }
    }
}
