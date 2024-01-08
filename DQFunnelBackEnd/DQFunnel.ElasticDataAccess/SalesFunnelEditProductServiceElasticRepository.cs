using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class SalesFunnelEditProductServiceElasticRepository : ElasticRepository<FunnelElastic>, ISalesFunnelEditProductServiceElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public SalesFunnelEditProductServiceElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public void UpdateProductService(SalesFunnelEditProductServiceElastic salesFunnel)
        {
            try
            {
                var scriptParams = new Dictionary<string, object>
                {
                {"FunnelItemsID", salesFunnel.FunnelItemsID},
                {"ItemID", salesFunnel.ItemID},
                {"ItemType", salesFunnel.ItemType},
                {"ItemName", salesFunnel.ItemName},
                {"ItemSubName", salesFunnel.ItemSubName},
                {"ItemDescription", salesFunnel.ItemDescription},
                {"OrderingPrice", salesFunnel.OrderingPrice},
                {"SellingPrice", salesFunnel.SellingPrice},
                {"ModifyDate", salesFunnel.ModifyDate},
                {"ModifyUserID", salesFunnel.ModifyUserID}
                };

                var result = Current.UpdateByQuery<FunnelElastic>(u => u
                .Index(_indexName)
                .Query(q1 => q1
                .Bool(bq => bq
                .Must(mu => mu
                                .Match(m => m
                                    .Field(f => f.id)
                                    .Query(salesFunnel.FunnelGenID.ToString()))
                )))
                .Script(s => s
                .Source("def targets = ctx._source.SalesFunnelItems.findAll(f -> f.FunnelItemsID == params.FunnelItemsID); for (i in targets) " +
                "{" +
                "i.ItemID = params.ItemID;" +
                "i.ItemName = params.ItemName;" +
                "i.ItemType = params.ItemType;" +
                "i.ItemSubName = params.ItemSubName;" +
                "i.ItemDescription = params.ItemDescription;" +
                "i.OrderingPrice = params.OrderingPrice;" +
                "i.SellingPrice = params.SellingPrice;" +
                "i.ModifyDate = params.ModifyDate;" +
                "i.ModifyUserID = params.ModifyUserID;" +
                "}")
                .Params(scriptParams)
                )
                );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
