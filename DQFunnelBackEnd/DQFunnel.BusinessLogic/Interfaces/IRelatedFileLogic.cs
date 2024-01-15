using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface IRelatedFileLogic
    {
        ResultAction GetRelatedFile();
        ResultAction InsertRelatedFile(CpRelatedFile objEntity);
        ResultAction UpdateRelatedFile(long Id, CpRelatedFile objEntity);
        ResultAction DeleteRelatedFile(long Id);
    }
}
