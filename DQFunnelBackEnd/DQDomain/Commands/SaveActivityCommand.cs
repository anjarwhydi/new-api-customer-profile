using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SaveActivityCommand : ActivityMapperCommand
    {
        public SaveActivityCommand(ActivityMapperCommand funnel)
        {
            SalesFunnelActivity = funnel.SalesFunnelActivity;
        }
    }
}
