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
    public class SendEmailActivityCommandHandler : IRequestHandler<SendEmailActivityCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailActivityCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SendEmailActivityCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailActivityEvent(request));
            return Task.FromResult(true);
        }
    }
}
