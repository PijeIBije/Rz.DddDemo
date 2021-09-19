using Rz.DddDemo.Base.Domain.DomainEvent;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class OrderUpdatedDomainEvent:DomainEventBase<OrderAggregate>
    {
        public OrderUpdatedDomainEvent(OrderAggregate id) : base(id)
        {
        }
    }
}
