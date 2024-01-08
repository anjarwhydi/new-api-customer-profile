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
    public class SendEmailPMOSMOCommandHandler : IRequestHandler<SendEmailPMOSMOCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailPMOSMOCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SendEmailPMOSMOCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailPMOSMOEvent(request));
            return Task.FromResult(true);
        }
    }
}
