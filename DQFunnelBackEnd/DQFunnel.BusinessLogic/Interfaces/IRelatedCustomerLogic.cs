using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface IRelatedCustomerLogic
    {
        ResultAction GetRelatedCustomer();
        ResultAction InsertRelatedCustomer(CpRelatedCustomer objEntity);
        ResultAction UpdateRelatedCustomer(long Id, CpRelatedCustomer objEntity);
        ResultAction DeleteRelatedCustomer(long Id);
    }
}
