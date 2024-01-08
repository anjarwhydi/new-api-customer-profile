using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class ProjectTransferElasticRepository : ElasticRepository<SalesProjectTransferElastic>,IProjectTransferElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public ProjectTransferElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }
        public List<SalesProjectTransferElastic> GetListByCreator(int createUserID)
        {
            var hits = Current
                          .Search<SalesProjectTransferElastic>(s => s.Query(q => q
                          .Match(m => m
                              .Field(f => f.CreateUserID)
                              .Query(createUserID.ToString())
                          )
                      )
                  );

            List<SalesProjectTransferElastic> typedList = hits.Documents.ToList();

            return typedList;
        }

        public List<ProjectTransferHistoryElastic> GetListHistoryByCreator(int createUserID)
        {
            var listSalesTransfer = GetListByCreator(createUserID);
            var listCustomer = listSalesTransfer
              .AsQueryable().Select(s => new SalesProjectTransferElastic()
              {
                  CreateDate = s.CreateDate,
                  CreateUserID = s.CreateUserID,
                  FunnelGenID = s.FunnelGenID,
                  FromSalesName = s.FromSalesName,
                  ToSalesName = s.ToSalesName,
                  CustomerName = s.CustomerName
              }
                )
              .Select(cl => new ProjectTransferHistoryElastic
              {
                  FromSales = cl.FromSalesName,
                  CustomerName = cl.CustomerName,
                  ToSales = cl.ToSalesName,
                  CreateDate = (DateTime)cl.CreateDate,
                  FunnelID = cl.FunnelGenID.ToString(),
                  CreatorUserID = cl.CreateUserID
              });

          List<ProjectTransferHistoryElastic> result = listCustomer
                .GroupBy(g => new { g.CustomerName, g.CreatorUserID, g.FromSales, g.ToSales, g.CreateDate.Date })
                .Select(cl => new ProjectTransferHistoryElastic
                {
                    ID = Guid.NewGuid(),
                    CustomerName = cl.First().CustomerName,
                    CreatorUserID = cl.First().CreatorUserID,
                    FromSales = cl.First().FromSales,
                    ToSales = cl.First().ToSales,
                    CreateDate = cl.First().CreateDate,
                    FunnelID = String.Join(", ", cl.Select(d=>d.FunnelID))
                }).ToList();

            return result;
        }
    }
}
