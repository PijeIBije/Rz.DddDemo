using System;
using System.Collections.Generic;
using System.Text;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces
{
    public interface IIntegrationEventPublisher<in TIntegrationEvent> where TIntegrationEvent:IIntegrationEvent
    {
        public void Publish(TIntegrationEvent integrationEvent);
    }

    public interface IIntegrationEventPublisher
    {
        public void Publish(object integrationEvent);
    }
}
