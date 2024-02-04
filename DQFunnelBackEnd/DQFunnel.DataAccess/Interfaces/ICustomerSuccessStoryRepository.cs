using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQFunnel.DataAccess.Interfaces
{
    public interface ICustomerSuccessStoryRepository : IRepository<CpCustomerSuccessStory>
    {
        List<string> GetCustomerStoriesByCustomerID(long funnelID);
    }
}
