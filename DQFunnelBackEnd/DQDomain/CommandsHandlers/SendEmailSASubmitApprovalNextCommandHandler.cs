using Domain.Core.Bus;
using DQDomain.Commands;
using DQDomain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DQDomain.CommandsHandlers
{
    public class SendEmailSASubmitApprovalNextCommandHandler : IRequestHandler<SendEmailSASubmitApprovalNextCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSASubmitApprovalNextCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSASubmitApprovalNextCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new FunnelSA_SendEmailSASubmitApprovalNextEvent(request));
            return Task.FromResult(true);
        }
    }
}
