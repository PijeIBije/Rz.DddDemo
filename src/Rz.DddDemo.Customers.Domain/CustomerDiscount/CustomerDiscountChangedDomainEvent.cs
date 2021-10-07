using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Customers.Domain.Purchase;

namespace Rz.DddDemo.Customers.Domain.CustomerDiscount
{
    public class CustomerDiscountChangedDomainEvent:DomainEventBase<CustomerDiscountAggregate>
    {
        public CustomerDiscountChangedDomainEvent(
            CustomerDiscountAggregate source) : base(source)
        {
            
        }
    }
}
