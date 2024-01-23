using System;
using System.Collections.Generic;
using System.Text;
using DQFunnel.BusinessObject;

namespace DQFunnel.BusinessLogic.Interfaces
{
    public interface ICustomerSuccessStoryLogic
    {
        ResultAction Insert(CpCustomerSuccessStory objEntity);
    }
}
