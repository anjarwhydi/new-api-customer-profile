using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelEditSellingElastic : BaseEntityES
    {
		[Number(Name = "FunnelGenID")]
		public long FunnelGenID { get; set; }

		[Number(Name = "TotalOrderingPriceProduct")]
		public decimal? TotalOrderingPriceProduct { get; set; }

		[Number(Name = "TotalSellingPriceProduct")]
		public decimal? TotalSellingPriceProduct { get; set; }

		[Number(Name = "TotalOrderingPriceService")]
		public decimal? TotalOrderingPriceService { get; set; }

		[Number(Name = "TotalSellingPriceService")]
		public decimal? TotalSellingPriceService { get; set; }

		[Number(Name = "TotalOrderingPrice")]
		public decimal? TotalOrderingPrice { get; set; }

		[Number(Name = "TotalSellingPrice")]
		public decimal? TotalSellingPrice { get; set; }

		[Number(Name = "GPMPctg")]
		public float? GPMPctg { get; set; }

		[Number(Name = "GPMAmount")]
		public decimal? GPMAmount { get; set; }

	}
}
