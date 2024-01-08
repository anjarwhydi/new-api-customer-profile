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
    public class SendEmailSACancelCommandHandler : IRequestHandler<SendEmailSACancelCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSACancelCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSACancelCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new FunnelSA_SendEmailSACancelEvent(request));
            return Task.FromResult(true);
        }
    }
}
