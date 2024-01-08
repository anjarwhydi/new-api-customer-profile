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
    public class SendEmailFunnelCustomerBlacklistCommandHandler : IRequestHandler<SendEmailFunnelCustomerBlacklistCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailFunnelCustomerBlacklistCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailFunnelCustomerBlacklistCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailFunnelCustomerBlacklistEvent(request));
            return Task.FromResult(true);
        }
    }
}
