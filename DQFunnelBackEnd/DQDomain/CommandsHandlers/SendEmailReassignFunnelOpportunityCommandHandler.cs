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
    public class SendEmailReassignFunnelOpportunityCommandHandler : IRequestHandler<SendEmailReassignFunnelOpportunityCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailReassignFunnelOpportunityCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SendEmailReassignFunnelOpportunityCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailReassignFunnelOpportunityEvent(request));
            return Task.FromResult(true);
        }
    }
}
