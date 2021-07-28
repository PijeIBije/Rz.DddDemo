using System;
using System.Collections.Generic;
using System.Text;
using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;
using Rz.DddDemo.Orders.Domain.Order;

namespace Rz.DddDemo.Orders.Application.IntegrationEvents.Outbound
{
    public class OrderUpdatedIntegrationEvent:IIntegrationEvent
    {
        public OrderAggregate Order { get; }

        public OrderUpdatedIntegrationEvent(OrderAggregate order)
        {
            Order = order;
        }
    }
}
