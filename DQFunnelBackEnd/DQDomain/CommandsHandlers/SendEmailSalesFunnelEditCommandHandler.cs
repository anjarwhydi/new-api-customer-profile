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
    public class SendEmailSalesFunnelEditCommandHandler : IRequestHandler<SendEmailSalesFunnelEditCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSalesFunnelEditCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSalesFunnelEditCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailSalesFunnelEditEvent(request));
            return Task.FromResult(true);
        }
    }
}
