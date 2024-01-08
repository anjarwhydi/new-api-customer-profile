using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class FunnelItemsElasticRepository : ElasticRepository<SalesFunnelItemsElastic>, IFunnelItemsElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public FunnelItemsElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public bool Delete(long funnelItemsID)
        {
            var result = Current.Delete<SalesFunnelItemsElastic>(funnelItemsID);
            return result.IsValid;

        }

        public List<SalesFunnelItems> GetByFunnelGenID(long funnelGenID)
        {
            var hits = Current
                            .Search<SalesFunnelItemsElastic>(s => s.Query(q => q
                            .Bool(bq => bq
                            .Filter(
                                fq => fq.Terms(t => t.Field(f => f.FunnelGenID).Terms(funnelGenID))
                                )
                        )
                    ));

            var typedList = from x in hits.Hits
                            select new SalesFunnelItems
                            {
                                FunnelGenID = x.Source.FunnelGenID,
                                CreateDate = x.Source.CreateDate,
                                CreateUserID = x.Source.CreateUserID,
                                DealRegExpiryDate = x.Source.DealRegExpiryDate,
                                DealRegNo = x.Source.DealRegNo,
                                FunnelItemsID = x.Source.FunnelItemsID,
                                ItemDescription = x.Source.ItemDescription,
                                ItemID = x.Source.ItemID,
                                ItemName = x.Source.ItemName,
                                ItemSubName = x.Source.ItemSubName,
                                ItemType = x.Source.ItemType,
                                ModifyDate = x.Source.ModifyDate,
                                OrderingPrice = x.Source.OrderingPrice,
                                SellingPrice = x.Source.SellingPrice,
                                ModifyUserID = x.Source.ModifyUserID
                            };

            return typedList.ToList();
        }
    }
}
