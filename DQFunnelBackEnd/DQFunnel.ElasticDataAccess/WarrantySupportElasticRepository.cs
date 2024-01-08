using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class WarrantySupportElasticRepository : ElasticRepository<SalesWarrantySupportElastic>, IWarrantySupportElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public WarrantySupportElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public bool Delete(long warrantySupportID)
        {
            var result = Current.Delete<SalesWarrantySupportElastic>(warrantySupportID);
            return result.IsValid;
        }

        public SalesWarrantySupport Get(long funnelGenID)
        {
            var hits = Current
                            .Search<SalesWarrantySupportElastic>(s => s.Query(q => q
                            .Bool(bq => bq
                            .Filter(
                                fq => fq.Terms(t => t.Field(f => f.FunnelGenID).Terms(funnelGenID))
                                )
                        )
                    ));

            var typedList = from x in hits.Hits
                            select new SalesWarrantySupport
                            {
                                FunnelGenID = x.Source.FunnelGenID,
                                CreateDate = x.Source.CreateDate,
                                CreateUserID = x.Source.CreateUserID,
                                CorrectivePolicy = x.Source.CorrectivePolicy,
                                PreventivePolicy = x.Source.PreventivePolicy,
                                ServiceLocation = x.Source.ServiceLocation,
                                StartDateWarranty = x.Source.StartDateWarranty,
                                WarrantySupportID = x.Source.WarrantySupportID
                            };

            return typedList.FirstOrDefault();
        }
    }
}
