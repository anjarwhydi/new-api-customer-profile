using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface IWarrantySLAElasticRepository : IElasticRepository<SalesWarrantySLAElastic>
    {
        SalesWarrantySLA Get(long supportID);
    }
}
