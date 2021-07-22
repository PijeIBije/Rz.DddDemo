using Rz.DddDemo.Orders.Domain.Customer;
using Rz.DddDemo.Orders.Domain.Customer.ValueObjects;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Inbound.Interfaces
{
    public interface ICustomerRepository
    {
        public void Save(CustomerAggregate customer);

        public CustomerAggregate TryGetById(CustomerId customerId);
    }
}
