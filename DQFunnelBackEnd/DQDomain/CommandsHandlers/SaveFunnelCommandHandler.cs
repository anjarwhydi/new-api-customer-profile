using Domain.Core.Bus;
using Domain.Core.Events;
using Domain.Core.Commands;
using DQDomain.Commands;
using DQDomain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DQFunnel.BusinessObject;

namespace DQDomain.CommandsHandlers
{
    public class SaveFunnelCommandHandler : IRequestHandler<SaveFunnelCommand, bool>
    {
        private readonly IEventBus _bus;
        public SaveFunnelCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SaveFunnelCommand request, CancellationToken cancellationToken)
        {
            //publish ke RabbitMQ
            _bus.Publish(new Funnel_SaveFunnelEvent(request));
            return Task.FromResult(true);
        }

    }
}
