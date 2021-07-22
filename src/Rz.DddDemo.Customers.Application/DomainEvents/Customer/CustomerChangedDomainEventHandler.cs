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
    public class CustomerUpdatedDomainEventHandler:DomainEventHanlderBase<CustomerUpdatedDomainEvent>
    {
        public CustomerUpdatedDomainEventHandler(
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher) : base(domainEventsHandler, integrationEventsPublisher)
        {
        }

        protected override Task HandleBody(CustomerUpdatedDomainEvent domainEvent)
        {
            RegisterIntegrationEvent(new CustomerUpdatedIntegrationEvent(domainEvent));
            return Task.CompletedTask;
        }
    }
}
