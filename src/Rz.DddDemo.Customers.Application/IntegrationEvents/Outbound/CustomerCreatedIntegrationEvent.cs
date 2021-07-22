using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Customers.Domain;

namespace Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound
{
    public class CustomerCreatedIntegrationEvent:IIntegrationEvent
    {
        public CustomerAggregate Customer { get; }

        public CustomerCreatedIntegrationEvent(CustomerAggregate customer)
        {
            Customer = customer;
        }
    }
}
