using System.Collections.Generic;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.Address.ValueObjects;
using Rz.DddDemo.Customers.Domain.DomainEvents;

namespace Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound
{
    public class CustomerUpdatedIntegrationEvent:IntegrationEventFromDomainEventBase<CustomerUpdatedDomainEvent>
    {
        public CustomerUpdatedIntegrationEvent(CustomerUpdatedDomainEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
