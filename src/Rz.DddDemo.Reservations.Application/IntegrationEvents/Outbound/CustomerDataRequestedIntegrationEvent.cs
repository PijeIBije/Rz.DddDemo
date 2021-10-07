using Rz.DddDemo.Base.Application.IntegrationEventHandling.Interfaces;

namespace Rz.DddDemo.Reservations.Application.IntegrationEvents.Outbound
{
    public class CustomerDataRequestedIntegrationEvent:IIntegrationEvent
    {
        public CustomerId CustomerId { get; }

        public CustomerDataRequestedIntegrationEvent(CustomerId customerId)
        {
            CustomerId = customerId;
        }
    }
}
