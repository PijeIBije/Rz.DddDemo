using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rz.DddDemo.Base.Application.DomainEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound;
using Rz.DddDemo.Customers.Domain.DomainEvents;

namespace Rz.DddDemo.Customers.Application.DomainEvents.Customer
{
    public class CustomerChangedDomainEventHandler:DomainEventHanlderBase<CustomerChangedDomainEvent>
    {
        public CustomerChangedDomainEventHandler(
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher) : base(domainEventsHandler, integrationEventsPublisher)
        {
        }

        protected override Task HandleBody(CustomerChangedDomainEvent domainEvent)
        {
            RegisterIntegrationEvent(new CustomerUpdatedIntegrationEvent(domainEvent.Id));
            return Task.CompletedTask;
        }
    }
}
