using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling
{
    public class IntegrationEventsPublisher
    {
        private readonly List<IIntegrationEvent> integrationEvents = new List<IIntegrationEvent>();

        private readonly Func<Type, IIntegrationEventPublisher> integrationEventPublisherLocatror;

        public IntegrationEventsPublisher(Func<Type, IIntegrationEventPublisher> integrationEventPublisherLocatror)
        {
            this.integrationEventPublisherLocatror = integrationEventPublisherLocatror;
        }

        public void Register(IIntegrationEvent integrationEvent)
        {
            integrationEvents.Add(integrationEvent);
        }

        public void PublishAll()
        {
            foreach (var integrationEvent in integrationEvents)
            {
                var integrationEventType = integrationEvent.GetType();

                var integrationEventPublisher = integrationEventPublisherLocatror(integrationEventType);

                integrationEventPublisher.Publish(integrationEvent);
            }
        }
    }
}
