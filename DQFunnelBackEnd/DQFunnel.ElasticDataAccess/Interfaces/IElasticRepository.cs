using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.ElasticDataAccess.Interfaces
{
    public interface IElasticRepository<T>
        where T : class
    {
        bool Index(T entity);
        T QueryById(string id);
        List<T> QueryAll();
    }
}
