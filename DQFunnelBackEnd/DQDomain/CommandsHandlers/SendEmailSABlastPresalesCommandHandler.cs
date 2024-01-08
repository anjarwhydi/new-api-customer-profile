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
    public class SendEmailSABlastPresalesCommandHandler : IRequestHandler<SendEmailSABlastPresalesCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSABlastPresalesCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSABlastPresalesCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new FunnelSA_SendEmailSABlastPresalesEvent(request));
            return Task.FromResult(true);
        }
    }
}
