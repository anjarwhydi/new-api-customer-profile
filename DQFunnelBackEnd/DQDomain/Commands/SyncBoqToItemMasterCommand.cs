using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SyncBoqToItemMasterCommand : SyncBoqToItemMasterMapperCommand
    {
        public SyncBoqToItemMasterCommand(SyncBoqToItemMasterMapperCommand funnel)
        {
            SalesBOQ = funnel.SalesBOQ;
            username = funnel.username;
            password = funnel.password;
            BUSales = funnel.BUSales;
        }
    }
}
