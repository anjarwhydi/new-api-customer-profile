using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailPOCReqCommand : SalesPOCRequirementMapperCommand
    {
        public SendEmailPOCReqCommand(SalesPOCRequirementMapperCommand obj)
        {
            SalesPOCRequirement = obj.SalesPOCRequirement;
            Email = obj.Email;
        }
    }
}
