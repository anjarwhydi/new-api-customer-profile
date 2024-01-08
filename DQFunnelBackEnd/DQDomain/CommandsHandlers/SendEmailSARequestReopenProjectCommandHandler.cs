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
    public class SendEmailSARequestReopenProjectCommandHandler : IRequestHandler<SendEmailSARequestReopenProjectCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSARequestReopenProjectCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSARequestReopenProjectCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new FunnelSA_SendEmailSARequestReopenProjectEvent(request));
            return Task.FromResult(true);
        }
    }
}
