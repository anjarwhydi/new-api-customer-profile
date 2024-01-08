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
    public class SendEmailReassignByListFunnelCommandHandler : IRequestHandler<SendEmailReassignByListFunnelCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailReassignByListFunnelCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailReassignByListFunnelCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailReassignByListFunnelEvent(request));
            return Task.FromResult(true);
        }
    }
}
