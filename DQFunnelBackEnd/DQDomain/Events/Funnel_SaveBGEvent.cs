using Domain.Core.Events;
using DQDomain.Commands;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.Elastic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SaveBGEvent : Event
    {
        public Funnel_SaveBGEvent()
        {
            SalesBankGuarantee = new SalesBankGuaranteeElastic();
        }
        public SalesBankGuaranteeElastic SalesBankGuarantee { get; set; }

        public Funnel_SaveBGEvent(SaveBankGuaranteeCommand funnel)
        {
            SalesBankGuarantee = funnel.SalesBankGuarantee;
        }
    }
}
