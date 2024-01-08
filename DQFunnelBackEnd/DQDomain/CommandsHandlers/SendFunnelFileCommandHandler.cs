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
    public class SendFunnelFileCommandHandler : IRequestHandler<SendFunnelFileCommand, bool>
    {
        private readonly IEventBus _bus;
        public SendFunnelFileCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(SendFunnelFileCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Funnel_SendFunnelFileEvent(request));
            return Task.FromResult(true);
        }
    }
}
