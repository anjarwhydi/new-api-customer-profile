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
    public class SendEmailDelegasiSubmitCommandHandler : IRequestHandler<SendEmailDelegasiSubmitCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailDelegasiSubmitCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SendEmailDelegasiSubmitCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailDelegasiSubmitEvent(request));
            return Task.FromResult(true);
        }
    }
}
