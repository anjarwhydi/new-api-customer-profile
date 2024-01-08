using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class SalesFunnelEditStatusElasticRepository : ElasticRepository<FunnelElastic>, ISalesFunnelEditStatusElasticRepository
    { 
        private string _indexName;
        private string _hostElastic;
        public SalesFunnelEditStatusElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public IEnumerable<SalesFunnelEditStatusElastic> GetViewFunnelStatusByFunnelGenID(long FunnelGenID)
        {
            try
            {
                var hits = Current
                            .Search<FunnelElastic>(s => s
                            .Source(sf => sf
                            .Includes(i => i
                            .Fields(
                                f => f.id,
                                f => f.FunnelID,
                                f => f.FunnelStatusID,
                                f => f.FunnelStatus,
                                f => f.DealCloseDate,
                                f => f.SalesID,
                                f => f.SalesName)))
                            .Query(q => q
                            .Match(m => m
                            .Field(mf => mf.id)
                            .Query(FunnelGenID.ToString())
                        )
                    ));

                var typedList = from x in hits.Hits
                                select new SalesFunnelEditStatusElastic
                                {
                                    FunnelGenID = Int32.Parse(x.Source.id),
                                    FunnelID = x.Source.FunnelID,
                                    FunnelStatusID = x.Source.FunnelStatusID,
                                    FunnelStatus = x.Source.FunnelStatus,
                                    DealCloseDate = x.Source.DealCloseDate,
                                    SalesID = x.Source.SalesID,
                                    SalesName = x.Source.SalesName
                                };

                return typedList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateStatus(SalesFunnelEditStatusElastic salesFunnel)
        {
            try
            {
                Current.Update<FunnelElastic, object>(salesFunnel.FunnelGenID.ToString(), u => u
               .Index(_indexName)
               .Doc(new FunnelElastic
               {
                   FunnelID = salesFunnel.FunnelID,
                   FunnelStatusID = salesFunnel.FunnelStatusID,
                   DealCloseDate = salesFunnel.DealCloseDate,
                   SalesID = salesFunnel.SalesID,
                   SalesName = salesFunnel.SalesName
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
