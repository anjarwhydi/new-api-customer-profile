using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesFunnelActivityElastic : BaseEntityES
    {
        [Number(Name = "FunnelActivityID")]
        public long FunnelActivityID { get; set; }

        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Number(Name = "ActivityTypeID")]
        public int ActivityTypeID { get; set; }

        [Text(Name = "ActivityTitle")]
        public string ActivityTitle { get; set; }

        [Date(Name = "ActivityStartTime")]
        public DateTime? ActivityStartTime { get; set; }

        [Date(Name = "ActivityEndTime")]
        public DateTime? ActivityEndTime { get; set; }

        [Text(Name = "ActivityText1")]
        public string ActivityText1 { get; set; }

        [Text(Name = "ActivityText2")]
        public string ActivityText2 { get; set; }

        [Text(Name = "ItemActivityText3Name")]
        public string ActivityText3 { get; set; }

        [Text(Name = "ActivityText4")]
        public string ActivityText4 { get; set; }

        [Text(Name = "ActivityText5")]
        public string ActivityText5 { get; set; }

        [Number(Name = "ActivityStatusID")]
        public int ActivityStatusID { get; set; }
    }
}
