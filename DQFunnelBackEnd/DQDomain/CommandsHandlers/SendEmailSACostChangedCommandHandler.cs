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
    public class SendEmailSACostChangedCommandHandler : IRequestHandler<SendEmailSACostChangedCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSACostChangedCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSACostChangedCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new FunnelSA_SendEmailSACostChangedEvent(request));
            return Task.FromResult(true);
        }
    }
}
