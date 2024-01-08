using Domain.Core.Commands;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailCCSAddTicketCommand : EmailSalesCCSMapperCommand
    {
        public SendEmailCCSAddTicketCommand(EmailSalesCCSMapperCommand obj)
        {
            SalesCustomerCreditServiceEmail = obj.SalesCustomerCreditServiceEmail;
            Email = obj.Email;
        }
    }
}
