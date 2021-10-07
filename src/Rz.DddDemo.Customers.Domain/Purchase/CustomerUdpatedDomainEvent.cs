using Rz.DddDemo.Base.Domain.DomainEvent;

namespace Rz.DddDemo.Customers.Domain.Purchase
{
    public class CustomerChangedDomainEvent:DomainEventBase<CustomerAggregate>
    {
        public CustomerChangedDomainEvent(CustomerAggregate source) : base(source)
        {

        }
    }
}
