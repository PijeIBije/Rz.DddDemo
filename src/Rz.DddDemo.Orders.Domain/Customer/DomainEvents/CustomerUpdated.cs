using Rz.DddDemo.Base.Domain.DomainEvent;

namespace Rz.DddDemo.Orders.Domain.Customer.DomainEvents
{
    public class CustomerUpdated:DomainEventBase<Customer>
    {
        public CustomerUpdated(Customer source) : base(source)
        {

        }
    }
}
