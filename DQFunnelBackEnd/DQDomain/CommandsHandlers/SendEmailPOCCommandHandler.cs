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
    public class SendEmailPOCCommandHandler : IRequestHandler<SendEmailPOCCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailPOCCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailPOCCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailPOCEvent(request));
            return Task.FromResult(true);
        }
    }
}
