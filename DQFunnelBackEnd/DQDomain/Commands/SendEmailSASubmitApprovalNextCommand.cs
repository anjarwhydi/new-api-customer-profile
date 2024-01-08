using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailSASubmitApprovalNextCommand : EmailSASubmitApprovalMapperCommand
    {
        public SendEmailSASubmitApprovalNextCommand(EmailSASubmitApprovalMapperCommand obj)
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
