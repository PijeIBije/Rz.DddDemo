using System.Collections.Generic;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Customer.DomainEvents
{
    public class CustomerUpdatedDomainEvent:DomainEventBase<CustomerAggregate>
    {
        public IEnumerable<AddressName> UpdatedAddressNames { get; }

        public CustomerUpdatedDomainEvent(CustomerAggregate source, IEnumerable<AddressName> updatedAddressNames) : base(source)
        {
            UpdatedAddressNames = updatedAddressNames;
        }
    }
}
