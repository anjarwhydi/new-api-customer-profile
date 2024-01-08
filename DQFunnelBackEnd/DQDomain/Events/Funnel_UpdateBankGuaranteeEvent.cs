using Domain.Core.Events;
using DQDomain.Commands;
using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_UpdateBankGuaranteeEvent : Event
    {
        public Funnel_UpdateBankGuaranteeEvent()
        {
            SalesBankGuarantee = new SalesBankGuarantee();
        }
        public SalesBankGuarantee SalesBankGuarantee { get; set; }

        public Funnel_UpdateBankGuaranteeEvent(UpdateBankGuaranteeCommand funnel)
        {
            SalesBankGuarantee = funnel.SalesBankGuarantee;
        }
    }
}
