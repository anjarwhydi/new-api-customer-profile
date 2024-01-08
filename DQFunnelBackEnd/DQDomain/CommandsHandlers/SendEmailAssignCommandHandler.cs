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
    public class SendEmailAssignCommandHandler : IRequestHandler<SendEmailAssignCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailAssignCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailAssignCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailAssignEvent(request));
            return Task.FromResult(true);
        }
    }
}
