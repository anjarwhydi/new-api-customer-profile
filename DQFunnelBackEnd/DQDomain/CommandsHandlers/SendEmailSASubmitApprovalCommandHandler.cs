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
    public class SendEmailSASubmitApprovalCommandHandler : IRequestHandler<SendEmailSASubmitApprovalCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSASubmitApprovalCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSASubmitApprovalCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new FunnelSA_SendEmailSASubmitApprovalEvent(request));
            return Task.FromResult(true);
        }
    }
}
