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
    public class SendEmailReqDiscountCommandHandler : IRequestHandler<SendEmailReqDiscountCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailReqDiscountCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailReqDiscountCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailReqDiscountEvent(request));
            return Task.FromResult(true);
        }
    }
}
