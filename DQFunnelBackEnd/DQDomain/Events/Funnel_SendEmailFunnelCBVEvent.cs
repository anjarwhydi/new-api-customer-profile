using Domain.Core.Events;
using DQFunnel.BusinessObject;
using DQFunnel.BusinessObject.Additional;
using DQFunnel.BusinessObject.CommandModel;
using DQFunnel.BusinessObject.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Events
{
    public class Funnel_SendEmailFunnelCBVEvent : Event
    {
        public Funnel_SendEmailFunnelCBVEvent()
        {
            SalesFunnelEmail = new SalesFunnelEmailSA();
            AWSBillingHeaderDashboard = new List<AwsBillingHeaderDashboard>();
            Email = new EmailAddrToCc();
            FunnelStatusHistory = new List<FunnelStatusHistory>();
        }

        public SalesFunnelEmailSA SalesFunnelEmail { get; set; }
        public List<AwsBillingHeaderDashboard> AWSBillingHeaderDashboard { get; set; }
        public EmailAddrToCc Email { get; set; }
        public List<FunnelStatusHistory> FunnelStatusHistory { get; set; }
        public string Process { get; set; }
        public string Notes { get; set; }
        public string Approval { get; set; }
        public string LastApproval { get; set; }
        public string LinkApproval { get; set; }

        public Funnel_SendEmailFunnelCBVEvent(SalesFunnelCBVEmailMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            AWSBillingHeaderDashboard = obj.AWSBillingHeaderDashboard;
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
