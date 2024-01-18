using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface IRelatedFileRepository : IRepository<CpRelatedFile>
    {
        CpRelatedFile GetRelatedFileById(long Id);
        List<CpRelatedFile> GetRelatedFileByCustomerID(long customerID);
        CpRelatedFile GetRelatedFileByDocumentPath(string documentPath);
    }
}
