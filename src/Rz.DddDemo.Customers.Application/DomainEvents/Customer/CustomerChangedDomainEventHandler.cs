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
    public class CustomerUpdatedDomainEventHandler:DomainEventHanlderBase<CustomerChangedDomainEvent>
    {
        public CustomerUpdatedDomainEventHandler(
            DomainEventsHandler domainEventsHandler, 
            IntegrationEventsPublisher integrationEventsPublisher) : base(domainEventsHandler, integrationEventsPublisher)
        {
        }

        protected override Task HandleBody(CustomerChangedDomainEvent domainEvent)
        {
            RegisterIntegrationEvent(new CustomerUpdatedIntegrationEvent(domainEvent.Source));
            return Task.CompletedTask;
        }
    }
}
