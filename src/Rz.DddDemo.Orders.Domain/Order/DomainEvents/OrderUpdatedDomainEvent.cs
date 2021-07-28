using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Base.Domain.DomainEvent.Interfaces;

namespace Rz.DddDemo.Orders.Domain.Order.DomainEvents
{
    public class OrderUpdatedDomainEvent:DomainEventBase<OrderAggregate>
    {
        public OrderUpdatedDomainEvent(OrderAggregate source) : base(source)
        {
        }
    }
}
