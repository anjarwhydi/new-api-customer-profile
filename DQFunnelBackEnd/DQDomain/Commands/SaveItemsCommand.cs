using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SaveItemsCommand : ItemsMapperCommand
    {
        public SaveItemsCommand(ItemsMapperCommand funnel)
        {
            SalesFunnelItems = funnel.SalesFunnelItems;
        }
    }
}
