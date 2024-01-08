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
    public class SendEmailAddProductCommandHandler : IRequestHandler<SendEmailAddProductCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailAddProductCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailAddProductCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailAddProductEvent(request));
            return Task.FromResult(true);
        }
    }
}
