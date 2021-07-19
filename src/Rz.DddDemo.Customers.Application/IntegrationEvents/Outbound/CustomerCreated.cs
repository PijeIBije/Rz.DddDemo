using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Customers.Domain;
using Rz.DddDemo.Customers.Domain.CustomerAggregate;

namespace Rz.DddDemo.Customers.Application.IntegrationEvents.Outbound
{
    public class CustomerCreated:IIntegrationEvent
    {
        public Customer Customer { get; }

        public CustomerCreated(Customer customer)
        {
            Customer = customer;
        }
    }
}
