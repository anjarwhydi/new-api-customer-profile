using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class SalesFunnelEditFunnelAdditionalElasticRepository : ElasticRepository<FunnelElastic>, ISalesFunnelEditFunnelAdditionalElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public SalesFunnelEditFunnelAdditionalElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public IEnumerable<SalesFunnelEditFunnelAdditionalElastic> GetViewFunnelAdditional(long funnelGenId)
        {
            try
            {
                var hits = Current
                            .Search<FunnelElastic>(s => s
                            .Source(sf => sf
                            .Includes(i => i
                            .Fields(
                                f => f.id,
                                f => f.CompellingEvent,
                                f => f.CustomerBudget,
                                f => f.CustomerNeeds,
                                f => f.Competitor,
                                f => f.SupportiveCoach)))
                            .Query(q => q
                            .Match(m => m
                            .Field(mf => mf.id)
                            .Query(funnelGenId.ToString())
                        )
                    ));

                var typedList = from x in hits.Hits
                                select new SalesFunnelEditFunnelAdditionalElastic
                                {
                                    FunnelGenID = Int32.Parse(x.Source.id),
                                    CompellingEvent = x.Source.CompellingEvent,
                                    Competitor = x.Source.Competitor,
                                    CustomerBudget = x.Source.CustomerBudget,
                                    CustomerNeeds = x.Source.CustomerNeeds,
                                    SupportiveCoach = x.Source.SupportiveCoach
                                };

                return typedList;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public void UpdateFunnelAdditional(SalesFunnelEditFunnelAdditionalElastic salesFunnel)
        {
            try
            {
                Current.Update<FunnelElastic, object>(salesFunnel.FunnelGenID.ToString(), u => u
               .Index(_indexName)
               .Doc(new FunnelElastic
               {
                   CompellingEvent = salesFunnel.CompellingEvent,
                   Competitor = salesFunnel.Competitor,
                   CustomerBudget = salesFunnel.CustomerBudget,
                   CustomerNeeds = salesFunnel.CustomerNeeds,
                   SupportiveCoach = salesFunnel.SupportiveCoach
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
