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
    public class SendEmailFunnelCBVCommandHandler : IRequestHandler<SendEmailFunnelCBVCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailFunnelCBVCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailFunnelCBVCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailFunnelCBVEvent(request));
            return Task.FromResult(true);
        }
    }
}
