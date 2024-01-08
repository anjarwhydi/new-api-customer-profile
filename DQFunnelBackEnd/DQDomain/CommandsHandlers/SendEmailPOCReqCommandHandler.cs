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
    public class SendEmailPOCReqCommandHandler : IRequestHandler<SendEmailPOCRequirementCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailPOCReqCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailPOCRequirementCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailPOCRequirementEvent(request));
            return Task.FromResult(true);
        }
    }
}
