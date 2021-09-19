using System.Collections.Generic;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Orders.Domain.Customer.Address.ValueObjects;

namespace Rz.DddDemo.Orders.Domain.Customer
{
    public class CustomerUpdatedDomainEvent:DomainEventBase<CustomerAggregate>
    {
        public IEnumerable<AddressName> UpdatedAddressNames { get; }

        public CustomerUpdatedDomainEvent(CustomerAggregate id, IEnumerable<AddressName> updatedAddressNames) : base(id)
        {
            UpdatedAddressNames = updatedAddressNames;
        }
    }
}
