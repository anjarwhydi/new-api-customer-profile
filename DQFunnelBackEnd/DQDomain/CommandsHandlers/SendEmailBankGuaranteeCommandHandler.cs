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
    public class SendEmailBankGuaranteeCommandHandler : IRequestHandler<SendEmailBankGuaranteeCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailBankGuaranteeCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SendEmailBankGuaranteeCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailBankGuaranteeEvent(request));
            return Task.FromResult(true);
        }
    }
}
