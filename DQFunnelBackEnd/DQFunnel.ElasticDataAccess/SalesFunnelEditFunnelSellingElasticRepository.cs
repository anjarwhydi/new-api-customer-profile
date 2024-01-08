using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class SalesFunnelEditFunnelSellingElasticRepository : ElasticRepository<FunnelElastic>, ISalesFunnelEditFunnelSellingElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public SalesFunnelEditFunnelSellingElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public IEnumerable<SalesFunnelEditSellingElastic> GetViewFunnelSelling(long funnelGenId)
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
                                select new SalesFunnelEditSellingElastic
                                {
                                    FunnelGenID = Int32.Parse(x.Source.id),
                                    GPMAmount = x.Source.GPMAmount,
                                    GPMPctg = x.Source.GPMPctg,
                                    TotalOrderingPrice = x.Source.TotalOrderingPrice,
                                    TotalOrderingPriceProduct = x.Source.TotalOrderingPriceProduct,
                                    TotalOrderingPriceService = x.Source.TotalOrderingPriceService,
                                    TotalSellingPrice = x.Source.TotalSellingPrice,
                                    TotalSellingPriceProduct = x.Source.TotalSellingPriceProduct,
                                    TotalSellingPriceService = x.Source.TotalSellingPriceService,
                                    ModifyUserID = x.Source.ModifyUserID
                                };

                return typedList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateFunnelSelling(SalesFunnelEditSellingElastic salesFunnel)
        {
            try
            {
                Current.Update<FunnelElastic, object>(salesFunnel.FunnelGenID.ToString(), u => u
               .Index(_indexName)
               .Doc(new FunnelElastic
               {
                   GPMAmount = salesFunnel.GPMAmount,
                   GPMPctg = salesFunnel.GPMPctg,
                   TotalOrderingPrice = salesFunnel.TotalOrderingPrice,
                   TotalOrderingPriceProduct = salesFunnel.TotalOrderingPriceProduct,
                   TotalOrderingPriceService = salesFunnel.TotalOrderingPriceService,
                   TotalSellingPrice = salesFunnel.TotalSellingPrice,
                   TotalSellingPriceProduct = salesFunnel.TotalSellingPriceProduct,
                   TotalSellingPriceService = salesFunnel.TotalSellingPriceService,
                   ModifyUserID = salesFunnel.ModifyUserID
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
