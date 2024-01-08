using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailBankGuaranteeCommand : SalesBankGuaranteeEmailMapperCommand
    {
        public SendEmailBankGuaranteeCommand(SalesBankGuaranteeEmailMapperCommand obj)
        {
            SalesBankGuaranteeEmail = obj.SalesBankGuaranteeEmail;
            emailTo = obj.emailTo;
            emailCc = obj.emailCc;
        }
    }
}
