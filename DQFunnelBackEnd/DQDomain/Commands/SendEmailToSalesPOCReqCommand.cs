using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailToSalesPOCReqCommand : SalesPOCRequirementMapperCommand
    {
        public SendEmailToSalesPOCReqCommand(SalesPOCRequirementMapperCommand obj)
        {
            SalesPOCRequirement = obj.SalesPOCRequirement;
            Email = obj.Email;
            SalesPOC = obj.SalesPOC;
            SalesFunnel = obj.SalesFunnel;
            POCReqPICIDName = obj.POCReqPICIDName;
            POCReqPICAssignName = obj.POCReqPICAssignName;
            CreateUserName = obj.CreateUserName;
        }
    }
}
