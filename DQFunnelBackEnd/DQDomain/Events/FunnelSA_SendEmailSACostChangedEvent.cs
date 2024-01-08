using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class FunnelSA_SendEmailSACostChangedEvent : Event
    {
        public FunnelSA_SendEmailSACostChangedEvent()
        {
            SalesFunnelSAEmail = new EmailSACostChanged();
            Email = new EmailAddr();
        }
        public EmailSACostChanged SalesFunnelSAEmail { get; set; }
        public EmailAddr Email { get; set; }

        public FunnelSA_SendEmailSACostChangedEvent(EmailSACostChangedMapperCommand obj)
        {
            SalesFunnelSAEmail = obj.SalesFunnelSAEmail;
            Email = obj.Email;
        }
    }
}
