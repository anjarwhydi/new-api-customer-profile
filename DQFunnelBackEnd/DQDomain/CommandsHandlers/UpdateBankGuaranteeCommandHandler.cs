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
    public class UpdateBankGuaranteeCommandHandler : IRequestHandler<UpdateBankGuaranteeCommand, bool>
    {
        private readonly IEventBus _bus;
        public UpdateBankGuaranteeCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(UpdateBankGuaranteeCommand request, CancellationToken cancellationToken)
        {
            //publish ke RabbitMQ
            _bus.Publish(new Funnel_UpdateBankGuaranteeEvent(request));
            return Task.FromResult(true);
        }
    }
}
