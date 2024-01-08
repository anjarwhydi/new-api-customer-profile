using DQFunnel.BusinessObject.CommandModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DQDomain.Commands
{
    public class SendEmailSABlastPresalesCommand : EmailSABlastPresalesMapperCommand
    {
        public SendEmailSABlastPresalesCommand(EmailSABlastPresalesMapperCommand obj)
        {
            SalesFunnelEmail = obj.SalesFunnelEmail;
            SalesFunnelServiceCatalogEmail = obj.SalesFunnelServiceCatalogEmail;
            PMActivityDetail = obj.PMActivityDetail;
            Email = obj.Email;
            attachmentList = obj.attachmentList;
        }
    }
}
