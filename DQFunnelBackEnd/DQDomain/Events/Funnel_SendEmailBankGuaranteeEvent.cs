using Domain.Core.Events;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailBankGuaranteeEvent : Event
    {
        public Funnel_SendEmailBankGuaranteeEvent()
        {
            SalesBankGuaranteeEmail = new SalesBankGuaranteeEmail();
        }
        public SalesBankGuaranteeEmail SalesBankGuaranteeEmail { get; set; }
        public string emailTo { get; set; }
        public string emailCc { get; set; }

        public Funnel_SendEmailBankGuaranteeEvent(SalesBankGuaranteeEmailMapperCommand obj)
        {
            SalesBankGuaranteeEmail = obj.SalesBankGuaranteeEmail;
            emailTo = obj.emailTo;
            emailCc = obj.emailCc;
        }
    }
}
