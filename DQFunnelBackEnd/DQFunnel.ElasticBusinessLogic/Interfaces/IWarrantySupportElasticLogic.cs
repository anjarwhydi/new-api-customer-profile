using DQFunnel.BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic.Interfaces
{
    public interface IWarrantySupportElasticLogic
    {
        SalesWarrantySupport Get(long funnelGenID);
    }
}
