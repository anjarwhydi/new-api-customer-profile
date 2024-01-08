using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailBGBankCommand : EmailBankBGMapperCommand
    {
        public SendEmailBGBankCommand(string PathFileUpload, string Email)
        {
            pathFileUpload = PathFileUpload;
            email = Email;
        }
    }
}
