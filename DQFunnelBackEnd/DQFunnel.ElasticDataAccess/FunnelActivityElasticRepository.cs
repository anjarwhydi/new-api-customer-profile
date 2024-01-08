using DQFunnel.BusinessObject;
using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class FunnelActivityElasticRepository : ElasticRepository<SalesFunnelActivityElastic>, IFunnelActivityElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public FunnelActivityElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }
        public List<FunnelActivityDashboard> Search(string text)
        {
            return null;
            //try
            //{
            //    var hits = Current
            //                .Search<SalesFunnelActivityElastic>(s => s
            //                .Scroll("2m")
            //                .Size(10000)
            //                .Source(sf => sf
            //                .Includes(i => i
            //                .Fields(
            //                    f => f.FunnelActivityID,
            //                    f => f.CreateDate,
            //                    f => f.CustomerGenID,
            //                    f => f.CustomerName,
            //                    f => f.DealCloseDate,
            //                    f => f.GPMAmount,
            //                    f => f.GPMPctg,
            //                    f => f.ProjectName,
            //                    f => f.SalesID,
            //                    f => f.SalesName,
            //                    f => f.TotalSellingPrice,
            //                    f => f.FunnelStatus)))
            //                .Query(q => q
            //                .Bool(bq => bq
            //                .Must(m => m
            //                .QueryString(qs => qs
            //                .Fields(fs => fs
            //                .Field(f1 => f1.CustomerName)
            //                .Field(f1 => f1.SalesName)
            //                .Field(f1 => f1.ProjectName)
            //                .Field(f1 => f1.FunnelStatus))
            //                .Query(text + "*")))
            //            )
            //        ));

            //    var typedList = from x in hits.Hits
            //                    select new FunnelDashboard
            //                    {
            //                        FunnelGenID = Convert.ToInt64(x.Source.id),
            //                        CreateDate = x.Source.CreateDate,
            //                        CustomerGenID = Convert.ToInt32(x.Source.CustomerGenID),
            //                        CustomerName = x.Source.CustomerName,
            //                        DealCloseDate = x.Source.DealCloseDate,
            //                        FunnelStatus = x.Source.FunnelStatus,
            //                        GPMAmount = x.Source.GPMAmount,
            //                        GPMPctg = Convert.ToInt32(x.Source.GPMPctg),
            //                        ProjectName = x.Source.ProjectName,
            //                        SalesID = x.Source.SalesID,
            //                        SalesName = x.Source.SalesName,
            //                        TotalSellingPrice = x.Source.TotalSellingPrice
            //                    };

            //    return typedList.ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }
    }
}
