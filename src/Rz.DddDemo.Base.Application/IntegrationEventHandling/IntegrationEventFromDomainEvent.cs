using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Base.Application.IntegrationEventHandling
{
    public abstract class IntegrationEventFromDomainEventBase<TDomainEvent>:IIntegrationEvent where TDomainEvent:IDomainEvent
    {
        public TDomainEvent DomainEvent { get; }

        protected IntegrationEventFromDomainEventBase(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
