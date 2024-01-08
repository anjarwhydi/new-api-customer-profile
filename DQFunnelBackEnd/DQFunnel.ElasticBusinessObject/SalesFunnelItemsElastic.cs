using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelItemsElastic : BaseEntityES
	{
		[Number(Name = "FunnelItemsID")]
		public long FunnelItemsID { get; set; }

		[Number(Name = "FunnelGenID")]
		public long FunnelGenID { get; set; }

		[Number(Name = "ItemType")]
		public int ItemType { get; set; }

		[Number(Name = "ItemID")]
		public int ItemID { get; set; }

		[Text(Name = "ItemName")]
		public string ItemName { get; set; }

		[Text(Name = "ItemSubName")]
		public string ItemSubName { get; set; }

		[Text(Name = "ItemDescription")]
		public string ItemDescription { get; set; }

		[Number(Name = "OrderingPrice")]
		public decimal? OrderingPrice { get; set; }

		[Number(Name = "SellingPrice")]
		public decimal? SellingPrice { get; set; }

		[Text(Name = "DealRegNo")]
		public string DealRegNo { get; set; }

		[Date(Name = "DealRegExpiryDate")]
		public DateTime? DealRegExpiryDate { get; set; }

	}
}