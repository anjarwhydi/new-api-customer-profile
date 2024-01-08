using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class FunnelSA_SendEmailSASubmitApprovalNextEvent : Event
    {
        public FunnelSA_SendEmailSASubmitApprovalNextEvent()
        {
            SalesFunnelEmail = new SalesFunnelEmailSA();
            Email = new EmailAddr();
            FunnelStatusHistory = new List<FunnelStatusHistory>();
        }
        public SalesFunnelEmailSA SalesFunnelEmail { get; set; }
        public EmailAddr Email { get; set; }
        public List<FunnelStatusHistory> FunnelStatusHistory { get; set; }
        public string Process { get; set; }
        public string Notes { get; set; }
        public string Approval { get; set; }
        public string LastApproval { get; set; }
        public string LinkApproval { get; set; }

        public FunnelSA_SendEmailSASubmitApprovalNextEvent(EmailSASubmitApprovalMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
            FunnelStatusHistory = obj.FunnelStatusHistory;
            Process = obj.Process;
            Notes = obj.Notes;
            Approval = obj.Approval;
            LastApproval = obj.LastApproval;
            LinkApproval = obj.LinkApproval;
        }
    }
}
