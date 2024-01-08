using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SaveBankGuaranteeCommand : SalesBankGuaranteeMapperCommand
    {
        public SaveBankGuaranteeCommand(SalesBankGuaranteeMapperCommand funnel)
        {
            SalesBankGuarantee = funnel.SalesBankGuarantee;
        }
    }
}
