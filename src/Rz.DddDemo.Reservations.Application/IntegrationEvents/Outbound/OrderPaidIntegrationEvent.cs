using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Reservations.Application.IntegrationEvents.Outbound
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
