using Rz.DddDemo.Base.Domain.DomainEvent;

namespace Rz.DddDemo.Orders.Domain.Customer.DomainEvents
{
    public class CustomerUpdatedDomainEvent:DomainEventBase<CustomerAggregate>
    {
        public CustomerUpdatedDomainEvent(CustomerAggregate source) : base(source)
        {

        }
    }
}
