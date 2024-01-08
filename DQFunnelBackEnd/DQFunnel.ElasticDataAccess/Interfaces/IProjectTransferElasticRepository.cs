using DQFunnel.ElasticBusinessObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface IProjectTransferElasticRepository: IElasticRepository<SalesProjectTransferElastic>
    {
        List<SalesProjectTransferElastic> GetListByCreator(int createUserID);
        List<ProjectTransferHistoryElastic> GetListHistoryByCreator(int createUserID);
    }
}
