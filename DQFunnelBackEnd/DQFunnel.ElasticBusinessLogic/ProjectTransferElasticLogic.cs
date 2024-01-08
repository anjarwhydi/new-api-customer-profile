using DQFunnel.ElasticBusinessLogic.Interfaces;
using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticBusinessObject.Common;
using DQFunnel.ElasticDataAccess;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticBusinessLogic
{
    public class ProjectTransferElasticLogic : IProjectTransferElasticLogic
    {
        private IProjectTransferElasticRepository objRepo;

        public ProjectTransferElasticLogic(string ES_URI)
        {
            objRepo = new ProjectTransferElasticRepository(IndexNameConst.SALES_PROJECT_TRANSFER, ES_URI);
        }

        public SalesProjectTransferElastic GetById(string id)
        {
            return objRepo.QueryById(id);
        }

        public List<ProjectTransferHistoryElastic> GetListHistoryByCreator(int createUserID)
        {
            return objRepo.GetListHistoryByCreator(createUserID);
        }

        public string Save(SalesProjectTransferElastic entity)
        {
            if (objRepo.Index(entity))
                return "Index Success";
            return "Index Failed";
        }
    }
}
