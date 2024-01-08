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
    public class SendEmailSummaryInsertFormCommandHandler : IRequestHandler<SendEmailSummaryInsertFormCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailSummaryInsertFormCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailSummaryInsertFormCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailSummaryInsertFormEvent(request));
            return Task.FromResult(true);
        }
    }
}
