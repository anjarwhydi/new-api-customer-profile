using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailBGBankEvent : Event
    {
        public string pathFileUpload { get; set; }
        public string email { get; set; }

        public Funnel_SendEmailBGBankEvent(EmailBankBGMapperCommand obj)
        {
            pathFileUpload = obj.pathFileUpload;
            email = obj.email;
        }
    }
}
