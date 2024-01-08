using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailToSalesPOCReqEvent : Event
    {
        public Funnel_SendEmailToSalesPOCReqEvent()
        {
            SalesPOCRequirement = new SalesPOCRequirement();
            SalesPOC = new SalesPOC();
            SalesFunnel = new SalesFunnel();
            Email = new EmailAddr();
        }

        public SalesPOCRequirement SalesPOCRequirement { get; set; }
        public SalesPOC SalesPOC { get; set; }
        public SalesFunnel SalesFunnel { get; set; }
        public EmailAddr Email { get; set; }

        public string POCReqPICIDName { get; set; }
        public string POCReqPICAssignName { get; set; }
        public string CreateUserName { get; set; }

        public Funnel_SendEmailToSalesPOCReqEvent(SalesPOCRequirementMapperCommand obj)
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
