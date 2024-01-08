using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SavePOCCommand : SalesPOCMapperCommand
    {
        public SavePOCCommand(SalesPOCMapperCommand funnel)
        {
            SalesPOC = funnel.SalesPOC;
        }
    }
}
