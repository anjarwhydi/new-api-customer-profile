using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailReqDiscountItemServiceCommand : DiscountItemServiceMapperCommand
    {
        public SendEmailReqDiscountItemServiceCommand(DiscountItemServiceMapperCommand obj)
        {
            DiscountItemService = obj.DiscountItemService;
            SalesFunnelServiceCatalog = obj.SalesFunnelServiceCatalog;
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
            CreatorName = obj.CreatorName;
        }
    }
}
