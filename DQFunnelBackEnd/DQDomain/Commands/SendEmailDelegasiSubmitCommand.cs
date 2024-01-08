using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailDelegasiSubmitCommand : EmailDelegasiSubmitMapperCommand
    {
        public SendEmailDelegasiSubmitCommand(EmailDelegasiSubmitMapperCommand obj)
        {
            DelegasiEmail = obj.DelegasiEmail;
            DelegasiDetailEmail = obj.DelegasiDetailEmail;
            DelegasiDetailOutstandingEmail = obj.DelegasiDetailOutstandingEmail;
            Email = obj.Email;
        }
    }
}
