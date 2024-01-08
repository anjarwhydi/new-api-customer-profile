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
    public class SendEmailPOCReqUploadCommandHandler : IRequestHandler<SendEmailPOCReqUploadCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendEmailPOCReqUploadCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(SendEmailPOCReqUploadCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendEmailPOCReqUploadEvent(request));
            return Task.FromResult(true);
        }
    }
}
