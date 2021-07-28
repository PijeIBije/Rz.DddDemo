using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.IntegrationEventHandling;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.Order.DomainEvents;
using Rz.DddDemo.Orders.Domain.Order.ValueObjects;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Outbound
{
    public class OrderPaidIntegrationEvent:IIntegrationEvent
    {
        public OrderId OrderId { get; }

        public OrderPaidIntegrationEvent(OrderId orderId)
        {
            OrderId = orderId;
        }
    }
}
