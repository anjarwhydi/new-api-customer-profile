using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface IRelatedCustomerRepository : IRepository<CpRelatedCustomer>
    {
        CpRelatedCustomer GetRelatedCustomerById(long Id);
        List<Req_CustomerSettingGetRelatedCustomer_ViewModel> GetRelatedCustomerByCustomerID(long customerID);
        bool DeleteRelatedCustomer(long Id);
    }
}
