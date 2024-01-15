using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface IRelatedCustomerRepository : IRepository<CpRelatedCustomer>
    {
        CpRelatedCustomer GetRelatedCustomerById(long Id);
    }
}
