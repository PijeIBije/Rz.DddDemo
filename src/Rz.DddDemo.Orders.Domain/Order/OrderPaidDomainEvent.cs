using Rz.DddDemo.Base.Domain.DomainEvent;

namespace Rz.DddDemo.Orders.Domain.Order
{
    public class OrderPaidDomainEvent:DomainEventBase<OrderAggregate>
    {
        public OrderPaidDomainEvent(OrderAggregate id) : base(id)
        {

        }
    }
}
