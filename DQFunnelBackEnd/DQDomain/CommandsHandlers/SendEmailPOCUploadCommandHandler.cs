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
    public class SendEmailPOCUploadCommandHandler : IRequestHandler<SendEmailPOCUploadCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailPOCUploadCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailPOCUploadCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailPOCUploadEvent(request));
            return Task.FromResult(true);
        }
    }
}
