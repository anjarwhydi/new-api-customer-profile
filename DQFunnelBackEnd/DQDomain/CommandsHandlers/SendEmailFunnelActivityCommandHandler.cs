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
    public class SendEmailFunnelActivityCommandHandler : IRequestHandler<SendEmailFunnelActivityCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailFunnelActivityCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SendEmailFunnelActivityCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailFunnelActivityEvent(request));
            return Task.FromResult(true);
        }
    }
}
