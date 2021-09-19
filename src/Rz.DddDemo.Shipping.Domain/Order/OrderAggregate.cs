using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Domain;
using Rz.DddDemo.Base.Domain.DomainEntity;
using Rz.DddDemo.Base.Domain.DomainEvent;
using Rz.DddDemo.Shipping.Domain.Order.OrderLine;

namespace Rz.DddDemo.Shipping.Domain.Order
{
    public class OrderAggregate:DomainEntityBase<OrderId>
    {
        public IReadOnlyList<OrderLineValueObject> OrderLines => orderLines;

        private readonly List<OrderLineValueObject> orderLines;
        
        public OrderAggregate(OrderId id, List<OrderLineValueObject> orderLines) : base(id)
        {
            Guard.AgaintsNullOrEmptyValue(orderLines,nameof(orderLines));

            this.orderLines = orderLines;
        }
    }
}
