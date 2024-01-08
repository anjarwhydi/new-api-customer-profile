using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class UpdateBankGuaranteeCommand : SalesBankGuaranteeUpdateMapperCommand
    {
        public UpdateBankGuaranteeCommand(SalesBankGuaranteeUpdateMapperCommand funnel)
        {
            SalesBankGuarantee = funnel.SalesBankGuarantee;
        }
    }
}
