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
    public class SaveTeamCommandHandler : IRequestHandler<SaveTeamCommand, bool>
    {
        private readonly IEventBus _bus;
        public SaveTeamCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SaveTeamCommand request, CancellationToken cancellationToken)
        {
            //publish ke RabbitMQ
            _bus.Publish(new Funnel_SaveTeamEvent(request));
            return Task.FromResult(true);
        }
    }
}
