using DQFunnel.ElasticBusinessObject.Base;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticBusinessObject
{
    [ElasticsearchType(IdProperty = nameof(FunnelAttachmentID))]
    public class FileFunnelAttachmentElastic : BaseEntityES
    {
        [Text(Name = "FunnelAttachmentID")]
        public string FunnelAttachmentID { get; set; }

        [Number(Name = "FunnelGenID")]
        public long FunnelGenID { get; set; }
        //public int FileTypeID { get; set; }

        [Number(Name = "DocumentTypeID")]
        public int DocumentTypeID { get; set; }
        //public string FileNameTitle { get; set; }

        [Text(Name = "DocumentName")]
        public string DocumentName { get; set; }

        [Text(Name = "Notes")]
        public string Notes { get; set; }
        //public string FileDescription { get; set; }

        [Number(Name = "VersionNumber")]
        public int VersionNumber { get; set; }

        [Number(Name = "ActiveFlag")]
        public int ActiveFlag { get; set; }

        [Binary(Name = "FileBlob")]
        public byte[] FileBlob { get; set; }

        [Text(Name = "FileExtension")]
        public string FileExtension { get; set; }

        [Number(Name = "FileSize")]
        public long FileSize { get; set; }
    }
}
