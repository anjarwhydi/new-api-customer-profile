using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class SalesFunnelEditCustomerElasticRepository : ElasticRepository<FunnelElastic>, ISalesFunnelEditCustomerElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public SalesFunnelEditCustomerElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public IEnumerable<SalesFunnelEditCustomerElastic> GetViewFunnelCustomerByFunnelGenID(long funnelGenID)
        {
            try
            {
                var hits = Current
                            .Search<FunnelElastic>(s => s
                            .Source(sf => sf
                            .Includes(i => i
                            .Fields(
                                f => f.id,
                                f => f.ActEndProjectDate,
                                f => f.ActStartProjectDate,
                                f => f.CustomerGenID,
                                f => f.CustomerPICID,
                                f => f.EndUserCustomerGenID,
                                f => f.EstEndProjectDate,
                                f => f.EstStartProjectDate)))
                            .Query(q => q
                            .Match(m => m
                            .Field(mf => mf.id)
                            .Query(funnelGenID.ToString())
                        )
                    ));

                var typedList = from x in hits.Hits
                                select new SalesFunnelEditCustomerElastic
                                {
                                    FunnelGenID = Convert.ToInt64(x.Source.id),
                                    ActEndProjectDate = x.Source.ActEndProjectDate,
                                    ActStartProjectDate = x.Source.ActStartProjectDate,
                                    CustomerGenID = x.Source.CustomerGenID,
                                    CustomerPICID = x.Source.CustomerPICID,
                                    EndUserCustomerGenID = x.Source.EndUserCustomerGenID,
                                    EstEndProjectDate = x.Source.EstEndProjectDate,
                                    EstStartProjectDate = x.Source.EstStartProjectDate
                                };

                return typedList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateCustomer(SalesFunnelEditCustomerElastic salesFunnel)
        {
            try
            {
                Current.Update<FunnelElastic, object>(salesFunnel.FunnelGenID.ToString(), u => u
               .Index(_indexName)
               .Doc(new FunnelElastic
               {
                   CustomerPICID = salesFunnel.CustomerPICID,
                   CustomerGenID = salesFunnel.CustomerGenID
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
