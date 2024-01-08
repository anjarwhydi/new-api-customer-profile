using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailActivityCommand : EmailActivityMapperCommand
    {
        public SendEmailActivityCommand(EmailActivityMapperCommand obj)
        {
            EmailActivity = obj.EmailActivity;
        }
    }
}
