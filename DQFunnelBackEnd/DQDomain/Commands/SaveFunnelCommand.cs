using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SaveFunnelCommand : FunnelElasticCommand
    {
        public SaveFunnelCommand(FunnelElasticCommand funnel)
        {
            FunnelElastic = funnel.FunnelElastic;
        }
    }
}
