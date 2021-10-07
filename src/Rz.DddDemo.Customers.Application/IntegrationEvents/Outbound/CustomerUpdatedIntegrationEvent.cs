using System.Collections.Generic;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Customers.Domain;

namespace Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound
{
    public class CustomerUpdatedIntegrationEvent : IIntegrationEvent
    {
        public CustomerUpdatedIntegrationEvent(CustomerAggregate customer)
        {
            Guard.AgainstNullValue(customer, nameof(customer));
            Customer = customer;
        }

        public CustomerAggregate Customer { get; }
    }
}
