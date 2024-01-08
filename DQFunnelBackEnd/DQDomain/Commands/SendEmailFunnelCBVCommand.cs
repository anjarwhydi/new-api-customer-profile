using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailFunnelCBVCommand : SalesFunnelCBVEmailMapperCommand
    {
        public SendEmailFunnelCBVCommand(SalesFunnelCBVEmailMapperCommand obj)
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
