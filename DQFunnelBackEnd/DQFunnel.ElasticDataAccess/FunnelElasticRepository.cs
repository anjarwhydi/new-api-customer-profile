using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using DQFunnel.ElasticBusinessObject;
using DQFunnel.ElasticDataAccess.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DQFunnel.ElasticDataAccess
{
    public class FunnelElasticRepository : ElasticRepository<FunnelElastic>, IFunnelElasticRepository
    {
        private string _indexName;
        private string _hostElastic;
        public FunnelElasticRepository(string indexName, string hostElastic) : base(indexName, hostElastic)
        {
            _indexName = indexName;
            _hostElastic = hostElastic;
        }

        public bool Delete(long funnelGenID)
        {
            var result = Current.Delete<FunnelElastic>(funnelGenID);
            return result.IsValid;

        }

        public List<FunnelDashboard> FilterSearch(Get_SalesFunnelFilterSearch_ViewModel obj)
        {
            List<int> listFunnelStatusID = null;
            List<int> listSalesID = null;
            List<int> listItemID = null;
            List<int> listCustomerGenID = null;
            if (obj.FunnelStatusID != null)
            {
                listFunnelStatusID = obj.FunnelStatusID.Split(",").Select(Int32.Parse).ToList();
            }
            if (obj.SalesID != null)
            {
                listSalesID = obj.SalesID.Split(",").Select(Int32.Parse).ToList();
            }
            if (obj.ItemID != null)
            {
                listItemID = obj.ItemID.Split(",").Select(Int32.Parse).ToList();
            }
            if (obj.CustomerGenID != null)
            {
                listCustomerGenID = obj.CustomerGenID.Split(",").Select(Int32.Parse).ToList();
            }

            try
            {
                var hits = Current
                            .Search<FunnelElastic>(s => s
                            .Source(sf => sf
                            .Includes(i => i
                            .Fields(
                                f => f.id,
                                f => f.CreateDate,
                                f => f.CustomerGenID,
                                f => f.CustomerName,
                                f => f.DealCloseDate,
                                f => f.GPMAmount,
                                f => f.GPMPctg,
                                f => f.ProjectName,
                                f => f.SalesID,
                                f => f.SalesName,
                                f => f.TotalSellingPrice,
                                f => f.FunnelStatus)))
                            .Query(q => q
                            .Bool(bq => bq
                            .Filter(
                                fq => fq.Terms(t => t.Field(f => f.SalesFunnelItems.First().ItemID).Terms(listItemID)) 
                                || fq.Terms(t => t.Field(f => f.SalesID).Terms(listSalesID))
                                || fq.Terms(t => t.Field(f => f.CustomerGenID).Terms(listCustomerGenID))
                                || fq.Terms(t => t.Field(f => f.FunnelStatusID).Terms(listFunnelStatusID))
                                || fq.DateRange(dt => dt
                                    .Field(f => f.DealCloseDate)
                                    .GreaterThanOrEquals(obj.DealCloseDateStart)
                                    .LessThanOrEquals(obj.DealCloseDateEnd))
                                || fq.LongRange(lr => lr
                                    .Field(f => f.TotalSellingPrice)
                                    .GreaterThanOrEquals(Convert.ToInt64(obj.TotalSellingPriceMin))
                                    .LessThanOrEquals(Convert.ToInt64(obj.TotalSellingPriceMax))
                                )
                                )
                        )
                    ));

                var typedList = from x in hits.Hits
                                select new FunnelDashboard
                                {
                                    FunnelGenID = Convert.ToInt64(x.Source.id),
                                    CreateDate = x.Source.CreateDate,
                                    CustomerGenID = Convert.ToInt32(x.Source.CustomerGenID),
                                    CustomerName = x.Source.CustomerName,
                                    DealCloseDate = x.Source.DealCloseDate,
                                    FunnelStatus = x.Source.FunnelStatus,
                                    GPMAmount = x.Source.GPMAmount,
                                    GPMPctg = Convert.ToInt32(x.Source.GPMPctg),
                                    ProjectName = x.Source.ProjectName,
                                    SalesID = x.Source.SalesID,
                                    SalesName = x.Source.SalesName,
                                    TotalSellingPrice = x.Source.TotalSellingPrice
                                };

                return typedList.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public FunnelElastic GetbyFunnelGenID(long funnelGenID)
        {
            var hits = Current
                            .Search<FunnelElastic>(s => s.Query(q => q
                            .Bool(bq => bq
                            .Filter(
                                fq => fq.Terms(t => t.Field(f => f.id).Terms(funnelGenID))
                                )
                        )
                    ));

            FunnelElastic typedList = hits.Documents.FirstOrDefault();

            return typedList;
        }

        public List<FunnelDashboard> GetListBySalesID(int salesID)
        {
            try
            {
                var hits = Current
                            .Search<FunnelElastic>(s => s
                            .Source(sf => sf
                            .Includes(i => i
                            .Fields(
                                f => f.id,
                                f => f.CreateDate,
                                f => f.CustomerGenID,
                                f => f.CustomerName,
                                f => f.DealCloseDate,
                                f => f.GPMAmount,
                                f => f.GPMPctg,
                                f => f.ProjectName,
                                f => f.SalesID,
                                f => f.SalesName,
                                f => f.TotalSellingPrice,
                                f => f.FunnelStatus)))
                            .Query(q => q
                            .Bool(bq => bq
                            .Filter(
                                fq => fq.Terms(t => t.Field(f => f.SalesID).Terms(salesID))
                                )
                        )
                    ));

                var typedList = from x in hits.Hits
                                select new FunnelDashboard
                                {
                                    FunnelGenID = Convert.ToInt64(x.Source.id),
                                    CreateDate = x.Source.CreateDate,
                                    CustomerGenID = Convert.ToInt32(x.Source.CustomerGenID),
                                    CustomerName = x.Source.CustomerName,
                                    DealCloseDate = x.Source.DealCloseDate,
                                    FunnelStatus = x.Source.FunnelStatus,
                                    GPMAmount = x.Source.GPMAmount,
                                    GPMPctg = Convert.ToInt32(x.Source.GPMPctg),
                                    ProjectName = x.Source.ProjectName,
                                    SalesID = x.Source.SalesID,
                                    SalesName = x.Source.SalesName,
                                    TotalSellingPrice = x.Source.TotalSellingPrice
                                };

                return typedList.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<FunnelCustomerElastic> GetListCustomerBySalesID(int salesID)
        {
            var hits = Current
                          .Search<FunnelElastic>(s => s.Query(q => q
                          .Match(m => m
                              .Field(f => f.SalesID)
                              .Query(salesID.ToString())
                          )
                      )
                  );

            List<FunnelElastic> typedList = hits.Documents.ToList();
            var result = typedList.Select(c => new FunnelCustomerElastic() { CustomerGenID = c.CustomerGenID, CustomerName = c.CustomerName });
            List<FunnelCustomerElastic> funnelCustomer = result
                .GroupBy(l => l.CustomerGenID)
                .Select(cl => new FunnelCustomerElastic
                {
                    CustomerGenID = cl.First().CustomerGenID,
                    CustomerName = cl.First().CustomerName
                }).ToList();

            return funnelCustomer;
        }

        public List<FunnelDashboard> Search(string text)
        {
            try
            {
                var hits = Current
                            .Search<FunnelElastic>(s => s
                            .Scroll("2m")
                            .Size(10000)
                            .Source(sf => sf
                            .Includes(i => i
                            .Fields(
                                f => f.id,
                                f => f.CreateDate,
                                f => f.CustomerGenID,
                                f => f.CustomerName,
                                f => f.DealCloseDate,
                                f => f.GPMAmount,
                                f => f.GPMPctg,
                                f => f.ProjectName,
                                f => f.SalesID,
                                f => f.SalesName,
                                f => f.TotalSellingPrice,
                                f => f.FunnelStatus)))
                            .Query(q => q
                            .Bool(bq => bq
                            .Must(m => m
                            .QueryString(qs => qs
                            .Fields(fs => fs
                            .Field(f1 => f1.CustomerName)
                            .Field(f1 => f1.SalesName)
                            .Field(f1 => f1.ProjectName)
                            .Field(f1 => f1.FunnelStatus))
                            .Query(text+"*")))
                        )
                    ));

                var typedList = from x in hits.Hits
                                select new FunnelDashboard
                                {
                                    FunnelGenID = Convert.ToInt64(x.Source.id),
                                    CreateDate = x.Source.CreateDate,
                                    CustomerGenID = Convert.ToInt32(x.Source.CustomerGenID),
                                    CustomerName = x.Source.CustomerName,
                                    DealCloseDate = x.Source.DealCloseDate,
                                    FunnelStatus = x.Source.FunnelStatus,
                                    GPMAmount = x.Source.GPMAmount,
                                    GPMPctg = Convert.ToInt32(x.Source.GPMPctg),
                                    ProjectName = x.Source.ProjectName,
                                    SalesID = x.Source.SalesID,
                                    SalesName = x.Source.SalesName,
                                    TotalSellingPrice = x.Source.TotalSellingPrice
                                };

                return typedList.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
