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
    public class SendEmailToSalesPOCReqCommandHandler : IRequestHandler<SendEmailToSalesPOCReqCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailToSalesPOCReqCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailToSalesPOCReqCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailToSalesPOCReqEvent(request));
            return Task.FromResult(true);
        }
    }
}
