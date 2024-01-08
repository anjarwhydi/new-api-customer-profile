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
    public class SaveActivityCommandHandler : IRequestHandler<SaveActivityCommand, bool>
    {
        private readonly IEventBus _bus;
        public SaveActivityCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SaveActivityCommand request, CancellationToken cancellationToken)
        {
            //publish ke RabbitMQ
            _bus.Publish(new Funnel_SaveActivityEvent(request));
            return Task.FromResult(true);
        }
    }
}
