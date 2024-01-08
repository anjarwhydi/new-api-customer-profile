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
    public class SendEmailSASubmitCommercialCommandHandler : IRequestHandler<SendEmailSASubmitCommercialCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSASubmitCommercialCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSASubmitCommercialCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new FunnelSA_SendEmailSASubmitCommercialEvent(request));
            return Task.FromResult(true);
        }
    }
}
