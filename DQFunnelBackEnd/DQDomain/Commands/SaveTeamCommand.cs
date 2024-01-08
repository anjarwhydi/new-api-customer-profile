using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SaveTeamCommand : SalesFunnelSupportTeamMapperCommand
    {
        public SaveTeamCommand(SalesFunnelSupportTeamMapperCommand funnel)
        {
            SalesFunnelSupportTeam = funnel.SalesFunnelSupportTeam;
        }
    }
}
