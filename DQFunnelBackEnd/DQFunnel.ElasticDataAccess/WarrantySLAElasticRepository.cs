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
    public class WarrantySLAElasticRepository : ElasticRepository<SalesWarrantySLAElastic>, IWarrantySLAElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public WarrantySLAElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public bool Delete(long warrantySLAGenID)
        {
            var result = Current.Delete<SalesWarrantySLAElastic>(warrantySLAGenID);
            return result.IsValid;

        }

        public SalesWarrantySLA Get(long supportID)
        {
            var hits = Current
                            .Search<SalesWarrantySLAElastic>(s => s.Query(q => q
                            .Bool(bq => bq
                            .Filter(
                                fq => fq.Terms(t => t.Field(f => f.WarrantySupportID).Terms(supportID))
                                )
                        )
                    ));

            var typedList = from x in hits.Hits
                            select new SalesWarrantySLA
                            {
                                BrandID = x.Source.BrandID,
                                CreateDate = x.Source.CreateDate,
                                CreateUserID = x.Source.CreateUserID,
                                CustomerWarranty = x.Source.CustomerWarranty,
                                ModifyDate = x.Source.ModifyDate,
                                ModifyUserID = x.Source.ModifyUserID,
                                ProblemClassID = x.Source.ProblemClassID,
                                StartWarrantyCust = x.Source.StartWarrantyCust,
                                StartWarrantyVendor = x.Source.StartWarrantyVendor,
                                SubBrandID = x.Source.SubBrandID,
                                WarrantySLAGenID = x.Source.WarrantySLAGenID,
                                VendorWarranty = x.Source.VendorWarranty,
                                WarrantySupportID = x.Source.WarrantySupportID
                            };

            return typedList.FirstOrDefault();
        }
    }
}
