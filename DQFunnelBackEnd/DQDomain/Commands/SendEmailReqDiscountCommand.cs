using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailReqDiscountCommand : DiscountServiceMapperCommand
    {
        public SendEmailReqDiscountCommand(DiscountServiceMapperCommand obj)
        {
            DiscountService = obj.DiscountService;
            SalesFunnelServiceCatalog = obj.SalesFunnelServiceCatalog;
            SalesFunnel = obj.SalesFunnel;
            Email = obj.Email;
            CreatorName = obj.CreatorName;
        }
    }
}
