using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    public class SalesBankGuaranteeElastic : BaseEntityES
    {
        [Number(Name = "BankGuaranteeGenID")]
        public long BankGuaranteeGenID { get; set; }

        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }

        [Text(Name = "BankGuaranteeNo")]
        public string BankGuaranteeNo { get; set; }

        [Text(Name = "BondType")]
        public string BondType { get; set; }

        [Text(Name = "LetterType")]
        public string LetterType { get; set; }

        [Text(Name = "Language")]
        public string Language { get; set; }

        [Date(Name = "RequireOn")]
        public DateTime RequireOn { get; set; }

        [Number(Name = "BondIssuerID")]
        public long BondIssuerID { get; set; }

        [Date(Name = "EffectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [Date(Name = "ExpireDate")]
        public DateTime ExpireDate { get; set; }

        [Text(Name = "TenderNo")]
        public string TenderNo { get; set; }

        [Date(Name = "TenderAnnouncementDate")]
        public DateTime TenderAnnouncementDate { get; set; }

        [Date(Name = "SubmitDate")]
        public DateTime SubmitDate { get; set; }

        [Object]
        public List<FileFunnelAttachmentElastic> SalesBankGuaranteeAttachment { get; set; }
    }
}
