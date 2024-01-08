using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class SalesFunnelEditPOElasticRepository : ElasticRepository<FunnelElastic>, ISalesFunnelEditPOElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public SalesFunnelEditPOElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public IEnumerable<SalesFunnelEditPOElastic> GetViewFunnelPOByFunnelGenID(long funnelGenID)
        {
            try
            {
                var hits = Current
                            .Search<FunnelElastic>(s => s
                            .Source(sf => sf
                            .Includes(i => i
                            .Fields(
                                f => f.id,
                                f => f.ContractStartDate,
                                f => f.ContractNo,
                                f => f.ContractEndDate,
                                f => f.POCustomerNo,
                                f => f.POCustomerDate)))
                            .Query(q => q
                            .Match(m => m
                            .Field(mf => mf.id)
                            .Query(funnelGenID.ToString())
                        )
                    ));

                var typedList = from x in hits.Hits
                                select new SalesFunnelEditPOElastic
                                {
                                    FunnelGenID = Convert.ToInt64(x.Source.id),
                                    ContractEndDate = x.Source.ContractEndDate,
                                    ContractNo = x.Source.ContractNo,
                                    ContractStartDate = x.Source.ContractStartDate,
                                    POCustomerNo = x.Source.POCustomerNo,
                                    SA = "test",
                                    SO = "test",
                                    POCustomerDate = x.Source.POCustomerDate
                                };

                return typedList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateFunnelPO(SalesFunnelEditPOElastic salesFunnel)
        {
            try
            {
                Current.Update<FunnelElastic, object>(salesFunnel.FunnelGenID.ToString(), u => u
               .Index(_indexName)
               .Doc(new FunnelElastic
               {
                   ContractEndDate = salesFunnel.ContractEndDate,
                   ContractNo = salesFunnel.ContractNo,
                   ContractStartDate = salesFunnel.ContractStartDate,
                   POCustomerNo = salesFunnel.POCustomerNo,
                   POCustomerDate = salesFunnel.POCustomerDate
               })
               .RetryOnConflict(3)
               );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
