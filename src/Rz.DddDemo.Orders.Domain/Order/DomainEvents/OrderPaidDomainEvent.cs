using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Orders.Domain.Order.DomainEvents
{
    public class OrderPaidDomainEvent:DomainEventBase<OrderAggregate>
    {
        public OrderPaidDomainEvent(OrderAggregate source) : base(source)
        {

        }
    }
}
