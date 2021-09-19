using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Customers.Domain.Address.ValueObjects;

namespace Rz.DddDemo.Customers.Domain.DomainEvents
{
    public class CustomerChangedDomainEvent:DomainEventBase<CustomerAggregate>
    {
        public CustomerChangedDomainEvent(CustomerAggregate id) : base(id)
        {

        }
    }
}
