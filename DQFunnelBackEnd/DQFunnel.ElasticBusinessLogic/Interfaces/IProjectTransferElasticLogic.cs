using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic.Interfaces
{
    public interface IProjectTransferElasticLogic
    {
        string Save(SalesProjectTransferElastic entity);
        SalesProjectTransferElastic GetById(string id);
        List<ProjectTransferHistoryElastic> GetListHistoryByCreator(int createUserID);
    }
}
