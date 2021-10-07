using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Reservations.Application.IntegrationEvents.Outbound
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
