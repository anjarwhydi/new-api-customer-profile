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
    public class SaveBankGuaranteeCommandHandler : IRequestHandler<SaveBankGuaranteeCommand, bool>
    {
        private readonly IEventBus _bus;
        public SaveBankGuaranteeCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SaveBankGuaranteeCommand request, CancellationToken cancellationToken)
        {
            //publish ke RabbitMQ
            _bus.Publish(new Funnel_SaveBGEvent(request));
            return Task.FromResult(true);
        }
    }
}
