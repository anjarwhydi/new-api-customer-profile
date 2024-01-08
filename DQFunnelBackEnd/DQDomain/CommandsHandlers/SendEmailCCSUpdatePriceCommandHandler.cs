using Domain.Core.Bus;
using DQDomain.Commands;
using DQDomain.Events;
using DQFunnel.BusinessObject.CommandModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DQDomain.CommandsHandlers
{
    public class SendEmailCCSUpdatePriceCommandHandler : IRequestHandler<SendEmailCCSUpdatePriceCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailCCSUpdatePriceCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailCCSUpdatePriceCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailCCSUpdatePriceEvent(request));
            return Task.FromResult(true);
        }
    }
}
