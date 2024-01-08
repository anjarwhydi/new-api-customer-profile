using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailActivityEvent : Event
    {
        public Funnel_SendEmailActivityEvent()
        {
            EmailActivity = new ActivityMeeting();
        }

        public ActivityMeeting EmailActivity { get; set; }

        public Funnel_SendEmailActivityEvent(EmailActivityMapperCommand obj)
        {
            EmailActivity = obj.EmailActivity;
        }
    }
}
