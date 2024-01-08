using Domain.Core.Commands;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailCCSUpdatePriceCommand : EmailSalesCCSMapperCommand
    {
        public SendEmailCCSUpdatePriceCommand(EmailSalesCCSMapperCommand obj)
        {
            SalesCustomerCreditServiceEmail = obj.SalesCustomerCreditServiceEmail;
            Email = obj.Email;
        }
    }
}
