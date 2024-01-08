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
    public class SaveItemsCommandHandler : IRequestHandler<SaveItemsCommand, bool>
    {
        private readonly IEventBus _bus;
        public SaveItemsCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SaveItemsCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SaveItemsEvent(request));
            return Task.FromResult(true);
        }
    }
}
