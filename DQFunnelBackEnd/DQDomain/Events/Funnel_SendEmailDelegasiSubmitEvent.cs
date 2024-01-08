using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailDelegasiSubmitEvent : Event
    {
        public Funnel_SendEmailDelegasiSubmitEvent()
        {
            DelegasiEmail = new DelegasiEmail();
            DelegasiDetailEmail = new List<DelegasiDetailEmail>();
            DelegasiDetailOutstandingEmail = new List<DelegasiDetailEmail>();
            Email = new EmailAddrToCc();
        }

        public DelegasiEmail DelegasiEmail { get; set; }
        public List<DelegasiDetailEmail> DelegasiDetailEmail { get; set; }
        public List<DelegasiDetailEmail> DelegasiDetailOutstandingEmail { get; set; }
        public EmailAddrToCc Email { get; set; }

        public Funnel_SendEmailDelegasiSubmitEvent(EmailDelegasiSubmitMapperCommand obj)
        {
            DelegasiEmail = obj.DelegasiEmail;
            DelegasiDetailEmail = obj.DelegasiDetailEmail;
            DelegasiDetailOutstandingEmail = obj.DelegasiDetailOutstandingEmail;
            Email = obj.Email;
        }
    }
}
