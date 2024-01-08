using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic.Interfaces
{
    public interface IFunnelActivityElasticLogic
    {
        List<FunnelActivityDashboard> Search(string text);
    }
}
