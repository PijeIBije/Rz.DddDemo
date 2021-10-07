using System;
using System.Collections.Generic;
using MediatR;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling
{
    public class IntegrationEventsPublisher
    {
        private readonly IMediator mediator;
        private readonly List<IIntegrationEvent> integrationEvents = new List<IIntegrationEvent>();

        public IntegrationEventsPublisher(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Register(IIntegrationEvent integrationEvent)
        {
            integrationEvents.Add(integrationEvent);
        }

        public void PublishAll()
        {
            foreach (var integrationEvent in integrationEvents)
            {
                mediator.Send(integrationEvent);
            }
        }
    }
}
