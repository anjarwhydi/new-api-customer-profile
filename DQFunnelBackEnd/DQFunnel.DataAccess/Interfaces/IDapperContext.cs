using System;
using System.Data;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface IDapperContext: IDisposable
    {
        IDbConnection db { get; }
        int GetLastId();
    }
}
