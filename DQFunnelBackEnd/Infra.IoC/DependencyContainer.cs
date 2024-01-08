using Domain.Core.Bus;
using DQDomain.Commands;
using DQDomain.CommandsHandlers;
using DQDomain.Events;
using DQFunnel.BusinessLogic;
using DQFunnel.BusinessLogic.Interfaces;
using DQFunnel.DataAccess.Interfaces;
using DQFunnel.DataAccess.Repositories;
using Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Command
            services.AddTransient<IRequestHandler<SaveFunnelCommand, bool>, SaveFunnelCommandHandler>(); //Save Funnel To Rabbit then Elastic
            //services.AddTransient<IRequestHandler<SendSalesIDCommand, bool>, SendSalesIDCommandHandler>();
            services.AddTransient<IRequestHandler<SendFunnelFileCommand, bool>, SendFunnelFileCommandHandler>(); // Save Attachment to Rabbit then Elastic
            services.AddTransient<IRequestHandler<SaveActivityCommand, bool>, SaveActivityCommandHandler>(); //Save Activity Meeting Request to Rabbit then Elastic
            services.AddTransient<IRequestHandler<SendEmailActivityCommand, bool>, SendEmailActivityCommandHandler>(); //Send Email to Rabbit then Email Service
            services.AddTransient<IRequestHandler<SaveBankGuaranteeCommand, bool>, SaveBankGuaranteeCommandHandler>(); //Send salesBG to rabbit then Elastic
            services.AddTransient<IRequestHandler<SendEmailBankGuaranteeCommand, bool>, SendEmailBankGuaranteeCommandHandler>(); //Send salesBG to rabbit then Elastic
            services.AddTransient<IRequestHandler<SendEmailSalesFunnelCommand, bool>, SendEmailSalesFunnelCommandHandler>(); //Send Email Sales Funnel to rabbit then EmailService
            services.AddTransient<IRequestHandler<UpdateBankGuaranteeCommand, bool>, UpdateBankGuaranteeCommandHandler>(); //Send Email Sales Funnel to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailPOCRequirementCommand, bool>, SendEmailPOCReqCommandHandler>(); //Send Email POC Requirement to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailPOCUploadCommand, bool>, SendEmailPOCUploadCommandHandler>(); //Send Email POC Requirement Upload File to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailUpdateStatusFunnelCommand, bool>, SendEmailUpdateStatusFunnelCommandHandler>(); //Send Email Update Status Funnel to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailAddProductCommand, bool>, SendEmailAddProductCommandHandler>(); //Send Email Add Product Funnel to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailToSalesPOCReqCommand, bool>, SendEmailToSalesPOCReqCommandHandler>(); //Send Email PIC Complete POCReq to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailReassignCommand, bool>, SendEmailReassignCommandHandler>(); //Send Email Reassign to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailReqDiscountCommand, bool>, SendEmailReqDiscountCommandHandler>(); //Send Email Reassign to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailPOCCommand, bool>, SendEmailPOCCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailAssignCommand, bool>, SendEmailAssignCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailEditProductCommand, bool>, SendEmailEditProductCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailSalesFunnelEditCommand, bool>, SendEmailSalesFunnelEditCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailReassignByFunnelCommand, bool>, SendEmailReassignByFunnelCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailReassignByListFunnelCommand, bool>, SendEmailReassignByListFunnelCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailSummaryInsertFormCommand, bool>, SendEmailSummaryInsertFormCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailFunnelActivityCommand, bool>, SendEmailFunnelActivityCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailFunnelOpportunityCommand, bool>, SendEmailFunnelOpportunityCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailReassignFunnelOpportunityCommand, bool>, SendEmailReassignFunnelOpportunityCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailSalesFunnelCloudServiceCommand, bool>, SendEmailSalesFunnelCloudServiceCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailReqDiscountItemServiceCommand, bool>, SendEmailReqDiscountItemServiceCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailFunnelCustomerBlacklistCommand, bool>, SendEmailFunnelCustomerBlacklistCommandHandler>(); //Send Email POC to rabbit then EmailService
            services.AddTransient<IRequestHandler<SendEmailPMOSMOCommand, bool>, SendEmailPMOSMOCommandHandler>(); //Send Email POC to rabbit then EmailService
			services.AddTransient<IRequestHandler<SendEmailBGBankCommand, bool>, SendEmailBGBankCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailCCSUpdatePriceCommand, bool>, SendEmailCCSUpdatePriceCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailCCSAddTicketCommand, bool>, SendEmailCCSAddTicketCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailSASubmitCommercialCommand, bool>, SendEmailSASubmitCommercialCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailSASubmitApprovalCommand, bool>, SendEmailSASubmitApprovalCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailSARequestReopenProjectCommand, bool>, SendEmailSARequestReopenProjectCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailSACancelCommand, bool>, SendEmailSACancelCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailSABlastPresalesCommand, bool>, SendEmailSABlastPresalesCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailSACostChangedCommand, bool>, SendEmailSACostChangedCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailDelegasiSubmitCommand, bool>, SendEmailDelegasiSubmitCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailSASubmitApprovalNextCommand, bool>, SendEmailSASubmitApprovalNextCommandHandler>();
            services.AddTransient<IRequestHandler<SyncBoqToItemMasterCommand, bool>, SyncBoqToItemMasterCommandHandler>();
            services.AddTransient<IRequestHandler<SendEmailFunnelCBVCommand, bool>, SendEmailFunnelCBVCommandHandler>();
            //services.AddTransient<IRequestHandler<SendEmailFunnelCustomerCreditServiceCommand, bool>, SendEmailFunnelCustomerCreditServiceCommandHandler>(); //Send Email POC to rabbit then EmailService

            services.AddTransient<IFunnelCommandLogic, FunnelCommandLogic>();

            //Event            
            services.AddTransient<IFunnelCommandRepository, FunnelCommandRepository>();
        }
    }
}
