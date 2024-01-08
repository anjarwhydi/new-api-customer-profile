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
    public class SendEmailBGBankCommandHandler : IRequestHandler<SendEmailBGBankCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailBGBankCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SendEmailBGBankCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailBGBankEvent(request));
            return Task.FromResult(true);
        }
    }
}
