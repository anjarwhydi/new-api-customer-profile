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
    public class SendEmailSalesFunnelCloudServiceCommandHandler : IRequestHandler<SendEmailSalesFunnelCloudServiceCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSalesFunnelCloudServiceCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSalesFunnelCloudServiceCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailSalesFunnelCloudServiceEvent(request));
            return Task.FromResult(true);
        }
    }
}
