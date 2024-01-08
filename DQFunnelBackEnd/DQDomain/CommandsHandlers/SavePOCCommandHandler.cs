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
    public class SavePOCCommandHandler : IRequestHandler<SavePOCCommand, bool>
    {
        private readonly IEventBus _bus;
        public SavePOCCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SavePOCCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SavePOCEvent(request));
            return Task.FromResult(true);
        }
    }
}
