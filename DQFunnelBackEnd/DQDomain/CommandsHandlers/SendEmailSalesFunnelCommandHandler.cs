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
    public class SendEmailSalesFunnelCommandHandler : IRequestHandler<SendEmailSalesFunnelCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSalesFunnelCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSalesFunnelCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailSalesFunnelEvent(request));
            return Task.FromResult(true);
        }
    }
}
