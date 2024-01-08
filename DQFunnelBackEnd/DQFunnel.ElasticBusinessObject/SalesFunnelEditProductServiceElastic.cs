using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelEditProductServiceElastic : BaseEntityES
    {
        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Text(Name = "FunnelID")]
        public string FunnelID { get; set; }

        [Number(Name = "FunnelStatusID")]
        public int FunnelStatusID { get; set; }

        [Number(Name = "FunnelItemsID")]
        public int FunnelItemsID { get; set; }

        [Number(Name = "ItemID")]
        public int ItemID { get; set; }

        [Number(Name = "ItemType")]
        public int ItemType { get; set; }

        [Text(Name = "ItemName")]
        public string ItemName { get; set; }

        [Text(Name = "ItemSubName")]
        public string ItemSubName { get; set; }

        [Text(Name = "ItemDescription")]
        public string ItemDescription { get; set; }

        [Number(Name = "OrderingPrice")]
        public decimal OrderingPrice { get; set; }

        [Number(Name = "SellingPrice")]
        public decimal SellingPrice { get; set; }
    }
}
