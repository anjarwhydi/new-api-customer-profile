using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class BankGuaranteeElasticRepository : ElasticRepository<SalesBankGuaranteeElastic>, IBankGuaranteeElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public BankGuaranteeElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public bool Delete(long bgID)
        {
            var result = Current.Delete<SalesBankGuaranteeElastic>(bgID);
            return result.IsValid;

        }

        public SalesBankGuaranteeElastic GetByBGID(long bgID)
        {
            var hits = Current
                            .Search<SalesBankGuaranteeElastic>(s => s.Query(q => q
                            .Bool(bq => bq
                            .Filter(
                                fq => fq.Terms(t => t.Field(f => f.BankGuaranteeGenID).Terms(bgID))
                                )
                        )
                    ));

            SalesBankGuaranteeElastic typedList = hits.Documents.FirstOrDefault();

            return typedList;
        }

        public SalesBankGuaranteeElastic GetByFunnelGenID(long funnelGenID)
        {
            var hits = Current
                            .Search<SalesBankGuaranteeElastic>(s => s.Query(q => q
                            .Bool(bq => bq
                            .Filter(
                                fq => fq.Terms(t => t.Field(f => f.FunnelGenID).Terms(funnelGenID))
                                )
                        )
                    ));

            SalesBankGuaranteeElastic typedList = hits.Documents.FirstOrDefault();

            return typedList;
        }
    }
}
