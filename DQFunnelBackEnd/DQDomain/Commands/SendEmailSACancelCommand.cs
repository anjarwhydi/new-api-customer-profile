using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailSACancelCommand : EmailSASubmitMapperCommand
    {
        public SendEmailSACancelCommand(EmailSASubmitMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            Email = obj.Email;
            FunnelStatusHistory = obj.FunnelStatusHistory;
            Approval = obj.Approval;
            Notes = obj.Notes;
        }
    }
}
