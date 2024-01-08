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
    public class SyncBoqToItemMasterCommandHandler : IRequestHandler<SyncBoqToItemMasterCommand, bool>
    {
        private readonly IEventBus _bus;
        public SyncBoqToItemMasterCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SyncBoqToItemMasterCommand request, CancellationToken cancellationToken)
        {
            //publish ke RabbitMQ
            _bus.Publish(new Funnel_SyncBoqToItemMasterEvent(request));
            return Task.FromResult(true);
        }
    }
}
