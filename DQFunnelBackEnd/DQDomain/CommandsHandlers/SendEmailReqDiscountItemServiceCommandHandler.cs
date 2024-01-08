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
    public class SendEmailReqDiscountItemServiceCommandHandler : IRequestHandler<SendEmailReqDiscountItemServiceCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailReqDiscountItemServiceCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailReqDiscountItemServiceCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailReqDiscountItemServiceEvent(request));
            return Task.FromResult(true);
        }
    }
}
