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
    public class SendEmailReassignCommandHandler : IRequestHandler<SendEmailReassignCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailReassignCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailReassignCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailReassignEvent(request));
            return Task.FromResult(true);
        }
    }
}
