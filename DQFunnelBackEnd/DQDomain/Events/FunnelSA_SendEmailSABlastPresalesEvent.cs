using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class FunnelSA_SendEmailSABlastPresalesEvent : Event
    {
        public FunnelSA_SendEmailSABlastPresalesEvent()
        {
            SalesFunnelEmail = new SalesFunnelEmailSA();
            SalesFunnelServiceCatalogEmail = new List<SalesFunnelServiceCatalogApprovalEmailSA>();
            PMActivityDetail = new List<SalesFunnelTOPEmailSA>();
            Email = new EmailAddr();
        }
        public SalesFunnelEmailSA SalesFunnelEmail { get; set; }
        public List<SalesFunnelServiceCatalogApprovalEmailSA> SalesFunnelServiceCatalogEmail { get; set; }
        public List<SalesFunnelTOPEmailSA> PMActivityDetail { get; set; }
        public EmailAddr Email { get; set; }

        public string attachmentList { get; set; }

        public FunnelSA_SendEmailSABlastPresalesEvent(EmailSABlastPresalesMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            SalesFunnelServiceCatalogEmail = obj.SalesFunnelServiceCatalogEmail;
            PMActivityDetail = obj.PMActivityDetail;
            Email = obj.Email;
            attachmentList = obj.attachmentList;
        }
    }
}
