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
    public class SendEmailUpdateStatusFunnelCommandHandler : IRequestHandler<SendEmailUpdateStatusFunnelCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailUpdateStatusFunnelCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailUpdateStatusFunnelCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailUpdateStatusFunnelEvent(request));
            return Task.FromResult(true);
        }
    }
}
