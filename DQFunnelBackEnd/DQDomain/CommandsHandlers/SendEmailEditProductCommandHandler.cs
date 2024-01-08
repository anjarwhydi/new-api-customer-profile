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
    public class SendEmailEditProductCommandHandler : IRequestHandler<SendEmailEditProductCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailEditProductCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailEditProductCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailEditProductEvent(request));
            return Task.FromResult(true);
        }
    }
}
